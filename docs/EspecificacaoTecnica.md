# BarberControl – Especificação Técnica

## 1. Visão Geral

### 1.1. Contexto

O BarberControl é um sistema de gestão para barbearias, criado com o objetivo de organizar o dia a dia do negócio.

Muitas barbearias ainda usam agenda de papel ou aplicativos genéricos para controlar horários, clientes e serviços, o que dificulta:

- visualizar a agenda de todos os barbeiros em um único lugar
- evitar conflitos de agendamento
- ter histórico de atendimento dos clientes
- ter visibilidade básica de desempenho (serviços mais realizados, horários de pico, rentabilidade, etc.)

O sistema é desenvolvido como um projeto de estudo, com foco em boas práticas de back-end e front-end usando .NET 10, Blazor e SQL Server.

### 1.2. Objetivo do Sistema

O objetivo do BarberControl é:

- Centralizar o cadastro de clientes, barbeiros e serviços.
- Permitir o agendamento de horários de forma simples e visual.
- Evitar conflitos de horário para o mesmo barbeiro.
- Facilitar a consulta ao histórico de atendimentos de cada cliente.
- Facilitar a visualização de indicadores como rentabilidade.
- Servir como base para estudos de:
  - arquitetura em camadas
  - Entity Framework Core 10
  - ASP.NET Core Web API
  - Blazor como front-end
  - boas práticas de versionamento com Git/GitHub

### 1.3. Público-Alvo

- Donos de barbearia que desejam organizar:
  - agenda de atendimentos
  - cadastro de clientes
  - cadastro de barbeiros
  - serviços oferecidos
  - visibilidade de rentabilidade

- Barbeiros que desejam visualizar seus agendamentos do dia.

- Desenvolvedor que utiliza o sistema como ferramenta de estudo em .NET 10, Blazor e SQL Server.

## 2. Escopo do Projeto

### 2.1. Funcionalidades Iniciais (MVP)

O MVP do BarberControl deve contemplar:

1. **Cadastro de Clientes**
   - Criar, listar, editar e desativar clientes.
   - Campos principais: Nome, Telefone, E-mail (opcional), Data de Cadastro.

2. **Cadastro de Barbeiros**
   - Criar, listar, editar e desativar barbeiros.
   - Campos principais: Nome, Especialidades (texto livre), Ativo/Inativo.

3. **Cadastro de Serviços**
   - Criar, listar, editar e desativar serviços.
   - Campos principais: Nome, Descrição, Duração em minutos, Preço.

4. **Agendamento**
   - Criar agendamentos vinculando Cliente + Barbeiro + Serviço + Data/Hora.
   - Impedir conflitos de agendamento para o mesmo barbeiro no mesmo horário.
   - Listar agendamentos por dia, por barbeiro e por cliente.

5. **Funcionalidades à Parte (primeiras ideias de expansão)**
   - Criar visibilidades de rentabilidade para os barbeiros.
   - Implementação de IA para auxílio ao barbeiro no agendamento de clientes.
   - Visibilidade de lucro, horário de pico, etc.

6. **Infraestrutura Básica**
   - Banco de dados SQL Server com EF Core 10 (migrations configuradas).
   - API em ASP.NET Core para gerenciar as entidades acima.
   - Front-end em Blazor para consumir a API e exibir as telas básicas.

### 2.2. Funcionalidades Futuras (Roadmap)

- Autenticação e autorização (login de dono / barbeiro).
- Dashboard com métricas:
  - Horários de pico.
  - Serviços mais realizados.
  - Barbeiro com mais atendimentos.
  - Rentabilidade por barbeiro.
- Integração com WhatsApp/API de envio de mensagens para lembrete de horários.
- Recomendações com IA:
  - Sugerir melhor horário baseado em histórico de movimento.
  - Sugerir serviços complementares para o cliente.
- Sistema de caixa simples:
  - Registro de atendimentos pagos.
  - Relatório diário/mensal de faturamento estimado.

---

## 3. Requisitos Funcionais

Os requisitos funcionais descrevem **o que o sistema deve fazer**, de forma objetiva e testável.

### 3.1. Clientes

**RF001 – Cadastrar Cliente**
O sistema deve permitir o cadastro de novos clientes, com os seguintes campos obrigatórios:
- Nome
- Telefone

