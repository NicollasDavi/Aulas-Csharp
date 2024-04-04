namespace webApi.Models;

public class Produto
{
    public Produto() { }

    public Produto(string nome, string descricao, double valor)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
    }

    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Valor { get; set; }

}