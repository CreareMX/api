namespace EssentialCore.Shared
{
    public static class ExceptionHelper
    {
        public static string GetFullMessage(Exception ex)
        {
            var message = $"- {ex.Message}";
            if(ex.InnerException != null)
                message += $"{Environment.NewLine}- {GetFullMessage(ex.InnerException)}";

            return message;
        }
    }
}
