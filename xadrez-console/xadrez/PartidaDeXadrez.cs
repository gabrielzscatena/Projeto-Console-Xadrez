using tabuleiro;

namespace xadrez;

public class PartidaDeXadrez
{
    public Tabuleiro Tab{ get; private set; }
    public bool Terminada { get; private set; }
    private int _turno;
    private Cor _jogadorAtual;

    public PartidaDeXadrez()
    {
        Tab = new Tabuleiro(8, 8);
        _turno = 1;
        _jogadorAtual = Cor.Branca;
        Terminada = false;
        ColocarPecas();
    }

    public void ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = Tab.RetirarPeca(origem);
        p.IncrementarQtdeMovimentos();
        Peca pecaCapturada = Tab.RetirarPeca(destino);
        Tab.ColocarPeca(p, destino);
    }

    private void ColocarPecas()
    {
        Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c',1).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c',2).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d',2).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e',2).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e',1).ConvertePosicao());
        Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d',1).ConvertePosicao());
        
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c',7).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c',8).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d',7).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e',7).ConvertePosicao());
        Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e',8).ConvertePosicao());
        Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d',8).ConvertePosicao());

    }
}