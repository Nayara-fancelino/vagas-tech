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
## Update: Atualizar Salario da Vaga e Delete: Cancelar Candidatura
UPDATE
* AtualizarSalarioVagaInterativo() só cuida da interface; quem mexe no banco de fato é o AtualizarSalarioVaga() que pode ser reaproveitado sem alterações.

* Uso do return logo depois de cada TryParse que falha, em vez de aninhar os ifs um dentro do outro — assim o método sai cedo se o ID for inválido, sem nem chegar a perguntar o salário. Deixa o fluxo mais linear e fácil de ler.

* decimal.TryParse em vez de int.TryParse para o salário, já que a tabela VAGAS define SALARIO como Número Decimal.

DELETE
* CancelarCandidaturaInterativo() fica responsável só pela parte de interface, pede o ID ao usuário (com Console.ReadLine) e depois chama o CancelarCandidatura() internamente. Assim separa a responsabilidade: um método cuida da interação com o usuário, o outro só mexe no banco. Isso permite reuso do CancelarCandidatura() em outras etapas, sem depender de input do usuário.

🚧 Projeto em desenvolvimento.