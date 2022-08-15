using Xunit;

public class TestCases
{

[Fact]
		public void TestLotsOfNumbers()
		{
			int i = 0;
			int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 17, 19, 21, 32, 54, 76, 98, 
								100, 101, 211, 825, 999, 1100, 5101, 23211, 785825,
								1000000, 2010203, 20102030, 34567890, 999999999, (int)2e9+3 };
			string[] expectedResult = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", 
										"ten", "eleven", "twelve", "thirteen", "seventeen", "nineteen",
										"twenty-one", "thirty-two", "fifty-four", "seventy-six", "ninety-eight",
										"one hundred", "one hundred one", "two hundred eleven", "eight hundred twenty-five",
										"nine hundred ninety-nine",	"one thousand, one hundred", "five thousand, one hundred one", 
										"twenty-three thousand, two hundred eleven", 
										"seven hundred eighty-five thousand, eight hundred twenty-five",
										"one million", "two million, ten thousand, two hundred three", 
										"twenty million, one hundred two thousand, thirty",
										"thirty-four million, five hundred sixty-seven thousand, eight hundred ninety",
										"nine hundred ninety-nine million, nine hundred ninety-nine thousand, nine hundred ninety-nine",
										"two billion, three"};
			foreach (int n in numbers)
			{
				string s = Converter.ConvertNumberToString(n);
				Assert.Equal(expectedResult[i++], i);
			}
		}
}