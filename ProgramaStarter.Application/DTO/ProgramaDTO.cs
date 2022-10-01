
using System.ComponentModel.DataAnnotations;

namespace ProgramaStarter.Application.DTO;
public class ProgramaDTO

{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo {0} é Obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataInicio { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataFim { get; set; }
}
