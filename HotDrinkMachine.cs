namespace AbstractFactory;

public class HotDrinkMachine
{
    private List<Tuple<string, IHotDrinkFactory>> _factories = new();
    public HotDrinkMachine()
    {
        foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
        {
            if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
            {
                _factories.Add(Tuple.Create(t.Name.Replace("Factory", String.Empty), 
                  (IHotDrinkFactory) Activator.CreateInstance(t)));
            }
        } 
    }

    public IHotDrink MakeDrink()
    {
        Console.WriteLine("Available Drinks : ");
        foreach (var tuple in _factories)
        {
            Console.WriteLine($"{tuple.Item1}, {tuple.Item2}");
        }

        while (true)
        {

        }
    }


    //This will break the Open Close Principal

    //public enum AvailableDrink
    //{
    //    Coffee,
    //    Tea
    //}

    //private readonly Dictionary<AvailableDrink, IHotDrinkFactory> factories = new();

    //public HotDrinkMachine()
    //{
    //    foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
    //    {
    //        try
    //        {
    //            var factory = (IHotDrinkFactory) Activator.CreateInstance(
    //                Type.GetType("AbstracyFactory."+ Enum.GetName(typeof(AvailableDrink), drink)+ " Factory")
    //            );
    //            factories.Add(drink, factory);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex);
    //        }
    //    }
    //}

    //public IHotDrink MakeADrink(AvailableDrink drink, int amount)
    //{
    //    return factories[drink].Prepare(amount);
    //}




}