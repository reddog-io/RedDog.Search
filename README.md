RedDog.Search
=============

This library interacts with the Microsoft Azure Search REST API. It will allow you to do manage indexes, populate indexes and execute queries.


## Getting Started

### Setting up the connection to Microsoft Azure Search:

```C#
ApiConnection connection = ApiConnection.Create("myservice",
  "mykey");
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

### Get the statistics of an index:

```C#
var client = new IndexManagementClient(connection);
var records = await client.GetIndexStatisticsAsync("records");
Console.WriteLine("Total documents: {0}", records.Body.DocumentCount);
Console.WriteLine("Total size: {0} bytes", records.Body.StorageSize);
```
