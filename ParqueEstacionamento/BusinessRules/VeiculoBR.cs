using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class VeiculoBR
    {
        public static bool AdicionarVeiculo(Veiculo veiculo)
        {
            return VeiculoDA.AdicionarVeiculo(veiculo);
        }

        public static List<Veiculo> VerVeiculos()
        {
            return VeiculoDA.VerVeiculos();
        }
    }
}
