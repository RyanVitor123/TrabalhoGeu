public class Usuario
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public Emprestimo? Emprestimos { get; set; }
}