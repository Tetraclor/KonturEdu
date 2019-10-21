namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            for(int i = 0; i < height/2 - 1; i++)
            {
                Direction direction = i % 2 == 0 ? Direction.Right : Direction.Left;
                MoveRepeat(robot, direction, width - 3);
                MoveRepeat(robot, Direction.Down, 2);
            }
            MoveRepeat(robot, Direction.Left, width - 3);
		}

        private static void MoveRepeat(Robot robot, Direction direction, int steps)
        {
            for (int i = 0; i < steps; i++)
                robot.MoveTo(direction);
        }
    }
}