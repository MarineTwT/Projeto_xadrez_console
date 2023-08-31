using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaXadrez partida;
        public Peao(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab) { this.partida = partida; }

        public override string ToString() { return "P"; }

        private bool existe_inimigo(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return tabuleiro.peca(pos) == null;
        }

        public override bool[,] mov_possivel()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);

            if(cor == Cor.Branco)
            {
                pos.definir_valores(posicao.linha - 1, posicao.coluna);
                if(tabuleiro.posicao_valida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definir_valores(posicao.linha - 2, posicao.coluna);
                if (tabuleiro.posicao_valida(pos) && livre(pos) && qteMovimento == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definir_valores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.posicao_valida(pos) && existe_inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definir_valores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.posicao_valida(pos) && existe_inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //# JE -- En Passant
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);

                    if(tabuleiro.posicao_valida(esquerda) && existe_inimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulner_passant)mat[esquerda.linha - 1,esquerda.coluna] = true;                   
                    else if (tabuleiro.posicao_valida(direita) && existe_inimigo(direita) && tabuleiro.peca(direita) == partida.vulner_passant) mat[direita.linha - 1, direita.coluna] = true;
                    
                }

            }

            else
            {
                pos.definir_valores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicao_valida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definir_valores(posicao.linha + 2, posicao.coluna);
                if (tabuleiro.posicao_valida(pos) && livre(pos) && qteMovimento == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definir_valores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.posicao_valida(pos) && existe_inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definir_valores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicao_valida(pos) && existe_inimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //# JE -- En Passant
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);

                    if (tabuleiro.posicao_valida(esquerda) && existe_inimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulner_passant) mat[esquerda.linha + 1, esquerda.coluna] = true;
                    else if (tabuleiro.posicao_valida(direita) && existe_inimigo(direita) && tabuleiro.peca(direita) == partida.vulner_passant) mat[direita.linha + 1, direita.coluna] = true;

                }
            }

            return mat;
        }
    }
}
