using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class SaidaBR
    {
        public static bool AdicionarSaida(Saida saida)
        {
            return SaidaDA.AdicionarSaida(saida);
        }

        public static List<Saida> VerSaidas()
        {
            return SaidaDA.VerSaidas();
        }
    }
}
