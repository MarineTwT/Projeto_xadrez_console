using tabuleiro;

namespace Projeto_xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Tabuleiro tabuleiro = new Tabuleiro(8,8);

            Tela.print_tabuleiro(tabuleiro);
        }
    }
}