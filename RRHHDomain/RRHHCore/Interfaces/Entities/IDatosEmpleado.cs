namespace RRHHCore.Interfaces.Entities
{
    public interface IDatosEmpleado
    {
        decimal Salario { get; set; }
        DateTime FechaContratacion { get; set; }
        long IdDepartamento { get; set; }
        long IdEmpleado { get; set; }
        long IdPuesto { get; set; }
    }
}