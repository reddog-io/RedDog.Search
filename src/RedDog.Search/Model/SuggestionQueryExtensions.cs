using System;

namespace RedDog.Search.Model
{
    public static class SuggestionQueryExtensions
    {
        public static SuggestionQuery Fuzzy(this SuggestionQuery query, bool fuzzy)
        {
            query.Fuzzy = fuzzy;
            return query;
        }

        public static SuggestionQuery SearchField(this SuggestionQuery query, string searchField)
        {
            if (String.IsNullOrEmpty(query.SearchFields))
                query.SearchFields = searchField;
            else
                query.SearchFields += "," + searchField;
            return query;
        }

        public static SuggestionQuery Top(this SuggestionQuery query, long top)
        {
            query.Top = top;
            return query;
        }

        public static SuggestionQuery Filter(this SuggestionQuery query, string filter)
        {
            query.Filter = filter;
            return query;
        }

        public static SuggestionQuery OrderBy(this SuggestionQuery query, string orderByField)
        {
            if (String.IsNullOrEmpty(query.OrderBy))
                query.OrderBy = orderByField;
            else
                query.OrderBy += "," + orderByField;
            return query;
        }

        public static SuggestionQuery Select(this SuggestionQuery query, string selectField)
        {
            if (String.IsNullOrEmpty(query.Select))
                query.Select = selectField;
            else
                query.Select += "," + selectField;
            return query;
        }

        public static SuggestionQuery SuggesterName(this SuggestionQuery query, string suggesterName)
        {
            query.SuggesterName = suggesterName;
            return query;
        }
    }
}