namespace AbstractFactory;

public interface IHotDrinkFactory
{
    IHotDrink Prepare(int amount);
}