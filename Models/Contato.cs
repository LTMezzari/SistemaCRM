using System.ComponentModel.DataAnnotations;

namespace SistemaCRM.Models {
    public class Contato {
        public int ID { get; set; }
        [Required(ErrorMessage = "O email é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage ="O email é obrigatório", AllowEmptyStrings =false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}