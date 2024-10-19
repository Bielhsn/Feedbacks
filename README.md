# Projeto de Feedbacks

Este projeto é uma API desenvolvida em ASP.NET para gerenciar feedbacks de projetos e colaboradores. Utiliza Oracle como banco de dados e está configurado para ser usado com Swagger para documentação e testes interativos.

## Índice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração do Ambiente](#configuração-do-ambiente)
- [Como Executar](#como-executar)
- [Endpoints da API](#endpoints-da-api)
- [CRUD Operações](#crud-operações)
- [Testes Implementados](#testes-implementados)
- [Prática de Clean Code]()
- [Funcionalidades de IA Generativa]()
- [Contribuição](#contribuição)

## Tecnologias Utilizadas

- **ASP.NET Core** - API Framework
- **Entity Framework Core** - ORM (Object-Relational Mapping)
- **Oracle** - Banco de Dados
- **Swagger** - Documentação e Testes Interativos
- **XuNIT** - Framework de testes
- **ML.NET** - Biblioteca para Machine Learning

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Properties**: Contém os arquivos de configuração do projeto.
- **Controllers**: Contém os controladores da API que manipulam as requisições HTTP.
- **Data**: Contém o contexto do banco de dados e configurações do Entity Framework.
- **Dto**: Contém os objetos de transferência de dados.
- **Migrations**: Contém as migrações do banco de dados geradas pelo Entity Framework.
- **Models**: Contém as classes de domínio (ex.: `Colaborador`, `Projeto`).
- **Services**: Contém os serviços que implementam a lógica de negócios.
- **Tests**: Contém os testes unitários e de integração usando xUnit.
- **MLModels**: Contém os modelos de Machine Learning e a lógica relacionada à IA generativa.

## Configuração do Ambiente

1. **Clone o Repositório**:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```

2. **Instale as Dependências**:

   Certifique-se de ter instalado o pacote NuGet:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.Design`
   - `Oracle.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.Tools`
   - `Microsoft.ML`
   - `System.Net.Http`
   - `xunit`
   - `xunit.runner.visualstudio`
   - `Moq`
   - `Microsoft.AspNetCore.Mvc.Testing`
   Execute o comando a seguir no seu console do gerenciador de pacotes NuGet:
   ```bash
   Install-Package Microsoft.EntityFrameworkCore
   Install-Package Microsoft.EntityFrameworkCore.Design
   Install-Package Oracle.EntityFrameworkCore
   Install-Package Microsoft.EntityFrameworkCore.Tools
   Install-Package Microsoft.ML
   dotnet add package System.Net.Http
   dotnet add package xunit
   dotnet add package xunit.runner.visualstudio
   dotnet add package Moq
   dotnet add package Microsoft.AspNetCore.Mvc.Testing
   ```

3. **Configuração do Banco de Dados**:

   Certifique-se de que o banco de dados Oracle está instalado e configurado corretamente. Atualize a string de conexão no arquivo `appsettings.json` com suas credenciais de banco de dados Oracle.

   ```json
   "ConnectionStrings": {
      "DefaultConnection": "User Id=seuUsuario;Password=suaSenha;Data Source=suaFonteDeDados"
   }
   ```

4. **Aplicar Migrações e Atualizar o Banco de Dados**:

   Gere as migrações necessárias e atualize o banco de dados com os seguintes comandos:

   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```

## Como Executar

1. **Inicie o Projeto**:

   Utilize o Visual Studio ou execute o seguinte comando no terminal:

   ```bash
   dotnet run
   ```

2. **Acessar a Documentação da API**:

   Após iniciar a aplicação, abra seu navegador e vá para `http://localhost:5000/swagger` para acessar o Swagger UI.

## Endpoints da API

### **Colaboradores**

- **GET** `/api/Colaborador/ListarColaboradores` - Obtém a lista de todos os colaboradores.
- **GET** `/api/colaborador/BuscarColaboradorPorId/{idColaborador}` - Obtém um colaborador específico pelo ID.
- **GET** `/api/colaborador/BuscarColaboradorPorIdProjeto/{idProjeto}` - Obtém um colaborador específico pelo ID do projeto.
- **POST** `/api/Colaborador/CriarColaborador` - Adiciona um novo colaborador.
- **PUT** `/api/Colaborador/EditarColaborador` - Atualiza as informações de um colaborador.
- **DELETE** `/api/Colaborador/ExcluirColaborador` - Remove um colaborador.

### **Projetos**

- **GET** `/api/Projeto/ListarProjetos` - Obtém a lista de todos os projetos.
- **GET** `/api/Projeto/BuscarProjetoId/{idProjeto}` - Obtém um projeto específico pelo ID.
- **GET** `/api/Projeto/BuscarProjetoPorIdColaborador/{idColaborador}` - Obtém um projeto específico pelo ID do colaborador.
- **POST** `/api/Projeto/CriarProjeto` - Adiciona um novo projeto.
- **PUT** `/api/Projeto/EditarProjeto` - Atualiza as informações de um projeto.
- **DELETE** `/api/Projeto/ExcluirProjeto` - Remove um projeto.

## CRUD Operações

Esta API suporta operações CRUD completas para as entidades `Colaborador` e `Projeto`.

- **Create (Criar)**: Adicionar novos registros ao banco de dados.
- **Read (Ler)**: Recuperar informações dos registros existentes.
- **Update (Atualizar)**: Modificar os registros existentes.
- **Delete (Excluir)**: Remover registros do banco de dados.

## Testes Implementados

**Objetivo**: Garantir que a API funcione corretamente.

- **Estratégia de Testes**
   - **Testes Unitários**: Usando xUnit, foram implementados testes para validar a lógica de negócios em serviços e controladores.
   - **Testes de Integração**: Realizados para verificar a integração entre diferentes partes da API e o banco de dados.
   - **Localização dos Testes**: Todos os testes estão localizados na pasta **Tests*, organizados por tipo(unitários e de integração).

## Práticas de Clean Code

**Objetivo**: Melhorar a legibilidade e manutenibilidade do código.

   - **Implementações**
     - Seguir princípios de **SOLID** para manter classes e métodos coesos e com responsabilidades bem definidas.
     - Uso de nomes descritivos para métodos e variáveis, facilitando a compreensão.
     - Documentação de métodos e classes usando comentários e XML para gerar documentação automática.

## Funcionalidade de IA Generativa

**Objetivo**: Adicionar valor à API utilizando Machine Learning.

   - **Implementações**
        - Integração do **ML.NET** para criar modelos de aprendizado de máquina.
        - Implementação de funcionalidades de IA generativa para análise de feedbacks e sugestões personalizadas.
        - Os modelos de IA estão localizados na pasta **MLModels**, com a lógica de treinamento e predição devidamente documentada.
## Contribuição

<table>
  <tr>
        <td align="center">
      <a href="https://github.com/Bielhsn" title="Perfil Gabriel Henrique Souza">
        <img src="https://avatars.githubusercontent.com/u/113404490?v=4" width="100px;" alt="Gabriel Henrique Souza"/><br>
        <sub>
          <b>Gabriel Souza</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/rafak7" title="Perfil Rafael Lino">
        <img src="https://avatars.githubusercontent.com/u/126628341?v=4" width="100px;" alt="Rafael Lino"/><br>
        <sub>
          <b>Rafael Lino</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/bruno1098" title="Perfil Bruno Antunes">
        <img src="https://avatars.githubusercontent.com/u/115303980?v=4" width="100px;" alt="Bruno Antunes"/><br>
        <sub>
          <b>Bruno Antunes</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/B1el-Henr1" title="Perfil Gabriel Henrique Figueiredo">
        <img src="https://avatars.githubusercontent.com/u/160192324?v=4" width="100px;" alt="Gabriel Henrique Figueiredo"/><br>
        <sub>
          <b>Gabriel Figueiredo</b>
        </sub>
      </a>
    </td>
     <td align="center">
      <a href="https://github.com/Pedro-Ferrari" title="Perfil Pedro Henrique">
        <img src="https://avatars.githubusercontent.com/u/126732959?v=4" width="100px;" alt="Pedro Henrique"/><br>
        <sub>
          <b>Pedro Ferrari</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
