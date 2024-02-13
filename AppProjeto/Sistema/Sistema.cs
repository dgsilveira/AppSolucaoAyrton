using AppProjeto.Entity;

namespace AppProjeto.Sistema
{
    public class Sistema
    {
        #region Propriedades
        public List<Pessoa> pessoas1 { get; set; }
        public List<Pessoa> pessoas2 { get; set; }
        #endregion

        #region Construtor
        public Sistema()
        {
            pessoas1 = new List<Pessoa>();
            pessoas2 = new List<Pessoa>();
        }
        #endregion

        #region Tela Inicial
        public void Iniciar()
        {
            InserirDados();

            int opcaoInicial = 0;
            do
            {
                MenuInicial();
                opcaoInicial = int.Parse(Console.ReadLine());
                switch (opcaoInicial)
                {
                    case 1:
                        Console.Clear();
                        Lista1();
                        break;
                    case 2:
                        Console.Clear();
                        Lista2();
                        break;
                    case 3:
                        Console.WriteLine("Saindo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opcaoInicial != 3);
        }

        private void MenuInicial()
        {
            Console.WriteLine("Digite 1 para lista 1");
            Console.WriteLine("Digite 2 para lista 2");
            Console.WriteLine("Digite 3 para sair");
        }
        #endregion

        #region Lista 1
        private void Lista1()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("LISTA 1");
                MenuListas();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        ResumoGeral(pessoas1);
                        break;
                    case 2:
                        Console.Clear();
                        Add(pessoas1);
                        break;
                    case 3:
                        Excluir(pessoas1);
                        Console.Clear();
                        break;
                    case 4:
                        Transferir(pessoas1, pessoas2);
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("Saindo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 5);
        }

        #endregion

        #region Lista 2
        private void Lista2()
        {
            Console.WriteLine("LISTA 2");
            MenuListas();
        }
        #endregion

        #region Listas Compartilhadas
        private void MenuListas()
        {
            Console.WriteLine("1 resumo geral\r\n2 Add\r\n3 Excluir\r\n4 Transferir\r\n5 Sair");
        }

        private void ResumoGeral(List<Pessoa> lista)
        {
            if (lista.Count == 0)
                Console.WriteLine("Lista vazia");
            else
            {
                foreach (Pessoa p in lista)
                {
                    Console.WriteLine(p.Id);
                    Console.WriteLine(p.Nome);
                    Console.WriteLine();
                }
            }
        }

        private void Add(List<Pessoa> lista)
        {
            Console.WriteLine("Digite o id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();

            var pessoa = new Pessoa(id, nome);

            lista.Add(pessoa);
        }

        private void Excluir(List<Pessoa> lista)
        {
            Console.WriteLine("1 - Buscar por Id");
            Console.WriteLine("2 - Buscar por Nome");

            int opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
            {
                Console.WriteLine("Digite o id");
                var id = int.Parse(Console.ReadLine());
                Pessoa pessoa = lista.Find(p => p.Id == id);

                lista.Remove(pessoa);

                Console.WriteLine($"Removido: {pessoa.Id} {pessoa.Nome}");

                Console.WriteLine("\nLista nova:");
                ResumoGeral(lista);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o nome");
                var nome = Console.ReadLine();
                Pessoa pessoa = lista.Find(p => p.Nome == nome);

                lista.Remove(pessoa);

                Console.WriteLine($"Removido: {pessoa.Id} {pessoa.Nome}");

                Console.WriteLine("\nLista nova:");
                ResumoGeral(lista);
                Console.ReadKey();
            }
        }

        private void Transferir(List<Pessoa> lista1, List<Pessoa> lista2)
        {
            Console.WriteLine("1 - Buscar por Id");
            Console.WriteLine("2 - Buscar por Nome");

            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Digite o id");
                var id = int.Parse(Console.ReadLine());
                Pessoa pessoa = lista1.Find(p => p.Id == id);

                lista1.Remove(pessoa);

                lista2.Add(pessoa);

                Console.WriteLine($"Transferido: {pessoa.Id} {pessoa.Nome}");

                Console.WriteLine("\nLista origem:");
                ResumoGeral(lista1);

                Console.WriteLine("\nLista destino:");
                ResumoGeral(lista2);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o nome");
                var nome = Console.ReadLine();
                Pessoa pessoa = lista1.Find(p => p.Nome == nome);

                lista1.Remove(pessoa);

                lista2.Add(pessoa);

                Console.WriteLine($"Removido: {pessoa.Id} {pessoa.Nome}");

                Console.WriteLine($"Transferido: {pessoa.Id} {pessoa.Nome}");

                Console.WriteLine("\nLista origem:");
                ResumoGeral(lista1);

                Console.WriteLine("\nLista destino:");
                ResumoGeral(lista2);
                Console.ReadKey();
            }
        }
        #endregion

        #region Métodos Privados

        private void InserirDados()
        {
            pessoas1.Add(new Pessoa(1, "Ayrton"));
            pessoas1.Add(new Pessoa(2, "Douglas"));
            pessoas1.Add(new Pessoa(3, "Andréa"));
            
            pessoas2.Add(new Pessoa(4, "Geisa"));
            pessoas2.Add(new Pessoa(5, "Sean"));
            pessoas2.Add(new Pessoa(6, "Cati"));
        }
        #endregion

    }
}
