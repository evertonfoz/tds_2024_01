using Microsoft.OpenApi.Models;
using Projeto02;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => {
        c.SwaggerDoc("v1", new OpenApiInfo
            {Title="", Description="", Version=""}
        );
    }
);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(
    c=> {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UTFPR API V1");
    }
);


var produtos = new List<Produto>();
produtos.Add(
    new Produto(){ProdutoID=1, Nome="Maçã"}
);
produtos.Add(
    new Produto(){ProdutoID=2, Nome="Pera"}
);

app.MapGet("/", () => "Hello World!");
app.MapGet("/produtos", () => produtos);
app.MapGet("/produtos/{id}", (int id) =>
{
    return produtos.SingleOrDefault(
        product => product.ProdutoID == id);
});

app.MapDelete("/produtos/{id}", (int id)=>
{
    produtos.Remove(new Produto(){
        ProdutoID = id
    });
});

app.MapPost("/produtos", (Produto produto) => {
    produtos.Add(produto);
});

app.MapPut("/produtos", (Produto produto)=> {
    Produto? produtoParaAtualizar = produtos.Find(p => p.ProdutoID.Equals(produto.ProdutoID));
    produtoParaAtualizar!.Nome = produto.Nome;
});

app.Run();
