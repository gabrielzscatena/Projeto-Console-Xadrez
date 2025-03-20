using tabuleiro;

namespace xadrez;

public class Rei : Peca
{
    
    private PartidaDeXadrez _partida;
    
    public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
    {
        this._partida = partida;
    }

    private bool PodeMover(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p == null || p.Cor != Cor;
    }

    private bool TesteTorreParaRoque(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p != null && p is Torre && p.Cor == Cor && p.QtdeMovimentos == 0;
    }
    
    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
        
        Posicao pos = new Posicao(0, 0);
        
        // Verif Acima
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Nordeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Sudeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Sul
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Sudoeste
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Esquerda
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // Verif Noroeste
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }
        
        // #JogadaEspecial Roque
        if (QtdeMovimentos == 0 && !_partida.Xeque)
        {
            // #JogadaEspecial Roque Pequeno
            Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
            if (TesteTorreParaRoque(posT1)) {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                if (Tab.Peca(p1) == null && Tab.Peca(p2) == null) {
                    mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }
            }
            
            // #JogadaEspecial Roque Grande
            Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
            if (TesteTorreParaRoque(posT2)) {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null) {
                    mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }
        }

        return mat;
    }

    public override string ToString()
    {
        return "R";
    }
}