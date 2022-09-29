using System.ComponentModel.DataAnnotations;

namespace ProgramaStarter.Application.DTO;
public class ModuloDTO
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo {0} é Obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }
}