<#
  setup-full-raizes.ps1
  Cria a solução Raízes completa (Clean Arch) com código-esqueleto
  • Requer .NET 8 SDK, git opcional
#>

# ---------- CONFIG ------------------------------------------------------
$sol = "Raizes"
$dotnet = "8.0"
$entities = @(
  "Usuario","Cidade","Propriedade","TipoSolo","HistoricoSolo",
  "Planta","Plantio","Colheita","Fornecedor","Insumo",
  "InsumoEstoque","InsumoGasto","UnidadeMedida","Venda"
)

# ---------- FUNÇÕES -----------------------------------------------------
function Out-FileEnsured($path,$content){
  $dir = Split-Path $path
  if(!(Test-Path $dir)){New-Item -ItemType Directory -Path $dir -Force|Out-Null}
  $content | Out-File -Encoding utf8 $path
}

# ---------- SOLUÇÃO E PROJETOS -----------------------------------------
dotnet new sln -n $sol
dotnet new classlib -n "$sol.Domain"          -f "net$dotnet"
dotnet new classlib -n "$sol.Application"     -f "net$dotnet"
dotnet new classlib -n "$sol.Infrastructure"  -f "net$dotnet"
dotnet new webapi   -n "$sol.WebApi"          -f "net$dotnet" --no-https
mkdir src
Get-ChildItem -Path . -Filter "${sol}.*" -Directory | Move-Item -Destination src
Get-ChildItem src/$sol.*/*.csproj | %{dotnet sln add $_}

dotnet add src/$sol.Application/$sol.Application.csproj   reference src/$sol.Domain/$sol.Domain.csproj
dotnet add src/$sol.Infrastructure/$sol.Infrastructure.csproj reference src/$sol.Application/$sol.Application.csproj,src/$sol.Domain/$sol.Domain.csproj
dotnet add src/$sol.WebApi/$sol.WebApi.csproj reference src/$sol.Application/$sol.Application.csproj,src/$sol.Infrastructure/$sol.Infrastructure.csproj

# ---------- NUGET -------------------------------------------------------
dotnet add src/$sol.Application/$sol.Application.csproj     package MediatR FluentValidation AutoMapper
dotnet add src/$sol.Infrastructure/$sol.Infrastructure.csproj package Pomelo.EntityFrameworkCore.MySql MediatR.Extensions.Microsoft.DependencyInjection AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add src/$sol.WebApi/$sol.WebApi.csproj               package Swashbuckle.AspNetCore MediatR

# ---------- DOMAIN ------------------------------------------------------
# BaseEntity
Out-FileEnsured "src/$sol.Domain/BaseEntity.cs" @"
namespace $sol.Domain;
public abstract class BaseEntity {
  public Guid Id {get; protected set;} = Guid.NewGuid();
  public DateTime CreatedAt {get;} = DateTime.UtcNow;
}
"@

# Entities
foreach($e in $entities){
  Out-FileEnsured "src/$sol.Domain/Entities/$e.cs" @"
using $sol.Domain;
namespace $sol.Domain.Entities;
public class $e : BaseEntity {
  // TODO: propriedades
}
"@
}

# Value Object exemplo
Out-FileEnsured "src/$sol.Domain/ValueObjects/Endereco.cs" @"
namespace $sol.Domain.ValueObjects;
public record Endereco(string Rua,string Numero,string Cidade,string Estado,string Cep);
"@

# ---------- APPLICATION -------------------------------------------------
# Interfaces de repositório
foreach($e in $entities){
  $repo="I$e`Repository"
  Out-FileEnsured "src/$sol.Application/Interfaces/$repo.cs" @"
using $sol.Domain.Entities;
namespace $sol.Application.Interfaces;
public interface $repo {
  Task AddAsync($e entity);
  Task<$e?> GetByIdAsync(Guid id);
  Task UpdateAsync($e entity);
  Task DeleteAsync(Guid id);
}
"@
}

# Exemplo Command / Handler de Propriedade
Out-FileEnsured "src/$sol.Application/Commands/Propriedades/CriarPropriedadeCommand.cs" @"
using MediatR;
namespace $sol.Application.Commands.Propriedades;
public record CriarPropriedadeCommand(string Nome) : IRequest<Guid>;
"@
Out-FileEnsured "src/$sol.Application/Commands/Propriedades/CriarPropriedadeCommandHandler.cs" @"
using MediatR;
using $sol.Application.Interfaces;
using $sol.Domain.Entities;

namespace $sol.Application.Commands.Propriedades;
public class CriarPropriedadeCommandHandler : IRequestHandler<CriarPropriedadeCommand,Guid>
{
  private readonly IPropriedadeRepository _repo;
  public CriarPropriedadeCommandHandler(IPropriedadeRepository repo)=>_repo=repo;
  public async Task<Guid> Handle(CriarPropriedadeCommand cmd, CancellationToken ct){
    var prop = new Propriedade(); // preencher depois
    await _repo.AddAsync(prop);
    return prop.Id;
  }
}
"@

# ---------- INFRASTRUCTURE ---------------------------------------------
# DbContext
Out-FileEnsured "src/$sol.Infrastructure/Persistence/$sol`DbContext.cs" @"
using Microsoft.EntityFrameworkCore;
using $sol.Domain.Entities;

namespace $sol.Infrastructure.Persistence;
public class ${sol}DbContext : DbContext {
  public ${sol}DbContext(DbContextOptions<${sol}DbContext> opt) : base(opt){}
@(
$entities | ForEach-Object { "  public DbSet<$_> $_`s => Set<$_>();" }
) -join "`n"
  protected override void OnModelCreating(ModelBuilder mb){
    base.OnModelCreating(mb);
    // TODO: configurations específicas
  }
}
"@

# Repositórios CRUD simples
foreach($e in $entities){
  $repo="I$e`Repository"
  Out-FileEnsured "src/$sol.Infrastructure/Repositories/${e}Repository.cs" @"
using $sol.Application.Interfaces;
using $sol.Domain.Entities;
using $sol.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace $sol.Infrastructure.Repositories;
public class ${e}Repository : $repo
{
  private readonly ${sol}DbContext _ctx;
  public ${e}Repository(${sol}DbContext ctx)=>_ctx=ctx;

  public async Task AddAsync($e entity){
    _ctx.Add(entity);
    await _ctx.SaveChangesAsync();
  }
  public Task<$e?> GetByIdAsync(Guid id)=>_ctx.Set<$e>().FindAsync(id).AsTask();
  public async Task UpdateAsync($e entity){
    _ctx.Update(entity);
    await _ctx.SaveChangesAsync();
  }
  public async Task DeleteAsync(Guid id){
    var ent = await GetByIdAsync(id);
    if(ent is null) return;
    _ctx.Remove(ent);
    await _ctx.SaveChangesAsync();
  }
}
"@
}

# ---------- WEBAPI ------------------------------------------------------
# Injeção de serviços no Program.cs
$programFile="src/$sol.WebApi/Program.cs"
(Get-Content $programFile) -replace 'builder.Services.AddControllers\(\);', @"
builder.Services.AddControllers();
builder.Services.AddDbContext<${sol}.Infrastructure.Persistence.${sol}DbContext>(opt =>
    opt.UseMySql(builder.Configuration.GetConnectionString(""Default""), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString(""Default""))));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof($sol.Application.Commands.Propriedades.CriarPropriedadeCommand).Assembly));

builder.Services.AddSwaggerGen();
" | Set-Content $programFile

# Connection string exemplo
Add-Content -Path "src/$sol.WebApi/appsettings.json" -Value @'
,
  "ConnectionStrings": {
    "Default": "server=localhost;port=3306;database=raizes;user=root;password=senha"
  }
'@

# Minimal Controller exemplo
Out-FileEnsured "src/$sol.WebApi/Controllers/PropriedadesController.cs" @"
using MediatR;
using Microsoft.AspNetCore.Mvc;
using $sol.Application.Commands.Propriedades;

namespace $sol.WebApi.Controllers;
[ApiController]
[Route(""api/[controller]"")]
public class PropriedadesController : ControllerBase
{
  private readonly IMediator _med;
  public PropriedadesController(IMediator med)=>_med=med;

  [HttpPost]
  public async Task<IActionResult> Post([FromBody]CriarPropriedadeCommand cmd){
    var id = await _med.Send(cmd);
    return Created($""api/propriedades/{id}"", new {id});
  }
}
"@

# ---------- FRONTEND ----------------------------------------------------
Out-FileEnsured "src/$sol.Frontend/login.html" "<!-- TODO: login page -->"

# ---------- BUILD PIPELINE ---------------------------------------------
Out-FileEnsured "build/azure-pipelines.yml" @"
trigger:
- main

pool:
  vmImage: 'ubuntu-latest'

steps:
- task: UseDotNet@2
  inputs:
    packageType: 'sdk'
    version: '$dotnet'

- script: |
    dotnet restore
    dotnet build --configuration Release
  displayName: 'Build'

- script: |
    dotnet publish src/$sol.WebApi/$sol.WebApi.csproj -c Release -o $(Build.ArtifactStagingDirectory)/publish
  displayName: 'Publish'
"@

# ---------- GIT INIT ----------------------------------------------------
if(Get-Command git -ErrorAction SilentlyContinue){
  git init
  git add .
  git commit -m "Estrutura inicial gerada por script"
}

Write-Host "`n🟢 Solução $sol criada com sucesso!"
