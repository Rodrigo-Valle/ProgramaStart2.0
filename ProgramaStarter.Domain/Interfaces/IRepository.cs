using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetListAsync();
    Task<T> GetByIdAsync(int? id);

    Task<T> CreateAsync(T entidade);
    Task<T> UpdateAsync(T entidade);
    Task<T> RemoveAsync(T entidade);
}
