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
                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);
                    
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConvertePosicao();
                    partida.ValidarPosicaoDeOrigem(origem);
                    
                    bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();
                    
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);
                    
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConvertePosicao();
                    partida.ValidarPosicaoDeDestino(origem, destino);
                    
                    partida.RealizaJogada(origem, destino);
                }
                catch (TabuleiroException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Tela.ImprimirPartida(partida);
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }    
}