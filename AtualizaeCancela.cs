// ============================================
// Pede o idVaga e o novoSalario ao usuário e atualiza
// ============================================
static void AtualizarSalarioVagaInterativo(string connectionString)
{
    Console.Write("===========================================");
    Console.Write("--Atualizar Salário da Vaga--");
    Console.Write("===========================================\n");
    Console.Write("Digite o ID da vaga que deseja atualizar: ");
    string entradaId = Console.ReadLine();

    if (!int.TryParse(entradaId, out int idVaga))
    {
        Console.WriteLine("ID inválido. Digite um número válido.");
        return;
    }

    Console.Write("Digite o novo salário: ");
    string entradaSalario = Console.ReadLine();

    if (!decimal.TryParse(entradaSalario, out decimal novoSalario))
    {
        Console.WriteLine("Salário inválido. Digite um valor numérico (ex: 9500 ou 9500.50).");
        return;
    }

    AtualizarSalarioVaga(connectionString, idVaga, novoSalario);
}
// ============================================
// Pede o ID da candidatura ao usuário e cancela da tabela Candidaturas
// ============================================
static void CancelarCandidaturaInterativo(string connectionString)
{
    Console.Write("===========================================\n");
    Console.Write("--Cancelar Candidatura--\n");
    Console.Write("===========================================\n");
    Console.Write("Digite o ID da candidatura que deseja cancelar: ");
    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out int idCandidatura))
    {
        CancelarCandidatura(connectionString, idCandidatura);
    }
    else
    {
        Console.WriteLine("ID inválido. Digite novamente a candidatura.");
    }

}