# Projeto de Feedbacks

Este projeto é uma API desenvolvida em ASP.NET para gerenciar feedbacks de projetos e colaboradores. Utiliza Oracle como banco de dados e está configurado para ser usado com Swagger para documentação e testes interativos.

## Índice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração do Ambiente](#configuração-do-ambiente)
- [Como Executar](#como-executar)
- [Endpoints da API](#endpoints-da-api)
- [CRUD Operações](#crud-operações)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Tecnologias Utilizadas

- **ASP.NET Core** - API Framework
- **Entity Framework Core** - ORM (Object-Relational Mapping)
- **Oracle** - Banco de Dados
- **Swagger** - Documentação e Testes Interativos

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Properties**: Contém os arquivos de configuração do projeto.
- **Controllers**: Contém os controladores da API que manipulam as requisições HTTP.
- **Data**: Contém o contexto do banco de dados e configurações do Entity Framework.
- **Dto**: Contém os objetos de transferência de dados.
- **Migrations**: Contém as migrações do banco de dados geradas pelo Entity Framework.
- **Models**: Contém as classes de domínio (ex.: `Colaborador`, `Projeto`).
- **Services**: Contém os serviços que implementam a lógica de negócios.

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

   Execute o comando a seguir no seu console do gerenciador de pacotes NuGet:
   ```bash
   Install-Package Microsoft.EntityFrameworkCore
   Install-Package Microsoft.EntityFrameworkCore.Design
   Install-Package Oracle.EntityFrameworkCore
   Install-Package Microsoft.EntityFrameworkCore.Tools
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
- - **GET** `/api/colaborador/BuscarColaboradorPorIdProjeto/{idProjeto}` - Obtém um colaborador específico pelo ID do projeto.
- **POST** `/api/Colaborador/CriarColaborador` - Adiciona um novo colaborador.
- **PUT** `/api/Colaborador/EditarColaborador` - Atualiza as informações de um colaborador.
- **DELETE** `/api/Colaborador/ExcluirColaborador` - Remove um colaborador.

### **Projetos**

- **GET** `/api/Projeto/ListarProjetos` - Obtém a lista de todos os projetos.
- **GET** `/api/Projeto/BuscarProjetoId/{idProjeto}` - Obtém um projeto específico pelo ID.
- - **GET** `/api/Projeto/BuscarProjetoPorIdColaborador/{idColaborador}` - Obtém um projeto específico pelo ID do colaborador.
- **POST** `/api/Projeto/CriarProjeto` - Adiciona um novo projeto.
- **PUT** `/api/Projeto/EditarProjeto` - Atualiza as informações de um projeto.
- **DELETE** `/api/Projeto/ExcluirProjeto` - Remove um projeto.

## CRUD Operações

Esta API suporta operações CRUD completas para as entidades `Colaborador` e `Projeto`.

- **Create (Criar)**: Adicionar novos registros ao banco de dados.
- **Read (Ler)**: Recuperar informações dos registros existentes.
- **Update (Atualizar)**: Modificar os registros existentes.
- **Delete (Excluir)**: Remover registros do banco de dados.

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

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
```

Certifique-se de substituir "https://github.com/seu-usuario/seu-repositorio.git" pelo URL real do seu repositório. Este README cobre as informações principais, como configuração, execução e utilização da API. Se precisar adicionar mais detalhes ou modificações, sinta-se à vontade para personalizar o conteúdo.
