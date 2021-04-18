using System;
using System.Collections.Generic;

namespace Lab6._0_GC
{
    class Program
    {
        static void Main(string[] args)
        {
            int faces = PosIntPrompt("How many faces are on your pair of dice? Positive integer: ");
            while (BoolPrompt($"Would you like to roll your {faces}-sided dice? (y/n)"))
            {
                RollDice(faces);
            }
        }

        // prompts, then loops until int larger than zero can be parsed from input.
        public static int PosIntPrompt(string message)
        {
            int returnVal = 0;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out returnVal) || returnVal < 1)
            {
                Console.Write("That was not a valid input. Try again: ");
            }
            return returnVal;
        }

        // loops until valid yes/no input recieved
        public static bool BoolPrompt(string message)
        {
            while (true)
            {
                bool returnVal = false;
                Console.Write(message);
                string input = Console.ReadLine().ToLower();
                if (input == "yes" || input == "y")
                {
                    return true;
                }
                if (input == "no" || input == "n")
                {
                    return false;
                }
                Console.Write("That was not a valid input. Try again. ");
            }
        }

        public static void RollDice(int faces)
        {
            //will instantiate a new DiceRollerApp object, and control the dice game
        }
    }

    // stores a list of dice that can be rolled, totaled, printed
    public class DiceRollerApp
    {
        List<Die> dice;

        // constructor defaults to 1 6-sided die
        public DiceRollerApp()
        {

        }

        // n 6-sided dice
        public DiceRollerApp(int dice)
        {

        }

        // n m-sided dice
        public DiceRollerApp(int dice, int faces)
        {

        }
    }

    // creates a Die object type, that the DiceRollerApp can roll
    public class Die
    {
        // defaults to 6-sided. Each die gets it's own randomizer object
        public Die()
        {
            Faces = 6;
            System.Random random = new Random();
        }

        public Die(int faces)
        {
            Faces = faces;
            System.Random random = new Random();
        }

        public int Faces { get; set; }
        public Random random { get; }

        // the Roll method can be called to grab the next random number for a die
        public int Roll()
        {
            return random.Next(Faces) + 1;
        }
    }
    // future extention description:
    // "Use the DiceRollerApp class to display special messages for craps, snake eyes, and box cars.
}
