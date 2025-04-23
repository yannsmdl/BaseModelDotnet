# 🏗️ Projeto em .NET com Clean Architecture + Multitenancy + JWT + Auditoria

Este projeto foi desenvolvido em **.NET 8** seguindo os princípios da **Clean Architecture** e aplicando alguns conceitos de **CQRS (Command Query Responsibility Segregation)**.

## 🔧 Tecnologias e Arquitetura

- **.NET 9**
- **Clean Architecture**
- **CQRS (parcial)**
- **Entity Framework Core**
- **JWT para autenticação**
- **MediatR para orquestração de comandos e queries**
- **Swagger para documentação da API**
- **FluentValidation para validações**
- **PostgreSQL**

## ✨ Funcionalidades Implementadas

### 🔐 Autenticação e Sessões
- Autenticação de usuários via **JWT**.
- Controle de sessões com persistência no banco de dados.
- Invalidação automática de sessões antigas ao novo login.
- Verificação de token revogado em cada requisição autenticada.

### 🏢 Multitenancy
- Implementado suporte a múltiplos tenants (multiempresas).
- Resolução do tenant por meio de header HTTP (`X-Tenant-Url`).
- Isolamento de dados por tenant.

### 📊 Auditoria
- Toda operação de **criação, alteração e exclusão** é auditada automaticamente.
- Campos utilizados:
  - `CreatedBy`, `CreatedAt`
  - `UpdatedBy`, `UpdatedAt`
  - `DeletedBy`, `DeletedAt`
- Auditoria automatizada utilizando `IHttpContextAccessor` para obter o usuário logado.

### ✅ Padrões de Código
- Uso de **CommandHandlers** para escrita (mutations).
- **DTOs** separados por camada.
- Repositórios genéricos com injeção de dependência.
- `UnitOfWork` para controle de transações.

## 🚀 Como Executar

1. Configure a connection string e chaves JWT no `appsettings.json`.
2. Rode os migrations com o EF Core.
3. Execute a aplicação (`dotnet run`) e acesse a documentação em `/swagger`.

---

### 📬 Contato

Caso tenha dúvidas ou sugestões, sinta-se à vontade para abrir uma issue ou contribuir com pull requests!

