using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenis
{
    public class GerenciadorPontuacaoJogo : IGerenciadorPontucao
    {
        public void AtualizarPontuacao(Jogador jogador1, Jogador jogador2, string NomeJogadorMaiorPontuacao)
        {
            if(NomeJogadorMaiorPontuacao == jogador1.Nome)
            {
                if(jogador1.Pontuacao >= Pontos.Quarenta && 
                    (int)jogador1.Pontuacao - (int)jogador2.Pontuacao >= 1)
                {
                    jogador1.Pontuacao = Pontos.Jogo;
                    return;
                }

                if(jogador2.Pontuacao == Pontos.Vantagem)
                {
                    jogador2.Pontuacao = Pontos.Quarenta;
                }
                else
                {
                    jogador1.Pontuacao = (Pontos)((int)jogador1.Pontuacao + 1);
                }
            }
            else
            {
                if (jogador2.Pontuacao >= Pontos.Quarenta &&
                    (int)jogador2.Pontuacao - (int)jogador1.Pontuacao >= 1)
                {
                    jogador2.Pontuacao = Pontos.Jogo;
                    return;
                }

                if (jogador1.Pontuacao == Pontos.Vantagem)
                {
                    jogador1.Pontuacao = Pontos.Quarenta;
                }
                else
                {
                    jogador2.Pontuacao = (Pontos)((int)jogador2.Pontuacao + 1);
                }
            }
        }

        public string ObterNomeJogadorVencedor(Jogador jogador1, Jogador jogador2)
        {
            string vencedor = "";
            if(jogador1.Pontuacao == Pontos.Jogo)
            {
                vencedor = jogador1.Nome;
            }
            else if(jogador2.Pontuacao == Pontos.Jogo)
            {
                vencedor = jogador2.Nome;
            }

            return vencedor;
        }
    }
}
