using AbstractFactory;

internal class Coffee : IHotDrink
{
    public void Consume()
    {
        Console.WriteLine("This Coffee is sensational");
    }
}