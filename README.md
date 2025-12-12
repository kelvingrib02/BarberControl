# 💈 BarberControl

Sistema de gestão para barbearias, focado em:

- controle de **clientes**
- **barbeiros**
- **serviços**
- **agendamentos**
- (futuro) visibilidade de **rentabilidade** e métricas do negócio

Projeto desenvolvido como estudo prático de:

- .NET 10
- ASP.NET Core Web API
- Blazor
- Entity Framework Core 10
- SQL Server
- Arquitetura em camadas (Domain / Infrastructure / API / UI)

---

## 🔍 Visão Geral

Muitas barbearias ainda usam:

- agenda de papel
- apps genéricos de calendário
- anotações soltas no WhatsApp

Isso dificulta:

- ver a agenda de todos os barbeiros em um único lugar
- evitar conflitos de horário
- manter histórico de atendimentos
- entender horários de pico, serviços mais vendidos, rentabilidade, etc.

O **BarberControl** nasce pra organizar isso de forma simples, focada e expandível.

---

## 🎯 Objetivos do Sistema

- Centralizar o **cadastro de clientes, barbeiros e serviços**
- Permitir **agendamento de horários** de forma simples e visual
- Evitar **conflitos de horários** para o mesmo barbeiro
- Guardar **histórico de atendimentos** por cliente
- Servir como base de estudo para:
  - arquitetura em camadas
  - ASP.NET Core Web API
  - EF Core 10 (migrations, DbContext, etc.)
  - Blazor como front-end
  - boas práticas de versionamento (Git/GitHub)

---

## 👤 Público-Alvo

- **Donos de barbearia** que querem:
  - organizar agenda
  - gerenciar clientes e barbeiros
  - ter visão básica de desempenho/rentabilidade

- **Barbeiros** que querem:
  - visualizar sua agenda diária de forma simples

- **Desenvolvedores** (tipo o Kelvin do presente e do futuro 😄) que querem:
  - estudar .NET 10, Blazor, Web API e EF Core
  - praticar arquitetura em camadas e boas práticas

---

## 🚀 Funcionalidades (MVP)

### 1. Cadastro de Clientes

- Criar, listar, editar e desativar clientes
- Campos principais:
  - Nome
  - Telefone
  - E-mail (opcional)
  - Data de Cadastro

### 2. Cadastro de Barbeiros

- Criar, listar, editar e desativar barbeiros
- Campos principais:
  - Nome
  - Especialidades (texto livre)
  - Ativo/Inativo

### 3. Cadastro de Serviços

- Criar, listar, editar e desativar serviços
- Campos principais:
  - Nome
  - Descrição
  - Duração em minutos
  - Preço

### 4. Agendamento

- Criar agendamentos vinculando:
  - Cliente
  - Barbeiro
  - Serviço
  - Data/Hora
- Impedir conflitos de agendamento para o **mesmo barbeiro** no **mesmo horário**
- Listar agendamentos:
  - por dia
  - por barbeiro
  - por cliente

### 5. Infraestrutura básica

- Banco **SQL Server** com:
  - `dbBarberControl` como banco principal
  - migrations via **EF Core 10**
- API em **ASP.NET Core** para gerenciar:
  - Clientes
  - Barbeiros
  - Serviços
  - Agendamentos
- Front-end em **Blazor** consumindo a API

---

## 🧭 Funcionalidades Futuras (Roadmap)

- Autenticação e autorização:
  - login de dono
  - login de barbeiro
- Dashboard com métricas:
  - horários de pico
  - serviços mais realizados
  - barbeiro com mais atendimentos
  - rentabilidade por barbeiro
- Integração com WhatsApp / API de mensagens:
  - lembrete de agendamentos
- Recomendações com IA:
  - melhores horários baseados em histórico
  - sugestão de serviços complementares
- Sistema de caixa simples:
  - registro de atendimentos pagos
  - relatório diário/mensal de faturamento estimado

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

```text
BarberControl/
  src/
    Barbearia.Domain/          -> Regras de negócio, entidades de domínio
    Barbearia.Infrastructure/  -> Acesso a dados (EF Core, DbContext, Migrations)
    Barbearia.Api/             -> ASP.NET Core Web API
    Barbearia.Blazor/          -> Front-end Blazor
  tests/
    Barbearia.Tests/           -> Testes automatizados (quando implementados)