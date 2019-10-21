namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            bool b = width > height;
            int countSteps = (b ? height : width) - 3;
            int lengthRigth = (width - 3) / countSteps;
            int lengthDown = (height - 3) / countSteps;
            if (b) MoveRepeat(robot, Direction.Right, lengthRigth);
            for (int i = 0; i < countSteps; i++)
            {
                MoveRepeat(robot, Direction.Down, lengthDown);
                MoveRepeat(robot, Direction.Right, lengthRigth);
            }
            if(!b) MoveRepeat(robot, Direction.Down, lengthDown);
        }
        private static void MoveRepeat(Robot robot, Direction direction, int steps)
        {
            for (int i = 0; i < steps; i++)
                robot.MoveTo(direction);
        }
    }
}