//Josefin Mikaelsson .Net23﻿
using System.Security.Cryptography.X509Certificates;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till spelt!" +
                "\n---*---*---*---*---*---" +
                "\nDu ska lista ut det på det hemliga numret");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Vilken svårighetsgrad vill du ha?" +
                    "\n [1] Lätt   || Tal mellan 1 och 10" +
                    "\n [2] Mellan || Tal mellan 1 och 50" +
                    "\n [3] Svår   || Tal mellan 1 och 100");
                try
                {
                    int userLevelInput = int.Parse(Console.ReadLine());

                    Console.WriteLine("Du får 5 försök på dig att gissa rätt" +
                        "\nLycka till!" +
                        "\n---*---*---*---*---*---" +
                        "\nFörsta gissningen: ");

                    //Run method depending on users choise of level. 
                    Program game = new Program();
                    if (userLevelInput == 1)
                    {
                        game.UserLevel1(userLevelInput);

                    }
                    else if (userLevelInput == 2)
                    {
                        game.UserLevel2(userLevelInput);
                    }
                    else if (userLevelInput == 3)
                    {
                        game.UserLevel3(userLevelInput);
                    }
                    //if the user anser 4, 5, 6... ect
                    else
                    {
                        Console.WriteLine("Väl mellan [1]Lätt [2]Mellan [3]Svår..");
                    }
                    //Ask user if they what to play again 
                    string inputPlayAgain = PlayAgain();
                    if (inputPlayAgain == "J")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        break;
                    }
                }
                //if the user ues letters insted of numbers
                catch (FormatException)
                {
                    Console.WriteLine("Fel format på svaret. Svara [1] eller [2] eller [3]");
                }
            }
            //Close the program if the user don´t want to play any more
            while (true);
            {
                Console.Clear();
                Console.WriteLine("Du valde att avsluta spelet.." +
                    "Tryck Enter för att avsluta!");
                Console.ReadKey();
            }


        }

        //Method for asking the user if they what to play again
        public static string PlayAgain()
        {
            while (true)
            {
                Console.WriteLine("Vill du spela igen?");
                Console.WriteLine("[J]a");
                Console.WriteLine("[N]ej");

                string inputPlayAgain = Console.ReadLine();
                inputPlayAgain = inputPlayAgain.ToUpper();
                if (inputPlayAgain == "J")
                {
                    return "J";
                }
                else if (inputPlayAgain == "N")
                {
                    return "N";
                }
                else
                {
                    Console.WriteLine("Du måste svara [J]a eller [N]ej");
                }

            }
        }


        //Method for Level 1
        public void UserLevel1(int userLevelInput)
        {

            Random randomerare = new Random();
            int randomNumber = randomerare.Next(1, 11);
            int attempts = 5;

            while (attempts > 0)
            {
                try
                {
                    int userInput = int.Parse(Console.ReadLine());

                    //If the users guess to high
                    if (randomNumber < userInput)
                    {
                        if (randomNumber + 1 == userInput)
                        {
                            Console.WriteLine("Det bränns! Ett för högt");
                        }
                        else
                        {
                            Console.WriteLine("För högt!");
                        }
                    }
                    //the users guess to low
                    else if (randomNumber > userInput)
                    {
                        if (randomNumber - 1 == userInput)
                        {
                            Console.WriteLine("Nu var det nära, bara 1 ifrån!");
                        }
                        else
                            Console.WriteLine("Nu va du för låg!");
                    }
                    //The user guess correctly
                    else
                    {
                        Console.WriteLine("WOHO! du gissade rätt");
                        Console.WriteLine("---*---*---*---*---*---");
                        break;
                    }
                    //run when the user gguess wrong
                    attempts--;
                    while (attempts > 0)
                    {
                        Console.WriteLine("---*---*---*---*---*---");
                        Console.WriteLine($"Du har {attempts} försök kvar!");
                        Console.WriteLine("Nästa gissning: ");
                        break;
                    }
                    //when thers no more attemts left
                    while (attempts == 0)
                    {
                        Console.WriteLine("---*---*---*---*---*---" +
                            "\nSlut på försök! Bättre lycka nästa gång" +
                            "\n Det rätta numret var: " + randomNumber);
                        break;
                    }
                }
                //if the user uses letters insted of numbers
                catch (FormatException)
                {
                    Console.WriteLine("Endast heltal, tack. Försök igen...");
                }
            }
        }


        //Method for Level 2
        public void UserLevel2(int userLevelInput)
        {

            Random randomerare = new Random();
            int randomNumber = randomerare.Next(1, 51);
            int attempts = 5;

            while (attempts > 0)
            {
                try
                {
                    int userInput = int.Parse(Console.ReadLine());

                    //If the users guess to high
                    if (randomNumber < userInput)
                    {
                        if (randomNumber + 5 > userInput)
                        {
                            Console.WriteLine("Det bränns! Men lite högt");
                        }
                        else
                            Console.WriteLine("nu tog du i ordentligt.. försök igen med ett lägre nummer!");
                    }
                    //the users guess to low
                    else if (randomNumber > userInput)
                    {
                        if (randomNumber - 5 < userInput)
                        {
                            Console.WriteLine("Nu var det nära, testa ett högre nummer.");
                        }
                        else
                            Console.WriteLine("KALTT!! alldeles för lågt.. gissa en gång till");
                    }
                    else if (userInput < 1 || userInput > 50)
                    {
                        Console.WriteLine("Dn gissning måste vara mellan 1 och 50");
                    }
                    //The user guess correctly
                    else
                    {
                        Console.WriteLine("WOHO! du gissade rätt");
                        Console.WriteLine("---*---*---*---*---*---");
                        break;
                    }
                    //Run when the user guess wrong
                    attempts--;
                    while (attempts > 0)
                    {
                        Console.WriteLine("---*---*---*---*---*---");
                        Console.WriteLine($"Du har {attempts} försök kvar!");
                        Console.WriteLine("Nästa gissning: ");
                        break;
                    }
                    //No more attempts left
                    while (attempts == 0)
                    {
                        Console.WriteLine("---*---*---*---*---*---" +
                            "\nSÅH NEJ!! Slut på försök! Bättre lycka nästa gång" +
                            "\n Det rätta numret var: " + randomNumber);
                        break;
                    }
                }
                //if the user uses letters insted of numbers
                catch (FormatException)
                {
                    Console.WriteLine("Endast heltal, tack. Försök igen...");
                }
            }
        }


        //Method for Level 3
        public void UserLevel3(int userLevelInput)
        {

            Random randomerare = new Random();
            int randomNumber = randomerare.Next(1, 101);
            int attempts = 5;

            while (attempts > 0)
            {
                try
                {
                    int userInput = int.Parse(Console.ReadLine());

                    //If the users guess to high
                    if (randomNumber < userInput)
                    {
                        if (randomNumber + 10 > userInput)
                        {
                            if (randomNumber + 3 > userInput)
                            {
                                Console.WriteLine("OJ OJ OJ!! Nu är du väldigt nära, men lite högt!");
                            }
                            else
                            {
                                Console.WriteLine("Nu bränns det! Men lite högt gissat.");
                            }
                        }
                        else
                            Console.WriteLine("nu tog du i ordentligt.. försök igen med ett lägre nummer!");
                    }
                    //the users guess to low
                    else if (randomNumber > userInput)
                    {
                        if (randomNumber - 10 < userInput)
                        {
                            if (randomNumber - 2 < userInput)
                            {
                                Console.WriteLine("Nästan rätt! Testa ett lite högre tal bara så ska du nog gissa rätt!");
                            }
                            else
                            {
                                Console.WriteLine("Nu var det nära, testa ett högre nummer.");
                            }
                        }
                        else
                            Console.WriteLine("KALTT!! alldeles för lågt....");
                    }
                    //The user guess correctly
                    else
                    {
                        Console.WriteLine("WOHO! du gissade rätt");
                        Console.WriteLine("---*---*---*---*---*---");
                        break;
                    }
                    //Run when the guess is wrong
                    attempts--;
                    while (attempts > 0)
                    {
                        Console.WriteLine("---*---*---*---*---*---");
                        Console.WriteLine($"Du har {attempts} försök kvar!");
                        Console.WriteLine("Nästa gissning: ");
                        break;
                    }
                    //when its no attempt left
                    while (attempts == 0)
                    {
                        Console.WriteLine("---*---*---*---*---*---" +
                            "\nÅH NEJ!! Slut på försök! Bättre lycka nästa gång" +
                            "\n Det rätta numret var: " + randomNumber);
                        break;
                    }
                }
                //if the user uses letters insted of numbers
                catch (FormatException)
                {
                    Console.WriteLine("Endast heltal, tack. Försök igen...");
                }
            }

        }

    }
}