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
				Console.Write("Digite os dados da vaga:\n");
				Console.Write("ID da vaga: ");
				if (!int.TryParse(Console.ReadLine(), out int vagaId)) { throw new Exception("ID da vaga inválido."); }
				
				Console.Write("Título: "); 
				string titulo = Console.ReadLine()!; 
				if (string.IsNullOrWhiteSpace(titulo)) { throw new Exception("Título inválido."); } 
				
				Console.Write("Empresa: "); 
				string empresa = Console.ReadLine()!; 
				if (string.IsNullOrWhiteSpace(empresa)) { throw new Exception("Empresa inválida."); } 
				
				Console.Write("Salário: "); 
				if (!decimal.TryParse(Console.ReadLine(), out decimal salario)) { throw new Exception("Salário inválido."); }

				MetodosCRUD.CadastrarVaga(conexao, vagaId, titulo, empresa, salario);
				Console.WriteLine("Vaga cadastrada com sucesso.");
				break;

			case "2":
				Console.Write("Digite os dados da candidata:\n");
				Console.Write("ID da candidata: ");
				if (!int.TryParse(Console.ReadLine(), out int candidataId)) { throw new Exception("ID da candidata inválido."); }
				
				Console.Write("Nome: ");
				string nome = Console.ReadLine() ?? throw new Exception("Nome inválido.");
				
				Console.Write("E-mail: ");
				string email = Console.ReadLine() ?? throw new Exception("E-mail inválido.");

				MetodosCRUD.CadastrarCandidata(conexao, candidataId, nome, email);
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

