using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class ParqueEstacionamento
    {
        // variaveis
        private int maximoLugares;

        //lista do tipo Objecto entrada e saida 
        //private List<Entrada> entradas;
        //private List<Saida> saidas;
        private List<Tarifa> tarifas;

        // construtores
        /// <summary>
        /// metodo vazio para construçao de objecto
        /// </summary>
        public ParqueEstacionamento()
        {
        }

        ///// <summary>
        ///// metodo para construçao de objecto
        ///// </summary>
        ///// <param name="maximoLugares">maximo de lugares permitidos</param>
        ///// <param name="entradas">lista de entradas (por defeito devera ser vazia)</param>
        ///// <param name="saidas">lista de entradas (por defeito devera ser vazia)</param>
        ///// <param name="tarifas"></param>
        //public ParqueEstacionamento(int maximoLugares, List<Entrada> entradas, List<Saida> saidas, List<Tarifa> tarifas)
        //{
        //    this.maximoLugares = maximoLugares;
        //    this.entradas = entradas;
        //    this.saidas = saidas;
        //    this.tarifas = tarifas;
        //}

        /// <summary>
        /// metodo para construçao de objecto
        /// </summary>
        /// <param name="maximoLugares">maximo de lugares permitidos</param>
        /// <param name="tarifas"></param>
        public ParqueEstacionamento(int maximoLugares, List<Tarifa> tarifas)
        {
            this.maximoLugares = maximoLugares;
            this.tarifas = tarifas;
        }

        //Propriedades
        public int MaximoLugares { get => maximoLugares; set => maximoLugares = value; }
        //public List<Entrada> Entradas { get => entradas; set => entradas = value; }
        //public List<Saida> Saidas { get => saidas; set => saidas = value; }
        public List<Tarifa> Tarifas { get => tarifas; set => tarifas = value; }

        //Override  
        public override string ToString()
        {
            //tostring tenta meter tudo que esta na lista e manda la ca para fora
            return string.Format("Lotação: {0} | Tarifa: {1}",
                        maximoLugares,
                        tarifas.ToString());
            //return string.Format("Lotação: {0} | Entradas: {1} | Saidas: {2} | Tarifa: {3}",
            //            maximoLugares,
            //            entradas.ToString(),
            //            saidas.ToString(),
            //            tarifas.ToString());
        }

    }
}
