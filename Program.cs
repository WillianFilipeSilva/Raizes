using Raizes.Contracts.Services;
using Raizes.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        await MostrarMenuCRUD();
    }

    public static async Task MostrarMenuCRUD()
    {
        IUsuarioService _usuarioService = new UsuarioService();

        Console.WriteLine("Selecione um Opção\n Create - C\n Read - R\n Update - U\n Delete - D\n");
        var opcao = Console.ReadLine();

        switch (opcao)
        {
            case "C":
            case "c":
                await _usuarioService.Create();
                break;
            case "R":
            case "r":
                await _usuarioService.Read();
                break;
            case "U":
            case "u":
                await _usuarioService.Update();
                break;
            case "D":
            case "d":
                await _usuarioService.Delete();
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
