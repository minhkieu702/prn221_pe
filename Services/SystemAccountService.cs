using Repository.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SystemAccountService
    {
        SystemAccountRepository repository = new();
        public SystemAccount Login(string email, string password) => repository.CheckLogin(email, password);
    }
}
