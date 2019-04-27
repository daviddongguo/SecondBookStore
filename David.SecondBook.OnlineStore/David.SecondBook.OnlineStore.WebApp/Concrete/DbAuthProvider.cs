using David.SecondBook.OnlineStore.Domain.Entities;
using David.SecondBook.OnlineStore.WebApp.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace David.SecondBook.OnlineStore.WebApp.Concrete
{
    public class DbAuthProvider : IAuthProvider
    {
        private EFDbContext _dbContext;

        public DbAuthProvider(EFDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public bool Authenticate(string username, string password)
        {
            var dbLoginUser = _dbContext.LoginUsers.FirstOrDefault(i => i.Username == username);
            
            // FIXME: use MD5 to encrypt the password
            if (dbLoginUser.Password.Equals(password, StringComparison.Ordinal))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return true;
            }

            return false;
        }

        public bool SignOut()
        {
            try
            {
            FormsAuthentication.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}