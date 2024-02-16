# CLSS.ExtensionMethods.IList.FirstLastIndex

### Problem

Sometimes, you have to find the index of an element that matches a condition within in a collection. This is done like this:

```csharp
int firstMatchingIndex;
for (int i = 0; i < collection.Count; ++i)
{
  if (!predicate(collection[i]) continue;
  firstMatchingIndex = i; break;
}
```

This takes a minimum of 6 lines of code that take some time to decode their purpose.

`List<T>` has a [`FindIndex`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.findindex) method that shortens this syntax to a single line:

```csharp
int firstMatchingIndex = collection.FindIndex(e => { /* predicate */ });
```

But this method is only available to `List<T>` and does not support finding the *last* matching index.

### Solution

This package provides `FirstIndex` and `LastIndex` to all [`IList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1) types to find the first and last index of an element matching a condition, respectively. Due to using manual index counting in its implementation, `FirstIndex` is also available to all `IEnumerable<T>` collections.

Example:

```csharp
using CLSS;

var numbers = new int[] { 6, 4, -3, 15, -18, 9, 23 };
var firstNegativeIdx = numbers.FirstIndex(n => n < 0); // 2
var lastSingleDigitIdx = numbers.LastIndex(n => n > -10 && n < 10); // 5
```

**Note**: `FirstIndex` and `LastIndex` work on all types implementing the [`IList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1) interface, *including raw C# array*.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).