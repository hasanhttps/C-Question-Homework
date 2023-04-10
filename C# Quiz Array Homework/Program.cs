using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Quiz {
    internal class Program {
        static void Main() {

            // Fixed-Size Array
            // Questions

            string[] questions = new string[10] {
                "What country has the highest life expectancy?", // Hong Kong
                "Where would you be if you were standing on the Spanish Steps?", // Rome
                "Which language has the more native speakers?", // Spanish
                "What is the most common surname in the United States?", // Smith
                "What year was the United Nations established?", // 1945
                "What artist has the most streams on Spotify?", // Drake
                "How many minutes are in a full week?", // 10.080
                "What car manufacturer had the highest revenue in 2020?", // Volkswagen
                "How many elements are in the periodic table?", // 118
                "Aureolin is a shade of what color?" // Yellow
            };

            // Fixed-Size MultiDimesional Array (Trangle Array)
            // Answers

            string[,] answers = new string[10, 3] {
                { "Sweden", "Germany", "Hong Kong" }, 
                { "Paris", "Rome", "Britian" }, 
                { "Spanish", "English", "Other"}, 
                { "Johnson", "White", "Smith" }, 
                { "1940", "1935", "1945"}, 
                { "Billie Elish", "Drake", "Justin Bieber"}, 
                { "36.000", "12.080", "10.080"},
                { "Mercedes", "Bmw", "Volkswagen"},
                { "142", "118", "122"},
                { "Yellow", "White", "Purple"}
            };

            // .NET Array
            // Correct Answers

            Array correctAnswers = Array.CreateInstance(typeof(string), questions.Length);

            correctAnswers.SetValue("Hong Kong", 0);
            correctAnswers.SetValue("Rome", 1);
            correctAnswers.SetValue("Spanish", 2);
            correctAnswers.SetValue("Smith", 3);
            correctAnswers.SetValue("1945", 4);
            correctAnswers.SetValue("Drake", 5);
            correctAnswers.SetValue("10.080", 6);
            correctAnswers.SetValue("Volkswagen", 7);
            correctAnswers.SetValue("118", 8);
            correctAnswers.SetValue("Yellow", 9);

            // Array is Abstract Base Class That's why we can't create an instance of the Array class.
            // Array class provides the CreateInstance method to construct an array.

            for (int i = 0; i < questions.Length; i++) {
                for (int j = 0; j < 3; j++) {
                    Random random = new Random();
                    int randomIndex = random.Next(0, j + 1);
                    string temp = answers[i, j];
                    answers[i, j] = answers[i, randomIndex];
                    answers[i, randomIndex] = temp;
                }
            }

            int index = 0, True = 0, False = 0;
            bool isTrue = false;
            while (index < questions.Length - 1) {
                Console.Clear();
                Console.WriteLine($"{index + 1}. {questions[index]} \n");
                Console.WriteLine($"a) {answers[index, 0]}");
                Console.WriteLine($"b) {answers[index, 1]}");
                Console.WriteLine($"c) {answers[index, 2]}\n");

                Console.Write("Please enter the correct variant : ");
                dynamic choose = Console.ReadKey();

                switch (choose.Key) {
                    case ConsoleKey.A:
                        if (answers[index, 0] == correctAnswers.GetValue(index)) isTrue = true;
                        else isTrue = false;
                        break;
                    case ConsoleKey.B:
                        if (answers[index, 1] == correctAnswers.GetValue(index)) isTrue = true;
                        else isTrue = false;
                        break; 
                    case ConsoleKey.C:
                        if (answers[index, 2] == correctAnswers.GetValue(index)) isTrue = true;
                        else isTrue = false;
                        break;
                    default:
                        isTrue = false;
                        index--;
                        break;
                }

                if (isTrue) {
                    True++;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou answered correct !");
                }
                else {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou answered wrong !");
                }
                Console.WriteLine("Next Question in 5 second ...");
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(5000);
                index++;
            }
        }
    }
}