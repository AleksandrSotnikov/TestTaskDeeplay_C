namespace System
{
    static class RandomExtensions
    {
        #region Генерация даты рождения
        public static DateTime GenRandomDateTime(this Random random) =>
             DateTime.Now.AddYears(-60) + new TimeSpan((long)(random.NextDouble() * (DateTime.Now.AddYears(-18) - DateTime.Now.AddYears(-60)).Ticks));
        #endregion
    }
}
