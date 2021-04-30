using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class Saida : Veiculo
    {
        //variaveis
        private string matricula;
        private DateTime data;

        //methods   
        public Saida()
        {
        }

        //metodo 
        public Saida(string matricula, DateTime data)
        {
            this.matricula = matricula;
            this.data = data;
        }

        //Propriedades  

        public string Matricula { get => matricula; set => matricula = value; }
        public DateTime Data { get => data; set => data = value; }

        //override
        public override string ToString()
        {
            return string.Format("Matricula: {0} | Data: {1}", matricula, data);
        }
    }
}
