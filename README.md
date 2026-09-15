# 🚗 Autoshopping - Sistema de Gestão

Sistema em modo console desenvolvido em C# (.NET) para informatizar e automatizar o controle operacional de uma concessionária/revenda automotiva (*Autoshopping*). O projeto abrange desde o cadastro de pessoas e veículos até o processamento completo de vendas com regras de desconto, comissão e baixa automática de estoque.

---

## 👥 Integrantes

* **Guilherme Taborda**
* **Leonardo Miranda**
* **Daniel Tissi**

---

## 📌 Descrição do Projeto

### O Problema
Em revendedoras de veículos e concessionárias de pequeno e médio porte, a gestão manual ou por planilhas descentralizadas frequentemente resulta em:
* Inconsistências na disponibilidade do estoque (veículos vendidos continuando anunciados);
* Falhas no cálculo e aplicação de descontos acordados com clientes;
* Erros na apuração de comissões devidas aos consultores de vendas;
* Falta de rastreabilidade do histórico de transações e vendas efetuadas.

### A Solução
O **Autoshopping - Gestão** resolve esse cenário fornecendo um sistema centralizado e estruturado que:
1. Mantém o inventário atualizado de veículos disponíveis (carros e motos com suas características específicas).
2. Centraliza os dados de clientes (com seus respectivos percentuais de desconto) e da equipe de vendas (com percentuais de comissão e matrículas).
3. Automatiza a rotina de checkout/venda: calcula valores finais com descontos, apura a comissão do vendedor e efetua a baixa imediata do veículo do estoque ativo.
4. Gera relatórios consolidados de vendas para acompanhamento financeiro e operacional.

---

## ⚙️ Funcionalidades

### 1. Gestão de Pessoas
* **Cadastro e Listagem de Clientes:** Registra ID, Nome, Telefone, CPF e Percentual de Desconto individual.
* **Cadastro e Listagem de Vendedores:** Registra ID, Matrícula, Nome, Telefone, CPF e Percentual de Comissão.

### 2. Gestão de Estoque de Veículos
* **Cadastro de Carros:** Marca, modelo, ano, preço, cor, quantidade de portas e tipo de combustível.
* **Cadastro de Motos:** Marca, modelo, ano, preço, cor, cilindradas e tipo de partida.
* **Listagem de Veículos Disponíveis:** Consulta filtrada entre carros ou motos em estoque com detalhamento técnico completo.

### 3. Operação de Vendas
* **Processamento de Venda:**
  * Validação prévia de existência de clientes, vendedores e veículos em estoque.
  * Associação de Cliente, Vendedor e Veículo escolhido.
  * Cálculo dinâmico do desconto do cliente sobre o valor base do veículo.
  * Cálculo proporcional da comissão devida ao vendedor.
  * Baixa automática do veículo comercializado da lista de disponíveis.
  * Emissão de resumo imediato da transação no terminal.
* **Relatório de Vendas:** Listagem detalhada de todas as vendas já concluídas com histórico completo.

---

## 🛠️ Tecnologias e Conceitos Utilizados

* **C#:** Linguagem de programação principal.
* **.NET (Console Application):** Plataforma de execução e desenvolvimento.
* **Git & GitHub:** Versionamento de código e colaboração em equipe.
* **Programação Orientada a Objetos (POO):**
  * **Herança & Classes Abstratas:** Classe base `Pessoa` herdada por `Cliente` e `Vendedor`; Classe base `Veiculo` herdada por `Carro` e `Moto`.
  * **Polimorfismo:** Sobrescrita de métodos abstratos (`ExibirDados()`, `MarcarComoVendido()`).
  * **Encapsulamento & Associação de Classes:** A classe `Venda` integra instâncias de `Cliente`, `Vendedor` e `Veiculo`.

---

## 🚀 Como Executar o Projeto

1. **Pré-requisitos:** Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. **Clonar o Repositório:**
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd <NOME_DA_PASTA>
   ```
3. **Executar a Aplicação:**
   ```bash
   dotnet run
   ```
