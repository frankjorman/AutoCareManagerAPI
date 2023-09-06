namespace AutoCareManagerAPI.Entities
{
    public class Vehiculo
    {
        public int id { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int AnioFabricacion { get; set; }
        public int idCliente { get; set; }

    }
}
