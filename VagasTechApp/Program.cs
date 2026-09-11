using Microsoft.Data.Sqlite;
using System.Data;
using VagasTechApp;

var stringConexao = "Data Source=/content/vagas_tech.db";

try
{
    Console.WriteLine("====================================================");
    Console.WriteLine("  INICIANDO INTEGRAÇÃO DA PLATAFOMRMA WOMENTORAS ...");
    Console.WriteLine("==================================================\n");

    using (var conexao = new SqliteConnection(stringConexao))
    {
        conexao.Open();

        if (conexao.State == ConnectionState.Open)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--> Conexão estabelecida com o arquivo 'vagas_tech.db'!");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        Console.WriteLine("\n[CREATE] --> Cadastrando candidaturas no Sistema...");
        MetodosCRUD.EnviarCandidatura(conexao, 1, DateTime.Now, 1, 1);
        MetodosCRUD.EnviarCandidatura(conexao, 2, DateTime.Now, 2, 1);

        Console.WriteLine("\n[READ] --> Consultando Candidaturas...");
        MetodosCRUD.ConsultarCandidaturas(conexao);
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Ocorreu um erro no pipeline de integração: {ex.Message}");

    Console.ForegroundColor = ConsoleColor.Gray;
}
finally
{
    Console.WriteLine();
    Console.WriteLine("===================================================");
    Console.WriteLine("         PROCESSO DE INTEGRAÇÃO FINALIZADO");
    Console.WriteLine("===================================================");
}