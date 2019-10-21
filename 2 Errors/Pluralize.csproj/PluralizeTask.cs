namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            var last = "ей";
            if (count % 100 != 11 && count % 10 == 1) last = "ь";
            else if ((count % 100 > 20 || count % 100 < 5) &&
                      count % 10 > 1   && count % 10 < 5) last = "я";
			return "рубл" + last;
		}
	}
}