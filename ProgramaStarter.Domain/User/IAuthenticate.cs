using System.Threading.Tasks;

namespace ProgramaStarter.Domain.Account;
public interface IAuthenticate
{
    Task<bool> Authenticate(string email, string password);
    Task<string> RegisterUser(string email, string password);
    Task Logout();
}
