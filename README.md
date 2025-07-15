# Desafio Técnico - Diagnóstico do Submarino

Esta é uma solução em C# para o desafio de diagnóstico de submarinos, que calcula o consumo de energia com base em um relatório de números binários.

## Descrição do Problema

O objetivo é calcular o consumo de energia de um submarino. Para isso, precisamos determinar a "taxa gama" e a "taxa épsilon" a partir de uma lista de números binários.

- A **taxa gama** é formada pelo bit *mais comum* em cada posição correspondente de todos os números do relatório.
- A **taxa épsilon** é formada pelo bit *menos comum* em cada posição.

O consumo de energia é o produto da versão decimal da taxa gama pela versão decimal da taxa épsilon.

## Tecnologias e Ferramentas

- **Linguagem**: C# 12
- **Plataforma**: .NET 8
- **Framework de Teste**: xUnit
- **Controle de Versão**: Git & GitHub

## Estrutura do Projeto

A solução foi dividida em três projetos para garantir uma boa separação de responsabilidades (Separation of Concerns):

- `SubmarineDiagnostics.App`: Aplicação de console responsável pela interação com o usuário (entrada de dados e exibição de resultados).
- `SubmarineDiagnostics.Core`: Biblioteca de classes que contém toda a lógica de negócio, algoritmos e regras. É o "cérebro" da aplicação.
- `SubmarineDiagnostics.Core.Tests`: Projeto dedicado aos testes unitários, garantindo a confiabilidade e a corretude da lógica de negócio.

Essa estrutura torna o código mais testável, reutilizável e fácil de manter.

## Padrões de Projeto e Algoritmos

### Algoritmo Principal

O algoritmo central itera sobre cada posição de bit (coluna) dos números binários de entrada. Para cada posição:

1. Conta a ocorrência de '0's e '1's em todos os números.
2. Com base na contagem, um bit é determinado para a taxa gama e outro para a taxa épsilon.
3. Os bits resultantes são concatenados para formar as strings binárias finais de cada taxa.
4. Finalmente, as strings binárias são convertidas para o formato decimal e multiplicadas.

Para implementar a lógica de forma elegante e extensível, foram adotados os seguintes padrões de projeto:

### 1. Strategy Pattern

- **O que é?** O padrão Strategy define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. Ele permite que o algoritmo varie independentemente dos clientes que o utilizam.

-**Onde foi usado?** Foi criada a interface `IRateCalculationStrategy` com duas implementações: `MostCommonBitStrategy` (para a taxa gama) e `LeastCommonBitStrategy` (para a taxa épsilon).

-**Por que foi escolhido?** A lógica para calcular a taxa gama e a taxa épsilon é quase idêntica, mudando apenas a regra de decisão do bit ("mais comum" vs. "menos comum"). Usar o padrão Strategy evitou duplicação de código e condicionais `if/else` complexas no serviço principal. Se no futuro uma nova taxa com uma terceira regra de cálculo for necessária (ex: "sempre escolher '1' em caso de empate"), bastaria criar uma nova classe de estratégia sem alterar o código existente, aderindo ao **Princípio Aberto/Fechado (Open/Closed Principle)**.

### 2. Facade Pattern

-**O que é?** O padrão Facade fornece uma interface unificada e simplificada para um conjunto de interfaces em um subsistema. Ele esconde a complexidade do sistema e fornece uma interface mais simples para o cliente.

-**Onde foi usado?** A classe `DiagnosticReportCalculator` atua como uma fachada.

-**Por que foi escolhido?** O cliente (neste caso, `Program.cs`) não precisa saber sobre estratégias, como as taxas são geradas ou como a conversão de binário para decimal é feita. Ele simplesmente instancia `DiagnosticReportCalculator` e chama um único método: `CalculatePowerConsumption()`. A fachada encapsula toda a complexidade de orquestrar a criação das estratégias e o cálculo das taxas, tornando a API do core da aplicação muito mais fácil de usar e entender.