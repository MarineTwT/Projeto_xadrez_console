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
                        Tela.imprimir_partida(partida);
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
                        Console.ReadLine();
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Formato errado de caracteres!!!!");
                        Console.ReadLine();
                    }

                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Não pode ser nulo, ou colocar um valor muito alto!!!");
                        Console.ReadLine();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Não pode inserir valores estranho !?");
                        Console.ReadLine();
                    }
                }
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}