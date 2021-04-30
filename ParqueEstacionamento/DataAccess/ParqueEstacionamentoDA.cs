﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAccess
{
    public class ParqueEstacionamentoDA
    {
        // atributos
        private static List<ParqueEstacionamento> parqueEstacionamentos;
        private static readonly string fileName;

        // construtores
        static ParqueEstacionamentoDA()
        {
            parqueEstacionamentos = new List<ParqueEstacionamento>();
            fileName = @"..\..\Files\listParqueEstacionamentos.bin";
        }


        // metodos da classe
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParqueEstacionamento"></param>
        /// <returns></returns>
        public static bool AdicionarParqueEstacionamento(ParqueEstacionamento parqueEstacionamento)
        {
            // limitar a 2 parques de estacionamento
            if (parqueEstacionamentos.Count >= 2)
                return false;

            // variaveis
            bool existe = ExisteParqueEstacionamento(parqueEstacionamento);

            // se o objecto nao for novo devemos nao o devemos adicionar à lista dos objetos
            if (existe)
                return false;

            // adicionar objeto aos parquesEstacionamentos existentes
            parqueEstacionamentos.Add(parqueEstacionamento);

            // retornar objeto adicionado
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParuqeEstacionamentoParaVerificar"></param>
        /// <returns></returns>
        public static bool ExisteParqueEstacionamento(ParqueEstacionamento parqueEstacionamentoParaVerificar)
        {
            // verificar se o objeto já existe na nossa lista
            foreach (ParqueEstacionamento parqueEstacionamento in parqueEstacionamentos)
            {
                // se exister retornar que o objeto ja existe
                if (parqueEstacionamentos.Equals(parqueEstacionamentoParaVerificar))
                    return true;
            }

            // se nao foi encontrado na lista retornar que o objeto é novo
            return false;
        }
        public static void VerParqueEstacionamento()
        {
            // se nao existirem entradas dizer que nao existem
            if (parqueEstacionamentos.Count == 0)
            {
                Console.WriteLine("Não existem parques de estacionamento de momento!");
                return;
            }

            // percorrer lista e mostrar as entradas
            foreach (ParqueEstacionamento parqueEstacionamento in parqueEstacionamentos)
            {
                Console.WriteLine(parqueEstacionamento.ToString());
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

                // tentar criar o ficheiro novamente e guardar a informacao dos parques de Estacionamento
                FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, parqueEstacionamentos);

                // fechar ficheiro
                fileStream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar o ficheiro dos Parques de Estacionamento! ", e);
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
                parqueEstacionamentos = (List<ParqueEstacionamento>)binaryFormatter.Deserialize(stream);

                // fechar ficheiro
                stream.Close();

                // sucesso
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o ficheiro dos Parques de Estacionamento! ", e);
            }
        }
    }
}