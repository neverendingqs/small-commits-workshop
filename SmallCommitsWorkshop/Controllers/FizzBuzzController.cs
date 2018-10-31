using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCommitsWorkshop.Models;
using SmallCommitsWorkshop.Services;

namespace SmallCommitsWorkshop.Controllers {
	[Route( "api/[controller]" )]
	public class FizzBuzzController : Controller {
		private readonly IFizzBuzzService m_fizzBuzzService;
		private readonly UsersContext m_usersContext;

		public FizzBuzzController(
			IFizzBuzzService fizzBuzzService,
			UsersContext usersContext
		) {
			m_fizzBuzzService = fizzBuzzService;
			m_usersContext = usersContext;
		}

		// GET api/fizzbuzz/{number}
		[HttpGet( "{number}" )]
		public string Get( int number ) {
			return m_fizzBuzzService.Calculate( number: number );
		}

		// GET api/fizzbuzz/{number}/users/{userId}
		[HttpGet( "{number}/users/{userId}" )]
		public async Task<ActionResult<string>> GetForUser( int number, long userId ) {
			User user = await m_usersContext.Users.FindAsync( userId );

			if( user == null ) {
				return NotFound();
			}

			return m_fizzBuzzService.Calculate(
				number: number,
				fizz: user.UserName,
				buzz: user.BuzzWord
			);
		}
	}
}
