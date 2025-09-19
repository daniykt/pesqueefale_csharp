using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Classe que representa um local de pesca
/// </summary>
public class LocalPesca
{
    public int Id { get; set; }                   // Identificador único
    public string Nome { get; set; }              // Nome do local
    public string Imagem { get; set; }            // URL da imagem
    public string Descricao { get; set; }         // Descrição do local
    public string Tipo { get; set; }              // Tipo (Rio, Represa, etc.)
    public string[] TiposPeixe { get; set; }      // Array de tipos de peixe encontrados
    public string Cidade { get; set; }            // Cidade e estado
    public double Avaliacao { get; set; }         // Avaliação média (0-5)
    public string[] Comodidades { get; set; }     // Array de comodidades
    public string MelhorEpoca { get; set; }       // Melhor época para pesca
}

/// <summary>
/// Classe estática para pesquisa de locais de pesca
/// </summary>
public static class PesquisaLocais
{
    // Array estático com dados mockados de locais de pesca
    private static LocalPesca[] locais = {
        new LocalPesca {
            Id = 1,
            Nome = "Represa do Vale Sereno",
            Imagem = "~/assets/eventos/evento1.jpg",
            Descricao = "Um dos melhores locais para pesca de tucunaré e pintado...",
            Tipo = "Represa",
            TiposPeixe = new[] { "tucunaré", "pintado", "dourado" },
            Cidade = "Barra do Garças, MT",
            Avaliacao = 4.7,
            Comodidades = new[] { "Boas estradas e trilhas" },
            MelhorEpoca = "Maio a Setembro"
        },
        // Adicionar os outros locais aqui...
    };

    /// <summary>
    /// Método para pesquisar locais com base em vários critérios
    /// </summary>
    /// <param name="termo">Termo de pesquisa (pode ser nome, descrição, cidade, etc.)</param>
    /// <param name="tipoPeixe">Tipo de peixe específico</param>
    /// <param name="tipoLocal">Tipo de local (Rio, Represa, etc.)</param>
    /// <param name="avaliacaoMinima">Avaliação mínima</param>
    /// <returns>Array de locais que correspondem aos critérios</returns>
    public static LocalPesca[] Pesquisar(
        string termo,
        string tipoPeixe,
        string tipoLocal,
        double avaliacaoMinima)
    {
        return locais.Where(local =>
            (string.IsNullOrEmpty(termo) || // Se não há termo, não filtra por termo
             local.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
             local.Descricao.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
             local.Cidade.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
             local.TiposPeixe.Any(p => p.Contains(termo, StringComparison.OrdinalIgnoreCase))) &&
            (string.IsNullOrEmpty(tipoPeixe) ||
             local.TiposPeixe.Contains(tipoPeixe)) && // Filtra por tipo de peixe, se fornecido
            (string.IsNullOrEmpty(tipoLocal) ||
             local.Tipo.Equals(tipoLocal, StringComparison.OrdinalIgnoreCase)) && // Filtra por tipo de local, se fornecido
            local.Avaliacao >= avaliacaoMinima // Filtra por avaliação mínima
        ).ToArray();
    }

    /// <summary>
    /// Obtém todos os tipos de peixe distintos presentes nos locais
    /// </summary>
    /// <returns>Array com todos os tipos de peixe</returns>
    public static string[] ObterTodosTiposPeixe()
    {
        return locais
            .SelectMany(l => l.TiposPeixe) // Junta todos os arrays de tipos de peixe
            .Distinct()                    // Remove duplicatas
            .ToArray();
    }

    /// <summary>
    /// Obtém todos os tipos de local distintos
    /// </summary>
    /// <returns>Array com todos os tipos de local</returns>
    public static string[] ObterTodosTiposLocais()
    {
        return locais
            .Select(l => l.Tipo)          // Seleciona apenas o tipo
            .Distinct()                   // Remove duplicatas
            .ToArray();
    }
}