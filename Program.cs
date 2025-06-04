using Raizes.Contracts.Repository;
using Raizes.Entity;
using Raizes.Repository;

namespace Raizes
{
    public class Program 
    {
        static async Task Main(string[] args) 
        {
            await MostrarMenu();
        }

        public static async Task MostrarMenu()
        {
            Console.WriteLine("Selecione um Opção\n Create - C\n Read - R\n Update - U\n Delete - D\n");
            var opcao = Console.ReadLine();

            switch (opcao) 
            {
                case "C":
                    Console.WriteLine("Cadastrando Usuário");
                    await Create();
                    break;
                case "R":
                    await Read();
                    break;
                case "U":
                    Console.WriteLine("Editando um Usuário");
                    await Read();

                    Console.WriteLine("Insira o Id o Usuário que deseja editar, ou alguma letra para cancelar.");
                    if (!int.TryParse(Console.ReadLine(), out var id))

                        await Update();
                    break;
                case "D":
                    Console.WriteLine("Apagando um Usuário");
                    await Delete();
                    break;
                default:
                    Console.WriteLine("Selecione uma opção válida");
                    break;
            }

            Console.WriteLine("Pressione enter para continuar");
            Console.ReadLine();
            Console.Clear();
        }

        static async Task Read ()
        {
            IUsuarioRepository usuarioRepository = new UsuarioRepository();
            var usuarioList = await usuarioRepository.GetAll();

            await ExibirUsuarios(usuarioList);
        }

        public static async Task ExibirUsuarios(IEnumerable<UsuarioEntity> UsuarioList)
        {
            Console.WriteLine("Mostrando todos os Usuários");
            foreach (var usuario in UsuarioList)
            {
                Console.WriteLine($"Id: {usuario.Id}\nNome: {usuario.Nome} {usuario.Sobrenome}\nCpf: {usuario.Cpf}\nEmail: {usuario.Email}\nSenha: {usuario.Senha}\nStatus: {(usuario.Status? "Ativo" : "Inativo")}\nCriadoEm: {usuario.CriadoEm}");
            }
        }

        static async Task Create()
        {
            Console.WriteLine("Digite o nome");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite o nome");
            var sobrenome = Console.ReadLine();

            Console.WriteLine("Digite o nome");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite o nome");
            var email = Console.ReadLine();

            Console.WriteLine("Digite o nome");
            var senha = Console.ReadLine();

            UsuarioEntity usuarioEntity = new UsuarioEntity(1, nome, sobrenome, cpf, email, senha);

            IUsuarioRepository usuarioRepository = new UsuarioRepository();
            await usuarioRepository.Insert(usuarioEntity);
        }

        static async Task Delete()
        {
            await Read();

            Console.WriteLine("Insira o Id o Usuário que deseja deletar, ou alguma letra para cancelar.");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Deletar Usuário cancelado.");
                return;
            }

            IUsuarioRepository usuarioRepository = new UsuarioRepository();
            await usuarioRepository.Delete(id);
        }

        static async Task Update()
        {
            IUsuarioRepository usuarioRepository = new UsuarioRepository();
            var usuarioList = await usuarioRepository.GetAll();

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
                }
                Console.WriteLine("Digite o nome");
                var nome = Console.ReadLine();
                usuario.Nome = nome;
                //... continuar

                Console.WriteLine("Digite o Sobrenome");
                var sobrenome = Console.ReadLine();

                Console.WriteLine("Digite o CPF");
                var cpf = Console.ReadLine();

                Console.WriteLine("Digite o E-mail");
                var email = Console.ReadLine();

                Console.WriteLine("Digite o Senha");
                var senha = Console.ReadLine();

                await usuarioRepository.Update(usuario);
            }
        }
    }
}