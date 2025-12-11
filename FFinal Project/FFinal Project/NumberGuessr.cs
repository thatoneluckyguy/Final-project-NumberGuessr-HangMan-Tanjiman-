using System;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text.Json;
using System.IO;

namespace Final_Project
{
    public class NumberGuessr
    {
        static int s_guessCount = 0;


        static string baseDirectory = AppContext.BaseDirectory;

        private const string FileName = "Record.txt";


        static readonly string s_recordPath = Path.Combine(baseDirectory, FileName);

        public class Record()
        {
            public int Guesses { get; set; }
            public string NickName { get; set; }
            public DateTime CurrentTime { get; set; }
        }

        public static void Start()
        {
            ///<summary>
            ///მომხმარებლის Input. ამოწმებს თუ მომხმარებელმა სწორის ტიპის არჩევანი შეიყვანა (int)
            ///</summary>
            Console.WriteLine("Welcome to NumberGuessr!");
            Console.WriteLine("Lets start, shall we?");
            Console.WriteLine("1 - Yup! \n 2 - Not today!");
            if (!int.TryParse(Console.ReadLine(), out int Choise))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                return;
            }

            switch (Choise)
            {
                ///<summary>
                ///ქმნის შემთხვევით რიცხვის 1-დან 10-მდე და ამოწმებს თუ მომხმარებელი სწორად გამოიცნო, ასევეა დაწერილი exception handling
                ///</summary>
                case 1:
                    while (true)
                    {
                        Random rand = new();

                        if (!int.TryParse(Console.ReadLine(), out int Input))
                        {
                            Console.WriteLine("Invalid input! Please enter a number.");
                            continue;
                        }

                        var RandomNum = rand.Next(11);



                        try
                        {
                            if (Input == RandomNum)
                            {
                                Console.WriteLine("Correct! Good Try! Wanna try again? 1-Sure! 2-Next time! 3- Write record");
                                Console.WriteLine($"Number of guesses: {s_guessCount}");
                                Thread.Sleep(1000);
                                int InputYN = int.Parse(Console.ReadLine());
                                switch (InputYN)
                                {
                                    case 1:
                                        continue;
                                    case 2:
                                        Console.Clear();
                                        Main_Menu.Menu();

                                        return;
                                    case 3:
                                        RecordSer();
                                        break;
                                    default:
                                        throw new Exception("Wrong Type!");
                                        return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong! Try again!");
                                s_guessCount++;
                                Console.WriteLine(s_guessCount);
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                    break;
                case 2:
                    Console.Clear();
                    Main_Menu.Menu();
                    break;
            }
        }

        public static void RecordSer()
        {
            Console.WriteLine("Please write your name");
            string? NickName = Console.ReadLine();
            DateTime currenttime = DateTime.Now;

            Console.WriteLine($"Name: {NickName}, Date of game: {currenttime}, Number of guesses: {s_guessCount}");
            Record rec = new()
            {
                Guesses = s_guessCount,
                NickName = NickName,
                CurrentTime = currenttime
            };

            string jsonString = JsonSerializer.Serialize(rec);


            using (StreamWriter writer = new StreamWriter(s_recordPath))
            {
                writer.WriteLine(jsonString);
            }

        }
    }
}
