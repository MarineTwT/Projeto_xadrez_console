using System.Data;
using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro){}

        public override string ToString() {return "R";}

        private bool pode_mover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] mov_possivel()
        {
            bool[,] mat = new bool[tabuleiro.linhas,tabuleiro.colunas];
            Posicao pos = new Posicao(0,0);

            //Acima
            pos.definir_valores(pos.linha - 1, pos.coluna);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha,pos.coluna] = true;

            //NE
            pos.definir_valores(pos.linha - 1, pos.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //Direita
            pos.definir_valores(pos.linha , pos.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //SE
            pos.definir_valores(pos.linha + 1, pos.coluna + 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //Abaixo
            pos.definir_valores(pos.linha + 1, pos.coluna);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //SU
            pos.definir_valores(pos.linha + 1, pos.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //Esquerda
            pos.definir_valores(pos.linha, pos.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            //NO
            pos.definir_valores(pos.linha - 1, pos.coluna - 1);
            if (tabuleiro.posicao_valida(pos) && pode_mover(pos)) mat[pos.linha, pos.coluna] = true;

            return mat;
        }
    }
}
