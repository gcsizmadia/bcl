# Egonsoft.HU BCL Extensions

[![GitHub](https://img.shields.io/github/license/gcsizmadia/EgonsoftHU.Extensions.Bcl?label=License)](https://opensource.org/licenses/MIT)
[![Nuget](https://img.shields.io/nuget/v/EgonsoftHU.Extensions.Bcl?label=NuGet)](https://www.nuget.org/packages/EgonsoftHU.Extensions.Bcl)
[![Nuget](https://img.shields.io/nuget/dt/EgonsoftHU.Extensions.Bcl?label=Downloads)](https://www.nuget.org/packages/EgonsoftHU.Extensions.Bcl)

C# extension methods for Base Class Library types.

## Introduction

The motivation behind this project is to collect reusable extension methods into a NuGet package avoiding CPD (copy-paste-development).

## Releases

You can download the package from [nuget.org](https://www.nuget.org/).
- [EgonsoftHU.Extensions.Bcl](https://www.nuget.org/packages/EgonsoftHU.Extensions.Bcl)

You can find the release notes [here](https://github.com/gcsizmadia/bcl/releases).

## Summary

- Extension methods for conveniently throwing `ArgumentNullException`
- Extension methods for conveniently throwing `ArgumentException`
- Extension methods for conveniently throwing `ArgumentOutOfRangeException`
- Extension methods for specific types
- Extension methods with generic type parameters
- Predefined (`const` / `readonly`) values
- Helper types

---


### Extension methods for conveniently throwing `ArgumentNullException` or `ArgumentException`

#### Type: `T`

- `ThrowIfNull<T>()`

#### Type: `System.String`

- `ThrowIfNullOrEmpty()`
- `ThrowIfNullOrWhiteSpace()`

#### Type: `System.Guid`

- `ThrowIfEmpty()`

#### Type: `System.Guid?`

- `ThrowIfNullOrEmpty()`

#### Examples

```csharp
void DoSomething(SomeClass obj, string value, Guid? nullableGuid, Guid guid)
{
    obj.ThrowIfNull();

    value.ThrowIfNullOrEmpty();
    value.ThrowIfNullOrWhiteSpace();

    nullableGuid.ThrowIfNull();
    nullableGuid.ThrowIfNullOrEmpty();

    guid.ThrowIfEmpty();
}
```

---


### Extension methods for throwing `ArgumentOutOfRangeException`

Would you like to use the static methods in `ArgumentOutOfRangeException` that were introduced in **.NET 8**, but your project targets an older framework?
In this package they are available as extension methods.

#### Type: `IEquatable<T>`

- `ThrowIfEqualTo()`
- `ThrowIfNotEqualTo()`

#### Type: `IComparable<T>`

- `ThrowIfLessThan()`
- `ThrowIfLessThanOrEqualTo()`
- `ThrowIfGreaterThan()`
- `ThrowIfGreaterThanOrEqualTo()`

#### Type: `System.SByte`, `System.Int16`, `System.Int32`, `System.Int64`,<br>`System.Byte`, `System.UInt16`, `System.UInt32`, `System.UInt64`,<br>`System.Half`, `System.Single`, `System.Double`, `System.Decimal`

- `ThrowIfZero()`
- `ThrowIfNegative()`
- `ThrowIfNegativeOrZero()`
- `ThrowIfPositive()`
- `ThrowIfPositiveOrZero()`

#### Examples

```csharp
void DoSomething(int value)
{
    value.ThrowIfNegativeOrZero();

    // net8.0, net9.0, net10.0:
    // calls ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);

    // netstandard2.0, netstandard2.1, net472:
    // custom check using IsNegativeOrZero() extension method, throws ArgumentOutOfRangeException manually
}
```

#### Remark

When throwing the `ArgumentOutOfRangeException` manually, this library uses exception messages identical to the English-language messages in .NET 8, if present.  
These messages can be customized or localized as follows, if necessary.

```csharp
using EgonsoftHU.Extensions.Bcl;

// This method is intended to be used for non-localizable error messages.
ErrorMessageConfiguration.Current.ConfigureErrorMessage(
    errorMessageKey: ErrorMessageKey.ArgumentOutOfRange_MustBeNonZero,
    errorMessage: "The parameter '{0}' must be non-zero. Actual value: {1}"
);

// This method is intended to be used for localizable error messages.
ErrorMessageConfiguration.Current.ConfigureErrorMessage(
    errorMessageKey: ErrorMessageKey.ArgumentOutOfRange_MustBeNonZero,
    errorMessageResourceType: typeof(YourCustomValidationResources),
    // This parameter is optional. If not specified then the value of errorMessageKey is used.
    errorMessageResourceName: "YourCustomResourceName"
);
```

*Applies to:*

|Extension method|Targets that throw custom exception|
|-|-|
|`ThrowIfEqualTo()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfNotEqualTo()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfLessThan()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfLessThanOrEqualTo()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfGreaterThan()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfGreaterThanOrEqualTo()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfZero()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfNegative()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfNegativeOrZero()`|`netstandard2.0`, `netstandard2.1`, `net472`|
|`ThrowIfPositive()`|all targets|
|`ThrowIfPositiveOrZero()`|all targets|

---

### Extension methods for specific types

#### Type: `System.Collections.Generic.IEnumerable<T>`

- `IsNullOrEmpty()`
- `DetectChanges(existingItems, incomingItems, keySelector)` - *Detects items to be added, to be updated and to be removed.*

#### Type: `System.Collections.Generic.ICollection<T>`

- `AddRange()`

#### Type: `System.Collections.Generic.IList<T>`

- `AsReadOnly()` - *Applies to targets: `netstandard2.0`, `netstandard2.1`, `net472`*

#### Type: `System.Collections.Generic.IDictionary<TKey, TValue>`

- `AsReadOnly()` - *Applies to targets: `netstandard2.0`, `netstandard2.1`, `net472`*
- `AsSorted()`
- `DefaultIfKeyNotFound()`
- `GetOrThrow()`

#### Type: `System.DateOnly`

- `IsInRange()` - *Applies to targets: `net8.0`, `net9.0`, `net10.0`*

#### Type: `System.DateTime`, `System.DateTimeOffset`

- `IsInRange()`
- `ToMinutePrecision()`
- `ToSecondPrecision()`

#### Type: `System.Exception`

- `GetHttpStatusCode()`
- `SetHttpStatusCode()`

#### Type: `System.IO.Stream`

- `ToByteArray()`
- `ToByteArrayAsync()` - *Applies to targets: `netstandard2.0`, `net472`*
- `ToByteArrayAsync(CancellationToken)` - *Applies to targets: `netstandard2.1`, `net8.0`, `net9.0`, `net10.0`*
- `TryResetStreamPosition()`

#### Type: `System.Reflection.Assembly`

- `SafeGetCodeBase()`
- `SafeGetLocation()`

#### Type: `System.Reflection.MemberInfo`, `System.Reflection.ParameterInfo`

- `Is<T>()`
- `Is<T>(string, StringComparison)`
  ```csharp
  using Autofac;
  using EgonsoftHU.Extensions.Bcl;
  using Serilog;

  // Instead of
  var resolvedParameter =
      new ResolvedParameter(
          (parameter, context) =>
            parameter != null
            &&
            parameter.ParameterType == typeof(ILogger)
            &&
            String.Equals(parameter.Name, "logger", StringComparison.Ordinal),
          (parameter, context) => Log.Logger.ForContext(parameter.Member.DeclaringType)
      );

  // you can write
  var resolvedParameter =
      new ResolvedParameter(
          (parameter, context) => parameter.Is<ILogger>("logger"),
          (parameter, context) => Log.Logger.ForContext(parameter.Member.DeclaringType)
      );
  ```
- `Is(Type)`
- `Is(Type, string, StringComparison)`

#### Type: `System.String`

- `IsNullOrEmpty()`
- `IsNullOrWhiteSpace()`
- `DefaultIfNullOrEmpty()`
  ```csharp
  // Instead of
  var value = String.IsNullOrEmpty(inputValue) ? defaultValue : inputValue;

  // you can write
  var value = inputValue.DefaultIfNullOrEmpty(defaultValue);
  ```
- `DefaultIfNullOrWhiteSpace()`
- `EnsureTrailingSlash()`
- `EnsureNoTrailingSlash()`

#### Type: `System.Type`

- `AsNullableValueType()`
- `IsNullableValueType()`
- `GetName()`

#### Type: `System.SByte`, `System.Int16`, `System.Int32`, `System.Int64`<br>`System.Byte`, `System.UInt16`, `System.UInt32`, `System.UInt64`<br>`System.Half`, `System.Single`, `System.Double`, `System.Decimal`

- `IsZero()`
- `IsNegative()`
- `IsNegativeOrZero()`
- `IsPositive()`
- `IsPositiveOrZero()`
- `IsInRange()`

---


### Extension methods with generic type parameters

#### IEnumerable-related

- `AsSingleElementSequence()` - *Applies to targets: `netstandard2.0`, `netstandard2.1`, `net472`*
  ```csharp
  void DoSomething(IEnumerable<Item> items)
  {
  }
  
  // Instead of
  DoSomething(new Item[] { item });

  // you can write
  DoSomething(item.AsSingleElementSequence());
  
  // This extension method is not available in .NET 8.0 or later versions, as you can use collection expressions as follows:
  DoSomething([item]);
  ```
- `IsIn()`
  ```csharp
  // Instead of
  bool IsWeekend(DateTime date)
  {
      return
          date.DayOfWeek == DateOfWeek.Saturday ||
          date.DayOfWeek == DateOfWeek.Sunday;
  }

  // you can write
  using EgonsoftHU.Extensions.Bcl;

  bool IsWeekend(DateTime date)
  {
      return date.DayOfWeek.IsIn(DateOfWeek.Saturday, DateOfWeek.Sunday);
  }
  ```
- `IsNotIn()`
  ```csharp
  using Microsoft.Extensions.Hosting;

  // Instead of
  var result = !hostEnvironment.IsDevelopment() && !hostEnvironment.IsStaging();

  // you can write
  using EgonsoftHU.Extensions.Bcl;

  var result = hostEnvironment.EnvironmentName.IsNotIn(
    StringComparer.OrdinalIgnoreCase,
    Environments.Development,
    Environments.Staging
  )
  ```

#### Reflection-related

- `GetPropertyValue()`
- `TryGetPropertyValue()`
- `SetPropertyValue()`
- `TrySetPropertyValue()`

#### Value selectors

- `GetStringValueOrNull()`
- `GetStringValueOrEmptyString()`
- `GetValueOrDefault()`
- `GetValue()`

---


### Predefined (`const` / `readonly`) values

Make code easier to read by avoiding magic strings using frequently used values as constants.

|Class|Members|
|-|-|
|`Chars`|`Comma`, `Semicolon`, `Slash`, `Space`, etc.|
|`DateTimeFormats`|`Iso8601`, `Rfc1123`, `DateOnly`, `DateTimeWithSecondPrecision`|
|`GenericTypeDefinitions`|`Nullable`|
|`GuidFormats`|`Number`, `Digit`, `Brace`, `Parenthesis`, `Hex`|
|`HttpStatusCodes`|`Status200OK`, `Status201Created`, `Status204NoContent`, etc.|
|`Strings`|`NullString`, `CommaSpaceSeparator`, `Comma`, `Semicolon`, etc.|

#### Examples

```csharp
// MS Dynamics 365 endpoint
string apiRoot = "/api/data/v9.0/";
string entitySetName = "incidents";
var entityId = Guid.NewGuid();

// Instead of
string endpoint = $"{apiRoot}{entitySetName}{entityId.ToString("P")}";

// you can write
string endpoint = $"{apiRoot}{entitySetName}{entityId.ToString(GuidFormats.Parenthesis)}";

// endpoint = "/api/data/v9.0/incidents(eee1df0f-4231-4dd2-8714-64e56149ad62)"
```

---

### Helper types

- `IntervalBoundsOptions`
  - An `enum` type that defines interval bounds as `Closed`, `LeftOpen`, `RightOpen` or `Open`.
  - It is used by the `IsInRange()` extension methods.
- `EnumInfo<TEnum>`
  - A wrapper class that provides additional information about an `enum` type or value.
    - Easy access to the custom attributes applied to a member. (E.g. for custom serialization)
    - Easy access to the list of the defined members.
    - Easy access to the name or the underlying value of a member.
    - Implements bitwise / comparison / implicit conversion / equality operators.
- `Encodings.UTF8WithoutBOM` - *Applies to: `netstandard2.0`, `netstandard2.1`, `net472`, `net8.0`, `net9.0`*
  - The UTF-8 encoding without the Unicode byte order mark.
- `System.Text.Encoding.UTF8WithoutBOM` extension property - *Applies to: `net10.0`*
  - The UTF-8 encoding without the Unicode byte order mark.
- `StructuralEqualityComparer<T>`
  - Provides a generic `IEqualityComparer<T>` instance for using the non-generic `System.Collections.StructuralComparisons.StructuralEqualityComparer`.
- `TypeHelper`
  - `GetName<T>()` / `GetName(Type)` methods as a shortcut for `Type.FullName ?? Type.Name` expression.
