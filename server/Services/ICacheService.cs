using System;
using System.Threading.Tasks;

namespace CookBook.Services
{
    public interface ICacheService
    {

        Task<bool> HasKeyAsync(string key);

        Task<string> GetKeyAsync(string key);

        Task PutAsync(string key, TimeSpan timeTimeLive, object obj);

        Task PutStringAsync(string key, TimeSpan timeTimeLive, string value);

    }
}
