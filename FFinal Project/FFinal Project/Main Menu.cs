using FFinal_Project;
using System.Diagnostics;
namespace Final_Project
{
    public class Main_Menu
    {
        /// <summary>
        /// This is a Menu class. User can Choose which minigame he wants to play
        /// </summary>
        public static void Menu()
        {

            Console.ForegroundColor = ConsoleColor.Green;

            string Logo = "       /$$$$$$ /$$$$$$$$  /$$$$$$$$ /$$   /$$ /$$   /$$\r\n      |_  $$_/|__  $$__/ | $$_____/| $$  | $$| $$$ | $$\r\n        | $$     | $$    | $$      | $$  | $$| $$$$| $$\r\n        | $$     | $$    | $$$$$   | $$  | $$| $$ $$ $$\r\n        | $$     | $$    | $$__/   | $$  | $$| $$  $$$$\r\n        | $$     | $$    | $$      | $$  | $$| $$\\  $$$\r\n       /$$$$$$   | $$ /$$| $$      |  $$$$$$/| $$ \\  $$\r\n      |______/   |__/|__/|__/       \\______/ |__/  \\__/\r\n                                                       \r\n                                                       \r\n                                                       ";

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Beep();
            //    Console.WriteLine(Logo);
            //    Thread.Sleep(200);
            //    Console.Clear();

            //}
            Console.WriteLine(Logo);

            Console.WriteLine("Welcome to IT.FUN! Please choose a mini game!");
            Console.Write("\n 1 - NumberGuessr, \n 2 - HangMan, \n 3 - Translator (Tanjiman)");
            string UserInput = Console.ReadLine();
            int FinalInput = Convert.ToInt32(UserInput);

            switch (FinalInput)
            {
                case 1:
                    Console.Clear();
                    NumberGuessr.Start();
                    break;
                case 2:
                    HangMan.Start();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    TanjiMan.Start();
                    break;
            }


        }
    }
}
