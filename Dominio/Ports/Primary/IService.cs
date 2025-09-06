using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Ports.Primary
{
    public interface IService
    {
        void Register(string name, decimal price);

        IEnumerable<Product> GetAll();
    }
}
