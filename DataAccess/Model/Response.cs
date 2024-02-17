namespace DataAccess.Model
{
    /// <summary>
    /// Modelo de respuesta apis
    /// </summary>
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? ObjetoADeserializar { get; set; }
        public string? TipoMensaje { get; set; }
    }
}
