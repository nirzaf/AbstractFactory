using AbstractFactory;

var machine = new HotDrinkMachine();

var drink = machine.MakeADrink(HotDrinkMachine.AvailableDrink.Coffee, 100);

drink.Consume();