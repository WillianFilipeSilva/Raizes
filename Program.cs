using Raizes.Application;
using Raizes.Contracts.Services;

namespace Raizes
{
    public class Program 
    {
        public static async Task Main(string[] args) 
        {
            await MostrarMenuCRUD();
        }

        public static async Task MostrarMenuCRUD()
        {
            IUsuarioAppService _usuarioAppService = new UsuarioAppService();

            Console.WriteLine("Selecione um Opção\n Create - C\n Read - R\n Update - U\n Delete - D\n");
            var opcao = Console.ReadLine();

            switch (opcao) 
            {
                case "C":
                case "c":
                    await _usuarioAppService.Create();
                    break;
                case "R":
                case "r":
                    await _usuarioAppService.Read();
                    break;
                case "U":
                case "u":
                    await _usuarioAppService.Update();
                    break;
                case "D":
                case "d":
                    await _usuarioAppService.Delete();
                    break;
                default:
                    Console.WriteLine("Selecione uma opção válida");
                    break;
            }

            Console.WriteLine("Pressione enter para continuar");
            Console.ReadLine();
            Console.Clear();
        }
    }
}