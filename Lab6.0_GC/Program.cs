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
                Console.WriteLine("");
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

        //initializes and plays a dice roller app
        public static void RollDice(int faces)
        {
            DiceRollerApp diceRoller = new DiceRollerApp(2, faces);
            diceRoller.Roll();
            diceRoller.Bonus();
        }
    }

    // stores a list of dice that can be rolled, totaled, printed
    public class DiceRollerApp
    {
        List<Die> dice;

        // n m-sided dice
        public DiceRollerApp(int diceNum, int faces)
        {
            dice = new List<Die>();
            for(int i=0; i<diceNum; i++)
            {
                dice.Add(new Die(faces));
            }

        }

        // constructor defaults to 1 6-sided die
        public DiceRollerApp() : this(1, 6) { }

        // n 6-sided dice
        public DiceRollerApp(int diceNum) : this(diceNum, 6) { }

        // prints and intro, rolls the dice, and leaves a space.
        public void Roll()
        {
            int total = 0;
            Console.WriteLine($"Your {((dice.Count==1)?"die":"dice")} rolled the following:");
            for(int i=0; i< dice.Count; i++)
            {
                total+= dice[i].Roll();
            }
            Console.WriteLine("");
        }

        public void Read()
        {

        }

        //allows special messages to be sent for the three special cases of craps, though it's unclear
        //what should count as "boxcars" for dice with more/less than 6 faces.
        public void Bonus()
        {
            switch (Total())
            {
                case 2:
                    Console.WriteLine("Craps! Snake Eyes!");
                    break;
                case 3:
                    Console.WriteLine("Craps!");
                    break;
            }
            if (Total() == (dice.Count * dice[0].Faces))
            {
                Console.WriteLine("Craps! Box cars!");
            }
        }

        public int Total()
        {
            int total = 0;
            for (int i = 0; i < dice.Count; i++)
            {
                total += dice[i].Value;
            }
            return total;
        }
    }

    // creates a Die object type, that the DiceRollerApp can roll
    public class Die
    {

        System.Random random = new Random();

        // defaults to 6-sided. Each die gets it's own randomizer object
        public Die() : this(6) { }

        public Die(int faces)
        {
            Faces = faces;
            Value = 0;      //Value is 0 until die is rolled
        }

        public int Faces { get; set; }
        public int Value { get; set; }

        // the Roll method can be called to grab the next random number for a die
        public int Roll()
        {
            Value = random.Next(1, Faces+1);
            Console.WriteLine(Value);
            return Value;
        }
    }
    // future extention description:
    // "Use the DiceRollerApp class to display special messages for craps, snake eyes, and box cars.
}
