using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Responsavel por todas as tarifas.
namespace DataAccess
{
    public class TarifaDA
    {
        // atributos
        private static List<Tarifa> tarifas;
        private static readonly string fileName;

        // construtores
        static TarifaDA()
        {
            tarifas = new List<Tarifa>();
            fileName = @"..\..\Files\listTarifa.bin";
        }


        // metodos da classe
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tarifa"></param>
        /// <returns></returns>
        public static bool AdicionarTarifa(Tarifa tarifa)
        {
            // variaveis
            bool existe = ExisteTarifa(tarifa);

            // se o object nao for novo devemos nao o devemos adicionar à lista dos objetos
            if (existe)
                return false;

            // adicionar objeto as tarifas existentes
            tarifas.Add(tarifa);

            // retornar objeto adicionado
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tarifaParaVerificar"></param>
        /// <returns></returns>
        public static bool ExisteTarifa(Tarifa tarifaParaVerificar)
        {
            // verificar se o objeto já existe na nossa lista
            foreach (Tarifa tarifa in tarifas)
            {
                // se exister retornar que o objeto ja existe
                if (tarifas.Equals(tarifaParaVerificar))
                    return true;
            }

            // se nao foi encontrado na lista retornar que o objeto é novo
            return false;
        }
        public static void VerTarifas()
        {
            // se nao existirem tarifas dizer que nao existem
            if (tarifas.Count == 0)
            {
                Console.WriteLine("Não existem tarifas de momento!");
                return;
            }

            // percorrer lista e mostrar as tarifas
            foreach (Tarifa tarifa in tarifas)
            {
                Console.WriteLine(tarifa.ToString());
        
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
                    // apagar o ficheiro
                    File.Delete(fileName);

                // tentar criar o ficheiro novamente e guardar a informacao dos veiculos
                FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, tarifas);

                // fechar ficheiro
                fileStream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar o ficheiro das tarifas! ", e);
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
                tarifas = (List<Tarifa>)binaryFormatter.Deserialize(stream);

                // fechar ficheiro
                stream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o ficheiro das tarifas! ", e);
            }
        }
    }
}
