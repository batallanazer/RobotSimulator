using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    public class Robot
    {
        public Direction direction { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Robot(Direction direction, int x, int y)
        {
            this.direction = direction;
            X = x;
            Y = y;
        }
        public string Move(List<string> commands)
        {
            var directionInt = (int)direction;
            foreach (var code in commands)
            {
                if (code == "MOVE")
                {
                    switch (direction)
                    {
                        case Direction.North:
                            Y++;
                            break;
                        case Direction.East:
                            X++;
                            break;
                        case Direction.South:
                            Y--;
                            break;
                        case Direction.West:
                            X--;
                            break;
                    }
                    if (Y > 5)
                    {
                        Y--;
                    }
                    if (Y < 0)
                    {
                        Y++;
                    }
                    if (X > 5)
                    {
                        X--;
                    }
                    if (X < 0)
                    {
                        X++;
                    }

                }
                else if (code == "LEFT")
                {
                    directionInt--;
                    if (directionInt < 0) directionInt = 3;
                    direction = (Direction)directionInt;
                }
                else if (code == "RIGHT")
                {
                    directionInt++;
                    if (directionInt > 3) directionInt = 0;
                    direction = (Direction)directionInt;
                }
                else if (code == "REPORT")
                {
                    return $"{X},{Y},{Enum.GetName(typeof(Direction), direction)}";
                }
            }

            return $"{X},{Y},{Enum.GetName(typeof(Direction), direction)}";
        }
    }
}
