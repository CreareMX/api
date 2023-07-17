namespace MultiSystemApi
{
    /// <summary>
    /// Determina una excepcion
    /// </summary>
    public static class MultiSystemException
    {
        /// <summary>
        /// Obtiene todos los mensajes de una excepcion
        /// </summary>
        /// <param name="ex">Excepcion interna</param>
        /// <returns>Mensaje de error concatenada.</returns>
        public static string ExMessage(Exception ex)
        {
            var error = $"- {ex.Message}";
            if (ex.InnerException != null)
                error += $"{Environment.NewLine}{ExMessage(ex.InnerException)}";

            return error;
        }
    }
}
