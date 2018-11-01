using NUnit.Framework;
using SmallCommitsWorkshop.Services;

namespace SmallCommitsWorkshopTests.Services {
	[TestFixture]
	internal sealed class FizzBuzzServiceUnitTests {
		private readonly IFizzBuzzService m_fizzBuzzService = new FizzBuzzService();

		[TestCase( 1 )]
		[TestCase( 2 )]
		[TestCase( 13 )]
		[TestCase( 9998 )]
		public void Calculate_IsNotDivisibleBy3Or5( int number ) {
			Assert.AreEqual(
				expected: number.ToString(),
				actual: m_fizzBuzzService.Calculate( number: number )
			);
		}

		[TestCase( 3 )]
		[TestCase( 123 )]
		[TestCase( 999999 )]
		public void Calculate_IsOnlyDivisibleBy3_ReturnsFizz( int number ) {
			Assert.AreEqual(
				expected: "Fizz",
				actual: m_fizzBuzzService.Calculate( number: number )
			);
		}

		[TestCase( 5 )]
		[TestCase( 125 )]
		[TestCase( 55555 )]
		public void Calculate_IsOnlyDivisibleBy5_ReturnsBuzz( int number ) {
			Assert.AreEqual(
				expected: "Buzz",
				actual: m_fizzBuzzService.Calculate( number: number )
			);
		}

		[TestCase( 0 )]
		[TestCase( 15 )]
		[TestCase( 135 )]
		public void Calculate_IsDivisibleBy3And5_ReturnsFizzBuzz( int number ) {
			Assert.AreEqual(
				expected: "FizzBuzz",
				actual: m_fizzBuzzService.Calculate( number: number )
			);
		}

		[TestCase( 1, "some-fizz", "some-buzz", ExpectedResult = "1" )]
		[TestCase( 3, "some-fizz", "some-buzz", ExpectedResult = "some-fizz" )]
		[TestCase( 3, "", "some-buzz", ExpectedResult = "" )]
		[TestCase( 3, null, "some-buzz", ExpectedResult = "" )]
		[TestCase( 5, "some-fizz", "some-buzz", ExpectedResult = "some-buzz" )]
		[TestCase( 5, "some-fizz", "", ExpectedResult = "" )]
		[TestCase( 5, "some-fizz", null, ExpectedResult = "" )]
		[TestCase( 15, "some-fizz", "some-buzz", ExpectedResult = "some-fizzsome-buzz" )]
		[TestCase( 15, "", "some-buzz", ExpectedResult = "some-buzz" )]
		[TestCase( 15, null, "some-buzz", ExpectedResult = "some-buzz" )]
		[TestCase( 15, "some-fizz", "", ExpectedResult = "some-fizz" )]
		[TestCase( 15, "some-fizz", null, ExpectedResult = "some-fizz" )]
		[TestCase( 15, "", "", ExpectedResult = "" )]
		[TestCase( 15, "", null, ExpectedResult = "" )]
		[TestCase( 15, null, "", ExpectedResult = "" )]
		[TestCase( 15, null, null, ExpectedResult = "" )]
		public string Calculate__int__string__string( int number, string fizz, string buzz ) {
			return m_fizzBuzzService.Calculate(
				number: number,
				fizz: fizz,
				buzz: buzz
			);
		}
	}
}
