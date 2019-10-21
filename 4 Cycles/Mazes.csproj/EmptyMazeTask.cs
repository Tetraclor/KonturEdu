namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            MoveRepeat(robot, Direction.Right, width-3);
            MoveRepeat(robot, Direction.Down, height-3);
		}
        private static void MoveRepeat(Robot robot, Direction direction, int steps)
        {
            for (int i = 0; i < steps; i++)
                robot.MoveTo(direction);
        }
    }
}