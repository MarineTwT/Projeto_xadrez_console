using Tabuleiro;

namespace Projeto_xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao P;

            P = new Posicao(3,4);

            Console.WriteLine("posição: " + P);

            Console.ReadLine();
        }
    }
}