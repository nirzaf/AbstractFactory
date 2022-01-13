


public interface IHotDrink
{
    void Consume();
}

public interface IHotDrinkFactory
{
    IHotDrink Prepare(int amount);
}

internal class TeaFactory : IHotDrinkFactory
{
    public IHotDrink Prepare(int amount)
    {
        Console.WriteLine($"Put int a tea bag boil water, pour {amount} ml, and add lemon, enjoy!" );
        return new Tea();
    }
}

internal class CoffeeFactory : IHotDrinkFactory
{
    public IHotDrink Prepare(int amount)
    {
        Console.WriteLine($"Grind  some beans and boil water, pour {amount}, add sugar & enjoy");
        return new Coffee();
    }
}

public class HotDrinkMachine
{
    public enum AvailableDrink
    {
        Coffee,
        Tea
    }

    private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

    public HotDrinkMachine()
    {
        foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        {
            var factory = (IHotDrinkFactory) Activator.CreateInstance(
                Type.GetType("AbstracyFactory."+ Enum.GetName(typeof(AvailableDrink), drink)+ "factory")
                );

            factories.Add(drink, factory);
        }
    }
}


internal class Tea : IHotDrink
{
    public void Consume()
    {
        Console.WriteLine("This tea is nice but I'd prefer it with milk");
    }
}

internal class Coffee : IHotDrink
{
    public void Consume()
    {
        Console.WriteLine("This Coffee is sensational");
    }
}




