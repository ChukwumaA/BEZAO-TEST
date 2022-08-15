static char cipher(char ch, int key)
{
    if (!char.IsLetter(ch))
    {
        return ch;
    }
    char d = char.IsUpper(ch) ? 'A' : 'a';
    return (char)((((ch + key) - d) % 26) + d);
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
    Console.Write("\n");

    Console.WriteLine("Decrypted Data: ");
    string t = Decrypt(cipherText, key);
    Console.WriteLine(t);
    

    Console.ReadKey();

