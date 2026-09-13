# Vagas Tech

Projeto desenvolvido em squad como desafio prático final do módulo de **Banco de Dados e Persistência de Dados** da WoMakersCode.

A proposta é desenvolver a persistência de dados de uma plataforma de vagas voltada para conectar empresas com vagas afirmativas a mulheres da área de tecnologia.

## Tecnologias utilizadas

- C#
- ADO.NET
- SQLite
- DBeaver
- Google Colab
- Git e GitHub

## Banco de dados

O banco `vagas_tech.db` possui três tabelas:

- `VAGAS`
- `CANDIDATAS`
- `CANDIDATURAS`

A tabela `CANDIDATURAS` faz a ligação entre uma candidata e uma vaga.

## Funcionalidades

O projeto contará com:

- Cadastro de vagas
- Cadastro de candidatas
- Envio de candidaturas
- Consulta de candidaturas
- Atualização do salário de uma vaga
- Cancelamento de candidatura

## Estrutura do projeto

- `vagas_tech.db` — banco de dados SQLite
- `DDL_Criacao.sql` — script de criação das tabelas
- Notebook do Google Colab — desenvolvimento e execução da aplicação em C#

## Squad Dorothy Vaughan

- Bruna Cruz
- Josiane Fatima
- Maria Luiza
- Nayara Francelino

## Status

✅ Projeto concluído.

## Métodos CRUD

### Update — `AtualizarSalarioVaga`

Atualiza o salário de uma vaga já cadastrada na tabela `VAGAS`.

```csharp
public static void AtualizarSalarioVaga(
    SqliteConnection conexao,
    int idVaga,
    decimal novoSalario)
```

**Parâmetros:**
| Parâmetro | Tipo | Descrição |
|---|---|---|
| `conexao` | `SqliteConnection` | Conexão já aberta com o banco `vagas_tech.db` |
| `idVaga` | `int` | ID da vaga a ser atualizada |
| `novoSalario` | `decimal` | Novo valor de salário |

**Versão interativa:** `AtualizarSalarioVagaInterativo(SqliteConnection conexao)` — pede o `idVaga` e o `novoSalario` via console, valida a entrada (`TryParse`) e chama o método acima.

---

### Delete — `CancelarCandidatura`

Remove um registro da tabela `CANDIDATURAS`, cancelando a candidatura de uma candidata a uma vaga.

```csharp
public static void CancelarCandidatura(
    SqliteConnection conexao,
    int idCandidatura)
```

**Parâmetros:**
| Parâmetro | Tipo | Descrição |
|---|---|---|
| `conexao` | `SqliteConnection` | Conexão já aberta com o banco `vagas_tech.db` |
| `idCandidatura` | `int` | ID da candidatura a ser excluída |

**Versão interativa:** `CancelarCandidaturaInterativo(SqliteConnection conexao)` — pede o `idCandidatura` via console, valida a entrada e chama o método acima.

---

### Exemplo de uso

```csharp
using var conexao = new SqliteConnection("Data Source=/content/vagas_tech.db");
conexao.Open();

AtualizarSalarioVagaInterativo(conexao);
CancelarCandidaturaInterativo(conexao);
```
