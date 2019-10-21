using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double AB = Length(ax, ay, bx, by);
            double AC = Length(ax, ay, x, y);
            if (AB == 0) return AC;
            double BC = Length(bx, by, x, y);
            if (AC + BC - AB < 1e-6) return 0;
            if (AC + AB - BC < 1e-6) return AC;
            if (AB + BC - AC < 1e-6) return BC;
            double alfa = Math.Acos((AC * AC - AB * AB - BC * BC) / (2 * BC * AB));
            double beta = Math.Acos((BC * BC - AC * AC - AB * AB) / (2 * AB * AC));
            if (alfa <= Math.PI/2 || beta <= Math.PI/2) return AC > BC ? BC : AC;
            double pp = (AC + AB + BC)/2;
            double S = Math.Sqrt(pp * (pp - AB) * (pp - AC) * (pp - BC));
            return S/AB*2;
        }
        private static double Length(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
	}
}