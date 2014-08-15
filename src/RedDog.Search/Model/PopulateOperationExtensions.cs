namespace RedDog.Search.Model
{
    public static class PopulateOperationExtensions
    {
        public static IndexOperation WithProperty(this IndexOperation operation, string name, object value)
        {
            operation.Properties.Add(name, value);
            return operation;
        }
    }
}