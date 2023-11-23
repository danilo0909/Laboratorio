using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Models
{
    public class Cadastro_Cliente
    {
        [Key]
        public int ID_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public string Documento { get; set; }
    }
}
