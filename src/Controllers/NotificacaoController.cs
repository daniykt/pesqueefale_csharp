using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

/// <summary>
/// Classe que representa uma notificação do sistema
/// </summary>
public class Notificacao
{
    public string Id { get; set; }         // Identificador único da notificação
    public bool Lida { get; set; }         // Indica se a notificação foi lida ou não
    public string Conteudo { get; set; }   // Conteúdo da notificação (HTML)
    public string Data { get; set; }        // Data da notificação (em formato de texto)
}

/// <summary>
/// Classe estática para gerenciar as notificações do sistema
/// Simula o comportamento do localStorage do JavaScript
/// </summary>
public static class GerenciadorNotificacoes
{
    private static List<Notificacao> notificacoes = new List<Notificacao>(); // Lista de notificações em memória
    private static int contadorNotificacoes = 0; // Contador de notificações não lidas

    /// <summary>
    /// Salva uma lista de notificações (substitui as existentes)
    /// </summary>
    /// <param name="novasNotificacoes">Array de notificações a serem salvas</param>
    public static void SalvarNotificacoes(Notificacao[] novasNotificacoes)
    {
        notificacoes = novasNotificacoes.ToList();
        contadorNotificacoes = notificacoes.Count(n => !n.Lida); // Atualiza o contador baseado nas não lidas

        // Simular localStorage (serializar para JSON)
        string json = JsonSerializer.Serialize(notificacoes);
        // Em um ambiente real, aqui seria a lógica para salvar no localStorage ou em um banco de dados
    }

    /// <summary>
    /// Carrega as notificações salvas
    /// </summary>
    /// <returns>Array com todas as notificações</returns>
    public static Notificacao[] CarregarNotificacoes()
    {
        // Simular carregamento do localStorage
        string json = ""; // Obter do localStorage - em uma aplicação real, isso viria de um storage persistente
        if (!string.IsNullOrEmpty(json))
        {
            notificacoes = JsonSerializer.Deserialize<List<Notificacao>>(json);
        }
        return notificacoes.ToArray();
    }

    /// <summary>
    /// Marca uma notificação como lida com base no ID
    /// </summary>
    /// <param name="id">ID da notificação a ser marcada como lida</param>
    public static void MarcarComoLida(string id)
    {
        var notificacao = notificacoes.FirstOrDefault(n => n.Id == id);
        if (notificacao != null)
        {
            notificacao.Lida = true;
            contadorNotificacoes = notificacoes.Count(n => !n.Lida); // Recalcula o contador
        }
    }

    /// <summary>
    /// Exclui uma notificação com base no ID
    /// </summary>
    /// <param name="id">ID da notificação a ser excluída</param>
    public static void ExcluirNotificacao(string id)
    {
        notificacoes = notificacoes.Where(n => n.Id != id).ToList();
        contadorNotificacoes = notificacoes.Count(n => !n.Lida); // Recalcula o contador
    }

    /// <summary>
    /// Obtém o número de notificações não lidas
    /// </summary>
    /// <returns>Quantidade de notificações não lidas</returns>
    public static int ObterContador()
    {
        return contadorNotificacoes;
    }
}