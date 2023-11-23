using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Models
{
    public class Inventario
    {
        [Key]
        public int ID_Inventario { get; set; }
        public int ID_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public int ID_Maquina { get; set; }
        public string Nome_Maquina { get; set; }
        public string Funciona { get; set; }
        public string Relatorio { get; set; }

        
    }
}
