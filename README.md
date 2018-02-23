[![TeixeiraSoftware.Finance.Money](https://github.com/TeixeiraSoftware/assets/raw/master/logo_small.png)](https://TeixeiraSoftware.github.io/TeixeiraSoftware.Finance.Money/)

# TeixeiraSoftware.Finance.Money [![Tweet](https://img.shields.io/twitter/url/http/shields.io.svg?style=social)](https://twitter.com/intent/tweet?text=A%20simple%20money%20class%20library&url=https://TeixeiraSoftware.github.io/TeixeiraSoftware.Finance.Money/&hashtags=money,finance,software,dotnet,crossplatform)

[![Build status](https://ci.appveyor.com/api/projects/status/oiuheni8ga39sd9f?svg=true)](https://ci.appveyor.com/project/TeixeiraSoftware/teixeirasoftware-finance-money)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/TeixeiraSoftware/TeixeiraSoftware.Finance.Money/blob/master/LICENSE)
[![Pull Requests](https://img.shields.io/badge/Pull%20Requests-Welcome-brightgreen.svg)](https://github.com/TeixeiraSoftware/TeixeiraSoftware.Finance.Money/blob/master/CONTRIBUTING.md)
[![NuGet](https://img.shields.io/nuget/dt/currency.svg)](https://www.nuget.org/packages/TeixeiraSoftware.Finance.Money/)

A simple cross platform money struct for .Net based on [Martin Fowler's Money pattern](https://martinfowler.com/eaaCatalog/money.html).

The implementation of this library is compatible with .Net Standard 2.0 (see [https://docs.microsoft.com/en-us/dotnet/standard/net-standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) for details).

TeixeiraSoftware.Finance.Money is an immutable value type.

## Installation

NuGet Package Manager:
```
Install-Package TeixeiraSoftware.Finance.Money
```

.NET CLI:
```
dotnet add package TeixeiraSoftware.Finance.Currency
```

Paket CLI:
```
paket add TeixeiraSoftware.Finance.Currency
```

## Dependencies

This package has no dependencies.

## Usage
The `Money` class makes use of an abstract class called `ICurrency` that must be implemented in order to use this library.
There is already an implementation available at nuget using the name [`TeixeiraSoftware.Finance.Currency`](https://www.nuget.org/packages/TeixeiraSoftware.Finance.Currency/), and for the examples in this documentation, the methods used to get `ICurrency` instances will come from that library. If you want, you can implement yourself the `ICurrency` abstract class in order to provide your own functionallity.

The usage is very simple:

``` c#
// XXX represents the ISO 4217 code of the currency
var tenMoneys = new Money(12.3m, Currency.XXX);
var aMillionMoneys = new Money(1000000, Currency.GetByLetterCode("XXX"));
```

### Math operations:

``` c#
// operator +
var halfMoney = new Money(0.25m, Currency.XXX) + 0.25m;
var tenMoneys = 1.5m + new Money(8.5m, Currency.XXX);
var aHundredMoneys = tenMoneys + 90;
var aThousandMoneys = 900 + aHundredMoneys;
var moreMoney = aHundredMoneys + aThousandMoneys;

// operator -
var oneMoney = new Money(2, Currency.XXX) - 1;
var tenMoneys = 1 - new Money(11, Currency.XXX);
var nineMoneys = tenMoneys - 1;
var eightMoneys = 1 - tenMoneys;
var sevenMoneys = eightMoneys - oneMoney;

// operator /
var fiveHundredMoneys = aThousandMoneys / 2;
// you cannot divide any number to a Money instance, like
// `2 / new Money(10, Currency.XXX)`, because it makes no sense at all

// operator *
var twoThousandMoneys = aThousandMoneys * 2;
var aLotOfMoney = 1000 * aThousandMoneys;
```

### Comparison operations

The available operators are: `==`, `!=`, `>`, `>=`, `<` and `<=`. And the `.Equals` method is also available.

``` c#
var aThousandMoneys = new Money(1000, Currency.XXX);
var fortyTwoMoneys = new Money(42, Currency.XXX);
var twoThousandMoneys = aThousandMoneys * 2;
var aLotOfMoneys = 1000 * aThousandMoneys;

if (aThousandMoneys == aLotOfMoneys)
{
    // ...
}

if (aThousandMoneys != new Money(10, Currency.XTS))
{
    // ...
}

if (aThousandMoneys.Equals(twoThousandMoneys))
{
    // ...
}

if (twoThousandMoneys > aLotOfMoneys)
{
    // ...
}

// and so on...
```

### Details about operations involving different currencies

You may pay attention when trying to use the operators when the currencies don't match.
the operators `>`, `>=`, `<` and `<=` will throw a `CurrencyMismatchException` if the currencies are not the same:

``` c#
var tenXXX = new Money(10, Currency.XXX);
var tenXTS = new Money(10, Currency.XTS);

if (tenXXX > tenXTS) // throws CurrencyMismatchException
```

However, you can perform an equality comparison between instances with different currencies, although in this case you will always obtain `false`:

``` c#
var tenXXX = new Money(10, Currency.XXX);
var tenXTS = new Money(10, Currency.XTS);

if (tenXXX == tenXTS)
{
    // no exception bill be thrown and the code in this block will never be executed
}

if (tenXXX.Equals(tenXTS))
{
    // no exception bill be thrown and the code in this block will never be executed
}
```

If you don't like this behavior, you can change it by setting the flag `StrictEqualityComparisons` to `true`.
When doing so, any try to compare the equality between instances with different currencies will result in a `CurrencyMismatchException` being thrown:

``` c#
Money.StrictEqualityComparisons = true;

var tenXXX = new Money(10, Currency.XXX);
var tenXTS = new Money(10, Currency.XTS);

if (tenXXX == tenXTS) // throws CurrencyMismatchException

if (tenXXX.Equals(tenXTS)) // throws CurrencyMismatchException
```

### Contributing
I'm currently looking for help to improve the project. You can see some topics that you can help with in the [issues section of the project's GitHub page](https://github.com/TeixeiraSoftware/TeixeiraSoftware.Finance.Money/issues).
You can also contribute by doing unit tests, documentation, making pull requests or sharing the project.
