
using MarsRover.Models;
using MarsRover.Models.Directions.Abstract;
using MarsRover.Models.Directions.Concrete;

Console.WriteLine("Keşif başlıyor..\n");

await Task.Delay(1500);

Console.WriteLine("Alanın X boyutunu giriniz..\n");
string xSize = Console.ReadLine() ?? "";

Console.WriteLine("Alanın Y boyutunu giriniz..\n");
string ySize = Console.ReadLine() ?? "";

Console.WriteLine("Robotun X konumu..\n");
string x = Console.ReadLine() ?? "";

Console.WriteLine("Robotun Y konumu..\n");
string y = Console.ReadLine() ?? "";

Console.WriteLine("Robotun yönü..\n");
string direction = Console.ReadLine() ?? "";


var coordinate = new Coordinate
{
    X = Convert.ToInt32(x),
    Y = Convert.ToInt32(y),
    SizeX = Convert.ToInt32(xSize),
    SizeY = Convert.ToInt32(ySize)
};

IRoverState state;
Rover rover;

switch (direction.ToUpper())
{
    default:
    case "N":
        state = new NorthDirection(coordinate);
        rover = new Rover(state);
        break;
    case "S":
        state = new SouthDirection(coordinate);
        rover = new Rover(state);
        break;
    case "W":
        state = new WestDirection(coordinate);
        rover = new Rover(state);
        break;
    case "E":
        state = new EastDirection(coordinate);
        rover = new Rover(state);
        break;
}

Console.WriteLine("Komutları göndermeya başla..\n");

string input = "";
while (true)
{
    input = Console.ReadLine() ?? "";

    if (input?.ToString().ToUpper() == "N")
        break;
    else if (input?.ToString().ToUpper() == "L")
    {
        rover?.TurnLeft();
    }
    else if (input?.ToString().ToUpper() == "R")
    {
        rover?.TurnRight();

    }
    else if (input?.ToString().ToUpper() == "M")
    {
        rover?.Forward();
    }

    Console.WriteLine($"x : {rover?.state._coordinates.X} Y : {rover?.state._coordinates.Y}");
}

