using System.Globalization;
using Microsoft.Data.Sqlite;
using VagasTechApp;

const string connectionString = "Data Source=/content/vagas_tech.db";
using var conexao = new SqliteConnection(connectionString);
conexao.Open();

Console.WriteLine("=== Vagas Tech ===");

string opcao;
do
{
	Console.WriteLine("\n1 - Cadastrar vaga");
	Console.WriteLine("2 - Cadastrar candidata");
	Console.WriteLine("3 - Enviar candidatura");
	Console.WriteLine("4 - Consultar candidaturas");
	Console.WriteLine("5 - Atualizar salário de vaga");
	Console.WriteLine("6 - Cancelar candidatura");
	Console.WriteLine("0 - Sair");
	Console.Write("Escolha uma opção: ");

	opcao = Console.ReadLine() ?? string.Empty;
	try
	{
		switch (opcao)
		{
			case "1":
				MetodosCRUD.CadastrarVaga(conexao, LerInteiro("ID da vaga: "), LerTexto("Título: "), LerTexto("Empresa: "), LerDecimal("Salário: "));
				Console.WriteLine("Vaga cadastrada com sucesso.");
				break;

			case "2":
				MetodosCRUD.CadastrarCandidata(conexao, LerInteiro("ID da candidata: "), LerTexto("Nome: "), LerTexto("E-mail: "));
				Console.WriteLine("Candidata cadastrada com sucesso.");
				break;

			case "3":
				break;

			case "4":
				break;

			case "5":
				break;

			case "6":
				break;

			case "0":
				Console.WriteLine("Encerrando sistema...");
				break;

			default:
				Console.WriteLine("Opção inválida.");
				break;
		}
	}
	catch (Exception erro)
	{
		Console.WriteLine($"Não foi possível concluir a operação: {erro.Message}");
	}
} while (opcao != "0");

static string LerTexto(string mensagem)
{
	while (true)
	{
		Console.Write(mensagem);
		string valor = Console.ReadLine()?.Trim() ?? string.Empty;
		if (!string.IsNullOrWhiteSpace(valor))
		{
			return valor;
		}

		Console.WriteLine("O valor é obrigatório.");
	}
}

static int LerInteiro(string mensagem)
{
	while (true)
	{
		Console.Write(mensagem);
		if (int.TryParse(Console.ReadLine(), out int valor))
		{
			return valor;
		}

		Console.WriteLine("Digite um número inteiro válido.");
	}
}

static decimal LerDecimal(string mensagem)
{
	while (true)
	{
		Console.Write(mensagem);
		string entrada = Console.ReadLine() ?? string.Empty;
		if (decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out decimal valor))
		{
			return valor;
		}

		Console.WriteLine("Digite um salário válido, por exemplo 9500,00.");
	}
}
