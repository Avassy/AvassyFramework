# Avassy.NetCore.Global.Extensions

See [http://www.avassy.com/framework/components/Avassy.NetCore.Global.Extensions](http://www.avassy.com/framework/components/Avassy.NetCore.Global.Extensions) for more info.

## Classes

- `Avassy.NetCore.Global.Extensions.EnumerableExtensions`
- `Avassy.NetCore.Global.Extensions.StringExtensions`

## Usage

### `EnumerableExtensions`

#### `AddRange<T>` adds a range of items to an `IEnumerable<T>`.

Example:

```
var arr1 = new [] {"string 1", "string 2"};
var arr2 = new [] {"string 3", "string 4"};

arr1.AddRange(arr2);

// Output: {"string 1", "string 2", "string 3", "string 4"}
```


#### `ToCollection<T>` converts a `IEnumerable<T>` to an `ICollection<T>`.

Example:

```
List<string> list = new List<string>();

Collection<string> collection = list.ToCollection();
```

---

### `StringExtensions`

#### `RemoveSpecialCharactersAndSpaces` removes all special characters and spaces in a string.

##### Parameters:

- charToReplaceSpace (char, optional, default '-'): the char you want to use to replace the spaces in a string.

```
var str = "~hello* user!".RemoveSpecialCharactersAndSpaces();

// Output: "hello-user"
```

This is useful to create an nicely formatted URL.