using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class Tarifa
    {
        //variaveis
        private int de;
        private int ate;
        private double preco;

        //Metodo vazio 

        public Tarifa() 
        {
        }

        public Tarifa(int de, int ate, double preco)
        {
            this.de = de;
            this.ate = ate;
            this.preco = preco;
        }

        //Propriedades

        public int De { get => de; set => de = value; }
        public int Ate { get => ate; set => ate = value; }
        public double Preco { get => preco; set => preco = value; }

        //Override  
        // preco to string para ter a certeza que vem o valor do preco e nao o valor da memoria
        public override string ToString()
        {
            //tostring tenta meter tudo que esta na lista e manda la ca para fora
            return string.Format("De: {0} | Ate: {1} | Preco: {2}", de, ate, preco.ToString());
        }
    }
}
