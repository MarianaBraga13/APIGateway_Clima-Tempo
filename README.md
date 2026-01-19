# 🌤️ Weather Gateway — Documentação Completa

> Projeto de integração entre **ASP.NET Core Web API** e **React (TypeScript)** para consumo de uma API externa de clima, com **API Gateway**, **autenticação por API Key**, **Swagger**, **CORS** e **interface amigável**.

---

## 📌 1. Visão Geral do Projeto

O **Weather Gateway** é um projeto demonstrativo com foco em **boas práticas de integração**, **segurança**, **organização de código** e **clareza arquitetural**.

A aplicação é composta por dois módulos independentes:

- **Backend (API Gateway)** — ASP.NET Core (.NET)
- **Frontend (Interface Web)** — React + TypeScript + Tailwind CSS

### 🎯 Objetivo

Criar um **intermediário (API Gateway)** que:

- Recebe o nome de uma cidade
- Consome a **WeatherAPI.com**
- Retorna dados climáticos simplificados
- Protege o acesso com **API Key**
- Disponibiliza documentação interativa via **Swagger**

---

## 🧱 2. Arquitetura Geral

```
[ React (Frontend) ]
        |
        |  HTTP + X-API-Key
        v
[ ASP.NET Core API Gateway ]
        |
        |  HTTP (API Key externa)
        v
[ WeatherAPI.com ]
```

### 🔐 Camadas de Segurança

- **Frontend → Backend**: autenticação via `X-API-Key`
- **Backend → WeatherAPI**: autenticação via API Key externa

---

## ⚙️ 3. Tecnologias Utilizadas

### Backend

- C#
- ASP.NET Core Web API
- HttpClient
- Middleware customizado
- Swagger / OpenAPI (Swashbuckle)
- DotNetEnv (.env)
- CORS

### Frontend

- React
- TypeScript
- Vite
- Axios
- Tailwind CSS

---

## 🗂️ 4. Estrutura de Pastas

### Backend

```
WeatherGateway/
├── Controllers/
│   └── WeatherController.cs
├── Middleware/
│   └── ApiKeyMiddleware.cs
├── Services/
│   ├── IWeatherService.cs
│   └── WeatherService.cs
├── Models/
│   └── WeatherResponseDto.cs
├── Program.cs
├── appsettings.json
├── .env
```

### Frontend

```
weather-frontend/
├── src/
│   ├── components/
│   │   ├── WeatherCard.tsx
│   │   └── WeatherAnimation.tsx
│   ├── services/
│   │   └── weatherApi.ts
│   ├── App.tsx
│   └── main.tsx
├── vite.config.ts
├── tailwind.config.js
├── .env
```

---

## 🔐 5. Autenticação por API Key (Backend)

### Conceito

O backend é protegido por uma **API Key do cliente**, enviada no header:

```
X-API-Key: <chave-do-cliente>
```

### Middleware

O middleware intercepta todas as requisições:

- Verifica a existência do header
- Compara com a chave válida definida em variável de ambiente
- Retorna **401 Unauthorized** se inválida

Essa abordagem simula um **API Gateway real**.

---

## 🌍 6. Consumo da API Externa de Clima

O serviço `WeatherService`:

- Utiliza `HttpClient`
- Lê a chave da WeatherAPI via `.env`
- Constrói a URL dinamicamente
- Mapeia a resposta externa para um **DTO interno**

### Benefícios

- Frontend desacoplado
- Contrato estável
- Facilidade para trocar fornecedor de clima no futuro

---

## 📄 7. Swagger / OpenAPI

A API disponibiliza documentação interativa em:

```
http://localhost:5278/swagger
```

Funcionalidades:

- Teste direto dos endpoints
- Campo para informar `X-API-Key`
- Visualização dos modelos de dados

---

## 🎨 8. Frontend (React)

### Funcionalidades

- Campo de busca por cidade
- Comunicação com API Gateway via Axios
- Envio automático do header `X-API-Key`
- Exibição clara dos dados climáticos
- Animações leves conforme condição do clima

### Animações

- ☀️ Sol → rotação suave
- ☁️ Nublado → pulse
- ☔ Chuva → bounce
- 🌫️ Nevoeiro → fade

Tudo feito apenas com **CSS + Tailwind**, sem bibliotecas externas.

---

## 🌱 9. Variáveis de Ambiente

### Backend (`.env`)

```
WEATHER_API_KEY=chave_da_weatherapi
CLIENT_API_KEY=123456
```

### Frontend (`.env`)

```
VITE_API_BASE_URL=http://localhost:5278/api
VITE_API_KEY=123456
```

📌 Importante: nomes devem ser **exatamente iguais** aos usados no código.

---

## 🚀 10. Como Rodar o Projeto (Guia para Usuários)

### Pré-requisitos

- Node.js (LTS)
- .NET SDK 7 ou superior
- Conta gratuita na WeatherAPI.com

---

### 🔹 Backend

1. Acesse a pasta do backend
2. Crie o arquivo `.env`
3. Preencha as chaves
4. Execute:

```
dotnet restore
dotnet run
```

API disponível em:

```
http://localhost:5278
```

---

### 🔹 Frontend

1. Acesse a pasta `weather-frontend`
2. Crie o arquivo `.env`
3. Preencha as variáveis
4. Execute:

```
npm install
npm run dev
```

Aplicação disponível em:

```
http://localhost:5173
```

---

## 🧪 11. Testes Manuais

- Testar API via Swagger
- Testar acesso sem API Key (erro 401)
- Testar acesso com API Key válida
- Testar consumo via frontend

---

## 🧠 12. Decisões Técnicas Importantes

- Uso de TypeScript para segurança de tipos
- API Gateway para desacoplamento
- Middleware ao invés de filtros para autenticação
- Animações leves sem dependências
- Separação total de frontend e backend

---

## 📈 13. Possíveis Evoluções

- Autenticação JWT
- Cache de respostas
- Testes unitários
- Deploy com Docker
- Dark mode

---

## ✅ Conclusão

Este projeto demonstra:

- Integração real entre sistemas
- Segurança por API Key
- Organização de código
- Clareza arquitetural
- Experiência do usuário

Ele foi pensado para ser **didático**, **robusto** e **fácil de manter**.

---

✨ Projeto desenvolvido com foco em qualidade, clareza e boas práticas.

