using Raizes.Contracts.Repository;
using Raizes.Entity;
using Raizes.Infraestructure;

namespace Raizes.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Connection _connection = new();

        public Task<IEnumerable<UsuarioEntity>> GetAll()
        {
            var sql = @"
                SELECT Id, Nome, Sobrenome, Cpf, Email,
                       Senha, CriadoEm, Status
                FROM raizes.usuario;
            ";
            return _connection.ExecuteQuery<UsuarioEntity>(sql);
        }

        public async Task<UsuarioEntity?> GetById(int id)
        {
            var sql = @"
                SELECT Id, Nome, Sobrenome, Cpf, Email,
                       Senha, CriadoEm, Status
                FROM raizes.usuario
                WHERE Id = @id;
            ";
            return (await _connection.ExecuteQuery<UsuarioEntity>(sql))
                   .FirstOrDefault();
        }

        public Task Insert(UsuarioEntity entity)
        {
            var sql = @"
                INSERT INTO raizes.usuario
                  (Nome, Sobrenome, Cpf, Email, Senha, CriadoEm, Status)
                VALUES
                  (@Nome, @Sobrenome, @Cpf, @Email, @Senha, @CriadoEm, @Status);
            ";
            return _connection.Execute(sql, entity);
        }

        public Task Update(UsuarioEntity entity)
        {
            var sql = @"
                UPDATE raizes.usuario
                SET Nome=@Nome, Sobrenome=@Sobrenome, Cpf=@Cpf,
                    Email=@Email, Senha=@Senha, Status=@Status
                WHERE Id = @Id;
            ";
            return _connection.Execute(sql, entity);
        }

        public Task Delete(int id)
        {
            var sql = @"DELETE FROM raizes.usuario WHERE Id = @id;";
            return _connection.Execute(sql, new { id });
        }
    }
}
