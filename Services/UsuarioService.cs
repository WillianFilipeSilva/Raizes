using Raizes.Contracts.Repository;
using Raizes.Contracts.Services;
using Raizes.Entity;
using Raizes.Repository;
using Raizes.Response;

namespace Raizes.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService()
        {
            _repository = new UsuarioRepository();
        }

        public async Task<UsuarioGetAllResponse> GetAll()
        {
            return new UsuarioGetAllResponse(await _repository.GetAll());
        }

        public async Task<UsuarioEntity?> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        //Post
        public async Task Insert(UsuarioEntity usuario)
        {
            await _repository.Insert(usuario);
        }

        //Antigos
        public async Task Create()
        {
            Console.WriteLine("Cadastrando Usuário\n");

            Console.WriteLine("Digite o nome");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o Sobrenome");
            var sobrenome = Console.ReadLine();

            Console.WriteLine("Digite o CPF");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite o Email");
            var email = Console.ReadLine();

            Console.WriteLine("Digite a Senha");
            var senha = Console.ReadLine();

            UsuarioEntity usuarioEntity = new UsuarioEntity(1, nome, sobrenome, cpf, email, senha);

            try
            {
                await _repository.Insert(usuarioEntity);

                Console.WriteLine($"Usuario: {usuarioEntity.Nome} {usuarioEntity.Sobrenome} Cadastrado com Sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve um erro ao salvar o Usuario: {usuarioEntity.Nome} {usuarioEntity.Sobrenome}: {ex.Message}");
            }
        }

        public async Task Read()
        {
            var usuarioList = await _repository.GetAll();

            await ExibirUsuarios(usuarioList);
        }

        public async Task Update()
        {
            var usuarioList = await _repository.GetAll();

            Console.WriteLine("Editar Usuário\n");
            await ExibirUsuarios(usuarioList);

            Console.WriteLine("Insira o Id o Usuário que deseja editar, ou alguma letra para cancelar.");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Editar Usuário cancelado.");
                return;
            }

            if (usuarioList.Where(usuario => usuario.Id == id).FirstOrDefault() is var usuario && usuario == null)
            {
                Console.WriteLine($"Não foi encontrado Usuário com o id: {id}");
            }
            else
            {
                Console.WriteLine("Digite a opção do que voce quer alterar:\n 1 -- = Nome\n 2 -- Sobrenome \n 3 -- cpf \n 4 -- E-mail\n 5 -- Senha\n 6 -- Inativar / Ativar Usuário");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                }
                Console.WriteLine("Digite o nome");
                var nome = Console.ReadLine();
                usuario.Nome = nome ?? "";

                Console.WriteLine("Digite o Sobrenome");
                var sobrenome = Console.ReadLine();
                usuario.Sobrenome = sobrenome ?? "";

                Console.WriteLine("Digite o CPF");
                var cpf = Console.ReadLine();
                usuario.Cpf = cpf ?? "";

                Console.WriteLine("Digite o E-mail");
                var email = Console.ReadLine();
                usuario.Email = email ?? "";

                Console.WriteLine("Digite o Senha");
                var senha = Console.ReadLine();
                usuario.Senha = senha ?? "";

                await _repository.Update(usuario);
            }
        }

        public async Task Delete()
        {
            Console.WriteLine("Deletar Usuário\n");

            await Read();

            Console.WriteLine("Insira o Id o Usuário que deseja deletar, ou alguma letra para cancelar.");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Deletar Usuário cancelado.");
                return;
            }

            await _repository.Delete(id);
        }

        private static async Task ExibirUsuarios(IEnumerable<UsuarioEntity> UsuarioList)
        {
            Console.WriteLine("Exibindo Usuários\n");

            foreach (var usuario in UsuarioList)
            {
                Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Sobrenome: {usuario.Sobrenome} Cpf: {usuario.Cpf} Email: {usuario.Email} Senha: {usuario.Senha} Status: {(usuario.Status ? "Ativo" : "Inativo")}");
            }
        }
    }
}
