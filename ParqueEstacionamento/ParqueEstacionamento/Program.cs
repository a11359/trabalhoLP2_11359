using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque
{
    class Program
    {
        static void Main(string[] args)
        {
            // variaveis
            string opcaoEscolhida = "-1";

            // sair com o numero 0
            while (!opcaoEscolhida.Equals("0"))
            {
                Console.Clear();

                // mostrar menu
                Menu();
                opcaoEscolhida = Console.ReadLine();

                // FAZER UM TRY CATCH PARA APARECER AQUI OS ERROS

                // verificar opção escolhida
                switch (opcaoEscolhida)
                {
                    case "1":
                        // inserir novo parque
                        

                        break;

                    case "2":
                        // ver parque

                        break;

                    case "3":
                        // inserir veiculo
                        InserirVeiculo();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;

                    case "4":
                        // ver veiculos
                        VerVeiculos();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;

                    case "5":
                        //Inserir tarifas
                        InserirTarifas();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;

                    case "5.1":
                        //Inserir tarifas
                        VerTarifas();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;

                    case "6":
                        //Inserir Entradas
                        InserirEntrada();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;
                    case "6.1":
                        //Inserir tarifas
                        VerEntradas();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;
                    case "7":
                        //Inserir saidas
                        InserirSaidas();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;
                    case "7.1":
                        //Inserir tarifas
                        InserirSaidas();

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;
                    case "8":
                        // guardar todos os ficheiros do sistema
                        GravarFicheiros();
                        Console.WriteLine("Ficheiros gravados com sucesso!");

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;
                    case "9":
                        // carregar todos os ficheiros do sistema
                        CarregarFicheiros();
                        Console.WriteLine("Ficheiros carregados com sucesso!");

                        Console.WriteLine("=== Clique numa tecla para continuar ===");
                        Console.ReadKey();

                        break;
                    case "0":
                        Console.WriteLine("Obrigado por usar o programa!");
                        break;
                    default:
                        Console.WriteLine("Opção invalida! Clique numa tecla para continuar");
                        Console.ReadKey();
                        break;
                }
            }
            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.WriteLine("=== MENU PARQUE ESTACIONAMENTO ===");
            Console.WriteLine("by Gonçalo Sena");
            Console.WriteLine("     Escolha a sua opção:");
            Console.WriteLine("         1 - Inserir Parque Estacionamento");
            Console.WriteLine("         2 - Ver Parque Estacionamento (entradas e saidas)");
            Console.WriteLine("         3 - Inserir Veiculo");
            Console.WriteLine("         4 - Ver Veiculos no sistema");
            Console.WriteLine("         5 - Inserir Tarifa");
            Console.WriteLine("         5.1 - Ver Tarifas no sistema");
            Console.WriteLine("         6 - Adicionar Entrada");
            Console.WriteLine("         6.1- Ver Entradas no sistema");
            Console.WriteLine("         7 - Adicionar Saida");
            Console.WriteLine("         7.1 - Ver Saidas no sistema");
            Console.WriteLine("         8 - Gravar ficheiros");
            Console.WriteLine("         9 - Carregar ficheiros");
            Console.WriteLine("\n       0 - Sair");
            Console.Write("     Opcao Escolhida: ");
        }

        //Metodos
        private static void CarregarFicheiros()
        {
            // recarregar todos os ficheiros das classes
            VeiculoDA.RecarregarFicheiro();
            TarifaDA.RecarregarFicheiro();
            ParqueEstacionamentoDA.RecarregarFicheiro();
            EntradaDA.RecarregarFicheiro();
            SaidaDA.RecarregarFicheiro();
            // falta parque estacionamento, entrada e saida
        }

        //gravar
        private static void GravarFicheiros()
        {
            // gravar todos os ficheiros
            VeiculoDA.GravarFicheiro();
            EntradaDA.GravarFicheiro();
            SaidaDA.GravarFicheiro();
            TarifaDA.GravarFicheiro();
            ParqueEstacionamentoDA.GravarFicheiro();

            // igual para os outros
        }

        //Veiculo
        public static void InserirVeiculo()
        {
            // variaveis
            string marca, tipo;
            Veiculo veiculo;

            // limpar consola
            Console.Clear();

            // pedir dados ao utilizador
            Console.Write("Insira a marca do veiculo: ");
            marca = Console.ReadLine();

            Console.Write("Insira o tipo de veiculo: ");
            tipo = Console.ReadLine();

            // inserir veiculo
            veiculo = new Veiculo(marca, tipo);

            // adicionar à lista de veiculos
            if (VeiculoDA.AdicionarVeiculo(veiculo))
                Console.WriteLine("Veiculo adicionado com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar veiculo!");
        }

        //Ver veiculos
        public static void VerVeiculos()
        {
            // limpar consola
            Console.Clear();

            // mostrar veiculos inseridos
            VeiculoDA.VerVeiculos();
        }

        //Entrada
        public static void InserirEntrada()
        {
            // variaveis
            string matricula;
            DateTime date;
            Entrada entrada;

            // limpar consola
            Console.Clear();

            // pedir dados ao utilizador
            Console.Write("Insira a matricula do veiculo: ");
            matricula = Console.ReadLine();
            date = DateTime.UtcNow;

            // inserir entrada nova entrada
            entrada = new Entrada(matricula, date);

            // adicionar à lista de entradas
            if (EntradaDA.AdicionarEntrada(entrada))
                Console.WriteLine("Entrada adicionada com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar Entrada!");
        }
        public static void VerEntradas()
        {
            // limpar consola
            Console.Clear();

            // mostrar entradas inseridas
            EntradaDA.VerEntradas();
        }

        //Saida
        public static void InserirSaidas()
        {
            // variaveis
            string matricula;
            DateTime date;
            Saida saida;

            // limpar consola
            Console.Clear();

            // pedir dados ao utilizador
            Console.Write("Insira a matricula do veiculo: ");
            matricula = Console.ReadLine();
            date = DateTime.UtcNow;

            // inserir saida
            saida = new Saida (matricula, date);

            // adicionar à lista de saidas
            if (SaidaDA.AdicionarSaida(saida))
                Console.WriteLine("Saida adicionada com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar Saida!");
        }
        public static void VerSaidas()
        {
            // limpar consola
            Console.Clear();

            // mostrar saidas inseridas
            SaidaDA.VerSaidas();
        }

        // Tarifa
        public static void InserirTarifas()
        {
            // variaveis
            int de, ate;
            double preco;
            Tarifa tarifa;

            // limpar consola
            Console.Clear();

            // pedir dados ao utilizador
            Console.Write("Insira a hora que entrou: ");
            de = int.Parse(Console.ReadLine());

            Console.Write("Insira a hora que saiu: ");
            ate = int.Parse(Console.ReadLine());

            Console.WriteLine("O preco a pagar é: ");
            preco = (de + ate * (3));
            Console.WriteLine("{0}", preco.ToString());

            // inserir tarifa
            tarifa = new Tarifa(de, ate, preco);

            // adicionar à lista de tarifas
            if (TarifaDA.AdicionarTarifa(tarifa))
                Console.WriteLine("Tarifa adicionada com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar Tarifa!");
        }
        public static void VerTarifas()
        {
            // limpar consola
            Console.Clear();

            // mostrar tarifas inseridas
            TarifaDA.VerTarifas();
        }

        ////Parque de Estacionamento
        //public static void InserirParquesEstacionamento()
        //{
        //    // variaveis
        //    int maximoLugares;
        //    List<Entrada> entradas;
        //    List<Saida> saidas; ;
        //    List<Tarifa> tarifas;
        //    ParqueEstacionamento parque;
        

        //    // limpar consola
        //    Console.Clear();

        //    // pedir dados ao utilizador
        //    Console.Write("Insira o numero maximo de lugares do parque de estacionamento: ");
        //    maximoLugares = int.Parse( Console.ReadLine());

        //    //nao sei como fazer isto
        //    entradas = int.Parse(Console.ReadLine());
        //    saidas = int.Parse(Console.ReadKey());
        //    tarifas = try.parse(Console.ReadKey());

        //    // inserir parque de estacionamento
        //    // estou com probelmas a inserir o parque por causa das listas ( esta me a pedir para passar a lista no parque )
        //    parque = new ParqueEstacionamento(maximoLugares, List<Entrada>, List<Saida>, List<Tarifa>);

        //    // adicionar à lista de parque de estacionamento
        //    if (ParqueEstacionamentoDA.AdicionarParqueEstacionamento(parque))
        //        Console.WriteLine("Parque de estacionamento adicionado com sucesso!!");
        //    else
        //        Console.WriteLine("Erro ao adicionar Parque de Estacionamento!");
        //}

        //public static void VerParqueEstacionamento()
        //{
        //    // limpar consola
        //    Console.Clear();

        //    // mostrar parques inseridos
        //    ParqueEstacionamentoDA.VerParqueEstacionamento();
        //}
    }
}
