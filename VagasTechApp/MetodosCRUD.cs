using Microsoft.Data.Sqlite;

namespace VagasTechApp;

public static class MetodosCRUD
{
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