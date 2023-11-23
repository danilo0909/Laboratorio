using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Models
{
    public class Cadastro_Maquina
    {
        [Key]
        public int ID_Maquina { get; set; }
        public string Nome_Maquina { get; set; }
    }
}
