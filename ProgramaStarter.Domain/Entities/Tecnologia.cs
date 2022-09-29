namespace ProgramaStarter.Domain.Entities;

public class Tecnologia : EntidadeBase
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }

    public ICollection<Grupo> Grupos { get; set; }

    public Tecnologia(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }
    public Tecnologia(int id, string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
        Id = id;
    }
}
