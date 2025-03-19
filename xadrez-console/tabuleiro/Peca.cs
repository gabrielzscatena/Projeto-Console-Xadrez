namespace tabuleiro;

public class Peca
{
    public Posicao Posicao { get; set; }
    public Cor Cor { get; protected set; }
    public int QtdeMovimentos { get; protected set; }
    public Tabuleiro Tab { get; protected set; }

    public Peca(Posicao posicao, Cor cor, Tabuleiro tab)
    {
        this.Posicao = posicao;
        this.Cor = cor;
        this.Tab = tab;
        this.QtdeMovimentos = 0;
    }
}