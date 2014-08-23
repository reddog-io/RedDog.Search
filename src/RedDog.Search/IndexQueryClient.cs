using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using RedDog.Search.Http;
using RedDog.Search.Model;

namespace RedDog.Search
{
    public class IndexQueryClient : IDisposable
    {
        private readonly ApiConnection _connection;

        public IndexQueryClient(ApiConnection connection)
        {
            _connection = connection;
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
        /// Search an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<IApiResponse<SearchQueryResult>> SearchAsync(string indexName, SearchQuery query)
        {
            var request = new ApiRequest("indexes/{0}/docs", HttpMethod.Get);
            if (!String.IsNullOrEmpty(query.Query))
                request.AddQueryParameter("search", query.Query);
            if (query.Mode.HasValue)
                request.AddQueryParameter("searchMode", query.Mode.ToString().ToLower());
            if (!String.IsNullOrEmpty(query.SearchFields))
                request.AddQueryParameter("searchFields", query.SearchFields);
            if (query.Skip > 0)
                request.AddQueryParameter("$skip", query.Skip.ToString(CultureInfo.InvariantCulture));
            if (query.Top > 0)
                request.AddQueryParameter("$top", query.Top.ToString(CultureInfo.InvariantCulture));
            if (query.Count)
                request.AddQueryParameter("$count", query.Count.ToString().ToLower());
            if (!String.IsNullOrEmpty(query.OrderBy))
                request.AddQueryParameter("$orderby", query.OrderBy);
            if (!String.IsNullOrEmpty(query.Select))
                request.AddQueryParameter("$select", query.Select);
            if (!String.IsNullOrEmpty(query.Facet))
            {
                if (query.Facet.Contains(","))
                {
                    foreach (var facet in query.Facet.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(f => f.Trim()))
                        request.AddQueryParameter("facet", facet);
                }
                else
                {
                    request.AddQueryParameter("facet", query.Facet);
                }
            }
            if (!String.IsNullOrEmpty(query.Filter))
                request.AddQueryParameter("$filter", query.Filter);
            if (!String.IsNullOrEmpty(query.Highlight))
                request.AddQueryParameter("highlight", query.Highlight);
            if (!String.IsNullOrEmpty(query.ScoringProfile))
                request.AddQueryParameter("scoringProfile", query.ScoringProfile);
            if (!String.IsNullOrEmpty(query.ScoringParameter))
                request.AddQueryParameter("scoringParameter", query.ScoringParameter);

            return _connection.Execute<SearchQueryResult>(request
                .WithUriParameter(indexName));
        }


        /// <summary>
        /// Get suggestions from an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<IApiResponse<SuggestionResult>> SuggestAsync(string indexName, SuggestionQuery query)
        {
            var request = new ApiRequest("indexes/{0}/docs/suggest", HttpMethod.Get);
            if (!String.IsNullOrEmpty(query.Search))
                request.AddQueryParameter("search", query.Search);

            request.AddQueryParameter("fuzzy", query.Fuzzy ? Boolean.TrueString : Boolean.FalseString);

            if (!String.IsNullOrEmpty(query.SearchFields))
                request.AddQueryParameter("searchFields", query.SearchFields);

            if (query.Top > 0)
                request.AddQueryParameter("$top", query.Top.ToString(CultureInfo.InvariantCulture));

            if (!String.IsNullOrEmpty(query.OrderBy))
                request.AddQueryParameter("$orderby", query.OrderBy);
            if (!String.IsNullOrEmpty(query.Select))
                request.AddQueryParameter("$select", query.Select);

            if (!String.IsNullOrEmpty(query.Filter))
                request.AddQueryParameter("$filter", query.Filter);


            return _connection.Execute<SuggestionResult>(request.WithUriParameter(indexName));
        }


        /// <summary>
        /// Lookup a document from an index.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<IApiResponse<LookupQueryResult>> LookupAsync(string indexName, LookupQuery query)
        {
            var request = new ApiRequest("indexes/{0}/docs/" + query.Key, HttpMethod.Get);
            
            if (!String.IsNullOrEmpty(query.Select))
                request.AddQueryParameter("$select", query.Select);

            return _connection.Execute<LookupQueryResult>(request.WithUriParameter(indexName));
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
                    _connection.Dispose();
            }
        }
    }
}