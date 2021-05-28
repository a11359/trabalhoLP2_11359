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
            CarregarFicheiros(true);

            // sair com o numero 0
            while (!opcaoEscolhida.Equals("0"))
            {
                // mostrar para continuar (primeira vez nao aparece)
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
                            InserirParqueEstacionamento();


                            break;

                        case "B":
                        case "b":
                            // ver parque
                            VerParqueEstacionamentos();

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
                            VerSaidas();

                            break;
                        case "K":
                        case "k":
                            // guardar todos os ficheiros do sistema
                            GravarFicheiros(true);

                            break;
                        case "L":
                        case "l":
                            // carregar todos os ficheiros do sistema
                            CarregarFicheiros(true);

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
                    Console.WriteLine("\n\nErro!! Mensagem: {0}\n", ex.Message);
                }

                // guardar todos os ficheiros ao inserir alguma coisa no menu
                GravarFicheiros(false);
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
        private static void CarregarFicheiros(bool apareceMensagem)
        {
            FicheiroBR.CarregarFicheiros();

            if (apareceMensagem)
                Console.WriteLine("Ficheiros carregados com sucesso!");
        }

        //gravar
        private static void GravarFicheiros(bool apareceMensagem)
        {
            FicheiroBR.GravarFicheiros();

            if (apareceMensagem)
                Console.WriteLine("Ficheiros gravados com sucesso!");
        }

        //Parque
        public static void InserirParqueEstacionamento()
        {
            // variaveis
            int lugares;
            ParqueEstacionamento parqueEstacionamento;

            // limpar consola
            Console.Clear();

            // pedir dados ao utilizador
            Console.Write("Insira o maximo de lugares: ");
            lugares = int.Parse(Console.ReadLine());

            // inserir parques
            parqueEstacionamento = new ParqueEstacionamento(lugares, new List<Tarifa>());

            // adicionar à lista de parques
            if (ParqueEstacionamentoBR.AdicionarParqueEstacionmento(parqueEstacionamento))
                Console.WriteLine("Parque adicionado com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar parque!");
        }

        //Ver veiculos
        public static void VerParqueEstacionamentos()
        {
            List<ParqueEstacionamento> parqueEstacionamentos;

            // limpar consola
            Console.Clear();

            // mostrar parques inseridos
            parqueEstacionamentos = ParqueEstacionamentoBR.VerParqueEstacionamento();

            foreach (ParqueEstacionamento parqueEstacionamento in parqueEstacionamentos)
            {
                Console.WriteLine(parqueEstacionamento.ToString());
            }
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

            // mostrar entradas
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
            double preco;

            // limpar consola
            Console.Clear();

            // pedir dados ao utilizador
            Console.Write("Insira a matricula do veiculo: ");
            matricula = Console.ReadLine();
            date = DateTime.Now;

            // inserir saida
            saida = new Saida (matricula, date);

            // quantidade a pagar
            preco = ParqueEstacionamentoBR.QuantidadePagar(saida);

            // adicionar à lista de saidas
            if (SaidaBR.AdicionarSaida(saida))
                Console.WriteLine("Saida adicionada com sucesso!!\nPreco a pagar: {0}", preco);
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
                Console.Write(saida.ToString());
                Console.Write(" - Preco que pagou: {0}\n", ParqueEstacionamentoBR.QuantidadePagar(saida));
            }
        }

        // Tarifa
        public static void InserirTarifas()
        {
            // variaveis
            int de, ate;
            double preco;
            Tarifa tarifa;
            List<Tarifa> tarifas = new List<Tarifa>();
            int escolha = -1;

            // limpar consola
            Console.Clear();

            while (escolha != 0)
            {
                Console.Write("Insira o DE: ");
                de = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o ATE: ");
                ate = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira o preco: ");
                preco = double.Parse(Console.ReadLine());

                // criar tarifa
                tarifa = new Tarifa(de, ate, preco);

                // adicionar a lista de tarifas
                tarifas.Add(tarifa);

                // mais tarifas?
                Console.WriteLine("Pretende adicionar mais tarifas? (0 -> NAO | 1 -> SIM)");
                escolha = int.Parse(Console.ReadLine());
            }

            // adicionar à lista de tarifas
            if (ParqueEstacionamentoBR.AdicionarTarifa(tarifas))
                Console.WriteLine("Tarifas adicionadas com sucesso!!");
            else
                Console.WriteLine("Erro ao adicionar Tarifas!");
        }

        public static void VerTarifas()
        {
            // variaveis
            List<Tarifa> tarifas;

            // limpar consola
            Console.Clear();

            // mostrar tarifas inseridas
            tarifas = ParqueEstacionamentoBR.VerTarifas();

            foreach (Tarifa tarifa in tarifas)
            {
                Console.WriteLine(tarifa.ToString());
            }
        }
    }
}
