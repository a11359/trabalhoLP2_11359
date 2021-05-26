using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// responsavel por gerir toda lista de entradas de veiculos.
namespace DataAccess
{
    public class EntradaDA
    {
        // atributos
        private static List<Entrada> entradas;
        private static readonly string fileName;

        // construtores
        static EntradaDA()
        {
            entradas = new List<Entrada>();
            fileName = @"..\..\Files\listEntrada.bin";
        }

        // metodos da classe
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public static bool AdicionarEntrada(Entrada entrada)
        {
            // exemplos de como limitar para 10 entradas
            if (entradas.Count >= Constantes.NUMERO_ENTRADAS)
                return false;

            // variaveis
         bool existe = ExisteEntrada(entrada);

            // se o object nao for novo devemos nao o devemos adicionar à lista dos objetos
            if (existe)
                return false;

            // adicionar objeto aos entradas existentes
            entradas.Add(entrada);

            // retornar objeto adicionado
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entradaParaVerificar"></param>
        /// <returns></returns>
        public static bool ExisteEntrada(Entrada entradaParaVerificar)
        {
            // verificar se o objeto já existe na nossa lista
            foreach (Entrada entrada in entradas)
            {
                // se exister retornar que o objeto ja existe
                if (entradas.Equals(entradaParaVerificar))
                    return true;
            }

            // se nao foi encontrado na lista retornar que o objeto é novo
            return false;
        }
        public static List<Entrada> VerEntradas()
        {
            // se nao existirem entradas dizer que nao existem
            if (entradas is null || entradas.Count == 0)
                return new List<Entrada>();

            // retornar todas as entradas
            return entradas;
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

                // tentar criar o ficheiro novamente e guardar a informacao das Entradas
                FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, entradas);

                // fechar ficheiro
                fileStream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar o ficheiro das entradas! ", e);
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

            // ficheiro vazio
            if (entradas.Count == 0)
                return true;

            try
            {
                // tentar abrir o ficheiro
                Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

                // ficheiro vazio
                if (stream.Length == 0)
                    return true;

                BinaryFormatter binaryFormatter = new BinaryFormatter();

                // formatar o ficheiro para a lista
                entradas = (List<Entrada>)binaryFormatter.Deserialize(stream);

                // fechar ficheiro
                stream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o ficheiro das entradas! ", e);
            }
        }
    }
}
