using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David.SecondBook.OnlineStore.WebApp.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
        bool SignOut();
    }
}
