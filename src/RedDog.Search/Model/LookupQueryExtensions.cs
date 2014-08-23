using System;

namespace RedDog.Search.Model
{
    public static class LookupQueryExtensions
    {
        public static LookupQuery Select(this LookupQuery query, string selectField)
        {
            if (String.IsNullOrEmpty(query.Select))
                query.Select = selectField;
            else
                query.Select += "," + selectField;
            return query;
        }
    }
}