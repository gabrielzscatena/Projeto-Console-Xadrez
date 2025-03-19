using tabuleiro;
using xadrez;

namespace xadrez_console;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.Terminada)
            {
                
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab);

                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().ConvertePosicao();
                
                bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();
                
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                
                Console.WriteLine();
                Console.Write("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().ConvertePosicao();
                
                partida.ExecutaMovimento(origem, destino);
            }
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }    
}