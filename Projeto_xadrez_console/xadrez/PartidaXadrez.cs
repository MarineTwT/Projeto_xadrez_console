﻿using tabuleiro;

namespace xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadoratual { get; private set; }
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

        public void realiza_jogada(Posicao origem, Posicao destino)
        {
            executar_movimento(origem,destino);
            turno++;
            mudar_jogador();
        }

        public void validar_posicao_origem(Posicao pos)
        {
            if(tabuleiro.peca(pos) == null)
            {
                throw new TabuleiroException ("Não existe peça na posição escolhida!");
            }

            if(jogadoratual != tabuleiro.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!tabuleiro.peca(pos).existe_mov_possivel())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validar_posicao_destino(Posicao origem,Posicao destino)
        {
            if(!tabuleiro.peca(origem).pode_mov_para(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudar_jogador()
        {
            if (jogadoratual == Cor.Branco) jogadoratual = Cor.Preto;          
            else jogadoratual = Cor.Branco;
        }

        private void colocar_pecas()
        {
            tabuleiro.colocar_peca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez(1,'a').toPosicao());
            tabuleiro.colocar_peca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez(1, 'h').toPosicao());

            tabuleiro.colocar_peca(new Rei(Cor.Branco, tabuleiro), new PosicaoXadrez(1, 'e').toPosicao());

            tabuleiro.colocar_peca(new Torre(Cor.Preto, tabuleiro), new PosicaoXadrez(8, 'a').toPosicao());
            tabuleiro.colocar_peca(new Torre(Cor.Preto, tabuleiro), new PosicaoXadrez(8, 'h').toPosicao());

            tabuleiro.colocar_peca(new Rei(Cor.Preto, tabuleiro), new PosicaoXadrez(8, 'd').toPosicao());

        }
    }
}
