using System;
using System.Collections.Generic;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenis
{
    public class GerenciadorPontuacaoAleatoria : IGerenciadorPontuacaoAleatoria
    {
        public string ObterPontucaoPorJogador(Jogador jogador1, Jogador jogador2)
        {
            var pontos = new Random();
            return pontos.Next(0, 2) == 0 ? jogador1.Nome : jogador2.Nome;
        }
    }
}
