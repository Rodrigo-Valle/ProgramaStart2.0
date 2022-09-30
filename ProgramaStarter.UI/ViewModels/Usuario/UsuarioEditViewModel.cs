using System.ComponentModel.DataAnnotations;

namespace ProgramaStarter.UI.ViewModels;
public class UsuarioEditViewModel
{
    public string Id { get; set; }
    public string IdentityId { get; set; }

    [Required(ErrorMessage = "Campo {0} é Obrigatório")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Endereço invalido")]
    [EmailAddress(ErrorMessage = "Entre com um endereço valido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo {0} é Obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Campo {0} é Obrigatório")]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "O campo deve ter {2} caracteres")]
    public string Letras { get; set; }
}