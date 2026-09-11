using System;
using System.Collections.Generic;

class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static List<Vendedor> vendedores = new List<Vendedor>();
    static List<Moto> motos = new List<Moto>();
    static List<Carro> carros = new List<Carro>();
    static List<Venda> vendas = new List<Venda>();

    static int contadorIdCliente = 1;
    static int contadorIdVendedor = 1;
    static int contadorIdVeiculo = 1;
    static int contadorIdVenda = 1;

    class Venda
    {
        public int Id;
        public Cliente Cliente;
        public Vendedor Vendedor;
        public Veiculo Veiculo;
        public float ValorFinal;

        public Venda(int id, Cliente cliente, Vendedor vendedor, Veiculo veiculo, float valorFinal)
        {
            Id = id;
            Cliente = cliente;
            Vendedor = vendedor;
            Veiculo = veiculo;
            ValorFinal = valorFinal;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"--- Dados da Venda {Id} ---");
            Console.WriteLine($"Vendedor: {Vendedor.Nome} (ID: {Vendedor.Id})");
            Console.WriteLine($"Cliente: {Cliente.Nome} (ID: {Cliente.Id})");
            Console.WriteLine($"Veiculo: {Veiculo.Marca} {Veiculo.Modelo} (ID: {Veiculo.Id})");
            Console.WriteLine($"Valor Final: R${ValorFinal}");
        }
    }

    abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
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
            Console.WriteLine($"--- Dados do Vendedor ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
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
            Console.WriteLine($"--- Dados do Cliente ---");
            Console.WriteLine($"ID: {Id}");
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
        public int QuantidadeEstoque;

        protected Veiculo(int id, string marca, string modelo, int ano, float preco, string cor, int quantidadeEstoque)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Preco = preco;
            Cor = cor;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public abstract void ExibirDados();
    }

    class Carro : Veiculo
    {
        public int QuantidadePortas;
        public string TipoCombustivel;

        public Carro(int id, string marca, string modelo, int ano, float preco, string cor, int quantidadeEstoque, int quantidadePortas, string tipoCombustivel) : base(id, marca, modelo, ano, preco, cor, quantidadeEstoque)
        {
            QuantidadePortas = quantidadePortas;
            TipoCombustivel = tipoCombustivel;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"--- Dados do Carro ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Preco: R${Preco}");
            Console.WriteLine($"Quantidade em Estoque: {QuantidadeEstoque}");
            Console.WriteLine($"Quantidade de portas: {QuantidadePortas}");
            Console.WriteLine($"Tipo de combustível: {TipoCombustivel}");
        }
    }

    class Moto : Veiculo
    {
        public int Cilindradas;
        public string TipoPartida;

        public Moto(int id, string marca, string modelo, int ano, float preco, string cor, int quantidadeEstoque, int cilindradas, string tipoPartida) : base(id, marca, modelo, ano, preco, cor, quantidadeEstoque)
        {
            Cilindradas = cilindradas;
            TipoPartida = tipoPartida;
        }

        public override void ExibirDados()
        {
            Console.WriteLine($"--- Dados da Moto ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Preco: R${Preco}");
            Console.WriteLine($"Quantidade em Estoque: {QuantidadeEstoque}");
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
        Console.WriteLine("\n========================================");
        Console.WriteLine("        AUTOSHOPPING - GESTÃO");
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
        Console.WriteLine("\nDigite a sua opção: ");
        
        return int.Parse(Console.ReadLine());
    }

    private static void Opcoes(int op)
    {
        switch (op)
        {
            case 1: CadastrarCliente(); break;
            case 2: CadastrarVendedor(); break;
            case 3: CadastroVeiculo(); break;
            case 4: ListagemVeiculo(); break;
            case 5: ListarCliente(); break;
            case 6: ListarVendedor(); break;
            case 7: RealizarVenda(); break;
            case 8: ListarVendas(); break;
            default: Console.WriteLine("Saindo..."); break;
        }
    }

    private static void RealizarVenda()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        REALIZAR VENDA");
        Console.WriteLine("========================================");

        if (vendedores.Count == 0 || clientes.Count == 0 || (carros.Count == 0 && motos.Count == 0))
        {
            Console.WriteLine("\nErro: Cadastre pelo menos 1 cliente, 1 vendedor e 1 veículo antes de vender!\n");
            return;
        }

        // --- BUSCA DO VENDEDOR COM DESEMPATE ---
        Vendedor vendedor = null;
        while (vendedor == null)
        {
            Console.Write("Digite o ID ou Nome do Vendedor: ");
            string entradaVendedor = Console.ReadLine();
            bool isIdVendedor = int.TryParse(entradaVendedor, out int idVendedorBusca);

            List<Vendedor> vendedoresEncontrados = new List<Vendedor>();

            if (isIdVendedor)
                vendedoresEncontrados = vendedores.FindAll(v => v.Id == idVendedorBusca);
            else
                vendedoresEncontrados = vendedores.FindAll(v => v.Nome.Equals(entradaVendedor, StringComparison.OrdinalIgnoreCase));

            if (vendedoresEncontrados.Count == 0)
            {
                Console.WriteLine("Nenhum vendedor encontrado. Tente novamente.\n");
            }
            else if (vendedoresEncontrados.Count == 1)
            {
                vendedor = vendedoresEncontrados[0];
            }
            else
            {
                Console.WriteLine("\nEncontramos mais de um vendedor com esse nome. Por favor, escolha pelo ID:");
                foreach (Vendedor v in vendedoresEncontrados)
                {
                    Console.WriteLine($"ID: {v.Id} | Nome: {v.Nome} | CPF: {v.Cpf}");
                }
                Console.Write("Digite o ID exato do vendedor escolhido: ");
                if (int.TryParse(Console.ReadLine(), out int idEscolhido))
                {
                    vendedor = vendedoresEncontrados.Find(v => v.Id == idEscolhido);
                    if (vendedor == null) Console.WriteLine("ID inválido. Tente novamente.\n");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.\n");
                }
            }
        }

        // --- BUSCA DO CLIENTE COM DESEMPATE ---
        Cliente cliente = null;
        while (cliente == null)
        {
            Console.Write("Digite o ID ou Nome do Cliente: ");
            string entradaCliente = Console.ReadLine();
            bool isIdCliente = int.TryParse(entradaCliente, out int idClienteBusca);

            List<Cliente> clientesEncontrados = new List<Cliente>();

            if (isIdCliente)
                clientesEncontrados = clientes.FindAll(c => c.Id == idClienteBusca);
            else
                clientesEncontrados = clientes.FindAll(c => c.Nome.Equals(entradaCliente, StringComparison.OrdinalIgnoreCase));

            if (clientesEncontrados.Count == 0)
            {
                Console.WriteLine("Nenhum cliente encontrado. Tente novamente.\n");
            }
            else if (clientesEncontrados.Count == 1)
            {
                cliente = clientesEncontrados[0];
            }
            else
            {
                Console.WriteLine("\nEncontramos mais de um cliente com esse nome. Por favor, escolha pelo ID:");
                foreach (Cliente c in clientesEncontrados)
                {
                    Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | CPF: {c.Cpf}");
                }
                Console.Write("Digite o ID exato do cliente escolhido: ");
                if (int.TryParse(Console.ReadLine(), out int idEscolhido))
                {
                    cliente = clientesEncontrados.Find(c => c.Id == idEscolhido);
                    if (cliente == null) Console.WriteLine("ID inválido. Tente novamente.\n");
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.\n");
                }
            }
        }

        // --- TIPO DE VEÍCULO ---
        int tipoVeiculo = 0;
        while (tipoVeiculo != 1 && tipoVeiculo != 2)
        {
            Console.WriteLine("Qual o tipo de veículo? (1 - Moto | 2 - Carro): ");
            if (!int.TryParse(Console.ReadLine(), out tipoVeiculo) || (tipoVeiculo != 1 && tipoVeiculo != 2))
                Console.WriteLine("Tente novamente.\n");
        }

        // --- BUSCA DO VEÍCULO COM DESEMPATE ---
        Veiculo veiculoVendido = null;
        
        while (veiculoVendido == null)
        {
            Console.Write("Digite o ID, Marca ou Modelo do Veículo escolhido: ");
            string entradaVeiculo = Console.ReadLine();
            bool isIdVeiculo = int.TryParse(entradaVeiculo, out int idVeiculoBusca);

            if (tipoVeiculo == 1) // LÓGICA PARA MOTO
            {
                List<Moto> motosEncontradas = new List<Moto>();
                
                if (isIdVeiculo)
                    motosEncontradas = motos.FindAll(m => m.Id == idVeiculoBusca);
                else
                    motosEncontradas = motos.FindAll(m => m.Modelo.Equals(entradaVeiculo, StringComparison.OrdinalIgnoreCase) || m.Marca.Equals(entradaVeiculo, StringComparison.OrdinalIgnoreCase));

                if (motosEncontradas.Count == 0)
                {
                    Console.WriteLine("Nenhuma moto encontrada. Tente novamente.\n");
                }
                else if (motosEncontradas.Count == 1)
                {
                    veiculoVendido = motosEncontradas[0]; // Só achou uma, seleciona automático
                }
                else
                {
                    Console.WriteLine("\nEncontramos mais de uma moto com esse nome. Por favor, escolha pelo ID:");
                    foreach (Moto m in motosEncontradas)
                    {
                        Console.WriteLine($"ID: {m.Id} | {m.Marca} {m.Modelo} | Preço: R${m.Preco}");
                    }
                    Console.Write("Digite o ID exato da moto escolhida: ");
                    if (int.TryParse(Console.ReadLine(), out int idEscolhido))
                    {
                        veiculoVendido = motosEncontradas.Find(m => m.Id == idEscolhido);
                        if (veiculoVendido == null) Console.WriteLine("ID inválido. Tente novamente.\n");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.\n");
                    }
                }

                // Remove do estoque se encontrou e confirmou
                if (veiculoVendido != null)
                {
                    veiculoVendido.QuantidadeEstoque--; 
                    if (veiculoVendido.QuantidadeEstoque == 0) motos.Remove((Moto)veiculoVendido); 
                }
            }
            else if (tipoVeiculo == 2) // LÓGICA PARA CARRO
            {
                List<Carro> carrosEncontrados = new List<Carro>();
                
                if (isIdVeiculo)
                    carrosEncontrados = carros.FindAll(c => c.Id == idVeiculoBusca);
                else
                    carrosEncontrados = carros.FindAll(c => c.Modelo.Equals(entradaVeiculo, StringComparison.OrdinalIgnoreCase) || c.Marca.Equals(entradaVeiculo, StringComparison.OrdinalIgnoreCase));

                if (carrosEncontrados.Count == 0)
                {
                    Console.WriteLine("Nenhum carro encontrado. Tente novamente.\n");
                }
                else if (carrosEncontrados.Count == 1)
                {
                    veiculoVendido = carrosEncontrados[0]; // Só achou um, seleciona automático
                }
                else
                {
                    Console.WriteLine("\nEncontramos mais de um carro com esse nome. Por favor, escolha pelo ID:");
                    foreach (Carro c in carrosEncontrados)
                    {
                        Console.WriteLine($"ID: {c.Id} | {c.Marca} {c.Modelo} | Preço: R${c.Preco}");
                    }
                    Console.Write("Digite o ID exato do carro escolhido: ");
                    if (int.TryParse(Console.ReadLine(), out int idEscolhido))
                    {
                        veiculoVendido = carrosEncontrados.Find(c => c.Id == idEscolhido);
                        if (veiculoVendido == null) Console.WriteLine("ID inválido. Tente novamente.\n");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.\n");
                    }
                }

                // Remove do estoque se encontrou e confirmou
                if (veiculoVendido != null)
                {
                    veiculoVendido.QuantidadeEstoque--;
                    if (veiculoVendido.QuantidadeEstoque == 0) carros.Remove((Carro)veiculoVendido);
                }
            }
        }

        float valorFinal = veiculoVendido.Preco - (veiculoVendido.Preco * (cliente.PercentualDesconto / 100));
        Venda novaVenda = new Venda(contadorIdVenda++, cliente, vendedor, veiculoVendido, valorFinal);
        vendas.Add(novaVenda);

        Console.WriteLine($"\nvoce comprou {veiculoVendido.Marca} {veiculoVendido.Modelo} com o vendedor {vendedor.Nome} , no valor de R${veiculoVendido.Preco}\n");
    }

    private static void ListarVendas()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        RELATÓRIO DE VENDAS");
        Console.WriteLine("========================================");

        if (vendas.Count == 0)
        {
            Console.WriteLine("\nNenhuma venda realizada ainda.\n");
            return;
        }

        foreach (Venda v in vendas)
        {
            v.ExibirDados();
            Console.WriteLine();
        }
    }

    private static void CadastrarCliente()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        CADASTRO DE CLIENTE");
        Console.WriteLine("========================================");

        int id = contadorIdCliente++;
        Console.WriteLine("Digite o nome do cliente: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do cliente: ");
        string cpf = Console.ReadLine();
        Console.WriteLine("Digite o percentual de desconto do cliente: ");
        float percentualDesconto = float.Parse(Console.ReadLine());

        clientes.Add(new Cliente(id, nome, telefone, cpf, percentualDesconto));
        Console.WriteLine($"\nCadastro realizado! ID do Cliente gerado: {id}\n");
    }

    private static void ListarCliente()
    {
        if (clientes.Count == 0) Console.WriteLine("\nNenhum cliente cadastrado.\n");
        foreach (Cliente c in clientes)
        {
            Console.WriteLine("\n");
            c.ExibirDados();
        }
    }

    private static void CadastrarVendedor()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        CADASTRO DE VENDEDOR");
        Console.WriteLine("========================================");

        int id = contadorIdVendedor++;
        Console.WriteLine("Digite o nome do vendedor: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o telefone do vendedor: ");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do vendedor: ");
        string cpf = Console.ReadLine();
        Console.WriteLine("Digite a matrícula do vendedor: ");
        string matricula = Console.ReadLine();
        Console.WriteLine("Digite o percentual de comissão do vendedor: ");
        float percentualComissao = float.Parse(Console.ReadLine());

        vendedores.Add(new Vendedor(id, nome, telefone, cpf, matricula, percentualComissao));
        Console.WriteLine($"\nCadastro realizado! ID do Vendedor gerado: {id}\n");
    }

    private static void ListarVendedor()
    {
        if (vendedores.Count == 0) Console.WriteLine("\nNenhum vendedor cadastrado.\n");
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
            Console.WriteLine("        CADASTRO DE VEÍCULO");
            Console.WriteLine("========================================");
            Console.WriteLine("1 - Cadastrar Moto");
            Console.WriteLine("2 - Cadastrar Carro");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("\nDigite a sua opção: ");
            op = int.Parse(Console.ReadLine());

            if (op == 1) CadastrarMoto();
            if (op == 2) CadastrarCarro();
        } while (op != 0 && op != 1 && op != 2);
    }

    private static void ListagemVeiculo()
    {
        int op = 0;
        do
        {
            Console.WriteLine("========================================");
            Console.WriteLine("        LISTA DE VEÍCULO");
            Console.WriteLine("========================================");
            Console.WriteLine("1 - Listar Motos");
            Console.WriteLine("2 - Listar Carros");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("\nDigite a sua opção: ");
            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                if (motos.Count == 0) Console.WriteLine("\nNenhuma moto cadastrada.\n");
                foreach (Moto m in motos) m.ExibirDados();
            }
            if (op == 2)
            {
                if (carros.Count == 0) Console.WriteLine("\nNenhum carro cadastrado.\n");
                foreach (Carro c in carros) c.ExibirDados();
            }
        } while (op != 0);
    }

    private static void CadastrarMoto()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        CADASTRAR MOTO");
        Console.WriteLine("========================================");
        
        int id = contadorIdVeiculo++;
        Console.Write("Digite a marca: ");
        string marca = Console.ReadLine();
        Console.Write("Digite o modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Digite o ano: ");
        int ano = int.Parse(Console.ReadLine());
        Console.Write("Digite o preco: ");
        float preco = float.Parse(Console.ReadLine());
        Console.Write("Digite a cor: ");
        string cor = Console.ReadLine();
        Console.Write("Digite a quantidade em estoque: ");
        int quantidade = int.Parse(Console.ReadLine());
        Console.Write("Digite a cilindrada: ");
        int cilindrada = int.Parse(Console.ReadLine());
        Console.Write("Digite o tipo de partida: ");
        string tipoPartida = Console.ReadLine();

        motos.Add(new Moto(id, marca, modelo, ano, preco, cor, quantidade, cilindrada, tipoPartida));
        Console.WriteLine($"\nCadastro realizado! ID do Veículo gerado: {id}\n");
    }

    private static void CadastrarCarro()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("        CADASTRAR CARRO");
        Console.WriteLine("========================================");
        
        int id = contadorIdVeiculo++;
        Console.Write("Digite a marca: ");
        string marca = Console.ReadLine();
        Console.Write("Digite o modelo: ");
        string modelo = Console.ReadLine();
        Console.Write("Digite o ano: ");
        int ano = int.Parse(Console.ReadLine());
        Console.Write("Digite o preco: ");
        float preco = float.Parse(Console.ReadLine());
        Console.Write("Digite a cor: ");
        string cor = Console.ReadLine();
        Console.Write("Digite a quantidade em estoque: ");
        int quantidade = int.Parse(Console.ReadLine());
        Console.Write("Digite a quantidade de portas: ");
        int portas = int.Parse(Console.ReadLine());
        Console.Write("Digite o tipo de combustível: ");
        string combustivel = Console.ReadLine();

        carros.Add(new Carro(id, marca, modelo, ano, preco, cor, quantidade, portas, combustivel));
        Console.WriteLine($"\nCadastro realizado! ID do Veículo gerado: {id}\n");
    }
}
