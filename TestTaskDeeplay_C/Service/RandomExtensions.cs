using System;


namespace System
{
    static class RandomExtensions
    {
		public static DateTime GenRandomDateTime(this Random random) =>
			 DateTime.Now.AddYears(-60) + new TimeSpan((long)(random.NextDouble() * (DateTime.Now.AddYears(-18) - DateTime.Now.AddYears(-60)).Ticks));
		
	}
}
