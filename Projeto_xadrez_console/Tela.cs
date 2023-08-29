using tabuleiro;
using xadrez;

namespace Projeto_xadrez_console
{
    internal class Tela
    {
        public static void print_tabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i<tabuleiro.linhas; i++) 
            {
                Console.Write(8-i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) 
                {
                    imprimir_peca(tabuleiro.peca(i, j));  
                }             
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void print_tabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (posicoesPossiveis[i, j]) Console.BackgroundColor = fundoAlterado;
                    
                    else Console.BackgroundColor = fundoOriginal;

                    imprimir_peca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez ler_posicao_xadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(linha,coluna);
        }

        public static void imprimir_peca(Peca peca)
        {
            if (peca == null) Console.Write("- ");
            
            else
            {
                if (peca.cor == Cor.Branco) Console.Write(peca);
                
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
