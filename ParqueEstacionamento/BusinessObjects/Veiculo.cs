using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    public class Veiculo
    {
        // variaveis da class
        private string marca;
        private string tipo;

        // methods
        
        /// <summary>
        /// Metodo vazio para criação de um veiculo
        /// </summary>
        public Veiculo()
        {
        }

        /// <summary>
        /// Metodo para criação de um veiculo completo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Veiculo(string marca, string tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
        }

        // propriedades
        public string Marca { get => marca; set => marca = value; }

        public string Tipo { get => tipo; set => tipo = value; }

        // overrides
        public override string ToString()
        {
            return string.Format("Marca: {0} | Tipo: {1}", marca, tipo);
        }
    }
}
