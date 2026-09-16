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

## Package Contents

### Extension methods for throwing `ArgumentNullException` or `ArgumentException`

- For generic `T` type:
  - `ThrowIfNull<T>()` throws `ArgumentNullException`
- For `System.String` type:
  - `ThrowIfNullOrEmpty()` throws `ArgumentNullException` or `ArgumentException`
  - `ThrowIfNullOrWhiteSpace()` throws `ArgumentNullException` or `ArgumentException`
- For `System.Guid` type:
  - `ThrowIfEmptyGuid()` throws `ArgumentException`

### Extension methods for throwing `ArgumentOutOfRangeException`

Would like to use the new static methods in `ArgumentOutOfRangeException` that were introduced in **.NET 8** but still on older target framework?
In this package they are available as extension methods.

- For `IEquatable<T>` type:
  - `ThrowIfEqualTo()`
  - `ThrowIfNotEqualTo()`
- For `IComparable<T>` type:
  - `ThrowIfLessThan()`
  - `ThrowIfLessThanOrEqualTo()`
  - `ThrowIfGreaterThan`
  - `ThrowIfGreaterThanOrEqualTo()`
- For numeric types:  
  `System.SByte`, `System.Int16`, `System.Int32`, `System.Int64`,  
  `System.Byte`, `System.UInt16`, `System.UInt32`, `System.UInt64`,  
  `System.Half`, `System.Single`, `System.Double`, `System.Decimal`
  - `ThrowIfZero()`
  - `ThrowIfNegative()`
  - `ThrowIfNegativeOrZero()`
  - `ThrowIfPositive()`
  - `ThrowIfPositiveOrZero()`

The exception messages are in English but they can be configured.
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

### Extension methods for the following types

This package contains extension methods for these types:

- `System.Collections.Generic.ICollection<T>`
  - `AddRange()`
- `System.Collections.Generic.IDictionary<TKey, TValue>`
  - `AsReadOnly()`
    - up to .NET 6 (An extension method with the same signature is part of .NET 7+.)
  - `AsSorted()`
  - `DefaultIfKeyNotFound()`
  - `GetOrThrow()`
- `System.Collections.Generic.IEnumerable<T>`
  - `IsNullOrEmpty()`
  - `DetectChanges()` - Get new, existing and removed items.
- `System.Collections.Generic.IList<T>`
  - `AsReadOnly()` up to .NET 6 (An extension method with the same signature is part of .NET 7+.)
- `System.DateOnly`
  - `IsInRange()`
- `System.DateTime`
  - `IsInRange()`
  - `ToMinutePrecision()`
  - `ToSecondPrecision()`
- `System.DateTimeOffset`
  - `IsInRange()`
  - `ToMinutePrecision()`
  - `ToSecondPrecision()`
- `System.Exception`
  - `GetHttpStatusCode()`
  - `SetHttpStatusCode()`
- `System.IO.Stream`
  - `ToByteArray()`
  - `ToByteArrayAsync()`
  - `TryResetStreamPosition()`
- `System.Reflection.Assembly`
  - `SafeGetCodeBase()`
  - `SafeGetLocation()`
- `System.Reflection.MemberInfo`
  - `Is<T>()`
  - `Is<T>(string, StringComparison)`
  - `Is(Type)`
  - `Is(Type, string, StringComparison)`
- `System.Reflection.ParameterInfo`
  - `Is<T>()`
  - `Is<T>(string, StringComparison)`
  - `Is(Type)`
  - `Is(Type, string, StringComparison)`
- `System.String`
  - `IsNullOrEmpty()`
  - `IsNullOrWhiteSpace()`
  - `DefaultIfNullOrEmpty()`
  - `DefaultIfNullOrWhiteSpace()`
  - `EnsureTrailingSlash()`
  - `EnsureNoTrailingSlash()`
- `System.Type`
  - `AsNullableValueType()`
  - `IsNullableValueType()`
  - `GetName()`
- Numeric types:  
  `System.SByte`, `System.Int16`, `System.Int32`, `System.Int64`,  
  `System.Byte`, `System.UInt16`, `System.UInt32`, `System.UInt64`,  
  `System.Half`, `System.Single`, `System.Double`, `System.Decimal`
  - `IsZero()`
  - `IsNegative()`
  - `IsNegativeOrZero()`
  - `IsPositive()`
  - `IsPositiveOrZero()`
  - `IsInRange()`

### Other extension methods with generic type parameters

- `IEnumerable`-related
  - `AsSingleElementSequence()`
    - up to .NET 7 (In case of .NET 8+, use the built-in collection expression feature.)
  - `IsIn()`
  - `IsNotIn()`
- `Reflection`-related
  - `GetPropertyValue()`
  - `TryGetPropertyValue()`
  - `SetPropertyValue()`
  - `TrySetPropertyValue()`
- value selectors
  - `GetStringValueOrNull()`
  - `GetStringValueOrEmptyString()`
  - `GetValueOrDefault()`
  - `GetValue()`

### Predefined (`const` / `readonly`) values

- `Chars`
- `DateTimeFormats`
- `GenericTypeDefinitions`
- `GuidFormats`
- `HttpStatusCodes`
- `Strings`

### `enum` types

- `IntervalBoundsOptions` - can be used e.g. in the new `IsInRange()` extension methods.

### Other types

- `EnumInfo<TEnum>`
  - A wrapper class that provides additional information about an `enum` type or value.
    - Easy access to the custom attributes applied to a member. Can be used for serialization.
    - Easy access to the list of the defined members.
    - Easy access to the name or the underlying value of a member.
    - Implements bitwise / comparison / implicit conversion / equality operators.
- `Encodings.UTF8WithoutBOM`
  - The UTF-8 encoding without the Unicode byte order mark.
  - up to .NET 9 (In case of .NET 10+, use the extension property `UTF8WithoutBOM` on the `System.Text.Encoding` type.
- `StructuralEqualityComparer<T>`
  - Provides a generic `IEqualityComparer<T>` instance for using the non-generic `System.Collections.StructuralComparisons.StructuralEqualityComparer`.
- `TypeHelper`
  - `GetName<T>()` / `GetName(Type)` methods as a shortcut for `Type.FullName ?? Type.Name` expression.
