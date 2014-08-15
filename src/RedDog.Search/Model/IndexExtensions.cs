using System;

namespace RedDog.Search.Model
{
    public static class IndexExtensions
    {
        public static Index WithField(this Index index, string name, string type, Action<IndexField> options = null)
        {
            var field = new IndexField(name, type);
            if (options != null)
                options(field);
            index.Fields.Add(field);
            return index;
        }

        public static Index WithStringField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.String, options);
        }

        public static Index WithStringCollectionField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.StringCollection, options);
        }

        public static Index WithIntegerField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.Integer, options);
        }

        public static Index WithGeographyPointField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.GeographyPoint, options);
        }

        public static Index WithDoubleField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.Double, options);
        }

        public static Index WithDateTimeField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.DateTimeOffset, options);
        }

        public static Index WithBooleanField(this Index index, string name, Action<IndexField> options = null)
        {
            return WithField(index, name, FieldType.Boolean, options);
        }
    }
}