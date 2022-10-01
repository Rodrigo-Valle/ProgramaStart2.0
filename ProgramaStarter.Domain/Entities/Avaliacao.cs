namespace ProgramaStarter.Domain.Entities;

public class Avaliacao : EntidadeBase
{
    public double Nota { get; private set; }
    public int StarterId { get; set; }
    public virtual Starter Starter { get; set; }
    public int ProjetoId { get; set; }
    public virtual Projeto Projeto { get; set; }


    public Avaliacao(double nota)
    {
        Nota = nota;
    }

    public Avaliacao(int id, double nota)
    {
        Nota = nota;
        Id = id;
    }
}
