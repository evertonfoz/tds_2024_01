namespace Projeto02;

public class Produto
{
    public int? ProdutoID { get; set; }
    public string? Nome { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) {
            return false;
        }

        Produto produto = (Produto)obj;
        return produto.ProdutoID.Equals(this.ProdutoID);
    }
}
