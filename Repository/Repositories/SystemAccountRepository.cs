using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SystemAccountRepository
    {
        public SystemAccount CheckLogin(string email, string password)
        {
            var context = new OilPaintingArt2024DbContext();
            return context.SystemAccounts.FirstOrDefault(c => c.AccountPassword.Equals(password) && c.AccountEmail.Equals(email));
        }
    }
}
