using Microsoft.Data.Sqlite;
using VagasTechApp;

const string connectionString = "Data Source=/content/vagas_tech.db";

using var conexao = new SqliteConnection(connectionString);
conexao.Open();

Console.WriteLine("=== Vagas Tech - Integração Final ===\n");

const int idVagaEngenharia = 1;
const int idVagaBi = 2;
const int idMariana = 1;

Console.WriteLine("1. Cadastrando vagas...");

MetodosCRUD.CadastrarVaga(
    conexao,
    idVagaEngenharia,
    "Engenheira de Dados",
    "Empresa Alfa",
    9000m
);

MetodosCRUD.CadastrarVaga(
    conexao,
    idVagaBi,
    "Analista de BI",
    "Empresa Ômega",
    7500m
);

Console.WriteLine("Vagas cadastradas.\n");

Console.WriteLine("2. Cadastrando candidata...");

MetodosCRUD.CadastrarCandidata(
    conexao,
    idMariana,
    "Mariana Souza",
    "mariana.souza@email.com"
);

Console.WriteLine("Candidata cadastrada.\n");

Console.WriteLine("3. Enviando candidaturas...");

MetodosCRUD.EnviarCandidatura(
    conexao,
    901,
    DateTime.Now,
    idVagaEngenharia,
    idMariana
);

MetodosCRUD.EnviarCandidatura(
    conexao,
    902,
    DateTime.Now,
    idVagaBi,
    idMariana
);

Console.WriteLine("Candidaturas enviadas.\n");

Console.WriteLine("4. Consultando candidaturas...");
MetodosCRUD.ConsultarCandidaturas(conexao);

Console.WriteLine("5. Atualizando salário...");

MetodosCRUD.AtualizarSalarioVaga(
    conexao,
    idVagaEngenharia,
    9500m
);

using (var comandoSalario = new SqliteCommand(
    "SELECT SALARIO FROM VAGAS WHERE ID_VAGA = @idVaga;",
    conexao))
{
    comandoSalario.Parameters.AddWithValue("@idVaga", idVagaEngenharia);

    var salarioAtualizado = Convert.ToDecimal(
        comandoSalario.ExecuteScalar()
    );

    Console.WriteLine(
        $"Salário atualizado no banco: R$ {salarioAtualizado:N2}\n"
    );
}

Console.WriteLine("6. Cancelando candidatura 902...");

MetodosCRUD.CancelarCandidatura(
    conexao,
    902
);

Console.WriteLine("Candidatura 902 cancelada.\n");

Console.WriteLine("7. Resultado final:");
MetodosCRUD.ConsultarCandidaturas(conexao);

Console.WriteLine("=== Simulação finalizada ===");