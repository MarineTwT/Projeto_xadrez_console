using tabuleiro;

namespace xadrez
{
    internal class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro){}

        private bool pode_mover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        public override string ToString() { return "T"; }

        public override bool[,] mov_possivel()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.definir_valores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            { 
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.linha = pos.linha - 1;
            }

            //Abaixo
            pos.definir_valores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.linha = pos.linha + 1;
            }

            //Direita
            pos.definir_valores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.coluna = pos.coluna + 1;
            }

            //Esquerda
            pos.definir_valores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) break;
                pos.coluna = pos.coluna - 1;
            }         
                return mat;
        }
    }
}
