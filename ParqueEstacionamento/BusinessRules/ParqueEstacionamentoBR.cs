using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class ParqueEstacionamentoBR
    {
        public static bool AdicionarParqueEstacionmento(ParqueEstacionamento parqueEstacionamento)
        {
            return ParqueEstacionamentoDA.AdicionarParqueEstacionamento(parqueEstacionamento);
        }

        public static List<ParqueEstacionamento> VerParqueEstacionamento()
        {
            return ParqueEstacionamentoDA.VerParqueEstacionamento();
        }

        public static List<Tarifa> VerTarifas()
        {
            return ParqueEstacionamentoDA.VerTarifas();
        }


        public static bool AdicionarTarifa(List<Tarifa> tarifas)
        {
            // object nao pode ser nulo
            if (tarifas is null)
                throw new Exception(Messages.OBJECT_NULL);

            // adicionar tarifas
            return ParqueEstacionamentoDA.AdicionarTarifa(tarifas);
        }

        public static double QuantidadePagar(Saida saida)
        {
            // variaveis
            double preco = -1;
            List<Tarifa> tarifas;
            List<Entrada> entradas;
            DateTime dataEntrada = DateTime.Now, backupDataEntrada;
            TimeSpan timeSpan;

            // ir buscar as entradas do parque
            entradas = EntradaDA.VerEntradas();

            // ficar com a data de entrada
            backupDataEntrada = dataEntrada;

            // verificar se a matricula entrou
            foreach (Entrada entrada in entradas)
            {
                if (entrada.Matricula.Equals(saida.Matricula))
                    dataEntrada = entrada.Data;
            }

            // data de entrada nao pode ser igual à data que estava no inicio
            if (dataEntrada.Equals(backupDataEntrada))
                throw new Exception(Messages.CARRO_NAO_ENCONTRADO);

            // calcular diferença de data
            timeSpan = saida.Data - dataEntrada;

            // ir buscar as tarifas do parque
            tarifas = ParqueEstacionamentoDA.VerTarifas();

            foreach (Tarifa tarifa in tarifas)
            {
                if (timeSpan.TotalMinutes >= tarifa.De && timeSpan.TotalMinutes < tarifa.Ate)
                    preco = tarifa.Preco;
            }

            // preco nao entrado...
            if (preco == -1)
                throw new Exception(Messages.PRECO_NAO_ENCONTRADO);

            // retornar valor total da saida
            return preco;
        }
    }
}
