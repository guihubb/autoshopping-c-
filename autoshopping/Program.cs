using System;
using System.Net.NetworkInformation;

class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static List<Vendedor> vendedores = new List<Vendedor>();
    static List<Moto> motos = new List<Moto>();
    static List<Carro> carros = new List<Carro>();


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
            Console.WriteLine($"--- Dados do Vendedor {Matricula} ---");
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
            Console.WriteLine($"--- Dados do Cliente {Id} ---");
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

    abstract class Veiculo
    {
        public int Id;
        public string Marca;
        public string Modelo;
        public int Ano;
        public float Preco;
        public string Cor;

        protected Veiculo(int id, string marca, string modelo, int ano, float preco, string cor)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Preco = preco;
            Cor = cor;
        }

        public abstract void ExibirDados();
    }

    class Carro : Veiculo
    {
        public int QuantidadePortas;
        public string TipoCombustivel;

        public Carro(int id, string marca, string modelo, int ano, float preco, string cor, int quantidadePortas, string tipoCombustivel) : base(id, marca, modelo, ano, preco, cor)
        {
            QuantidadePortas = quantidadePortas;
            TipoCombustivel = tipoCombustivel;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"--- Dados do Carro {Id} ---");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Preco: R${Preco}");
            Console.WriteLine($"Quantidade de portas: {QuantidadePortas}");
            Console.WriteLine($"Tipo de combustível: {TipoCombustivel}");
        }
    }

    class Moto : Veiculo
    {
        public int Cilindradas;
        public string TipoPartida;

        public Moto(int id, string marca, string modelo, int ano, float preco, string cor, int cilindradas, string tipoPartida) : base(id, marca, modelo, ano, preco, cor)
        {
            Cilindradas = cilindradas;
            TipoPartida = tipoPartida;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"--- Dados da Moto {Id} ---");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Preco: R${Preco}");
            Console.WriteLine($"Cilindradas: {Cilindradas}");
            Console.WriteLine($"Tipo de partida: {TipoPartida}");
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
        } while (op != 0);
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
                CadastrarVendedor();
                break;
            case 3:
                CadastroVeiculo();
                break;
            case 4:
                ListagemVeiculo();
                break;
            case 5:
                ListarCliente();
                break;
            case 6:
                ListarVendedor();
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
        Console.WriteLine("========================================");
        Console.WriteLine("         CADASTRO DE CLIENTE");
        Console.WriteLine("========================================");

        Console.WriteLine("\nDigite o id do cliente: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o telefone do cliente");
        string telefone = Console.ReadLine();

        Console.WriteLine("Digite o CPF do cliente");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite o percentual de desconto do cliente:");
        float percentualDesconto = float.Parse(Console.ReadLine());

        clientes.Add(new Cliente(id, nome, telefone, cpf, percentualDesconto));

        Console.WriteLine("Cadastro realizado!");
    }

    private static void ListarCliente()
    {
        foreach (Cliente c in clientes)
        {
            Console.WriteLine("\n");
            c.ExibirDados();
        }
    }

    private static void CadastrarVendedor()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         CADASTRO DE VENDEDOR");
        Console.WriteLine("========================================");

        Console.WriteLine("\nDigite o id do vendedor: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nome do vendedor: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o telefone do vendedor");
        string telefone = Console.ReadLine();

        Console.WriteLine("Digite o CPF do vendedor");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite a matrícula do vendedor: ");
        string matricula = Console.ReadLine();

        Console.WriteLine("Digite o percentual de desconto do vendedor:");
        float percentualComissao = float.Parse(Console.ReadLine());

        vendedores.Add(new Vendedor(id, nome, telefone, cpf, matricula, percentualComissao));

        Console.WriteLine("Cadastro realizado!");
    }

    private static void ListarVendedor()
    {
        foreach (Vendedor v in vendedores)
        {
            Console.WriteLine("\n");
            v.ExibirDados();
        }
    }

    private static void CadastroVeiculo()
    {
        int op = 0;
        do
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         CADASTRO DE VEÍCULO");
            Console.WriteLine("========================================");

            Console.WriteLine("1 - Cadastrar Moto");
            Console.WriteLine("2 - Cadastrar Carro");
            Console.WriteLine("0 - Sair");

            Console.WriteLine("\n");
            Console.WriteLine("Digite a sua opção: ");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                CadastrarMoto();
                Console.WriteLine("Cadastro realizado!");
            }

            if (op == 2)
            {
                CadastrarCarro();
                Console.WriteLine("Cadastro realizado!");
            }
        } while (op != 0);
    }

    private static void ListagemVeiculo()
    {
        int op = 0;
        do
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         LISTA DE VEÍCULO");
            Console.WriteLine("========================================");

            Console.WriteLine("1 - Listar Motos");
            Console.WriteLine("2 - Listar Carros");
            Console.WriteLine("0 - Sair");

            Console.WriteLine("\n");
            Console.WriteLine("Digite a sua opção: ");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                foreach (Moto m in motos)
                {
                    m.ExibirDados();
                }
            }

            if (op == 2)
            {

                foreach (Carro c in carros)
                {
                    c.ExibirDados();
                }
            }
        } while (op != 0);
    }

    private static void CadastrarMoto()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         CADASTRAR MOTO");
        Console.WriteLine("========================================");

        Console.WriteLine("\nDigite o id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Digite a marca: ");
        string marca = Console.ReadLine();

        Console.Write("Digite o modelo: ");
        string modelo = Console.ReadLine();

        Console.Write("Digite o ano: ");
        int ano = int.Parse(Console.ReadLine());

        Console.Write("Digite o preco: ");
        float preco = float.Parse(Console.ReadLine());

        Console.WriteLine("Digite a cor: ");
        string cor = Console.ReadLine();

        Console.Write("Digite a cilindrada: ");
        int cilindrada = int.Parse(Console.ReadLine());

        Console.Write("Digite o tipo de partida: ");
        string tipoPartida = Console.ReadLine();

        motos.Add(new Moto(id, marca, modelo, ano, preco, cor, cilindrada, tipoPartida));
    }

    private static void CadastrarCarro()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         CADASTRAR CARRO");
        Console.WriteLine("========================================");

        Console.WriteLine("\nDigite o id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Digite a marca: ");
        string marca = Console.ReadLine();

        Console.Write("Digite o modelo: ");
        string modelo = Console.ReadLine();

        Console.Write("Digite o ano: ");
        int ano = int.Parse(Console.ReadLine());

        Console.Write("Digite o preco: ");
        float preco = float.Parse(Console.ReadLine());

        Console.WriteLine("Digite a cor: ");
        string cor = Console.ReadLine();

        Console.Write("Digite a quantidade de portas: ");
        int portas = int.Parse(Console.ReadLine());

        Console.Write("Digite o tipo de combustível: ");
        string combustível = Console.ReadLine();

        carros.Add(new Carro(id, marca, modelo, ano, preco, cor, portas, combustível));
    }
}