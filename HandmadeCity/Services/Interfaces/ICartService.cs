using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HandmadeCity.Services.Interfaces
{
    public interface ICartService
    {
        IList<int> Get(ISession session);
        void Add(ISession session, int productId);
        void Remove(ISession session, int productId);
    }
}
