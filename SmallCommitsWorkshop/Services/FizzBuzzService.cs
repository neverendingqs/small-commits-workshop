using System.Text;

namespace SmallCommitsWorkshop.Services {
	public class FizzBuzzService : IFizzBuzzService {
		string IFizzBuzzService.Calculate( int number ) {
			IFizzBuzzService @this = this;
			return @this.Calculate( number, "Fizz", "Buzz" );
		}

		string IFizzBuzzService.Calculate(
			int number,
			string fizz,
			string buzz
		) {
			fizz = fizz ?? "";
			buzz = buzz ?? "";

			if( number % 15 == 0 ) {
				return $"{fizz}{buzz}";
			}

			if( number % 3 == 0 ) {
				return fizz;
			}

			if( number % 5 == 0 ) {
				return buzz;
			}

			return number.ToString();
		}
	}
}
