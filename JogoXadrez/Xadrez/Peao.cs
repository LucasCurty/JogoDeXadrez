using tabuleiro;

namespace Xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez Partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tab.peca(pos) == null;
        }




        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.definirValores(Posicao.linha - 1, Posicao.coluna);
                if (Tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(Posicao.linha - 2, Posicao.coluna);
                if (Tab.posicaoValida(pos) && livre(pos) && qteMovimento == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // #jogadaEspecial en passant

                if (Posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    if (Tab.posicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == Partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha -1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    if (Tab.posicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == Partida.vulneravelEnPassant)
                    {
                        mat[direita.linha -1, direita.coluna] = true;
                    }
                }

            }
            else
            {

                pos.definirValores(Posicao.linha + 1, Posicao.coluna);
                if (Tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(Posicao.linha + 2, Posicao.coluna);
                if (Tab.posicaoValida(pos) && livre(pos) && qteMovimento == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(Posicao.linha + 1, Posicao.coluna - 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
                if (Tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }


                // #jogadaEspecial en passant

                if (Posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    if (Tab.posicaoValida(esquerda) && existeInimigo(esquerda) && Tab.peca(esquerda) == Partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    if (Tab.posicaoValida(direita) && existeInimigo(direita) && Tab.peca(direita) == Partida.vulneravelEnPassant)
                    {
                        mat[direita.linha +1, direita.coluna] = true;
                    }
                }
            }
           

            return mat;
        }
    }
}