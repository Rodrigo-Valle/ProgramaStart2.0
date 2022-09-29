
namespace ProgramaStarter.Domain.Entities;

public class ProgramaStart : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }

    public ICollection<Grupo> Grupos { get; set; }

    public ProgramaStart(string nome, DateTime dataInicio, DateTime dataFim)
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }
    public ProgramaStart(int id, string nome, DateTime dataInicio, DateTime dataFim)
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Id = id;
    }
}
