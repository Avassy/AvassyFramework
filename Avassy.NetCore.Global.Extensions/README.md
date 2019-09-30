# Avassy.NetCore.Global.Extensions

See [http://www.avassy.com/framework/components/Avassy.NetCore.Global.Extensions](http://www.avassy.com/framework/components/Avassy.NetCore.Global.Extensions) for more info.

## Classes

- `Avassy.NetCore.Global.Extensions.EnumerableExtensions`
- `Avassy.NetCore.Global.Extensions.StringExtensions`
- `Avassy.netCore.Global.Extension.NumberExtensions`
- `Avassy.NetCore.Global.Extensions.QueryableExtensions`

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

- charToReplaceSpace (char, optional, default '-'): The char you want to use to replace the spaces in a string.

```
var str = "~hello* user!".RemoveSpecialCharactersAndSpaces();

// Output: "hello-user"
```

This is useful to create an nicely formatted URL.

#### `ToBase64` converts a simple string to a base64 string.

```
var str = "~hello* user!".ToBase64();

// Output: "fmhlbGxvKiB1c2VyIQ=="
```

Quick encoding to a base64 string.

#### `FromBase64` converts a base64 string to a simple string .

```
var str = "fmhlbGxvKiB1c2VyIQ==".FromBase64();

// Output: "~hello* user!"
```

Quick encoding to a base64 string.

#### `ToCamelCase` converts a PascalCase string to a camelCase string .

```
var str = "ThisIsAPascalCaseString".ToCamelCase();

// Output: "thisIsAPascalCaseString"
```

Quick encoding to a base64 string.

---

### `NumberExtensions`

#### `ToByteSizeString` converts a number (long, int, double) to a formatted byte size string.

 var byteSizeString = "";

int i = 125;
byteSizeString = i.ToByteSizeString();

// Output: 125 Bytes

long j = 693678789445;
byteSizeString = j.ToByteSizeString();

// Output: 646,04 GB

double k = 56985.32;
byteSizeString = k.ToByteSizeString();

// Output: 55,65 KB

---

### `QueryableExtensions`

#### `OrderBy` orders an `IQueryable` by the parameter name.

##### Parameters:

- propertyName (string, required): The name of the property you want to order by.

Example:

```
public class Person {
    public string Name { get; set; }
		public DateTime Birthday { get; set; }
}

var list = new List<Person> { new Person { Name = "Jack", Birthday = new DateTime(1970,1,1) }, new Person { Name = "Bill", Birthday = new DateTime(1970,6,6) } };
var queryable = list.AsQueryable();
var orderedQueryable = queryable.OrderBy("Name");
```

#### `OrderByDescending` orders an `IQueryable` by the parameter name in descending direction.

Example:

```
public class Person {
    public string Name { get; set; }
		public DateTime Birthday { get; set; }
}

var list = new List<Person> { new Person { Name = "Jack", Birthday = new DateTime(1970,1,1) }, new Person { Name = "Bill", Birthday = new DateTime(1970,6,6) } };
var queryable = list.AsQueryable();
var orderedQueryable = queryable.OrderByDescending("Name");
```

##### Parameters:

- propertyName (string, required): The name of the property you want to order by.

#### `ThenBy` orders an `IOrderedQueryable` by the parameter name.

##### Parameters:

- propertyName (string, required): The name of the property you want to order by.

Example:

```
public class Person {
    public string Name { get; set; }
		public DateTime Birthday { get; set; }
}

var list = new List<Person> { new Person { Name = "Jack", Birthday = new DateTime(1970,1,1) }, new Person { Name = "Bill", Birthday = new DateTime(1970,6,6) } };
var queryable = list.AsQueryable();
var orderedQueryable = queryable.OrderBy("Name").ThenBy("Bitrthday");
```

#### `ThenByDescending orders an `IOrderedQueryable` by the parameter name in descending direction.`

##### Parameters:

- propertyName (string, required): The name of the property you want to order by.

Example:

```
public class Person {
    public string Name { get; set; }
		public DateTime Birthday { get; set; }
}

var list = new List<Person> { new Person { Name = "Jack", Birthday = new DateTime(1970,1,1) }, new Person { Name = "Bill", Birthday = new DateTime(1970,6,6) } };
var queryable = list.AsQueryable();
var orderedQueryable = queryable.OrderBy("Name").ThenByDescending("Birthday");
```
