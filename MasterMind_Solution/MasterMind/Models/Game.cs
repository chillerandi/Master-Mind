using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MasterMind
{
    public class Game
    {
        public Game()
        {
            Play();
           
        }

        private static void Play()
        {
            int numberCount = GetRandomNumberCount();
            int[] PCArray = GenerateRandomNumber(numberCount);
            bool won = false;
            while (won == false) {
                int[] userGuess = GetUserGuess(numberCount);

                if (CountHits(PCArray, userGuess) == numberCount)
                    won = true;
            }
            Console.WriteLine(PCArray);
            Console.Read();
        }

        private static int CountHits(int[] PCArray, int[] userGuess)
        {
            int hits = 0;
            for(int i = 0; i < PCArray.Length; i++) {
                if (PCArray[i] == userGuess[i])
                    hits++;
            }
            Console.WriteLine("Results: {0} Hit(s), {1} Miss(es)", hits, PCArray.Length - hits);
            return hits;
        }

        private static int[] GetUserGuess(int userSize)
        {
            int number = 0;
            int[] userGuess = new int[userSize];
            for (int i = 0; i < userSize; i++) {
                Console.Write("Digit {0}: ", (i + 1));
                while (!int.TryParse(Console.ReadLine(), out number) /*|| number < 1 || number > 4*/)
                    Console.WriteLine("Invalid number!");
                userGuess[i] = number;
            }
            Console.WriteLine();
            Console.Write("Your guess: ");
            for (int i = 0; i < userSize; i++) {
                Console.Write(userGuess[i] + " ");
            }
            Console.WriteLine();
            return userGuess;
        }                   
       
        public static int GetRandomNumberCount()
        {
            int randomNumberCount;
            Console.Write("Wie viele Zahlen wollen Sie benutzen ( 4- 10 ) ? ");
            int  numberCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sie haben " + numberCount + " Zahlen ausgewählt.");
            randomNumberCount = numberCount;
            return randomNumberCount;
        }

        public static int[] GenerateRandomNumber(int RandomNumberCount)
        {
            int singleNumber;
            int[] randomNumber = new int[RandomNumberCount];
            Random rnd = new Random();
            Console.Write("PC Number : ");
            for (int i = 0; i < RandomNumberCount; i++) {
                singleNumber = rnd.Next(1, 9);
                randomNumber[i] = singleNumber;
                Console.Write(singleNumber);
            }
            Console.WriteLine();
            return randomNumber;
        }
    }
}
