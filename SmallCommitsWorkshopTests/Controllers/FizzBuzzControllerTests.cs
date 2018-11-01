using System.Net;
using System.Net.Http;
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
		private WebApplicationFactory<Startup> m_factory;
		private HttpClient m_client;
		private IServiceScope m_scope;
		private UsersContext m_usersContext;

		[SetUp]
		public void SetUp() {
			m_factory = new WebApplicationFactory<Startup>();
			m_client = m_factory.CreateClient();
			m_scope = m_factory.Server.Host.Services.CreateScope();
			m_usersContext = m_scope.ServiceProvider.GetService<UsersContext>();
		}

		[TearDown]
		public void TearDown() {
			m_scope.Dispose();
			m_client.Dispose();
			m_factory.Dispose();
		}

		[TestCase( 33, ExpectedResult = "Fizz" )]
		[TestCase( 34, ExpectedResult = "34" )]
		[TestCase( 35, ExpectedResult = "Buzz" )]
		[TestCase( 90, ExpectedResult = "FizzBuzz" )]
		public async Task<string> Get( int number ) {

			using( HttpResponseMessage response = await m_client.GetAsync( $"/api/fizzbuzz/{number}" ) ) {

				var result = await response.Content.ReadAsStringAsync();

				return result;
			}
		}

		[TestCase( 63, "Test", "Bzzt", ExpectedResult = "Test" )]
		[TestCase( 64, "Test", "Bzzt", ExpectedResult = "64" )]
		[TestCase( 65, "Test", "Bzzt", ExpectedResult = "Bzzt" )]
		[TestCase( 30, "some-name", "some-word", ExpectedResult = "some-namesome-word" )]
		public async Task<string> GetForUser( int number, string userName, string buzzWord ) {

			await AddUsers( new User { Id = 169, UserName = userName, BuzzWord = buzzWord } );

			using( HttpResponseMessage response = await m_client.GetAsync( $"/api/fizzbuzz/{number}/users/169" ) ) {

				var result = await response.Content.ReadAsStringAsync();

				return result;
			}
		}

		[Test]
		public async Task GetForUser_UserNotFound() {

			using( HttpResponseMessage response = await m_client.GetAsync( $"/api/fizzbuzz/15/users/169" ) ) {

				Assert.AreEqual(
					HttpStatusCode.NotFound,
					response.StatusCode
				);
			}
		}

		[Test]
		public async Task GetForUser_CallsCalculate() {
			// Arrange
			var user = new User { Id = 1234, UserName = "user-name", BuzzWord = "some-word" };
			await AddUsers( user );

			const int number = 5;
			const string calculatedValue = "some-value";
			var fizzBuzzService = new Mock<IFizzBuzzService>( MockBehavior.Strict );
			fizzBuzzService
				.Setup( x => x.Calculate( number, user.UserName, user.BuzzWord ) )
				.Returns( calculatedValue );

			var controller = new FizzBuzzController(
				fizzBuzzService: fizzBuzzService.Object,
				usersContext: m_usersContext
			);

			using( controller ) {

				// Act
				var result = await controller.GetForUser( number: number, userId: user.Id );

				// Assert
				Assert.AreEqual(
					expected: calculatedValue,
					actual: result.Value
				);
			}
		}

		private Task AddUsers( params User[] users ) {
			m_usersContext.Users.AddRange( users );
			return m_usersContext.SaveChangesAsync();
		}
	}
}
