namespace tabuleiro
{
    abstract internal class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimento { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            this.posicao = null;
            this.cor = cor;
            this.qteMovimento = 0;
            this.tabuleiro = tabuleiro;
        }

        public void incrementar_movimentos()
        {
            qteMovimento++;
        }

        public void decrementar_movimentos()
        {
            qteMovimento--;
        }

        public bool existe_mov_possivel()
        {
            bool[,] mat = mov_possivel();
            for(int i = 0;i < tabuleiro.linhas;i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool pode_mov_para(Posicao pos)
        {
            return mov_possivel()[pos.linha,pos.coluna];
        }

        public abstract bool[,] mov_possivel();

    }
}
