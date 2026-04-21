namespace App_menstrual.Models// Ajusta el namespace si tu proyecto se llama diferente
{
    public class UserProfile
    {
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; } = DateTime.Today;
        public int DuracionCicloPromedio { get; set; } = 28; // Promedio estándar
    }

    public class AppService
    {
        public UserProfile Usuario { get; set; } = new UserProfile();

        // Lista para guardar los días que la usuaria registra que tuvo sangrado
        public List<DateTime> FechasPeriodo { get; set; } = new List<DateTime>();

        // Método para registrar "Me bajó hoy"
        public void RegistrarPeriodo(DateTime fecha)
        {
            if (!FechasPeriodo.Contains(fecha.Date))
            {
                FechasPeriodo.Add(fecha.Date);
                FechasPeriodo.Sort(); // Mantener ordenado
            }
        }

        // Lógica para el círculo principal
        public string ObtenerEstadoCiclo()
        {
            if (FechasPeriodo.Count == 0) return "Sin datos. Registra tu último periodo.";

            DateTime ultimoPeriodo = FechasPeriodo.Last();
            DateTime proximoEsperado = ultimoPeriodo.AddDays(Usuario.DuracionCicloPromedio);

            int diasDiferencia = (proximoEsperado - DateTime.Today).Days;

            if (diasDiferencia > 0)
                return $"Faltan {diasDiferencia} días para tu periodo";
            else if (diasDiferencia < 0)
                return $"Atraso de {Math.Abs(diasDiferencia)} días";
            else
                return "¡Tu periodo debería empezar hoy!";
        }
    }
}