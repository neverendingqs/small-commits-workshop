using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmallCommitsWorkshop;
using SmallCommitsWorkshopTests.Extensions;

namespace SmallCommitsWorkshopTests.Controllers {
	[TestFixture]
	internal sealed class UsersControllerTests {
		private WebApplicationFactory<Startup> m_factory;

		[SetUp]
		public void SetUp() {
			m_factory = new WebApplicationFactory<Startup>();
		}

		[Test]
		public async Task GetAll_ReturnsUsers() {
			HttpClient client = m_factory.CreateClient();

			using( HttpResponseMessage response = await client.GetAsync( "/api/users" ) ) {
				CollectionAssert.AreEquivalent(
					new Dictionary<long, string>() {
						{ 169, "D2LSupport" },
						{ 175, "user1" },
					}, 
					await response.Content.ReadAsJsonAsync<IDictionary<long, string>>()
				);
			}
		}
	}
}
