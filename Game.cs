internal class Game
{
    bool stopThread = false;
    internal void    guessCheck(int min, int max, ref int tries, ref bool exitGame, ref int number, Random randomNum)
    {
        while(!exitGame)
        {
            Console.Write("Please insert your guess: ");
            int guess = Convert.ToInt32(Console.ReadLine());
    
            tries++;
            if(guess > max)
                Console.WriteLine("Your selection passes the maximum value you chose (" + max + "). Try again.");
            else if(guess < min)
                Console.WriteLine("Your selection passes the maximum value you chose (" + max + "). Try again.");
            else if(guess < number)
                Console.WriteLine("Your selection IS LOWER than the number generated.");
            else if(guess > number)
                Console.WriteLine("Your selection IS HIGHER than the number generated.");
            else if(guess == number)
            {
                Console.WriteLine("Congratulations, you guessed the right number! It was " + number + "!");
                Console.WriteLine("It took you " + tries + " tries.");
                tries = 0;
                while(true)
                {
                    Console.WriteLine("Do you want to play again? (Y/N)");
                    ConsoleKeyInfo option = Console.ReadKey(true);
                    string retry = option.KeyChar.ToString();
                    if(retry == "n" || retry == "N")
                    {
                        Console.WriteLine("Thank you for playing!");
                        exitGame = true;
                        stopThread = true;
                        break;
                    }
                    else if(retry == "y" || retry == "Y")
                    {
                        number = randomNum.Next(1, max + 1);
                        break;
                    }
                    else
                        Console.WriteLine("Invalid option.");
                }
            }
        }
    }

    internal void   escListener()
    {
        while (!stopThread)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nESC key pressed. Exiting the program...");
                    Environment.Exit(0);
                }
            }
            Thread.Sleep(100);
        }
    }

    internal void   threadStopper()
    {
        stopThread = true;
    }
}