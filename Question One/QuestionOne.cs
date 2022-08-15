int number;

        
//any number between 0 & INT_MAX (2,147,483,647)
static string ConvertNumberToString(int n)
{
    if (n < 0)
        throw new NotSupportedException("negative numbers not supported");
    if (n == 0)
        return "zero";
    if (n < 10)
        return ConvertDigitToString(n);
    if (n < 20)
        return ConvertTeensToString(n);
    if (n < 100)
        return ConvertHighTensToString(n);
    if (n < 1000)
        return ConvertBigNumberToString(n, (int)1e2, "hundred and");
    if (n < 1e6)
        return ConvertBigNumberToString(n, (int)1e3, "thousand");
    if (n < 1e9)
        return ConvertBigNumberToString(n, (int)1e6, "million");
    //if (n < 1e12)
    return ConvertBigNumberToString(n, (int)1e9, "billion");
}




Console.WriteLine("Amount in Numbers: ");
number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Amount in Words: ");
Console.Write(ConvertNumberToString(number) + " naira");
Console.ReadLine();

Console.WriteLine("\n");


static string ConvertDigitToString(int i)
{
    switch (i)
    {
        case 0: return "";
        case 1: return "one";
        case 2: return "two";
        case 3: return "three";
        case 4: return "four";
        case 5: return "five";
        case 6: return "six";
        case 7: return "seven";
        case 8: return "eight";
        case 9: return "nine";
        default:
            throw new IndexOutOfRangeException(String.Format("{0} not a digit",i));
    }
}

//any number between 10 & 19
static string ConvertTeensToString(int n)
{
    switch (n)
    {
        case 10: return "ten";
        case 11: return "eleven";
        case 12: return "twelve";
        case 13: return "thirteen";
        case 14: return "fourteen";
        case 15: return "fifteen";
        case 16: return "sixteen";
        case 17: return "seventeen";
        case 18: return "eighteen";
        case 19: return "nineteen";
        default:
            throw new IndexOutOfRangeException(String.Format("{0} not a teen", n));
    }
}

//any number between 20 and 99
static string ConvertHighTensToString(int n)
{
    int tensDigit = (int)( Math.Floor((double)n / 10.0));

    string tensStr;
    switch (tensDigit)
    {
        case 2: tensStr = "twenty"; break;
        case 3: tensStr = "thirty"; break;
        case 4: tensStr = "forty"; break;
        case 5: tensStr = "fifty"; break;
        case 6: tensStr = "sixty"; break;
        case 7: tensStr = "seventy"; break;
        case 8: tensStr = "eighty"; break;
        case 9: tensStr = "ninety"; break;
        default:
            throw new IndexOutOfRangeException(String.Format("{0} not in range 20-99", n));
    }
    if (n % 10 == 0) return tensStr;
    string onesStr = ConvertDigitToString(n - tensDigit * 10);
    return tensStr + "-" + onesStr;
}

//to convert any integer bigger than 99
static string ConvertBigNumberToString(int n, int baseNum, string baseNumStr)
{
    string separator = (baseNumStr != "hundred and") ? ", " : " ";

    int bigPart = (int)(Math.Floor((double)n / baseNum));
    string bigPartStr = ConvertNumberToString(bigPart) + " " + baseNumStr;
   
    if (n % baseNum == 0) return bigPartStr;
    int restOfNumber = n - bigPart * baseNum;
    return bigPartStr + separator + ConvertNumberToString(restOfNumber);
}






string words;

static int FromWordsToNumbers(string number) {
    string[] words = number.ToLower().Split(new char[] {' ', '-', ','}, StringSplitOptions.RemoveEmptyEntries);
    string[] ones = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    string[] teens = {"eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
    string[] tens = {"ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
    Dictionary<string, int> modifiers = new Dictionary<string, int>() {
        {"billion", 1000000000},
        {"million", 1000000},
        {"thousand", 1000},
        {"hundred", 100}
    };

    if(number == "eleventy billion")
        return int.MaxValue; // 110,000,000,000 is out of range for an int!
   

    int result = 0;
    int currentResult = 0;
    int lastModifier = 1;

    foreach(string word in words) {
        if(modifiers.ContainsKey(word)) {

            lastModifier *= modifiers[word];
        } 
        else {
            
            int n;

            if(lastModifier > 1) {
                result += currentResult * lastModifier;
                lastModifier = 1;
                currentResult = 0;
            }
           

            if((n = Array.IndexOf(ones, word) + 1) > 0) {
                currentResult += n;
            } else if((n = Array.IndexOf(teens, word) + 1) > 0) {
                currentResult += n + 10;
            } else if((n = Array.IndexOf(tens, word) + 1) > 0) {
                currentResult += n * 10;
            } else if(word != "and") {
                throw new ApplicationException("Unrecognized word: " + word);
            }
        }
    }
     
    return result + (currentResult * lastModifier);
}


Console.WriteLine("Amount in Words: ");
words = Convert.ToString(Console.ReadLine());

Console.WriteLine("Amount in Numbers: ");
Console.WriteLine(FromWordsToNumbers(words) + " naira");
Console.ReadLine();


//THe logic in my algorithm is
//-the highest power of the string, in the arrangement from billion to million to thousand to hundred
//i encountered a dilemma when i tried writing seven hundred and sixty five thousand.
//The foreach loop sets the thousand as a higher priority or has a higher index position that the hundred,
//Which led my result to be 65700, 
//i tried cracking my head on setting "hundred and" to be of a higher index or a higher priority than thousand,
//But i was unsuccessful.

//To print 765000, one has to input "seven hundred thousand and sixty-five thousand."













