public class Weapon
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int[] Beats { get; set; }
    public required int[] IsBeaten { get; set; }
}