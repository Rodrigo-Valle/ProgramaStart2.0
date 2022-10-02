using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Application.DTO;
public class AvaliacaoDTO
{
    [Required]
    public int Id { get; set; }
    public Starter Starter { get; set; }
    [DisplayName("Starter")]
    public int StarterId { get; set; }
    [DisplayName("Projeto")]
    public Projeto Projeto { get; set; }
    public int ProjetoId { get; set; }
    [Required]
    [Range(0.0, 10.0, ErrorMessage = "Nota de 0.0 a 10.0")]
    public double Nota { get; set; }
}
