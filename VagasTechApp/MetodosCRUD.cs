using Microsoft.Data.Sqlite;

namespace VagasTechApp;

public static class MetodosCRUD
{
    // ============================================
    // UPDATE: Atualiza o salário de uma vaga existente
    // ============================================
    public static void AtualizarSalarioVaga(
        SqliteConnection conexao,
        int idVaga,
        decimal novoSalario)
    {
        var sql = @"
            UPDATE VAGAS
            SET SALARIO = @novoSalario
            WHERE ID_VAGA = @idVaga;
        ";

        using var comando = new SqliteCommand(sql, conexao);
        comando.Parameters.AddWithValue("@novoSalario", novoSalario);
        comando.Parameters.AddWithValue("@idVaga", idVaga);

        comando.ExecuteNonQuery();
    }

    // Versão interativa: pede idVaga e novoSalario ao usuário
    public static void AtualizarSalarioVagaInterativo(SqliteConnection conexao)
    {
        Console.Write("Digite o ID da vaga que deseja atualizar: ");
        string entradaId = Console.ReadLine();

        if (!int.TryParse(entradaId, out int idVaga))
        {
            Console.WriteLine("ID inválido. Digite apenas números.");
            return;
        }

        Console.Write("Digite o novo salário: ");
        string entradaSalario = Console.ReadLine();

        if (!decimal.TryParse(entradaSalario, out decimal novoSalario))
        {
            Console.WriteLine("Salário inválido. Digite um valor numérico (ex: 9500 ou 9500.50).");
            return;
        }

        AtualizarSalarioVaga(conexao, idVaga, novoSalario);
        Console.WriteLine($"Salário da vaga {idVaga} atualizado para R$ {novoSalario:N2}.");
    }

    // ============================================
    // DELETE: Cancela uma candidatura (exclui da tabela CANDIDATURAS)
    // ============================================
    public static void CancelarCandidatura(
        SqliteConnection conexao,
        int idCandidatura)
    {
        var sql = @"
            DELETE FROM CANDIDATURAS
            WHERE ID_CANDIDATURA = @idCandidatura;
        ";

        using var comando = new SqliteCommand(sql, conexao);
        comando.Parameters.AddWithValue("@idCandidatura", idCandidatura);

        comando.ExecuteNonQuery();
    }

    // Versão interativa: pede o idCandidatura ao usuário
    public static void CancelarCandidaturaInterativo(SqliteConnection conexao)
    {
        Console.Write("Digite o ID da candidatura que deseja cancelar: ");
        string? entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int idCandidatura))
        {
            Console.WriteLine("ID inválido. Digite apenas números.");
            return;
        }

        CancelarCandidatura(conexao, idCandidatura);
        Console.WriteLine($"Candidatura {idCandidatura} cancelada (removida do banco).");
    }
	public static void CadastrarVaga(SqliteConnection conexao, int idVaga, string titulo, string empresa, decimal salario)
	{
		var sql = "INSERT INTO VAGAS (ID_VAGA, TITULO, EMPRESA, SALARIO) VALUES (@idVaga, @titulo, @empresa, @salario);";
		using (var comando = new SqliteCommand(sql, conexao))
		{
			comando.Parameters.AddWithValue("@idVaga", idVaga);
			comando.Parameters.AddWithValue("@titulo", titulo);
			comando.Parameters.AddWithValue("@empresa", empresa);
			comando.Parameters.AddWithValue("@salario", salario);
			comando.ExecuteNonQuery();
		}
	}

	public static void CadastrarCandidata(SqliteConnection conexao, int idCandidata, string nome, string email)
	{
		var sql = "INSERT INTO CANDIDATAS (ID_CANDIDATA, NOME, EMAIL) VALUES (@idCandidata, @nome, @email);";
		using (var comando = new SqliteCommand(sql, conexao))
		{
			comando.Parameters.AddWithValue("@idCandidata", idCandidata);
			comando.Parameters.AddWithValue("@nome", nome);
			comando.Parameters.AddWithValue("@email", email);
			comando.ExecuteNonQuery();
		}
	}
    public static void EnviarCandidatura(SqliteConnection conexao, int idCandidatura, DateTime dataEnvio, int idVaga, int idCandidata)
    {
        var sql = "INSERT INTO CANDIDATURAS (ID_CANDIDATURA, DATA_ENVIO, ID_VAGA, ID_CANDIDATA) VALUES (@idCandidatura, @dataEnvio, @idVaga, @idCandidata);";
        using (var comando = new SqliteCommand(sql, conexao))
        {
            comando.Parameters.AddWithValue("@idCandidatura", idCandidatura);
            comando.Parameters.AddWithValue("@dataEnvio", dataEnvio);
            comando.Parameters.AddWithValue("@idVaga", idVaga);
            comando.Parameters.AddWithValue("@idCandidata", idCandidata);
            comando.ExecuteNonQuery();
        }
    }

    public static void ConsultarCandidaturas(SqliteConnection conexao)
    {
        var sql = @"
      SELECT 
        CANDIDATAS.NOME AS NOME_CANDIDATA, CANDIDATAS.EMAIL AS EMAIL_CANDIDATA, VAGAS.TITULO AS VAGA, VAGAS.EMPRESA AS EMPRESA
      FROM CANDIDATURAS
      INNER JOIN VAGAS ON VAGAS.ID_VAGA = CANDIDATURAS.ID_VAGA
      INNER JOIN CANDIDATAS ON CANDIDATAS.ID_CANDIDATA = CANDIDATURAS.ID_CANDIDATA;";

        using (var comando = new SqliteCommand(sql, conexao))
        {
            using (var leitor = comando.ExecuteReader())
            {
                Console.WriteLine("\n=== CANDIDATURAS CADASTRADAS ===");
                while (leitor.Read())
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Candidata: {leitor["NOME_CANDIDATA"]} - E-mail: {leitor["EMAIL_CANDIDATA"]} | Vaga: {leitor["VAGA"]} - Empresa: {leitor["EMPRESA"]}");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=====================================\n");
            }
        }
    }
}
