using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class EntradaBR
    {
        public static bool AdicionarEntrada(Entrada entrada)
        {
            return EntradaDA.AdicionarEntrada(entrada);
        }

        public static List<Entrada> VerEntradas()
        {
            return EntradaDA.VerEntradas();
        }
    }
}
