using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IRepository;

namespace Tracy.WebFrameworks.Repository.Factory
{
    public class CorporationRepositoryFactory
    {
        public static ICorporationRepository GetInstance()
        {
            return new CorporationRepository();
        }

    }
}
