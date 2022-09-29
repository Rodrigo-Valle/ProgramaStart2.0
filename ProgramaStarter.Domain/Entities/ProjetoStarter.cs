namespace ProgramaStarter.Domain.Entities;

public class ProjetoStarter : EntidadeBase
{
    public double Avaliacao { get; private set; }
    public int StarterId { get; set; }
    public virtual Starter Starter { get; set; }
    public int ProjetoId { get; set; }
    public virtual Projeto Projeto { get; set; }


    public ProjetoStarter(double avaliacao)
    {
        Avaliacao = avaliacao;
    }

    public ProjetoStarter(int id, double avaliacao)
    {
        Avaliacao = avaliacao;
        Id = id;
    }
}
