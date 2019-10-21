using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
        private static Rectangle rect;
        private static void IntersectionRectangle(Rectangle r1, Rectangle r2)
        {
            int left, top;
            rect = new Rectangle(
          top = r1.Top > r2.Top       ? r1.Top  : r2.Top,
         left = r1.Left > r2.Left     ? r1.Left : r2.Left,
                r1.Right < r2.Right   ? r1.Right - left : r2.Right - left,
                r1.Bottom < r2.Bottom ? r1.Bottom - top : r2.Bottom - top
                );
        }

        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            IntersectionRectangle(r1, r2);
            return rect.Height >= 0 && rect.Width >= 0;
        }

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (!AreIntersected(r1, r2)) return 0;
			return rect.Width * rect.Height;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (r1.Top < r2.Top && r1.Left < r2.Left && r1.Right > r2.Right && r1.Bottom > r2.Bottom) return 1;
            if (r1.Top >= r2.Top && r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom) return 0;
            return -1;
		}
	}
}