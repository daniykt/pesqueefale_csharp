/// <summary>
/// Classe que gerencia o estado de seguir/deixar de seguir um perfil
/// </summary>
public class PerfilUsuario
{
    public bool Seguindo { get; private set; } // Indica se o usuário atual está seguindo o perfil

    /// <summary>
    /// Alterna o estado de seguindo
    /// </summary>
    public void ToggleSeguir()
    {
        Seguindo = !Seguindo;
    }

    /// <summary>
    /// Retorna o texto do botão de acordo com o estado
    /// </summary>
    /// <returns>Texto para exibir no botão</returns>
    public string ObterTextoBotao()
    {
        return Seguindo ? "Deixar de seguir" : "Seguir";
    }

    /// <summary>
    /// Retorna o ícone do botão de acordo com o estado
    /// </summary>
    /// <returns>Nome do ícone Material Design</returns>
    public string ObterIcone()
    {
        return Seguindo ? "person_remove" : "person_add";
    }
}