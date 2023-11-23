namespace Laboratorio.Models
{
    public class InventarioModel : Cadastro_Cliente
    {
        public int ID_Inventario { get; set; }
        public int ID_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public int ID_Maquina { get; set; }
        public string Nome_Maquina { get; set; }
        public string Funciona { get; set; }
        public string Relatorio { get; set; }


        public List<Cadastro_Cliente> ListaCliente { get; set; }
        public List<Cadastro_Maquina> ListaMaquina { get; set; }
    }
}
