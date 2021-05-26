using BusinessObjects;
using BusinessRules;
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

            // carregar ficheiros do programa
            CarregarFicheiros();

            // sair com o numero 0
            while (!opcaoEscolhida.Equals("0"))
            {
                if (!opcaoEscolhida.Equals("-1"))
                {
                    Console.WriteLine("=== Clique numa tecla para continuar ===");
                    Console.ReadKey();
                    Console.Clear();
                }

                // mostrar menu
                Menu();
                opcaoEscolhida = Console.ReadLine();

                try
                {
                    // verificar opção escolhida
                    switch (opcaoEscolhida)
                    {
                        case "A":
                        case "a":
                            // inserir novo parque


                            break;

                        case "B":
                        case "b":
                            // ver parque

                            break;

                        case "C":
                        case "c":
                            // inserir veiculo
                            InserirVeiculo();

                            break;

                        case "D":
                        case "d":
                            // ver veiculos
                            VerVeiculos();

                            break;

                        case "E":
                        case "e":
                            //Inserir tarifas
                            InserirTarifas();

                            break;

                        case "F":
                        case "f":
                            //Inserir tarifas
                            VerTarifas();

                            break;

                        case "G":
                        case "g":
                            //Inserir Entradas
                            InserirEntrada();

                            break;
                        case "H":
                        case "h":
                            //Inserir tarifas
                            VerEntradas();

                            break;
                        case "I":
                        case "i":

                            //Inserir saidas
                            InserirSaidas();

                            break;
                        case "J":
                        case "j":
                            //Inserir tarifas
                            InserirSaidas();

                            break;
                        case "K":
                        case "k":
                            // guardar todos os ficheiros do sistema
                            GravarFicheiros();

                            break;
                        case "L":
                        case "l":
                            // carregar todos os ficheiros do sistema
                            CarregarFicheiros();

                            break;
                        case "0":
                            Console.WriteLine("Obrigado por usar o programa!");
                            break;
                        default:
                            Console.WriteLine("Opção invalida!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro1! Mensagem: {0}", ex.Message);
                    Console.ReadKey();
                }
            }

            // pausar programa
            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.WriteLine("=== MENU PARQUE ESTACIONAMENTO ===");
            Console.WriteLine("by Gonçalo Sena");
            Console.WriteLine("     Escolha a sua opção:");
            Console.WriteLine("         A - Inserir Parque Estacionamento");
            Console.WriteLine("         B - Ver Parque Estacionamento (entradas e saidas)");
            Console.WriteLine("         C - Inserir Veiculo");
            Console.WriteLine("         D - Ver Veiculos no sistema");
            Console.WriteLine("         E - Inserir Tarifa");
            Console.WriteLine("         F - Ver Tarifas no sistema");
            Console.WriteLine("         G - Adicionar Entrada");
            Console.WriteLine("         H - Ver Entradas no sistema");
            Console.WriteLine("         I - Adicionar Saida");
            Console.WriteLine("         J - Ver Saidas no sistema");
            Console.WriteLine("         K - Gravar ficheiros");
            Console.WriteLine("         L - Carregar ficheiros");
            Console.WriteLine("\n       0 - Sair");
            Console.Write("     Opcao Escolhida: ");
        }

        //Metodos
        private static void CarregarFicheiros()
        {
            FicheiroBR.CarregarFicheiros();
            Console.WriteLine("Ficheiros carregados com sucesso!");
        }

        //gravar
        private static void GravarFicheiros()
        {
            FicheiroBR.GravarFicheiros();
            Console.WriteLine("Ficheiros gravados com sucesso!");
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
            if (VeiculoBR.AdicionarVeiculo(veiculo))
                Console.WriteLine("Veiculo adicionado com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar veiculo!");
        }

        //Ver veiculos
        public static void VerVeiculos()
        {
            List<Veiculo> veiculos;

            // limpar consola
            Console.Clear();

            // mostrar veiculos inseridos
            veiculos = VeiculoBR.VerVeiculos();

            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine(veiculo.ToString());
            }
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
            date = DateTime.Now;

            // inserir entrada nova entrada
            entrada = new Entrada(matricula, date);

            // adicionar à lista de entradas
            if (EntradaBR.AdicionarEntrada(entrada))
                Console.WriteLine("Entrada adicionada com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar Entrada!");
        }
        public static void VerEntradas()
        {
            List<Entrada> entradas;

            // limpar consola
            Console.Clear();

            // mostrar entradas inseridas
            entradas = EntradaBR.VerEntradas();

            foreach (Entrada entrada in entradas)
            {
                Console.WriteLine(entrada.ToString());
            }
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
            date = DateTime.Now;

            // inserir saida
            saida = new Saida (matricula, date);

            // adicionar à lista de saidas
            if (SaidaBR.AdicionarSaida(saida))
                Console.WriteLine("Saida adicionada com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar Saida!");
        }
        public static void VerSaidas()
        {
            List<Saida> saidas;
            // limpar consola
            Console.Clear();

            // mostrar saidas inseridas
            saidas = SaidaBR.VerSaidas();

            foreach (Saida saida in saidas)
            {
                Console.WriteLine(saida.ToString());
            }
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
            if (TarifaBR.AdicionarTarifa(tarifa))
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

        public static void Teste()
        {
            // exemplos para uma lista dentro do parque
            List<Entrada> entradas = new List<Entrada>();
            List<Saida> saidas = new List<Saida>();
            DateTime data = DateTime.Now;
            ParqueEstacionamento parque;

            parque = new ParqueEstacionamento();

            parque.MaximoLugares = 10;

            parque.Entradas.Add(new Entrada("AA-14-BB", data));
            parque.Entradas.Add(new Entrada("AA-14-BB", data.AddSeconds(1)));
            parque.Entradas.Add(new Entrada("AA-14-BB", data.AddSeconds(2)));
            parque.Entradas.Add(new Entrada("AA-14-BB", data.AddSeconds(3)));
            parque.Entradas.Add(new Entrada("AA-14-BB", data.AddSeconds(4)));

            // recolha dos dados do utilizador
            Console.WriteLine("Insira a matricula:");

            // ver se a matricula ja nao está no parque
            Entrada entrada = new Entrada("AA-14-BB", data);

            // business rules

            // adicionar ao parque
            parque.Entradas.Add(entrada);

            //parque.Saidas.Add(new );
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
