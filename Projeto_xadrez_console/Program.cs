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
                PartidaXadrez partida = new PartidaXadrez();

                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.print_tabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem [coluna,linha -- a3]: ");
                    Posicao origem = Tela.ler_posicao_xadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.ler_posicao_xadrez().toPosicao();

                    partida.executar_movimento(origem, destino);

                }

                
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}