using Microsoft.AspNetCore.Mvc;
using webApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();
    produtos.Add(new Produto("Celular", "IOS", 5000));
    produtos.Add(new Produto("Celular", "Android", 4000));
    produtos.Add(new Produto("Televisão", "LG", 2300.5));
    produtos.Add(new Produto("Placa de Vídeo", "NVIDIA", 2500));


app.MapGet("/", () => "API de Produtos");

app.MapGet("/produto/listar", () => produtos);

app.MapGet("/produto/buscar/{nome}", ([FromRoute] string nome) =>
    {
        for (int i = 0; i < produtos.Count; i++)
        {
            if (produtos[i].Nome == nome)
            {
                return Results.Ok(produtos[i]);
            }
        }
        return Results.NotFound("Produto não encontrado!");
    }
);

app.MapPost("/produto/cadastrar", ([FromBody] Produto produto) =>
{
    produtos.Add(produto);
    return Results.Created($"/produto/buscar/{produto.Nome}", produto); 
});

app.MapDelete("/produto/deletar/{nome}", (string nome) =>
{
    var produto = produtos.Find(p => p.Nome == nome);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    produtos.Remove(produto);
    return Results.Ok("Produto deletado com sucesso!");
});

app.MapPut("/produtos/atualizar/{nome}", (string nome, Produto novoProduto) =>
{
    var produto = produtos.Find(p => p.Nome == nome);
    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }


    produto.Nome = novoProduto.Nome ?? produto.Nome;
    produto.Descricao = novoProduto.Descricao ?? produto.Descricao;
    produto.Valor = novoProduto.Valor != 0 ? novoProduto.Valor : produto.Valor;

    return Results.Ok("Produto atualizado com sucesso!");
});


;

app.Run();