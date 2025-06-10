using Raizes.Contracts.Repository;
using Raizes.Entity;
using Raizes.Infraestructure;

namespace Raizes.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Connection _connection = new();

        public async Task<UsuarioEntity> GetById(int id)
        {
            var sql = @"
                SELECT Id, Nome, Sobrenome, Cpf, Email,
                       Senha, CriadoEm, Status
                FROM raizes.usuario
                WHERE Id = @id;
            ";

            return await _connection.ExecuteQueryFirstAsync<UsuarioEntity>(sql, new { id });
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAll()
        {
            var sql = @"
                SELECT Id, Nome, Sobrenome, Cpf, Email,
                       Senha, CriadoEm, Status
                FROM raizes.usuario;
            ";
            return await _connection.ExecuteQueryAsync<UsuarioEntity>(sql);
        }

        public async Task Insert(UsuarioEntity entity)
        {
            var sql = @"
                INSERT INTO raizes.usuario
                  (Nome, Sobrenome, Cpf, Email, Senha, CriadoEm, Status)
                VALUES
                  (@Nome, @Sobrenome, @Cpf, @Email, @Senha, @CriadoEm, @Status);
            ";
            await _connection.ExecuteAsync(sql, entity);
        }

        public async Task Update(UsuarioEntity entity)
        {
            var sql = @"
                UPDATE raizes.usuario
                SET Nome=@Nome, Sobrenome=@Sobrenome, Cpf=@Cpf,
                    Email=@Email, Senha=@Senha, Status=@Status
                WHERE Id = @Id;
            ";
            await _connection.ExecuteAsync(sql, entity);
        }

        public async Task Delete(int id)
        {
            var sql = @"DELETE FROM raizes.usuario WHERE Id = @id;";
            await _connection.ExecuteAsync(sql, new { id });
        }
    }
}
