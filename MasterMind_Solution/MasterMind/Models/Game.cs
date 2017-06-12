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
            Console.Write("Wie viele Zahlen wollen Sie benutzen ( 4- 10 ) ? ");
            numberCountInput = GetRandomNumberCount();
            randomNumber =  GenerateRandomNumber(numberCountInput);            
            bool won = false;
            while (won == false) {
                userGuess = GetUserGuess(numberCountInput);
            }                      
            Console.WriteLine(randomNumber);
            Console.Read();
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

        private static int numberCountInput;       
        private int[] randomNumber;        
        private int randomNumberCount;
        private int[] userGuess;
        

        public int GetRandomNumberCount()
        {
            numberCountInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sie haben " + numberCountInput + " Zahlen ausgewählt.");
            randomNumberCount = numberCountInput;
            return randomNumberCount;
        }

        public int[] GenerateRandomNumber(int RandomNumberCount)
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
