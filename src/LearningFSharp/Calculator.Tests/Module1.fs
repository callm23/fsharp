module Call.Demo.Calculator.Tests

open Xunit

[<Fact>]
let ``adder add 5 and 3 should return 8``() =
  Assert.Equal(8, Adder.add 5 3)

