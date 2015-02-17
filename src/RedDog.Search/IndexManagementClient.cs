using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using RedDog.Search.Http;
using RedDog.Search.Model;
using RedDog.Search.Model.Internal;

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
            return CreateIndexAsync(index, default(CancellationToken));
        }
        /// <summary>
        /// Create a new index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> CreateIndexAsync(Index index, CancellationToken cancelToken)
        {
            return _connection.Execute<Index>(
                new ApiRequest("indexes", HttpMethod.Post) { Body = index }, cancelToken);
        }

        /// <summary>
        /// Update an existing index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> UpdateIndexAsync(Index index)
        {
            return UpdateIndexAsync(index, default(CancellationToken));
        }

        /// <summary>
        /// Update an existing index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> UpdateIndexAsync(Index index, CancellationToken cancelToken)
        {
            return _connection.Execute<Index>(new ApiRequest("indexes/{0}", HttpMethod.Put) { Body = index }
                .WithUriParameter(index.Name), cancelToken);
        }


        /// <summary>
        /// Delete an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public Task<IApiResponse> DeleteIndexAsync(string indexName)
        {
            return DeleteIndexAsync(indexName, default(CancellationToken));
        }

        /// <summary>
        /// Delete an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public Task<IApiResponse> DeleteIndexAsync(string indexName, CancellationToken cancelToken)
        {
            return _connection.Execute(new ApiRequest("indexes/{0}", HttpMethod.Delete)
                .WithUriParameter(indexName), cancelToken);
        }

        /// <summary>
        /// Get an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> GetIndexAsync(string indexName)
        {
            return GetIndexAsync(indexName, default(CancellationToken));
        }

        /// <summary>
        /// Get an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public Task<IApiResponse<Index>> GetIndexAsync(string indexName, CancellationToken cancelToken)
        {
            return _connection.Execute<Index>(new ApiRequest("indexes/{0}", HttpMethod.Get)
                .WithUriParameter(indexName), cancelToken);
        }


        /// <summary>
        /// Get the index statistics.
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public Task<IApiResponse<IndexStatistics>> GetIndexStatisticsAsync(string indexName)
        {
            return GetIndexStatisticsAsync(indexName, default(CancellationToken));
        }

        /// <summary>
        /// Get the index statistics.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public Task<IApiResponse<IndexStatistics>> GetIndexStatisticsAsync(string indexName, CancellationToken cancelToken)
        {
            return _connection.Execute<IndexStatistics>(new ApiRequest("indexes/{0}/stats", HttpMethod.Get)
                .WithUriParameter(indexName), cancelToken);
        }


        /// <summary>
        /// Get all indexes.
        /// </summary>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<Index>>> GetIndexesAsync()
        {
            return GetIndexesAsync(default(CancellationToken));
        }

        /// <summary>
        /// Get all indexes.
        /// </summary>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<Index>>> GetIndexesAsync(CancellationToken cancelToken)
        {
            var request = new ApiRequest("indexes", HttpMethod.Get);
            return _connection.Execute(request, cancelToken, IndexList.GetIndexes);
        }


        /// <summary>
        /// Populate an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<IndexOperationResult>>> PopulateAsync(string indexName, params IndexOperation[] operations)
        {
            return PopulateAsync(indexName, default(CancellationToken), operations);
        }

        /// <summary>
        /// Populate an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="cancelToken"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public Task<IApiResponse<IEnumerable<IndexOperationResult>>> PopulateAsync(string indexName, CancellationToken cancelToken, params IndexOperation[] operations)
        {
            return _connection.Execute(new ApiRequest("indexes/{0}/docs/index", HttpMethod.Post)
                .WithBody(new { value = operations })
                .WithUriParameter(indexName), cancelToken, IndexOperationList.GetIndexes);
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