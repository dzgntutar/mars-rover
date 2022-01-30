using MarsRover;
using MarsRover.Directions.Abstract;
using MarsRover.Directions.Concrete;

Console.WriteLine("Keşif başlıyor..\n");

await Task.Delay(1500);

// Grid Size 
Console.WriteLine("Alanın boyutlarını giriniz..\n");
string size = Console.ReadLine() ?? String.Empty;

var sizeArray = size.Trim().Split(' ');
int xSize = Convert.ToInt32(sizeArray[0]);
int ySize = Convert.ToInt32(sizeArray[1]);


var roverTaskList = new List<RoverModel>();
int x = 0;
int y = 0;
string direction = "";

for (int i = 0; i < 2; i++)
{
    //Rover Input
    Console.WriteLine($"{i + 1}. Robotun konumunu giriniz..\n");
    var directionInput = Console.ReadLine() ?? String.Empty;

    var directionArray = directionInput.Trim().Split(' ');
    x = Convert.ToInt32(directionArray[0]);
    y = Convert.ToInt32(directionArray[1]);
    direction = directionArray[2];


    Console.WriteLine($"{i + 1}. Robotun görevini giriniz..\n");
    var roverTask = Console.ReadLine() ?? String.Empty;

    roverTaskList.Add(new RoverModel
    {
        X = x,
        Y = y,
        SizeX = xSize,
        SizeY = ySize,
        Direction = direction,
        RoverTask = roverTask
    });
}

IRoverState state;
Rover rover;
Coordinate coordinate;

for (int i = 0; i < roverTaskList.Count; i++)
{
    coordinate = new Coordinate
    {
        X = roverTaskList[i].X,
        Y = roverTaskList[i].Y,
        SizeX = roverTaskList[i].SizeX,
        SizeY = roverTaskList[i].SizeY,
    };

    switch (roverTaskList[i].Direction.ToUpper())
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

    Console.WriteLine($"{i + 1}. robot gitmeye hazır..\n");

    foreach (char c in roverTaskList[i].RoverTask)
    {
        if (c.ToString().ToUpper() == "N")
            break;
        else if (c.ToString().ToUpper() == "L")
        {
            rover?.TurnLeft();
        }
        else if (c.ToString().ToUpper() == "R")
        {
            rover?.TurnRight();
        }
        else if (c.ToString().ToUpper() == "M")
        {
            rover?.Forward();
        }
    }

    Console.WriteLine($"Son Konum {rover?.state._coordinates.X} {rover?.state._coordinates.Y} {rover?.state.GetDirection()}");

}

Console.ReadKey();







