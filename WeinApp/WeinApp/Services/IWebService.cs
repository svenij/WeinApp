using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public interface IWebService<T>
    {
        Task<IEnumerable<T>> Get();

        Task<int> Post(T toPost);
    }
}
