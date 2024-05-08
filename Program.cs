using System;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of ToyRobot
            ToyRobot toyRobot = new ToyRobot();

            //
            bool isPlaceFirst = false;
            
            // Test commands
            string[] commands = {
                "PLACE 0,0,NORTH",
                "LEFT",
                "REPORT"
            };

            // Iterate through each command
            foreach (var command in commands)
            {
                // Print the current command
                Console.WriteLine($"Input: {command}");

                // Split the command into parts
                string[] parts = command.Split(' ');

                // Determine the command type and execute corresponding method
                if(isPlaceFirst || parts[0] == "PLACE")
                {
                    switch (parts[0])
                    {
                    // If the command is "PLACE", parse arguments and call Place method
                    case "PLACE":
                        string[] argsPlace = parts[1].Split(',');
                        toyRobot.Place(int.Parse(argsPlace[0]), int.Parse(argsPlace[1]), (Direction)Enum.Parse(typeof(Direction), argsPlace[2]));
                        isPlaceFirst = true;
                        break;
                    
                    // If the command is "MOVE", call Move method
                    case "MOVE":
                        toyRobot.Move();
                        break;
                    
                    // If the command is "LEFT", call Left method
                    case "LEFT":
                        toyRobot.Left();
                        break;
                    
                    // If the command is "RIGHT", call Right method
                    case "RIGHT":
                        toyRobot.Right();
                        break;
                    
                    // If the command is "REPORT", call Report method
                    case "REPORT":
                        toyRobot.Report();
                        break;
                   }
                }
            }
        }
    }
}