GameManager gameManager = new();
List<Weapon> weapons = await gameManager.GetWeapons();

while (true)
{
    try
    {
        int gameMode = gameManager.GetGameMode();

        Weapon? firstPlayerWeapon = null;
        Weapon? secondPlayerWeapon = null;

        if (gameMode == (int)GameModesEnum.HumanVsComputer)
        {
            firstPlayerWeapon = gameManager.GetUserWeapon(weapons);

            secondPlayerWeapon = gameManager.GetRandomWeapon(weapons);

        }
        else if (gameMode == (int)GameModesEnum.ComputerVsComputer)
        {
            firstPlayerWeapon = gameManager.GetRandomWeapon(weapons);

            secondPlayerWeapon = gameManager.GetRandomWeapon(weapons);
        }
        
        if (firstPlayerWeapon is not null && secondPlayerWeapon is not null)
        {
            Console.WriteLine($"\nPlayer1 selection is: {firstPlayerWeapon.Name}");
            Console.WriteLine($"\nPlayer2 selection is: {secondPlayerWeapon.Name}");

            Weapon winnerWeapon = gameManager.GetWinner(firstPlayerWeapon, secondPlayerWeapon);

            if (winnerWeapon.Id == firstPlayerWeapon.Id && winnerWeapon.Id == secondPlayerWeapon.Id)
            {
                Console.WriteLine($"\nThe result is: Tie");
            }
            else if (winnerWeapon.Id == firstPlayerWeapon.Id)
            {
                Console.WriteLine($"\nThe winner is: Player1");
            }
            else
            {
                Console.WriteLine($"\nThe winner is: Player2");
            }

            bool wantToPlayAgain = gameManager.DoesUserWantToPlayAgain();

            if (!wantToPlayAgain)
            {
                Console.WriteLine($"\nThank you.\n");
                break;
            }
        }
    }
    catch (InvalidDataException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nSorry, your input is not valid, the game will be restarted...\n");
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(2000);
        continue;
    }
    catch (Exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nSorry, there was an unexpected error, the game will be restated...\n");
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(2000);
        continue;
    }
}