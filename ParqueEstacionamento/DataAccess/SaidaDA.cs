using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Responsavel por gerir todas as saidas.
namespace DataAccess
{
    public class SaidaDA
    {
        // atributos
        private static List<Saida> saidas;
        private static readonly string fileName;

        // construtores
        static SaidaDA()
        {
            saidas = new List<Saida>();
            fileName = @"..\..\Files\listSaidas.bin";
        }


        // metodos da classe
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public static bool AdicionarSaida(Saida saida)
        {
            // exemplos de como limitar para 10 saidas
            if (saidas.Count >= Constantes.NUMERO_SAIDAS)
                return false;

            // variaveis
            bool existe = ExisteSaida(saida);

            // se o object nao for novo devemos nao o devemos adicionar à lista dos objetos
            if (existe)
                return false;

            // adicionar objeto aos saidas existentes
            saidas.Add(saida);

            // retornar objeto adicionado
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="saidaParaVerificar"></param>
        /// <returns></returns>
        public static bool ExisteSaida(Saida saidaParaVerificar)
        {
            // verificar se o objeto já existe na nossa lista
            foreach (Saida saida in saidas)
            {
                // se exister retornar que o objeto ja existe
                if (saidas.Equals(saidaParaVerificar))
                    return true;
            }

            // se nao foi encontrado na lista retornar que o objeto é novo
            return false;
        }
        public static List<Saida> VerSaidas()
        {
            // se nao existirem saidas dizer que nao existem
            if (saidas is null || saidas.Count == 0)
                return new List<Saida>();

            // retornar lista
            return saidas;
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

                // tentar criar o ficheiro novamente e guardar a informacao das saidas
                FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, saidas);

                // fechar ficheiro
                fileStream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar o ficheiro das saidas! ", e);
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
                saidas = (List<Saida>)binaryFormatter.Deserialize(stream);

                // fechar ficheiro
                stream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o ficheiro das saidas! ", e);
            }
        }
    }
}