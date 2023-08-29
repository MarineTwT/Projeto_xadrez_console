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

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.print_tabuleiro(partida.tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);

                        Console.WriteLine("Aguardando jogador da partida atual: " + partida.jogadoratual);


                        Console.WriteLine();
                        Console.Write("Origem [coluna,linha -- a3]: ");
                        Posicao origem = Tela.ler_posicao_xadrez().toPosicao();
                        partida.validar_posicao_origem(origem);

                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).mov_possivel();

                        Console.Clear();
                        Tela.print_tabuleiro(partida.tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.ler_posicao_xadrez().toPosicao();
                        partida.validar_posicao_destino(origem,destino);

                        partida.realiza_jogada(origem, destino);
                    }

                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                /*Console.Clear();
                Tela.imprimirPartida(partida);*/
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}