namespace ApiLojaManoel.models;

public class Caixa
{
    public string  Id { get; set; }
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Comprimento { get; set; }
    public double Volume { get; set; }

    public Caixa(string id, double altura, double largura, double comprimento)
    {
        Id = id;
        Altura = altura;
        Largura = largura;
        Comprimento = comprimento;
        Volume = altura * largura * comprimento;
    }
}