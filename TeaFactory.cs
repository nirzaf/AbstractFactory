namespace AbstractFactory;

internal class TeaFactory : IHotDrinkFactory
{
    public IHotDrink Prepare(int amount)
    {
        Console.WriteLine($"Put int a tea bag in boil water, pour {amount} ml, and add lemon, enjoy!" );
        return new Tea();
    }
}