Campo opcional:
- E-mail

**RF002 – Listar Clientes**
O sistema deve permitir listar todos os clientes cadastrados, com possibilidade de:
- filtrar por nome
- filtrar por status (ativo/inativo) – se adotado no modelo

**RF003 – Editar Cliente**
O sistema deve permitir a edição dos dados de um cliente existente.

**RF004 – Desativar Cliente**
O sistema deve permitir desativar um cliente (soft delete), impedindo novos agendamentos para ele, mas mantendo o histórico.

### 3.2. Barbeiros

**RF005 – Cadastrar Barbeiro**
O sistema deve permitir o cadastro de barbeiros com os campos:
- Nome (obrigatório)
- Especialidades (texto livre, opcional)
- Status (Ativo/Inativo, padrão Ativo)

**RF006 – Listar Barbeiros**
O sistema deve listar todos os barbeiros cadastrados, com opção de filtro por status.

**RF007 – Editar Barbeiro**
O sistema deve permitir a edição dos dados de um barbeiro.

**RF008 – Ativar/Desativar Barbeiro**
O sistema deve permitir ativar/desativar um barbeiro.
Barbeiros inativos não devem aparecer como opção na criação de novos agendamentos.

### 3.3. Serviços

**RF009 – Cadastrar Serviço**
O sistema deve permitir o cadastro de serviços com:
- Nome (obrigatório)
- Descrição (opcional)
- Duração em minutos (obrigatório)
- Preço (obrigatório)

**RF010 – Listar Serviços**
O sistema deve listar serviços cadastrados, com opção de filtro por status (ativo/inativo) se adotado.

**RF011 – Editar Serviço**
O sistema deve permitir a edição dos dados de um serviço.

**RF012 – Desativar Serviço**
O sistema deve permitir desativar serviços, impedindo que sejam usados em novos agendamentos, sem apagar histórico.

### 3.4. Agendamentos

**RF013 – Criar Agendamento**
O sistema deve permitir criar um agendamento vinculando:
- Cliente
- Barbeiro
- Serviço
- Data
- Hora de início (e/ou horário estimado)

**RF014 – Impedir Conflito de Horário**
O sistema não deve permitir criar dois agendamentos para o **mesmo barbeiro** em horários que se sobreponham, considerando a duração do serviço.

**RF015 – Listar Agendamentos por Dia**
O sistema deve permitir listar agendamentos por data (ex.: agenda do dia), exibindo:
- horário
- cliente
- barbeiro
- serviço

**RF016 – Listar Agendamentos por Barbeiro**
O sistema deve permitir filtrar os agendamentos por barbeiro e período (ex.: dia/semana).

**RF017 – Listar Agendamentos por Cliente**
O sistema deve permitir visualizar o histórico de agendamentos de um determinado cliente.

**RF018 – Atualizar/Cancelar Agendamento**
O sistema deve permitir:
- atualizar a data/hora, barbeiro, serviço de um agendamento
- marcar um agendamento como cancelado, mantendo registro para fins de histórico

### 3.5. Relatórios / Visibilidade (primeira versão)

**RF019 – Visão de Agenda do Dia**
O sistema deve oferecer uma visão consolidada da agenda do dia para todos os barbeiros, para facilitar a operação diária.

**RF020 – Visão Básica de Rentabilidade (versão simples)**
Numa primeira versão, o sistema deve permitir:
- consultar total de serviços realizados em um período
- somar o valor total estimado (baseado nos preços de serviços)

(As versões mais completas de relatórios ficarão para o roadmap futuro.)

---

## 4. Requisitos Não Funcionais

Requisitos não funcionais descrevem **como** o sistema deve se comportar, em termos de qualidade, desempenho, segurança, etc.

### 4.1. Tecnologia e Plataforma

**RNF001 – Stack Tecnológica Back-end**
O back-end deve ser desenvolvido em:
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- SQL Server como banco de dados relacional

**RNF002 – Stack Tecnológica Front-end**
O front-end deve ser desenvolvido em:
- Blazor (Server ou WebAssembly, conforme decisão do projeto)
- Integração via HTTP com a API ASP.NET Core

### 4.2. Arquitetura e Organização

**RNF003 – Arquitetura em Camadas**
O sistema deve seguir uma organização em camadas/projetos separados, por exemplo:

