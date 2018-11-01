using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SmallCommitsWorkshop;
using SmallCommitsWorkshop.Controllers;
using SmallCommitsWorkshop.Models;
using SmallCommitsWorkshop.Services;

namespace SmallCommitsWorkshopTests.Controllers {
	[TestFixture]
	internal sealed class FizzBuzzControllerUnitTests {

		[Test]
		public void Get_CallsCalculate() {
			const int number = 5;
			const string calculatedValue = "Buzz";
			Mock<IFizzBuzzService> fizzBuzzService = new Mock<IFizzBuzzService>( MockBehavior.Strict );
			fizzBuzzService
				.Setup( x => x.Calculate( number ) )
				.Returns( calculatedValue );

			FizzBuzzController sut = new FizzBuzzController(
				fizzBuzzService: fizzBuzzService.Object,
				usersContext: null
			);

			Assert.AreEqual(
				expected: calculatedValue,
				actual: sut.Get( number: number )
			);
		}
	}
}
