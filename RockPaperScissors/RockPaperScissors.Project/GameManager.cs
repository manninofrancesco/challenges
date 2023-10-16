using System.Text.Json;
public class GameManager
{
    /// <summary>
    /// Ask the user how he/she wants to play the game
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    public int GetGameMode()
    {
        Console.Clear();
        Console.WriteLine("Hi, let's play together!");
        Console.WriteLine("Please, select one option from this menu:");
        Console.WriteLine("0: Human vs Computer");
        Console.WriteLine("1: Computer vs Computer");
        Console.WriteLine("2: Exit");

        string? untypedUserSelection = Console.ReadLine();

        if (untypedUserSelection is not null
            && int.TryParse(untypedUserSelection, out int userSelection))
        {
            //check if the user selection is a valid Game Mode
            if (Enum.GetNames(typeof(GameModesEnum)).Length - 1 >= userSelection)
            {
                return userSelection;
            }
        }

        throw new InvalidDataException();
    }

    /// <summary>
    /// Ask the user which Weapon he/she wants to play with
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    public Weapon GetUserWeapon(List<Weapon> weapons)
    {
        Console.WriteLine("Please, select one option from this menu:");

        foreach (var weapon in weapons)
        {
            Console.WriteLine($"{weapon.Id}: {weapon.Name}");
        }

        string? untypedUserSelection = Console.ReadLine();

        if (untypedUserSelection is not null
            && int.TryParse(untypedUserSelection, out int userSelection)
            && weapons.Any(x => x.Id == userSelection))
        {
            return weapons.First(x => x.Id == userSelection);
        }

        throw new InvalidDataException();
    }

    public Weapon GetRandomWeapon(List<Weapon> weapons)
    {
        var random = new Random();
        return weapons.ElementAt(random.Next(weapons.Count));
    }

    /// <summary>
    /// Return the winner between 2 weapons
    /// </summary>
    /// <param name="firstWeapon"></param>
    /// <param name="secondWeapon"></param>
    /// <returns></returns>
    public Weapon GetWinner(Weapon firstWeapon, Weapon secondWeapon)
    {
        if (firstWeapon.Beats.Any(x => x == secondWeapon.Id))
        {
            return firstWeapon;
        }
        else if (firstWeapon.IsBeaten.Any(x => x == secondWeapon.Id))
        {
            return secondWeapon;
        }
        else
        {
            return firstWeapon;
        }
    }

    /// <summary>
    /// Returns true if user want to play again
    /// Returns false is user does not want to play again
    /// </summary>
    /// <returns></returns>
    public bool DoesUserWantToPlayAgain()
    {
        Console.WriteLine($"\nDo you want to play again?");
        Console.WriteLine($"Press 1 to play again");
        Console.WriteLine($"Press anything else to quit the game");

        string? untypedPlayAgainUserSelection = Console.ReadLine();
        if (untypedPlayAgainUserSelection is not null && int.TryParse(untypedPlayAgainUserSelection, out int playAgainUserSelection))
        {
            return playAgainUserSelection == 1;
        }

        return false;
    }

    public async Task<List<Weapon>> GetWeapons()
    {
        using FileStream stream = File.OpenRead("Weapons.json");
        return await JsonSerializer.DeserializeAsync<List<Weapon>>(stream) ?? Enumerable.Empty<Weapon>().ToList();
    }
}