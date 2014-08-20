RedDog.Search
=============

This library interacts with the Microsoft Azure Search REST API. You can use the library to manage indexes, populate indexes and execute queries.


## Getting Started

### Initialize the ApiConnection with your credentials:

```C#
ApiConnection connection = ApiConnection.Create("myservice","mykey");
```

### Creating an index:

```C#
var client = new IndexManagementClient(connection);
await client.CreateIndexAsync(new Index("records")
    .WithStringField("id", f => f
        .IsKey()
        .IsRetrievable())
    .WithStringField("title", f => f
        .IsSearchable()
        .IsRetrievable())
    .WithDateTimeField("createdOn", f => f
        .IsRetrievable()));
```

### Updating an index:

```C#
var client = new IndexManagementClient(connection);
await client.UpdateIndexAsync(new Index("records")
    .WithStringField("id", f => f
        .IsKey()
        .IsRetrievable())
    .WithStringField("author", f => f
        .IsSearchable()
        .IsSortable()
        .IsRetrievable())
    .WithStringField("title", f => f
        .IsSearchable()
        .IsRetrievable())
    .WithDateTimeField("createdOn", f => f
        .IsRetrievable()));
```

### List all indexes:

```C#
var client = new IndexManagementClient(connection);
var indexes = await client.GetIndexesAsync();
```

### Delete an index:

```C#
var client = new IndexManagementClient(connection);
var records = await client.DeleteIndexAsync("records");
```

### Get the statistics for an index:

```C#
var client = new IndexManagementClient(connection);
var records = await client.GetIndexStatisticsAsync("records");
Console.WriteLine("Total documents: {0}", records.Body.DocumentCount);
Console.WriteLine("Total size: {0} bytes", records.Body.StorageSize);
```

### Upload data to your index:

```C#
var client = new IndexManagementClient(connection);
var result = await client.PopulateAsync("records",
    new IndexOperation(IndexOperationType.Upload, "id", "1")
        .WithProperty("title", "My first movie")
        .WithProperty("author", "Sandrino")
        .WithProperty("createdOn", new DateTimeOffset(2014, 8, 1, 0, 0, 0, TimeSpan.Zero)),
    new IndexOperation(IndexOperationType.Upload, "id", "2")
        .WithProperty("title", "My second movie")
        .WithProperty("author", "Sandrino")
        .WithProperty("createdOn", new DateTimeOffset(2014, 8, 2, 0, 0, 0, TimeSpan.Zero)));
```

### Execute a query:


```C#
var client = new IndexQueryClient(connection);
var results = await client.SearchAsync("records", new SearchQuery("movie")
    .OrderBy("author")
    .SearchField("title")
    .Count(true));
```

### Execute a suggestion:


```C#
var client = new IndexQueryClient(connection);
var results = await client.SuggestAsync("records", new SuggestionQuery("mov")
	.Fuzzy(true)
	.Select("author")
	.Select("title")                    
	.SearchField("title")
	.OrderBy("title")
	.Top(10));
```

### Handling exceptions:

```C#
var response = await client.DoSomething();
if (!response.IsSuccess)
{
    Console.WriteLine("{0}: {1}", response.Error.Code, response.Error.Message);
}
```
