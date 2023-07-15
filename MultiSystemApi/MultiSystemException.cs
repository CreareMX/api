namespace MultiSystemApi
{
    public static class MultiSystemException
    {
        public static string ExMessage(Exception ex)
        {
            var error = $"- {ex.Message}";
            if (ex.InnerException != null)
                error += $"{Environment.NewLine}{ExMessage(ex.InnerException)}";

            return error;
        }
    }
}
