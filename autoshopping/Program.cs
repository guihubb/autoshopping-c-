using System;

class Program
{
    static List<Pessoa> pessoas = new List<Pessoa>();
    abstract class Pessoa
    {
        public int Id;
        public string Nome;
        public string Telefone;
        public string Cpf;

        protected Pessoa(int id, string nome, string telefone, string cpf)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
        }

        public abstract void ExibirDados();
    }

    class Vendedor : Pessoa
    {
        public string Matricula;
        public float PercentualComissao;

        public Vendedor(int id, string nome, string telefone, string cpf, string matricula, float percentualComissao) : base(id, nome, telefone, cpf)
        {
            Matricula = matricula;
            PercentualComissao = percentualComissao;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"--- Dados do Vendedor {Matricula}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Telefone: {Telefone}");
            Console.WriteLine($"Comissão: {PercentualComissao}%");
        }
    }

    class Cliente : Pessoa
    {
        public float PercentualDesconto;

        public Cliente(int id, string nome, string telefone, string cpf, float percentualDesconto) : base(id, nome, telefone, cpf)
        {
            PercentualDesconto = percentualDesconto;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"--- Dados do Cliente {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Telefone: {Telefone}");
            if (PercentualDesconto > 0)
            {
                Console.WriteLine($"Desconto: {PercentualDesconto}%");
            }
            else
            {
                Console.WriteLine($"Não possui desconto.");
            }
        }
    }
    static void Main(string[] args)
    {
        int op;

        do
        {
            op = MenuPrincipal();
            if (op != 0)
            {
                Opcoes(op);
            }
        }while(op != 0);
    }

    private static int MenuPrincipal()
    {
        Console.WriteLine("\n");
        Console.WriteLine("========================================");
        Console.WriteLine("         AUTOSHOPPING - GESTÃO");
        Console.WriteLine("========================================");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Cadastrar Vendedor");
        Console.WriteLine("3 - Cadastrar Veículo");
        Console.WriteLine("4 - Listar Veículos Disponíveis");
        Console.WriteLine("5 - Listar Clientes");
        Console.WriteLine("6 - Listar Vendedores");
        Console.WriteLine("7 - Realizar Venda");
        Console.WriteLine("8 - Relatório de vendas");
        Console.WriteLine("0 - Sair");

        Console.WriteLine("\n");
        Console.WriteLine("Digite a sua opção: ");
        int op = int.Parse(Console.ReadLine());

        return op;
    }

    private static void Opcoes(int op)
    {
        switch (op)
        {
            case 1:
                CadastrarCliente();
                break;
            case 2:
                Console.WriteLine("Cadastro de vendedor");
                break;
            case 3:
                Console.WriteLine("Cadastro de veículo");
                break;
            case 4:
                Console.WriteLine("Listagem de veículos em estoque");
                break;
            case 5:
                ListarCliente();
                break;
            case 6:
                Console.WriteLine("Listagem de vendedores");
                break;
            case 7:
                Console.WriteLine("Realizar venda");
                break;
            case 8:
                Console.WriteLine("Relatório de vendas");
                break;
            default:
                Console.WriteLine("Saindo...");
                break;
        }
    }

    private static void CadastrarCliente()
    {
        Console.WriteLine("Digite o id do cliente: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o telefone do cliente");
        string telefone = Console.ReadLine();

        Console.WriteLine("Digite o CPF do cliente");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite o percentual de desconto do cliente:");
        float percentualDesconto = float.Parse(Console.ReadLine());

        pessoas.Add(new Cliente(id, nome, telefone, cpf, percentualDesconto));
    }

    private static void ListarCliente()
    {
        foreach (Cliente c in pessoas)
        {
            Console.WriteLine("\n");
            c.ExibirDados();
        }
    }
}