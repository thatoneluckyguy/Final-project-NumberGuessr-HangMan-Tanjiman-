using System;
using System.IO;
using System.Text;

namespace Final_Project
{
    public class TanjiMan
    {
        /// <summary>
        /// კითხულობს ინგლისურ, ქართულ და რუსულ ლექსიკონებს,
        /// მომხმარებელს აძლევს თარგმნის მიმართულების არჩევის საშუალებას
        /// და თარგმნის სიტყვებს მანამ, სანამ 'exit'-ს არ შეიყვანს.
        /// </summary>
        public static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string pathEn = "English.txt";
            string pathGeo = "Georgian.txt";
            string pathRu = "Russian.txt";

            /// <summary>
            /// ინგლისური სიტყვების სია. ინდექსები ემთხვევა ქართულ და რუსულ სიებს.
            /// </summary>
            string[] linesEn = File.ReadAllLines(pathEn);

            /// <summary>
            /// ქართული სიტყვების სია. თითოეული ინდექსი შეესაბამება იმავე ინგლისურ/რუსულ სიტყვას.
            /// </summary>
            string[] linesGeo = File.ReadAllLines(pathGeo);

            /// <summary>
            /// რუსული სიტყვების სია. ინდექსები სინქრონშია ინგლისურ და ქართულ სიისთან.
            /// </summary>
            string[] linesRu = File.ReadAllLines(pathRu);

            Console.WriteLine("აირჩიე თარგმნის ტიპი:");
            Console.WriteLine("1 - en/geo");
            Console.WriteLine("2 - geo/en");
            Console.WriteLine("3 - en/ru");
            Console.WriteLine("4 - ru/en");
            Console.WriteLine("5 - geo/ru");
            Console.WriteLine("6 - ru/geo");

            /// <summary>
            /// ამოწმებს მომხმარებლის მიერ შეყვანილ თარგმნის ტიპს და იღებს მნიშვნელობას 1–6.
            /// </summary>
            if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > 6)
            {
                Console.WriteLine("არასწორი არჩევანი! აირჩიე 1-დან 6-მდე.");
                return;
            }

            Console.WriteLine("შეიყვანე სიტყვა (გასასვლელად დაწერე 'exit'):");

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.Clear();
                    Main_Menu.Menu();
                }

                int index;
                string translation = null;

                /// <summary>
                /// ეძებს სიტყვის ინდექსს შესაბამის სიაში და აბრუნებს თარგმანს იმავე ინდექსის მიხედვით.
                /// </summary>
                switch (input)
                {
                    case 1: // en → geo
                        index = Array.IndexOf(linesEn, userInput);
                        if (index >= 0) translation = linesGeo[index];
                        break;

                    case 2: // geo → en
                        index = Array.IndexOf(linesGeo, userInput);
                        if (index >= 0) translation = linesEn[index];
                        break;

                    case 3: // en → ru
                        index = Array.IndexOf(linesEn, userInput);
                        if (index >= 0) translation = linesRu[index];
                        break;

                    case 4: // ru → en
                        index = Array.IndexOf(linesRu, userInput);
                        if (index >= 0) translation = linesEn[index];
                        break;

                    case 5: // geo → ru
                        index = Array.IndexOf(linesGeo, userInput);
                        if (index >= 0) translation = linesRu[index];
                        break;

                    case 6: // ru → geo
                        index = Array.IndexOf(linesRu, userInput);
                        if (index >= 0) translation = linesGeo[index];
                        break;
                }

                /// <summary>
                /// ბეჭდავს თარგმანს ან „სიტყვა ვერ მოიძებნა“-ს შეტყობინებას.
                /// </summary>
                if (translation != null)
                {
                    Console.WriteLine($"თარგმანი: {translation}");
                }
                else
                {
                    Console.WriteLine("სიტყვა ვერ მოიძებნა!");
                }
            }
        }
    }
}
