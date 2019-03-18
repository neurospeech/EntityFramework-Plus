---
permalink: batch-update
---

## Introduction

Updating using Entity Framework can be very slow if you need to update hundreds or thousands of entities with the same expression. Entities are first loaded in the context before being updated which is very bad for the performance and then, they are updated one by one which makes the update operation even worse.

**EF+ Batch Update** updates multiple rows using an expression in a single database roundtrip and without loading entities in the context.

{% include template-example.html %} 
{% highlight csharp %}

// using Z.EntityFramework.Plus; // Don't forget to include this.

// UPDATE all users inactive for 2 years
var date = DateTime.Now.AddYears(-2);
ctx.Users.Where(x => x.LastLoginDate < date)
         .Update(x => new User() { IsSoftDeleted = 1 });

{% endhighlight %}

## Batch Update

### Problem

You need to update one or millions of records based on a query criteria and an expression.

### Solution

The **Update** IQueryable extension method updates rows matching the query criteria with an expression without loading entities in the context.

{% include template-example.html %} 
{% highlight csharp %}

// using Z.EntityFramework.Plus; // Don't forget to include this.

// UPDATE all users inactive for 2 years
var date = DateTime.Now.AddYears(-2);
ctx.Users.Where(x => x.LastLoginDate < date)
         .Update(x => new User() { IsSoftDeleted = 1 });

{% endhighlight %}

## Batch UpdateAsync

### Problem

You need to update one or millions of records based on a query criteria and an expression asynchronously.

### Solution

The **UpdateAsync** IQueryable extension method updates asynchronously rows matching the query criteria with an expression without loading entities in the context.

{% include template-example.html %} 
{% highlight csharp %}

// using Z.EntityFramework.Plus; // Don't forget to include this.

// UPDATE all users inactive for 2 years
var date = DateTime.Now.AddYears(-2);
ctx.Users.Where(x => x.LastLoginDate < date)
         .UpdateAsync(x => new User() { IsSoftDeleted = 1 });

{% endhighlight %}

## Executing Interceptor

### Problem

You need to log the DbCommand information or change the CommandText, Connection or Transaction before the batch is executed.

### Solution

The **Executing** property intercepts the DbCommand with an action before being executed.

{% include template-example.html %} 
{% highlight csharp %}

// using Z.EntityFramework.Plus; // Don't forget to include this.

string commandText
var date = DateTime.Now.AddYears(-2);
ctx.Users.Where(x => x.LastLoginDate < date)
         .Update(x => new User() { IsSoftDeleted = 1 },
                 x => { x.Executing = command => commandText = command.CommandText; });

{% endhighlight %}

## Limitations

 - **DO NOT** support Complex Type
 - **DO NOT** support Enum
 - **DO NOT** support TPC
 - **DO NOT** support TPH
 - **DO NOT** support TPT

## Requirements

- **EF+ Batch Delete:** Full version or Standalone version
- **Database Provider:** SQL Server, SQL Azure (More provider will be added in a close future)
- **Entity Framework Version:** EF5, EF6, EFCore
- **Minimum Framework Version:** .NET Framework 4

## Conclusion

**EF+ Batch Update** is the most efficient way to update records using an expression. You drastically improve your application performance by removing the need to retrieve and load entities in your context and by performing a single database roundtrip instead of making one for every record.

Need help getting started? [info@zzzprojects.com](mailto:info@zzzprojects.com)

We welcome all comments, ideas and suggestions to improve our library.
