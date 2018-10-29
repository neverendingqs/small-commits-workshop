using System.Text;

namespace SmallCommitsWorkshop.Services {
	public class FizzBuzzService : IFizzBuzzService {
		string IFizzBuzzService.Calculate( int number ) {
			StringBuilder response = new StringBuilder();

			if( number % 3 == 0 ) {
				response.Append( "Fizz" );
			}

			if( number % 5 == 0 ) {
				response.Append( "Buzz" );
			}

			return response.Length == 0
				? number.ToString()
				: response.ToString();
		}
	}
}
