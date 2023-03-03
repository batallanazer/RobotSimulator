using RobotSimulator;

var logFile = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),"commands.txt"));
var commands = new List<string>(logFile);

var position = commands.First().Split(',');
var direction = position.Last().ToUpper() switch
{
    "NORTH" => Direction.North,
    "SOUTH" => Direction.South,
    "EAST" => Direction.East,
    "WEST" => Direction.West,
    _ => throw new Exception("Invalid Direction")
};
var x = int.Parse(position[1]);
var y = int.Parse(position[2]);
commands.RemoveAt(0);

Robot robot = new Robot(direction, x, y);
var result = robot.Move(commands);
Console.WriteLine(result);
