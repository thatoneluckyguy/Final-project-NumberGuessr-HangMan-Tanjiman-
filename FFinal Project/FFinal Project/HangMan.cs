using Final_Project;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace FFinal_Project
{
    internal class HangMan
    {
        public static void Start()
        {
            Console.Clear();
            int maxWrongGuesses = 5;
            int wrongGuesses = 0;
            Random randint = new();

            string path = "C:\\Users\\lukas_70j9se5\\source\\repos\\Final Project\\Final Project\\TanjiMan Dictionary\\English.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Dictionary file not found: " + path);
                Thread.Sleep(1500);
                Main_Menu.Menu();
                return;
            }

            string[] lines = File.ReadAllLines(path)
                                 .Where(l => !string.IsNullOrWhiteSpace(l))
                                 .Select(l => l.Trim())
                                 .ToArray();

            if (lines.Length == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                Thread.Sleep(1500);
                Main_Menu.Menu();
                return;
            }

            int randIndex = randint.Next(0, lines.Length);
            string guessWord = lines[randIndex].ToLowerInvariant();
            char[] hidden = Enumerable.Repeat('_', guessWord.Length).ToArray();

            HashSet<char> correctGuesses = new();
            HashSet<char> wrongGuessedLetters = new();
            HashSet<string> triedWords = new();

            Console.WriteLine("Hangman started! Guess letters or try the whole word.");
            Console.WriteLine($"Word: {new string(hidden)}");

            while (true)
            {
                Console.Write("\nEnter a letter or the full word: ");
                string userInput = Console.ReadLine()?.Trim().ToLowerInvariant();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter something.");
                    continue;
                }

                // Whole-word guess
                if (userInput.Length > 1)
                {
                    if (triedWords.Contains(userInput))
                    {
                        Console.WriteLine("You already tried that word.");
                        continue;
                    }

                    triedWords.Add(userInput);

                    if (userInput == guessWord)
                    {
                        Console.WriteLine("Good Job! You guessed the word!");
                        Console.WriteLine($"Word Was: {guessWord}");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Main_Menu.Menu();
                        return;
                    }
                    else
                    {
                        wrongGuesses++;
                        Console.WriteLine($"Wrong word. Wrong guesses: {wrongGuesses}/{maxWrongGuesses}");
                        if (wrongGuesses >= maxWrongGuesses)
                        {
                            Console.Clear();
                            Console.WriteLine("You Lost!");
                            Console.WriteLine($"Word Was: {guessWord}");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Main_Menu.Menu();
                            return;
                        }
                        continue;
                    }
                }

                
                char c = userInput[0];
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Enter a letter (a-z).");
                    continue;
                }

                if (correctGuesses.Contains(c) || wrongGuessedLetters.Contains(c))
                {
                    Console.WriteLine($"You already guessed '{c}'.");
                    continue;
                }

                if (guessWord.Contains(c))
                {
                    correctGuesses.Add(c);

                    for (int i = 0; i < guessWord.Length; i++)
                    {
                        if (guessWord[i] == c)
                            hidden[i] = c;
                    }

                    Console.WriteLine("Good guess!");
                    Console.WriteLine($"Word: {new string(hidden)}");


                    if (!new string(hidden).Contains('_'))
                    {
                        Console.WriteLine("Congratulations — you solved it!");
                        Console.WriteLine($"Word Was: {guessWord}");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Main_Menu.Menu();
                        return;
                    }
                }
                else
                {
                    wrongGuessedLetters.Add(c);
                    wrongGuesses++;
                    Console.WriteLine($"Nope. '{c}' is not in the word. Wrong guesses: {wrongGuesses}/{maxWrongGuesses}");
                    Console.WriteLine($"Word: {new string(hidden)}");

                    if (wrongGuesses >= maxWrongGuesses)
                    {
                        Console.Clear();
                        Console.WriteLine("You Lost!");
                        Console.WriteLine($"Word Was: {guessWord}");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Main_Menu.Menu();
                        return;
                    }
                }
            }
        }


        public static bool HasSameCharacters(string s1, string s2)
        {
            if (s1 == null || s2 == null) return false;
            return s1.Distinct().OrderBy(c => c).SequenceEqual(s2.Distinct().OrderBy(c => c));
        }
    }
}
