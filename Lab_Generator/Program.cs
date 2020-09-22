using System;

namespace Lab_Generator
{

    class Program
    {
        static bool exit = false;

        static void Main(string[] args)
        {
            
           
            Console.WriteLine("Select option");
            Console.WriteLine("0: Obtain information about the types of generator");

            Console.WriteLine("Select the type of generator (You can select multiple generators)");
            Generator.GetInfoTypes();

            Console.WriteLine("5: Generate password");
            Console.WriteLine("6: Reset settings");
            Console.WriteLine("7: Exit");
            while (!exit)
            {
                Console.Write("Answer: ");
                int a;
                Console.ForegroundColor = ConsoleColor.Magenta;
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong data");
                }
                Console.ResetColor();
                Console.WriteLine();

                switch (a)
                {
                    case 0:
                        Generator.GetInfoTypes();
                        break;
                    case 1:
                        Generator.SetTypePassword(a);                      
                        break;
                    case 2:
                        Generator.SetTypePassword(a);
                        break;
                    case 3:
                        Generator.SetTypePassword(a);
                        break;
                    case 4:
                        Generator.SetTypePassword(a);
                        break;
                    case 5:
                        Console.Write("Enter password length: ");
                        int length;
                        char answer;
                        while (!int.TryParse(Console.ReadLine(), out length) || length < 5)
                        {
                            Console.WriteLine("Length must be more than 5 characters and no text");
                        }
                        Generator.GeneratePasword(length);

                        //Console.WriteLine("\nSave the password?" +
                        //    "\nY - yes N - no");

                        //while (!char.TryParse(Console.ReadLine(), out answer) || answer != 'Y' || answer == 'N')
                        //{
                        //    Console.WriteLine("Only Y or N");
                        //}
                        ////answer = Convert.ToChar(Console.ReadLine());
                        //if (answer == 'Y')
                        //{
                        //    Generator.SavePassword();
                        //}
                        Generator.ClearPassw();
                        Console.WriteLine();
                        break;
                    case 6:
                        Generator.Reset();
                        break;
                    case 7:
                        exit = true;
                        break;


                    default:
                        Console.WriteLine("Wrong data");
                        break;
                }

            }
        }

    }   
}
