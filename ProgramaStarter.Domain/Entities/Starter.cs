using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Entities;

public class Starter : EntidadeBase
{
    public string Nome { get; private set; }
    public string Letras { get; private set; }

    public int GrupoId { get; set; }
    public virtual Grupo Grupo { get;  set; }
    public ICollection<Daily> Daylies { get; set; }
    public ICollection<ProjetoStarter> ProjetoStarter { get; set; }

    public Starter(string nome, string letras)
    {
        Nome = nome;
        Letras = letras;
    }

    public Starter(int id, string nome, string letras)
    {
        Nome = nome;
        Letras = letras;
        Id = id;
    }
}
