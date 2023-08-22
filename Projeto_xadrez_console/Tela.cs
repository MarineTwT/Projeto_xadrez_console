using tabuleiro;

namespace Projeto_xadrez_console
{
    internal class Tela
    {
        public static void print_tabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i<tabuleiro.linhas; i++) 
            { 
                for (int j = 0; j < tabuleiro.colunas; j++) 
                {
                    if(tabuleiro.peca(i,j) == null) Console.Write("- ");
                    
                    else Console.Write( tabuleiro.peca(i,j) + " ");
                }             
                Console.WriteLine();
            }
        }
    }
}
