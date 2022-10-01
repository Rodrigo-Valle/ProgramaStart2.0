
namespace ProgramaStarter.Domain.Entities;

public class Programa : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }

    public ICollection<Grupo> Grupos { get; set; }

    public Programa(string nome, DateTime dataInicio, DateTime dataFim)
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }
    public Programa(int id, string nome, DateTime dataInicio, DateTime dataFim)
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Id = id;
    }
}
