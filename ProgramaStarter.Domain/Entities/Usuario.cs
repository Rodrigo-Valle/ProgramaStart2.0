using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Entities;

public class Usuario : EntidadeBase
{
    public string Nome { get; private set; }
    public string Letras { get; private set; }
    public string Email { get; private set; }
    public string Identity { get; private set; }
    public virtual Grupo Grupo { get; set; }


    public void setIdentity(string identity) {
        this.Identity = identity;
    }

    public Usuario(string nome, string letras, string email)
    {
        Nome = nome;
        Letras = letras;
        Email = email;
    }

    public Usuario(int id, string nome, string letras, string email, string identity)
    {
        Nome = nome;
        Letras = letras;
        Id = id;
        Identity = identity;
        Email = email;
    }
}
