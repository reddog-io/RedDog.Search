RedDog.Search
=============

This library interacts with the Microsoft Azure Search REST API. It will allow you to do manage indexes, populate indexes and execute queries.


## Getting Started

### Setting up the connection to Microsoft Azure Search

```C#
ApiConnection connection = ApiConnection.Create("myservice",
  "mykey");
```

### Creating an index.

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
