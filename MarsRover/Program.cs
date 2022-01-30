
using MarsRover.Models;
using MarsRover.Models.Directions.Abstract;
using MarsRover.Models.Directions.Concrete;

Console.WriteLine("Keşif başlıyor..\n");

await Task.Delay(1500);

Console.WriteLine("Alanın boyutlarını giriniz..\n");
string size = Console.ReadLine() ?? String.Empty;

var sizeArray = size.Trim().Split(' ');
int xSize = Convert.ToInt32(sizeArray[0]);
int ySize = Convert.ToInt32(sizeArray[1]);

Console.WriteLine("Robotun  konumunu giriniz..\n");
var directionInput = Console.ReadLine() ?? String.Empty;

var directionArray = directionInput.Trim().Split(' ');
int x = Convert.ToInt32(directionArray[0]);
int y = Convert.ToInt32(directionArray[1]);
string direction = directionArray[2];

var coordinate = new Coordinate
{
    X = x,
    Y = y,
    SizeX = xSize,
    SizeY = ySize
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

Console.WriteLine("Gitmeye hazırız..\n");

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

    Console.WriteLine($"x : {rover?.state._coordinates.X} Y : {rover?.state._coordinates.Y} Direction : {rover?.state.GetDirection()}");
}

Console.WriteLine($"x : {rover?.state._coordinates.X} Y : {rover?.state._coordinates.Y} Direction : {rover?.state.GetDirection()}");

