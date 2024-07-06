using Repository.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SupplierCompanyService
    {
        SupplierCompanyRepository repository = new();
        public List<SupplierCompany> GetAll() => repository.GetAll();
    }
}
