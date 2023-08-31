using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab) { }

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
            }

            return mat;
        }
    }
}
