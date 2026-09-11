using Microsoft.Data.Sqlite;

namespace VagasTechApp;

public static class MetodosCRUD
{
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
      SELECT CANDIDATURAS.DATA_ENVIO, VAGAS.TITULO AS VAGA, CANDIDATAS.NOME AS NOME_CANDIDATA
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
                    Console.WriteLine($"Data: {leitor["DATA_ENVIO"]} | Candidata: {leitor["NOME_CANDIDATA"]} | Vaga: {leitor["VAGA"]} ");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=====================================\n");
            }
        }
    }
}