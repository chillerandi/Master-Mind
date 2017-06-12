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
            GetRandomNumberCount();
            GenerateRandomNumber(RandomNumberCount);
            GetUserGuess();
            CompareWithRandom();
            //Console.WriteLine(RandomNumber);
            Console.Read();

        }

        private bool CompareWithRandom()
        {
            if (RandomNumber == UserGuess) {
                Console.WriteLine("Jippie! Du hast gewonnen!!");
                Console.Read();
                return true;
            }
            else {
                Console.WriteLine("Leider falsch. Bitte versuche es nochmal.");

                return false;
            }

        }

        private void GetUserGuess()
        {
            Console.WriteLine("Bitte geben Sie Ihren Tip ab!");
            stringUserGuess = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ihr Tip ist " + StringUserGuess + ".");

        }

        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private int numberCountInput;

        public int NumberCountInput
        {
            get { return numberCountInput; }
            set { numberCountInput = value; }
        }


        private int randomNumber;
        public int RandomNumber
        {
            get { return randomNumber; }
            set { randomNumber = value; }
        }

        private int randomNumberCount;



        public int RandomNumberCount
        {
            get { return randomNumberCount; }
            set { randomNumberCount = value; }
        }

        private int userGuess;
        public int UserGuess
        {
            get { return userGuess; }
            set { userGuess = value; }
        }

        private int countHits;
        public int CountHits
        {
            get { return countHits; }
            set { countHits = value; }
        }

        private int stringUserGuess;
        public int StringUserGuess
        {
            get { return stringUserGuess; }
            set { stringUserGuess = value; }
        }

        public int GetRandomNumberCount()
        {
            Console.Write("Wie viele Zahlen wollen Sie benutzen ( 4- 10 ) ? ");
            NumberCountInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sie haben " + NumberCountInput + " Zahlen ausgewählt.");
            Console.Read();
            //if (int.TryParse(Console.ReadLine(), out NumberCountInput)) {
            //    Console.WriteLine("Sie haben " + NumberCountInput + " Zahlen ausgewählt.");
            //}

            //if(input < 4 || input > 10) {
            //    Console.Write(" Bitte wählen Sie eine Anzahl zwischen 4 und 10! ");
            //}
            //Console.Write("Die gewünschte Anzahl ist " + input);
            RandomNumberCount = NumberCountInput;
            return RandomNumberCount;
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
