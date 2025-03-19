using tabuleiro;
using xadrez;

namespace xadrez_console;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            PosicaoXadrez pos2 = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos);
            Console.WriteLine(pos.convertePosicao());
            Console.WriteLine(pos2.convertePosicao());
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }    
}