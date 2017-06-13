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
            Console.WriteLine("************** Let's play Master-Mind **************\n");
            string name = GetPlayerName();

            do {
                Play();

                Console.Write("\nWould you like to play again (Y/N)? ");
            }
            while (Console.ReadLine().ToUpper() == "Y");
        }

        private static string GetPlayerName()
        {
            Console.Write("Bitter gib Deinen Namen ein: ");
            string name = Console.ReadLine();
            Console.WriteLine("Willkommen, {0}. Viel Spaß!!\n", name);
            return name;
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
            if (won)
                Console.WriteLine("You win!");
            else
                Console.WriteLine("Oh nein! Du hast die Zahl nicht erraten.");
            Console.Write("Die richtige Zahl lautet: ");
            for (int j = 0; j < numberCount; j++)
                Console.Write(PCArray[j] + " ");
            Console.WriteLine();
        }

        private static int CountHits(int[] PCArray, int[] userGuess)
        {
            int metaHits = 0;

            for (int i = 0; i < PCArray.Length; i++) {
                if (userGuess.Any(item => item == PCArray[i]) && (PCArray[i] != userGuess[i])) {
                    metaHits++;
                }

            }
            Console.WriteLine("Sie haben " + metaHits + " Fast-Treffer, die richtige Zahl, aber an der falschen Position");

            int hits = 0;
            for (int i = 0; i < PCArray.Length; i++) {
                if (PCArray[i] == userGuess[i])
                    hits++;
            }
            Console.WriteLine("Ergebnis: {0} Treffer, {1} Daneben, {2} Fast-Treffer", hits, PCArray.Length - metaHits - hits, metaHits);
            return hits;
        }

        private static int[] GetUserGuess(int userSize)
        {
            int number = 0;
            int[] userGuess = new int[userSize];
            for (int i = 0; i < userSize; i++) {
                Console.Write("Digit {0}: ", (i + 1));
                while (!int.TryParse(Console.ReadLine(), out number) /*|| number < 1 || number > 4*/)
                    Console.WriteLine("Ungültige Zahl!");
                userGuess[i] = number;
            }
            Console.WriteLine();
            Console.Write("Dein Tip: ");
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
            int numberCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sie haben " + numberCount + " Zahlen ausgewählt.");
            randomNumberCount = numberCount;
            return randomNumberCount;
        }

        public static int[] GenerateRandomNumber(int RandomNumberCount)
        {
            int singleNumber;
            int[] randomNumber = new int[RandomNumberCount];
            Random rnd = new Random();
            Console.Write("Die geheime Zahl ist ausgewählt : ");
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
