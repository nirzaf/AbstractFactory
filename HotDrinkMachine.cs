namespace AbstractFactory;

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
            try
            {
                var factory = (IHotDrinkFactory) Activator.CreateInstance(
                    Type.GetType("AbstracyFactory."+ Enum.GetName(typeof(AvailableDrink), drink)+ " Factory")
                );
                factories.Add(drink, factory);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public IHotDrink MakeADrink(AvailableDrink drink, int amount)
    {
        return factories[drink].Prepare(amount);
    }
}