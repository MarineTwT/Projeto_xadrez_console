using tabuleiro;

namespace xadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Cor cor,Tabuleiro tab) : base(cor, tab) {}

        public override string ToString() {return "B";}

        private bool pode_mover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] mov_possivel()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);

            //NO
            pos.definir_valores(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.definir_valores(pos.linha - 1, pos.coluna - 1);
            }

            //NE
            pos.definir_valores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.definir_valores(pos.linha - 1, pos.coluna + 1);
            }

            //SE
            pos.definir_valores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.definir_valores(pos.linha + 1, pos.coluna + 1);
            }

            //SU
            pos.definir_valores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.definir_valores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}
