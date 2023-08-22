using tabuleiro;

namespace xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadoratual;
        public bool terminada { get; private set; }

        public PartidaXadrez()
        {
            tabuleiro = new Tabuleiro(8,8);
            turno = 1;
            jogadoratual = Cor.Branco;
            colocar_pecas();
            terminada = false;
        }

        public void executar_movimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.retirar_peca(origem);
            p.incrementar_movimentos();
            Peca pecaCapturada = tabuleiro.retirar_peca(destino);

            tabuleiro.colocar_peca(p, destino);
        }

        private void colocar_pecas()
        {
            tabuleiro.colocar_peca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez(1,'a').toPosicao());
            tabuleiro.colocar_peca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez(1, 'h').toPosicao());

            tabuleiro.colocar_peca(new Rei(Cor.Branco, tabuleiro), new PosicaoXadrez(1, 'e').toPosicao());

        }
    }
}
