using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.Repository;

namespace Tracy.WebFrameworks.Repository.Factory
{
    public class GenericRepositoryFactory<T> where T : class
    {
        public static IGenericRepository<T> GetInstance()
        {
            return new GenericRepository<T>();
        }

    }
}
