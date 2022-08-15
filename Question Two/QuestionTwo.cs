static char cipher(char ch, int key)
{
    if (!char.IsLetter(ch))
    {
        return ch;
    }
    char value = char.IsUpper(ch) ? 'A' : 'a';
    return (char)((((ch + key) - value) % 26) + value);
}

static string Encrypt(string input, int key)
{
    string output = string.Empty;
    foreach (char ch in input)
    {
        output += cipher(ch, key);
    }
    return output;
}

static string Decrypt(string input, int key)
{
    return Encrypt(input, 26 - key);
}


    Console.WriteLine("Enter information to encrypt: ");
    string UserString = Console.ReadLine();
    Console.WriteLine("\n");

    Console.Write("Enter your  Cipher-Key, (Must be an integer) ");
    int key = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n");

    Console.WriteLine("Encrypted Data ");
    string cipherText = Encrypt(UserString, key);
    Console.WriteLine(cipherText);
    Console.WriteLine("\n");


    Console.WriteLine("Decrypted Data: ");
    string text = Decrypt(cipherText, key);
    Console.WriteLine(text);
    Console.WriteLine("\n");

    Console.ReadKey();

