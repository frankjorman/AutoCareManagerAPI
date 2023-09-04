namespace AutoCareManagerAPI.Entities
{
    public class Reparaciones
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
    }
}
