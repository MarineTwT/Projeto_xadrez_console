using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab) { }

        public override string ToString() { return "C"; }

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
            pos.definir_valores(posicao.linha - 1, posicao.coluna - 2);
            if(tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //NE
            pos.definir_valores(posicao.linha - 2, posicao.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //SE
            pos.definir_valores(posicao.linha - 2, posicao.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //SU
            pos.definir_valores(posicao.linha - 1, posicao.coluna + 2);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //<
            pos.definir_valores(posicao.linha + 1, posicao.coluna + 2);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //>
            pos.definir_valores(posicao.linha + 2, posicao.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //^
            pos.definir_valores(posicao.linha + 2, posicao.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //´´
            pos.definir_valores(posicao.linha + 1, posicao.coluna - 2);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
