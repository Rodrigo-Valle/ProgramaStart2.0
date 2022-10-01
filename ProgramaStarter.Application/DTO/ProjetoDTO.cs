using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Application.DTO;
public class ProjetoDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:F1}")]

    public double Avaliacao { get; set; }
    [Required(ErrorMessage = "Campo {0} é Obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Etapa { get; set; }
    public Modulo Modulo { get; set; }
    [DisplayName("Modulo")]
    public int ModuloId { get; set; }
}
