# RPAdev

RPA (Robotic Process Automation) de busca de dados de cursos no site 'Alura'. Busca 1 curso por vez, nunca o mesmo.

## Índice

- [Exemplo de Funcionamento](#exemplo-de-funcionamento)
- [Tecnologias](#tecnologias)
- [Instalação](#instalação)

## Exemplo de Funcionamento

https://github.com/Gludke/RPAdev/assets/90224160/e7c1eac9-cf6f-4148-abc4-3231ea2f321e

## Tecnologias

Uso das seguintes tecnologias:

1. C# .NET 6
2. Selenium
3. EF Core
4. SQL Server
5. Blazor App Server
6. Uso de SOLID e Clean Code (Arquitetura DDD, etc)

## Instalação

1. Necessário possuir um 'SDK .NET 6' (URL Download abaixo).
```bash
https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
```
2. Necessário possuir o bando de dados 'SQL Server' local instalado (URL Download abaixo).
```bash
https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
```
3. Baixar o repositório.
4. No arquivo 'appsettings.json', trocar a URL de conexão 'ConnectionStrings' - 'Default' para a do seu bando de dados SQL Server.

Não é necessário criar o Banco de dados, isso será feito automaticamente pelo EF Core.
5. Executar as migrations conforme abaixo:

No Visual Sudio, abrir o 'Console do gerenciador de pacotes', selecionar o projeto 'RPAdev.Data' e executar o comando:
```bash
Update-database
```
No VS Code, abrir o 'Terminal', selecionar o projeto 'RPAdev.Data' e executar o comando:
```bash
dotnet ef database update
```
6. Executar/Debugar o projeto.






















