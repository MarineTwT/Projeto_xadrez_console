namespace tabuleiro
{
    internal class Peca
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

    }
}
