// See https://aka.ms/new-console-template for more information

int min = 1, max , tries = 0;
bool exitGame = false;
Random randomNum = new Random();
Game gameLogic = new Game();

Console.Clear();

Thread escKey = new Thread(gameLogic.escListener);
escKey.Start();

Console.WriteLine("Welcome to the number guessing game!");

Thread.Sleep(2000);
Console.Clear();

Console.Write("Please choose the maximum limit: ");
string maxCheck = Console.ReadLine() ?? "n";
bool approvedMax = int.TryParse(maxCheck, out max);
while(!approvedMax)
{
    Console.WriteLine("Invalid selection. Please select an integer number.");
    Thread.Sleep(2000);
    Console.Clear();
    Console.Write("Please choose the maximum limit: ");
    maxCheck = Console.ReadLine() ?? "n";
    approvedMax = int.TryParse(maxCheck, out max);
}
Console.WriteLine("Your maximum limit is " + max + ".");

Thread.Sleep(1000);
Console.Clear();

Console.WriteLine("Sorting number...");

int number = randomNum.Next(min, max + 1);

Thread.Sleep(2000);
Console.Clear();

gameLogic.guessCheck(min, max, ref tries, ref exitGame, ref number, randomNum);