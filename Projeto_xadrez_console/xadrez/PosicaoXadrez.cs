using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set;}

        public PosicaoXadrez(int linha, char coluna)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            return ""+linha + coluna;
        }
    }
}
