﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using RedDog.Search.Http;
using RedDog.Search.Model;
using RedDog.Search.Model.Internal;
using System.Globalization;

namespace RedDog.Search
{
    public class IndexManagementClient : IDisposable
    {
        private ApiConnection _connection;

        public IndexManagementClient(ApiConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Create a new index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> CreateIndexAsync(Index index)
        {
            return _connection.Execute<Index>(
                new ApiRequest("indexes", HttpMethod.Post) {Body = index});
        }

        /// <summary>
        /// Update an existing index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> UpdateIndexAsync(Index index)
        {
            return _connection.Execute<Index>(new ApiRequest("indexes/{0}", HttpMethod.Put) {Body = index}
                .WithUriParameter(index.Name));
        }

        /// <summary>
        /// Delete an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public Task<IApiResponse> DeleteIndexAsync(string indexName)
        {
            return _connection.Execute(new ApiRequest("indexes/{0}", HttpMethod.Delete)
                .WithUriParameter(indexName));
        }

        /// <summary>
        /// Get an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> GetIndexAsync(string indexName)
        {
            return _connection.Execute<Index>(new ApiRequest("indexes/{0}", HttpMethod.Get)
                .WithUriParameter(indexName));
        }

        /// <summary>
        /// Get the index statistics.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public Task<IApiResponse<IndexStatistics>> GetIndexStatisticsAsync(string indexName)
        {
            return _connection.Execute<IndexStatistics>(new ApiRequest("indexes/{0}/stats", HttpMethod.Get)
                .WithUriParameter(indexName));
        }

        /// <summary>
        /// Get all indexes.
        /// </summary>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<Index>>> GetIndexesAsync()
        {
            var request = new ApiRequest("indexes", HttpMethod.Get);
            return _connection.Execute(request, IndexList.GetIndexes);
        }

        /// <summary>
        /// Populate an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<IndexOperationResult>>> PopulateAsync(string indexName, params IndexOperation[] operations)
        {
            if (operations.Length > Constants.MaxDocumentPerBatch)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture,
                    "The operation params collection must have from 1 to {0} valid items.", Constants.MaxDocumentPerBatch));
            }
            return _connection.Execute(new ApiRequest("indexes/{0}/docs/index", HttpMethod.Post)
                .WithBody(new {value = operations})
                .WithUriParameter(indexName), IndexOperationList.GetIndexes);
        }

        /// <summary>
        /// Populate an index in batch mode
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<IndexOperationResult>>[]> PopulateBatchAsync(string indexName, params IndexOperation[] operations)
        {
            List<List<IndexOperation>> chunked = new List<IndexOperation>(operations).Chunk(Constants.MaxDocumentPerBatch);
            List<Task<IApiResponse<IEnumerable<IndexOperationResult>>>> tasks = new List<Task<IApiResponse<IEnumerable<IndexOperationResult>>>>();
            foreach (var item in new List<IndexOperation>(operations).Chunk(Constants.MaxDocumentPerBatch))
            {
                tasks.Add(PopulateAsync(indexName, item.ToArray()));

            }
            return Task.WhenAll(tasks);
        }

        ~IndexManagementClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }
    }
}