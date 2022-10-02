using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramaStarter.Domain.Entities;

namespace ProgramaStarter.Domain.Interfaces;

public interface IAvaliacaoRepository
{
    Task<IEnumerable<Avaliacao>> GetListAsync(int? starterId);
    Task<Avaliacao> GetByIdAsync(int? id);

    Task<Avaliacao> CreateAsync(Avaliacao avaliacao);
    Task<Avaliacao> UpdateAsync(Avaliacao avaliacao);
    Task<Avaliacao> RemoveAsync(Avaliacao avaliacao);
}
