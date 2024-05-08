using System;

namespace ToyRobotSimulator
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class ToyRobot
    {
        // Define the dimensions of the table
        private const int TableWidth = 5;
        private const int TableHeight = 5;

        // Robot's current position and direction
        private int x;
        private int y;
        private Direction facing;

        // Constructor to initialize the robot's position and direction
        public ToyRobot()
        {
            x = -1; // Default to an invalid position
            y = -1; // Default to an invalid position
            facing = Direction.NORTH; // Default facing direction
        }

        // Place the robot on the table at the specified position and direction
        public void Place(int x, int y, Direction facing)
        {
            // Check if the specified position is valid
            if (IsValidPosition(x, y))
            {
                // Set the robot's position and direction
                this.x = x;
                this.y = y;
                this.facing = facing;
            }
        }

        // Move the robot one unit in the direction it is facing
        public void Move()
        {
            int newX = x;
            int newY = y;

            // Update the new position based on the current direction
            switch (facing)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            // Check if the new position is valid
            if (IsValidPosition(newX, newY))
            {
                // Update the robot's position
                x = newX;
                y = newY;
            }
        }

        // Rotate the robot 90 degrees to the left
        public void Left()
        {
            // Calculate the new direction by decrementing the current direction
            facing = (Direction)(((int)facing + 3) % 4);
        }

        // Rotate the robot 90 degrees to the right
        public void Right()
        {
            // Calculate the new direction by incrementing the current direction
            facing = (Direction)(((int)facing + 1) % 4);
        }

        // Report the robot's current position and direction
        public void Report()
        {
            // Print the robot's position and direction if position is valid
            if(x!=-1 && y!=-1)
                Console.WriteLine($"Output: {x},{y},{facing} \n\n");
        }

        // Check if the specified position is within the bounds of the table
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < TableWidth && y >= 0 && y < TableHeight;
        }
    }
}