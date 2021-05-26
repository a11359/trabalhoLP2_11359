using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class FicheiroBR
    {
        public static void CarregarFicheiros()
        {
            // recarregar todos os ficheiros das classes
            VeiculoDA.RecarregarFicheiro();
            TarifaDA.RecarregarFicheiro();
            ParqueEstacionamentoDA.RecarregarFicheiro();
            EntradaDA.RecarregarFicheiro();
            SaidaDA.RecarregarFicheiro();
            // falta parque estacionamento, entrada e saida
        }

        public static void GravarFicheiros()
        {
            // gravar todos os ficheiros
            VeiculoDA.GravarFicheiro();
            EntradaDA.GravarFicheiro();
            SaidaDA.GravarFicheiro();
            TarifaDA.GravarFicheiro();
            ParqueEstacionamentoDA.GravarFicheiro();

            // igual para os outros
        }
    }
}
