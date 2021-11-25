using System;
using ProjetoSeriesConsole.Interfaces;

namespace ProjetoSeriesConsole
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeriesDisponiveis();
                        break;
                    case "2":
                        ListarSeriesExcluidas();
                        break;
                    case "3":
                        InserirSerie();
                        break;
                    case "4":
                        AtualizarSerie();
                        break;
                    case "5":
                        ExcluirSerie();
                        break;
                    case "6":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("A Opcao {0} é inexistente", opcaoUsuario);
                        break;

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeriesDisponiveis()
        {
            Console.WriteLine("Listar séries Disponiveis");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                if (!serie.retornaExcluido())
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }

        }

        private static void ListarSeriesExcluidas()
        {
            Console.WriteLine("Listar séries Excluidas");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }


            foreach (var serie in lista)
            {
                if (serie.retornaExcluido())
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }

            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova séries");


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.WriteLine("Digite o genêro entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Inserir(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.WriteLine("Digite o genêro entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualizar(indiceSerie, novaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);


            Console.WriteLine("Deseja excluir esta série? ");
            Console.WriteLine(serie);
            Console.WriteLine("Digite S(sim) ou N(não)");
            Console.WriteLine();
            string resposta = Console.ReadLine();
            if (resposta.ToUpper() == "S")
            {
                repositorio.Excluir(indiceSerie);
            }

        }
        private static void VisualizarSerie()
        {

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            else
            {
                Console.WriteLine("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                if (indiceSerie >= lista.Count)
                {
                    Console.WriteLine("ID de série inexistente.");
                    return;
                }
                else
                {
                    var serie = repositorio.RetornaPorId(indiceSerie);

                    Console.WriteLine(serie);
                }

            }

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-----------Séries a seu dispor!!-------------");
            Console.WriteLine("Informe a opçao desejada:");

            Console.WriteLine("1 - Listar Séries Disponiveis");
            Console.WriteLine("2 - Listar Séries Excluidas");
            Console.WriteLine("3 - Inserir nova série");
            Console.WriteLine("4 - Atualizar série");
            Console.WriteLine("5 - Excluir série");
            Console.WriteLine("6 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair!!");
            Console.WriteLine();

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return ObterOpcaoUsuario;
        }


    }
}
