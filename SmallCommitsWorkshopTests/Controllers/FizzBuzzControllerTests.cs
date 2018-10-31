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
	internal sealed class FizzBuzzControllerTests {

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

		[Test]
		public async Task GetForUser_CallsCalculate() {
			// Arrange
			using( var factory = new WebApplicationFactory<Startup>() )
			using( factory.CreateClient() ) // Needed to create the server
			using( var scope = factory.Server.Host.Services.CreateScope() ) {
				var usersContext = scope.ServiceProvider.GetService<UsersContext>();

				var user = new User { Id = 1234, UserName = "user-name", BuzzWord = "some-word" };
				usersContext.Users.Add( user );
				usersContext.SaveChanges();

				const int number = 5;
				const string calculatedValue = "some-value";
				var fizzBuzzService = new Mock<IFizzBuzzService>( MockBehavior.Strict );
				fizzBuzzService
					.Setup( x => x.Calculate( number, user.UserName, user.BuzzWord ) )
					.Returns( calculatedValue );

				var controller = new FizzBuzzController(
					fizzBuzzService: fizzBuzzService.Object,
					usersContext: usersContext
				);

				// Act
				var result = await controller.GetForUser( number: number, userId: user.Id );

				// Assert
				Assert.AreEqual(
					expected: calculatedValue,
					actual: result.Value
				);
			}
		}
	}
}
