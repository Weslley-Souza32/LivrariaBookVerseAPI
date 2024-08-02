# **BookVerse - API de Gerenciamento de Livraria**

## **Descrição**
BookVerse é uma API desenvolvida em C# e .NET 8, projetada para gerenciar uma livraria, permitindo o cadastro, edição, exclusão e consulta de livros e usuários. 
O sistema implementa autenticação e autorização com JWT, permitindo a diferenciação de papéis entre usuários comuns e administradores. Além disso, o projeto segue 
boas práticas de desenvolvimento, incluindo validações com Data Annotations, arquitetura limpa com padrão de camadas, e testes automatizados para garantir a robustez e qualidade do código.

## **Principais Funcionalidades**
- **Cadastro de Usuários:** Registro de usuários com validação de idade mínima e campos obrigatórios.
- **Gerenciamento de Livros:** Cadastro, edição e exclusão de livros com validação de ISBN único e controle de estoque.
- **Documentação:** Documentação da API com Swagger para facilitar a integração e testes.

## **Tecnologias Utilizadas**
- C# e .NET 8
- Entity Framework Core
- SQL Server
- Swagger

## **Como Executar**
1. Clone o repositório.
   ```bash
   git clone https://github.com/seu-usuario/bookverse.git

2. Configure a string de conexão com o banco de dados no arquivo appsettings.json.
3. Execute as migrações do Entity Framework para criar as tabelas do banco de dados.
   ```bash
   dotnet ef database update
4. Inicie a aplicação e acesse o Swagger para explorar e testar a API.
  
   
