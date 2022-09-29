using System.Collections.Generic;

namespace ProgramaStarter.Domain.Entities;

public class Projeto : EntidadeBase
{
    public string Etapa { get; private set; }

    public int ModuloId { get; set; }
    public Modulo Modulo { get; set; }
    public ICollection<ProjetoStarter> ProjetoStarter { get; set; } 


    public Projeto(string etapa)
    {
        Etapa = etapa;
    }
    public Projeto(int id, string etapa)
    {
        Etapa = etapa;
        Id = id;
    }
}
