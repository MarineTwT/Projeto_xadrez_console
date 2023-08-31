using System.Data.Common;
using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaXadrez partida;
        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaXadrez partida) : base(cor, tabuleiro){ this.partida = partida; }

        public override string ToString() {return "R";}

        private bool pode_mover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool test_tor_roque(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimento == 0;
        }

        public override bool[,] mov_possivel()
        {
            bool[,] mat = new bool[tabuleiro.linhas,tabuleiro.colunas];
            Posicao pos = new Posicao(0,0);

            //Acima
            pos.definir_valores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha,pos.coluna] = true;

            //NE
            pos.definir_valores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //Direita
            pos.definir_valores(posicao.linha , posicao.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //SE
            pos.definir_valores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //Abaixo
            pos.definir_valores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //SU
            pos.definir_valores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //Esquerda
            pos.definir_valores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //NO
            pos.definir_valores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //#JE --- Roque
            if(qteMovimento == 0 && !partida.xeque)
            {
                //#JE -- Roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(test_tor_roque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //#JE -- Roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (test_tor_roque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
