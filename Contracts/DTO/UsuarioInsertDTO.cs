namespace Raizes.Contracts.DTO
{
    public class UsuarioInsertDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string? Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Status { get; set; }

        public UsuarioInsertDTO() { }

        public UsuarioInsertDTO(string nome, string sobrenome, string? cpf, string email, string senha)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Email = email;
            Senha = senha;
            CriadoEm = DateTime.UtcNow;
            Status = true;
        }
    }
}
