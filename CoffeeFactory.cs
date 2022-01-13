using AbstractFactory;

internal class CoffeeFactory : IHotDrinkFactory
{
    public IHotDrink Prepare(int amount)
    {
        Console.WriteLine($"Grind  some beans and boil water, pour {amount}, add sugar & enjoy");
        return new Coffee();
    }
}