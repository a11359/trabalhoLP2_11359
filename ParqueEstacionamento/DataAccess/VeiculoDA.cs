using BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VeiculoDA
    {
        // atributos
        private static List<Veiculo> veiculos;
        private static readonly string fileName;

        // construtores
        static VeiculoDA()
        {
            veiculos = new List<Veiculo>();
            fileName = @"..\..\Files\listVeiculo.bin";
        }


        // metodos da classe
        /// <summary>
        /// 
        /// </summary>
        /// <param name="veiculo"></param>
        /// <returns></returns>
        public static bool AdicionarVeiculo(Veiculo veiculo)
        {
            // exemplos de como limitar para 10 veiculos
            if (veiculos.Count >= 10)
                return false;

            // variaveis
            bool existe = ExisteVeiculo(veiculo);

            // se o object nao for novo devemos nao o devemos adicionar à lista dos objetos
            if (existe)
                return false;

            // adicionar objeto aos veiculos existentes
            veiculos.Add(veiculo);

            // retornar objeto adicionado
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="veiculoParaVerificar"></param>
        /// <returns></returns>
        public static bool ExisteVeiculo(Veiculo veiculoParaVerificar)
        {
            // verificar se o objeto já existe na nossa lista
            foreach (Veiculo veiculo in veiculos)
            {
                // se exister retornar que o objeto ja existe
                if (veiculo.Equals(veiculoParaVerificar))
                    return true;
            }

            // se nao foi encontrado na lista retornar que o objeto é novo
            return false;
        }


        public static void VerVeiculos()
        {
            // se nao existirem veiculos dizer que nao existem
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não existem veiculos de momento!");
                return ;
            }

            // percorrer lista e mostrar os veiculos
            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine(veiculo.ToString());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool GravarFicheiro()
        {
            try
            {
                // verificar se o ficheiro já existe para o apagar
                if (File.Exists(fileName))
                    File.Delete(fileName);

                // tentar criar o ficheiro novamente e guardar a informacao dos veiculos
                FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, veiculos);

                // fechar ficheiro
                fileStream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar o ficheiro dos veiculos! ", e);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool RecarregarFicheiro()
        {
            // se o ficheiro nao exister nao o podemos recarregar
            if (!File.Exists(fileName))
                return false;

            try
            {
                // tentar abrir o ficheiro
                Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

                // ficheiro vazio
                if (stream.Length == 0)
                    return true;

                BinaryFormatter binaryFormatter = new BinaryFormatter();

                // formatar o ficheiro para a lista
                veiculos = (List<Veiculo>)binaryFormatter.Deserialize(stream);

                // fechar ficheiro
                stream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o ficheiro de veiculos! ", e);
            }
        }
    }
}
