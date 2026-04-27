# 📝 DayNotes API

<p align="center">
  API REST segura para gerenciamento de notas com autenticação JWT
</p>

<p align="center">
  <a href="https://www.linkedin.com/in/kau%C3%A3-daudt-848548345/">
    <img src="https://img.shields.io/badge/LinkedIn-Kauã_Daudt-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white"/>
  </a>
</p>

---

## 🚀 Visão geral

O **DayNotes API** é uma aplicação backend desenvolvida em **C# com .NET 8**, focada na criação e gerenciamento de anotações com autenticação segura.

O sistema garante que cada usuário tenha acesso exclusivo aos seus dados, aplicando controle de acesso baseado em identidade.

---

## ⚙️ Stack Tecnológica

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square\&logo=dotnet\&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Backend-239120?style=flat-square\&logo=c-sharp\&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-Core-512BD4?style=flat-square)
![SQLite](https://img.shields.io/badge/SQLite-Database-003B57?style=flat-square\&logo=sqlite\&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-Authentication-black?style=flat-square\&logo=jsonwebtokens\&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-API-85EA2D?style=flat-square\&logo=swagger\&logoColor=black)

---

## 📦 Dependências

```bash
Microsoft.AspNetCore.Authentication.JwtBearer (8.0.16)
Microsoft.EntityFrameworkCore.Sqlite (8.0.16)
Microsoft.EntityFrameworkCore.Design (8.0.16)
Swashbuckle.AspNetCore (6.6.2)
System.IdentityModel.Tokens.Jwt (8.17.0)
BCrypt.Net-Next (4.1.0)
```

---

## 🧱 Arquitetura

O projeto foi estruturado seguindo boas práticas de separação de responsabilidades:

* **Controllers** → definição dos endpoints
* **Services** → lógica de negócio
* **DTOs** → transferência de dados
* **Models** → entidades do sistema
* **Data** → contexto do banco
* **Migrations** → versionamento do banco

---

## 🔐 Autenticação e Segurança

A aplicação utiliza **JWT (JSON Web Token)** para autenticação.

### Implementações:

* Registro e login de usuários
* Geração de token JWT
* Proteção de rotas com `[Authorize]`
* Validação de acesso por usuário
* Hash de senha com BCrypt

### Exemplo de proteção:

```csharp
if (note.UserId != int.Parse(userId))
{
    return Forbid();
}
```

---

## 🗄️ Banco de Dados

O banco não é versionado no repositório.

Ele é criado automaticamente utilizando **Entity Framework Core Migrations**.

### 🔧 Como gerar o banco:

```bash
dotnet ef database update
```

Esse processo:

* Cria o banco SQLite
* Gera as tabelas
* Aplica toda a estrutura automaticamente

---

## 🚀 Execução do projeto

```bash
git clone https://github.com/SEU_USUARIO/daynotes-api.git
cd daynotes-api

dotnet restore
dotnet ef database update
dotnet run
```

---

## 🌐 Documentação (Swagger)

```text
http://localhost:5105/swagger
```

---

## 🔑 Autorização no Swagger

Após realizar login, copie o token retornado.

No botão **Authorize**, utilize apenas:

```text
SEU_TOKEN_AQUI
```

### ⚠️ Observação

O Swagger já adiciona automaticamente o prefixo `Bearer`.

---

## 🧪 Validação de autenticação

Utilize a rota:

```text
GET /api/Test
```

### Resultado esperado:

* ✔ `200 OK` → token válido
* ❌ `401 Unauthorized` → token inválido

---

## 📌 Funcionalidades

* ✔ Registro de usuários
* ✔ Login com JWT
* ✔ Criação de notas
* ✔ Listagem de notas por usuário
* ✔ Atualização de notas
* ✔ Exclusão de notas
* ✔ Controle de acesso por usuário

---

## 💼 Diferenciais Técnicos

* Arquitetura organizada e escalável
* Uso de DTOs para desacoplamento
* Segurança com JWT e validação de identidade
* Hash de senha com BCrypt
* Banco gerado via migrations (sem dependência de arquivos locais)
* Documentação interativa com Swagger

---

## 👨‍💻 Autor

Desenvolvido por **Kauã Daudt Gomes**

🔗 LinkedIn:
https://www.linkedin.com/in/kau%C3%A3-daudt-848548345/

---

## ⭐ Feedback

Se este projeto foi útil ou chamou sua atenção, considere deixar uma estrela ⭐ no repositório
