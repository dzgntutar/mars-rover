using MarsRover;
using MarsRover.Directions.Abstract;
using MarsRover.Directions.Concrete;

Console.WriteLine("Discovery begins..\n");

await Task.Delay(1500);

// Grid Size 
Console.WriteLine("Enter plateau size..\n");
string size = Console.ReadLine() ?? String.Empty;

var sizeArray = size.Trim().Split(' ');
int xSize, ySize;

//validation
if (sizeArray.Length != 2 || !(int.TryParse(sizeArray[0], out xSize) && int.TryParse(sizeArray[1], out ySize)))
{
    Console.WriteLine("Wrong format");
    Console.WriteLine("Correct format is like 5 5");
    Console.ReadLine();
    return;
}

var roverTaskList = new List<RoverModel>();
int x, y = 0;
string direction = "";

for (int i = 0; i < 2; i++)
{
    //Rover Input
    Console.WriteLine("*****************************************************************");
    Console.WriteLine($"Enter {i + 1}. rover's coordinate..\n");
    var directionInput = Console.ReadLine() ?? String.Empty;

    var directionArray = directionInput.Trim().Split(' ');

    //validation
    if (directionArray.Length != 3 || !(int.TryParse(directionArray[0], out x) && int.TryParse(directionArray[0], out y)))
    {
        Console.WriteLine("Wrong format");
        Console.WriteLine("Correct format is like 1 2 N");
        Console.ReadLine();
        return;
    }

    x = Convert.ToInt32(directionArray[0]);
    y = Convert.ToInt32(directionArray[1]);
    direction = directionArray[2];


    Console.WriteLine($"Enter {i + 1}. rover's task..\n");
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

    Console.WriteLine($"{rover?.state._coordinates.X} {rover?.state._coordinates.Y} {rover?.state.GetDirection()}");
}

Console.ReadKey();
