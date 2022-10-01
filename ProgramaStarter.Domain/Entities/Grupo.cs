using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Domain.Entities;

public class Grupo : EntidadeBase
{
    public int TecnologiaId { get; set; }
    public Tecnologia Tecnologia { get; set; }
    public int ProgramaId { get; set; }
    public Programa Programa { get; set; }
    public int ScrumMasterId { get; set; }
    public virtual Usuario ScrumMaster { get; set; }
    public ICollection<Starter> Starters { get; set; }

    public Grupo()
    { }
    public Grupo(int id)
    {
        Id = id;
    }
}
