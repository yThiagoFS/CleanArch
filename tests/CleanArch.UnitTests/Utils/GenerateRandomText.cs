namespace CleanArch.UnitTests.Utils
{
    public static class GenerateRandomText
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static Random random = new();

        public static string Generate(int length)
            => new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
