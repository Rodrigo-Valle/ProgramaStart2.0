using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Entities
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}
