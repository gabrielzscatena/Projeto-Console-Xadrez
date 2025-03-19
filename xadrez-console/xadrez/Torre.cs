using tabuleiro;

namespace xadrez;

public class Torre : Peca
{
    public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
    {
    }

    private bool PodeMover(Posicao pos)
    {
        Peca p = Tab.Peca(pos);
        return p == null || p.Cor != Cor;
    }
    
    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
        
        Posicao pos = new Posicao(0, 0);
        
        // Verif Acima
        pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha = pos.Linha - 1;
        }
        
        // Verif Abaixo
        pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha = pos.Linha + 1;
        }
        
        // Verif Direita
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Coluna = pos.Coluna + 1;
        }
        
        // Verif Esquerda
        pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
        while (Tab.PosicaoValida(pos) && PodeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Coluna = pos.Coluna - 1;
        }

        return mat;
    }
    
    public override string ToString()
    {
        return "T";
    }
}