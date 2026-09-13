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
        string? entradaId = Console.ReadLine();

        if (!int.TryParse(entradaId, out int idVaga))
        {
            Console.WriteLine("ID inválido. Digite um ID de vaga válido.");
            return;
        }

        Console.Write("Digite o novo salário: ");
        string? entradaSalario = Console.ReadLine();

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
            Console.WriteLine("ID inválido. Digite um ID de candidatura válido.");
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
}