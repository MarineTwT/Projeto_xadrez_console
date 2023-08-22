namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas {  get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas,colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha,coluna]; 
        }

        public void colocar_peca(Peca p, Posicao pos)
        {
            if (existe_peca(pos)) throw new TabuleiroException("Já existe uma peça nesta posição!");
            pecas[pos.linha,pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirar_peca(Posicao pos)
        {
            if (peca(pos) == null) return null;
            
            Peca aux = peca(pos);
            aux.posicao = null;

            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool existe_peca(Posicao pos)
        {
            validar_posicao(pos);
            return peca(pos) != null;
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha,pos.coluna];
        }

        public bool posicao_valida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= 8 || pos.coluna < 0 || pos.coluna >= 8) return false;
            return true;
        }

        public void validar_posicao(Posicao pos)
        {
            if (!posicao_valida(pos)) throw new TabuleiroException("Posição inválida");
        }
    }
}
