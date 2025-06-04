namespace Raizes.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string? Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Status { get; set; }

        public UsuarioEntity() { }

        public UsuarioEntity(int id, string nome, string sobrenome, string? cpf, string email, string senha)
        {
            Id = id;
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
