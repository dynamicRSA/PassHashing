using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a password to be hashed...");
            string pw = Console.ReadLine();
            Console.WriteLine();

            HashData hd = new HashData();
            Console.WriteLine("The hash value for the password " + pw + " is: ");
            string pwh = hd.CreateHash(pw);
            Console.WriteLine(pwh);         //THIS WOULD BE STORED IN A DB 


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("When the user logs in later, we'll get a password ");
            Console.WriteLine("and compare it to the previous hash...");

            Console.WriteLine("Enter the original password: "); //THIS WOULD BE THE PASSWORD ENTERED TO LOG IN
            string pw2 = Console.ReadLine();
            string pwh2 = hd.CreateHash(pw2);

            Console.WriteLine();
            Console.WriteLine("First Hash is : " + pwh);
            Console.WriteLine("Second Hash is: " + pwh2);

            if (pwh == pwh2)
            {
                Console.WriteLine("Hashes match.");
            }
            else
            {
                Console.WriteLine("Hashes DO NOT match.");
            }
            Console.ReadLine();
        }
    }

    public class HashData
    {
        public string CreateHash(string input)
        {
            HashAlgorithm sha = SHA256.Create();
            byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(input));
            return Convert.ToBase64String(hashData);


        }
    }
}
