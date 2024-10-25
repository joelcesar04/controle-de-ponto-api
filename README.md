# Controle de Ponto API

Esta é uma API RESTful para controle de ponto (Check-in e Check-out) desenvolvida em ASP.NET Core.

## Funcionalidades
- Realizar check-in e check-out dos funcionários.
- Consultar registros de ponto.
- Validações personalizadas para as operações.
- Autenticação e autorização de usuários.
- Gerenciamento de enums (status, tipo de ponto, etc.).
- Relatórios de horas trabalhadas.

## Tecnologias Utilizadas
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token) para autenticação
- Swagger (para documentação da API)

## Estrutura do Projeto
```bash
ControlePontoAPI/
│
├── Controllers/       # Controladores da API
├── Data/              # Contexto e configuração do banco de dados
├── Enums/             # Definição de enums usados na aplicação
├── Migrations/        # Arquivos de migração do banco de dados
├── Models/            # Modelos de dados
├── Repositories/      # Implementação de repositórios
├── Services/          # Lógica de negócios
├── Validations/       # Regras e validações personalizadas
├── appsettings.json   # Configurações do projeto
└── Program.cs         # Inicialização da aplicação
```
## Contribuições
Sinta-se à vontade para abrir issues e pull requests!
