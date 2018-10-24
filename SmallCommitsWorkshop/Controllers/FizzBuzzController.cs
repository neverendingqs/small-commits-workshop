using Microsoft.AspNetCore.Mvc;
using SmallCommitsWorkshop.Services;

namespace SmallCommitsWorkshop.Controllers {
	[Route( "api/[controller]" )]
	public class FizzBuzzController : Controller {
		private readonly IFizzBuzzService m_fizzBuzzService;

		public FizzBuzzController( IFizzBuzzService fizzBuzzService ) {
			m_fizzBuzzService = fizzBuzzService;
		}

		// GET api/fizzbuzz/{number}
		[HttpGet( "{number}" )]
		public string Get( int number ) {
			return m_fizzBuzzService.Calculate( number: number );
		}
	}
}
