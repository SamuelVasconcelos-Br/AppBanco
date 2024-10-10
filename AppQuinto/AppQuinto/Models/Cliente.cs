using System.ComponentModel.DataAnnotations;

namespace AppQuinto.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int? idCli { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]

        public string nomeCli { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.DateTime)]

        public DateTime DataNasc { get; set; }
    }
}
