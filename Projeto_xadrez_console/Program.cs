using tabuleiro;
using xadrez;

namespace Projeto_xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.colocar_peca(new Torre(Cor.Preto, tabuleiro), new Posicao(0, 0));
                tabuleiro.colocar_peca(new Torre(Cor.Preto, tabuleiro), new Posicao(1, 3));

                tabuleiro.colocar_peca(new Rei(Cor.Preto, tabuleiro), new Posicao(2, 4));

                Tela.print_tabuleiro(tabuleiro);
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}