- `Barbearia.Domain` → regras de negócio e entidades de domínio
- `Barbearia.Infrastructure` → acesso a dados, EF Core, migrations
- `Barbearia.Api` → exposição de endpoints REST
- `Barbearia.Blazor` → camada de apresentação (UI)
- `Barbearia.Tests` → testes automatizados

**RNF004 – Padrões de Código**
O projeto deve seguir boas práticas de código C#, incluindo:
- uso de `Nullable Reference Types` habilitado
- uso de `Implicit Usings`
- nomes de classes e namespaces consistentes
- separação de responsabilidades (SRP sempre que possível)

### 4.3. Desempenho e Escalabilidade

**RNF005 – Desempenho Inicial**
Para o MVP, o sistema deve suportar o uso simultâneo de:
- até alguns barbeiros
- alguns milhares de registros de clientes e agendamentos

Sem foco em alta escalabilidade neste momento, mas evitando decisões que impeçam crescimento futuro.

### 4.4. Segurança

**RNF006 – Comunicação**
A API deve ser preparada para rodar em HTTPS (ambiente real).
Em ambiente de desenvolvimento, pode ser usado certificado de desenvolvimento do ASP.NET Core.

**RNF007 – Autenticação (futuro)**
A implementação de autenticação/autorização será feita em fase posterior (fase de roadmap), mas o design da API deve permitir essa evolução sem grandes quebras.

### 4.5. Manutenibilidade

**RNF008 – Documentação**
O código deve ser acompanhado de:
- README na raiz do projeto
- este documento de Especificação Técnica
- comentários explicativos apenas onde necessário (evitar comentários redundantes)

**RNF009 – Testes**
O projeto deve contar com uma base inicial de testes automatizados (unitários ou de integração) no projeto `Barbearia.Tests`, começando pelos componentes de domínio mais críticos (ex.: regras de conflito de agendamento).

---

## 5. Arquitetura da Aplicação

(Esqueleto para preencher depois com mais detalhes.)

- Descrever os projetos (`Domain`, `Infrastructure`, `Api`, `Blazor`, `Tests`).
- Descrever o fluxo principal:
  - Blazor → chama API REST → API usa `BarbeariaDbContext` → SQL Server.
- Explicar onde ficam as regras de negócio (no `Domain`) e onde ficam as operações de persistência (no `Infrastructure`).

---

## 6. Modelagem de Domínio

(Esqueleto para preencher quando você quiser detalhar as entidades.)

Sugestão de seções aqui:

- Entidade **Cliente**
- Entidade **Barbeiro**
- Entidade **Servico**
- Entidade **Agendamento**
- Regras de negócio principais (ex.: validação de conflito de horários, etc.)

---

## 7. Banco de Dados

(Esqueleto – depois você pode colocar o diagrama ou descrever as tabelas.)

- Tabelas correspondentes às entidades de domínio.
- Estratégia de chave primária (int identity, por exemplo).
- Relações:
  - `Agendamento` → `Cliente` (N:1)
  - `Agendamento` → `Barbeiro` (N:1)
  - `Agendamento` → `Servico` (N:1)

---

## 8. API (Back-end)

(Esqueleto.)

- Endpoints planejados (ex.: `/api/clientes`, `/api/barbeiros`, `/api/servicos`, `/api/agendamentos`).
- Padrão de retorno (JSON, status codes, etc.).

---

## 9. Front-end (Blazor)

(Esqueleto.)

- Páginas previstas:
  - Lista/Cadastro de Clientes
  - Lista/Cadastro de Barbeiros
  - Lista/Cadastro de Serviços
  - Agenda (visualização de agendamentos)

---

## 10. Segurança e Autenticação

(Para detalhar quando você começar a parte de login.)

---

## 11. Observabilidade (Logs, Erros, etc.)

(Esqueleto.)

- Uso do logging padrão do ASP.NET Core.
- Estratégia futura para monitorar erros/exceções.

---

## 12. Roadmap Técnico e Próximos Passos

(Esqueleto para organizar milestones técnicos.)

- MVP:
  - CRUDs básicos
  - Agendamento com validação de conflito
  - Telas simples em Blazor
- Próximas fases:
  - Autenticação
  - Dashboards
  - Integrações externas
  - IA para recomendações