namespace tabuleiro;

public class Tabuleiro
{
    public int Linhas { get; set; }
    public int Colunas { get; set; }
    private Peca[,] Pecas;

    public Tabuleiro(int linhas, int colunas)
    {
        this.Linhas = linhas;
        this.Colunas = colunas;
        Pecas = new Peca[linhas, colunas];
    }

    /// <summary>
    /// Metódo utilizado para acessar uma peça na matriz do tabuleiro
    /// </summary>
    /// <returns></returns>
    public Peca Peca(int linha, int coluna)
    {
        return Pecas[linha, coluna];
    }
}