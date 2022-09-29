using ProgramaStarter.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Entities;

public class Daily : EntidadeBase
{
    public DateTime Data { get; private set; }
    public string Fazendo { get; private set; }
    public string Feito { get; private set; }
    public string Impedimentos { get; private set; }
    public bool Presenca { get; private set; }

    public int ModuloId { get; set; }
    public virtual Modulo Modulo { get; set; }
    public int StarterId { get; set; }
    public virtual Starter Starter { get; private set; }

    public Daily(DateTime data, string fazendo, string feito, string impedimentos, bool presenca)
    {
        Data = data;
        Fazendo = fazendo;
        Feito = feito;
        Impedimentos = impedimentos;
        Presenca = presenca;
    }

    public Daily(int id, DateTime data, string fazendo, string feito, string impedimentos, bool presenca)
    {
        Data = data;
        Fazendo = fazendo;
        Feito = feito;
        Impedimentos = impedimentos;
        Presenca = presenca;
        Id = id;
    }
}