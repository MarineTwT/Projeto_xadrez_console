using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadoratual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaXadrez()
        {
            tabuleiro = new Tabuleiro(8,8);
            turno = 1;
            jogadoratual = Cor.Branco;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocar_pecas();
        }

        public Peca executar_movimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.retirar_peca(origem);
            p.incrementar_movimentos();
            Peca pecaCapturada = tabuleiro.retirar_peca(destino);

            tabuleiro.colocar_peca(p, destino);
            if (pecaCapturada != null) capturadas.Add(pecaCapturada); 

            return pecaCapturada;
        }

        public void desfaz_mov(Posicao origem,Posicao destino,Peca pecaCapturada)
        {
            Peca p = tabuleiro.retirar_peca(destino);
            p.decrementar_movimentos();

            if(pecaCapturada != null)
            {
                tabuleiro.colocar_peca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocar_peca(p, origem);
        }

        public void realiza_jogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executar_movimento(origem,destino);

            if (esta_em_xeque(jogadoratual))
            {
                desfaz_mov(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (esta_em_xeque(adversaria(jogadoratual))) xeque = true;           
            else xeque = false;

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

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca x in capturadas)
            {
                if(x.cor == cor) aux.Add(x);
            }

            return aux;
        }

        public HashSet<Peca> pecas_Em_jogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas)
            {
                if (x.cor == cor) aux.Add(x);
            }

            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public bool esta_em_xeque(Cor cor)
        {
            Peca R = rei(cor);

            if(R == null)
            {
                throw new TabuleiroException("Não existe rei da cor " + cor + " no tabuleiro!");
            }

            foreach(Peca x in pecas_Em_jogo(adversaria(cor)))
            {
                bool[,] mat = x.mov_possivel();
                if (mat[R.posicao.linha, R.posicao.coluna]) return true;
            }

            return false;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branco) return Cor.Preto;
            else return Cor.Branco;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecas_Em_jogo(cor))
            {
                if(x is Rei) return x;
            }
            return null;
        }

        public void colocar_nova_peca(int linha, char coluna, Peca peca)
        {
            tabuleiro.colocar_peca(peca, new PosicaoXadrez(linha,coluna).toPosicao());
            pecas.Add(peca);
        }

        private void colocar_pecas()
        {
            //Branco
            colocar_nova_peca(1,'a',new Torre(Cor.Branco, tabuleiro));
            colocar_nova_peca(1, 'h', new Torre(Cor.Branco, tabuleiro));
            colocar_nova_peca(1, 'e', new Rei(Cor.Branco, tabuleiro));

            //Preto
            colocar_nova_peca(8, 'a', new Torre(Cor.Preto, tabuleiro));
            colocar_nova_peca(8, 'h', new Torre(Cor.Preto, tabuleiro));
            colocar_nova_peca(8, 'd', new Rei(Cor.Preto, tabuleiro));

        }
    }
}
