using System.Security.Cryptography;

namespace Final_Project
{
    public class NumberGuessr
    {
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
                                Console.WriteLine("Correct! Good Try! Wanna try again? 1-Sure! 2-Next time!");
                                int InputYN = int.Parse(Console.ReadLine());
                                switch (InputYN)
                                {
                                    case 1:
                                        continue;
                                    case 2:
                                        Console.Clear();
                                        Main_Menu.Menu();
                                        return; 
                                    default:
                                        throw new Exception("Wrong Type!");
                                        return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong! Try again!");
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
    }
}
