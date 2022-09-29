using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Entities;
public class Modulo : EntidadeBase
{
    public string Nome { get; private set; }
    public ICollection<Projeto> Projetos { get; set; }
    public ICollection<Daily> Daylies { get; set; }

    public Modulo(string nome)
    {
        Nome = nome;
    }
    public Modulo(int id, string nome)
    {
        Nome = nome;
        Id = id;
    }
}
