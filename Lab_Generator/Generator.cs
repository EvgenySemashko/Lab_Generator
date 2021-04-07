using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;


namespace Lab_Generator
{
    class Generator
    {
        static Dictionary<(int, bool), string> Status = new Dictionary<(int, bool), string>();
        static ArrayList Password = new ArrayList();

      
        static Generator()
        {

            Status.Add((1, false), "IsOnlyNumbers");
            Status.Add((2, false), "IsOnlyAlphabetLower");
            Status.Add((3, false), "IsOnlyAlphabetUpper");
            Status.Add((4, false), "IsOnlySymbols");
        }

        // Вывод информации о текущем состоянии генераторов
        public static void GetInfoTypes()
        {
            foreach (var stat in Status)
            {
                if (stat.Key.Item2 == false)
                {
                    Console.Write($"\t{stat.Key.Item1} - {stat.Value}: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{stat.Key.Item2}\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"\t{stat.Key.Item1} - {stat.Value}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{stat.Key.Item2}\n");
                    Console.ResetColor();
                }
            }
        }
        

        // Установка 
        public static void SetTypePassword(int select)
        {

            switch (select)
            {
                case 1:
                    Status.Remove((1, false));
                    Status.Add((1, true), "IsOnlyNumbers");
                    var type = Status.FirstOrDefault(x => x.Value == "IsOnlyNumbers").Key;


                    Console.Write($"Selected: {Status[(1, true)]}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(type.Item2 + "\n\n");
                    Console.ResetColor();
                    break;

                case 2:
                    Status.Remove((2, false));
                    Status.Add((2, true), "IsOnlyAlphabetLower");
                    type = Status.FirstOrDefault(x => x.Value == "IsOnlyAlphabetLower").Key;


                    Console.Write($"Selected: {Status[(2, true)]}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(type.Item2 + "\n\n");
                    Console.ResetColor();
                    break;
                case 3:
                    Status.Remove((3, false));
                    Status.Add((3, true), "IsOnlyAlphabetUpper");
                    type = Status.FirstOrDefault(x => x.Value == "IsOnlyAlphabetUpper").Key;


                    Console.Write($"Selected: {Status[(3, true)]}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(type.Item2 + "\n\n");
                    Console.ResetColor();
                    break;
                case 4:
                    Status.Remove((4, false));
                    Status.Add((4, true), "IsOnlySymbols");
                    type = Status.FirstOrDefault(x => x.Value == "IsOnlySymbols").Key;


                    Console.Write($"Selected: {Status[(4, true)]}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(type.Item2 + "\n\n");
                    Console.ResetColor();
                    break;


                default:
                    Console.WriteLine("Wrong data");
                    break;
            }

        }

        public static void GeneratePasword(int length)
        {

            var rand = new Random();


            var selectedTypes = from types in Status
                                where types.Key.Item2 == true
                                select types.Key.Item1;


            string s = "";
            foreach (int item in selectedTypes)
            {
                switch (item)
                {
                    case 1:
                        for (int i = 0; i < length; i++)
                        {
                            Password.Add(rand.Next(0, 9));
                            s += (int)rand.Next(0, 9);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < length; i++)
                        {
                            Password.Add((char)rand.Next(97, 122));
                        }
                        break;
                    case 3:
                        for (int i = 0; i < length; i++)
                        {
                            Password.Add((char)rand.Next(65, 90));
                        }
                        break;
                    case 4:
                        for (int i = 0; i < length; i++)
                        {
                            Password.Add((char)rand.Next(33, 38));
                        }
                        break;
                }
            }

            // Перемешивание массива
            for (int i = 0; i < Password.Count; i++)
            {
                    int j = rand.Next(i + 1);
                    var temp = Password[j];
                    Password[j] = Password[i];
                    Password[i] = temp;
            }

            
            Console.Write("Generated password: ");
            foreach (var item in Password.ToArray().Take(length))
            {
                Console.Write(item);
            }
            

        }

        public static void ClearPassw()
        {
            Password.Clear();
        }

        public static void Reset()
        {
            Console.WriteLine("Settings has been reset");

            Status.Clear();

            Status.Add((1, false), "IsOnlyNumbers");
            Status.Add((2, false), "IsOnlyAlphabetLower");
            Status.Add((3, false), "IsOnlyAlphabetUpper");
            Status.Add((4, false), "IsOnlySymbols");
        }

        public static void SavePassword()
        {
            string pathFile = @"C:\Users\ASUS\Documents\SavedPasswords";
            string writePath = @"C:\Users\ASUS\Documents\SavedPasswords\password.txt";

            DirectoryInfo directory = new DirectoryInfo(pathFile);

            if (!directory.Exists)
            {
                directory.Create();
            }

            using (StreamWriter writer = new StreamWriter(writePath))
            {

                foreach (var item in Password)
                {
                    writer.WriteAsync(item.ToString());
                }

            }


        }
    }
}
