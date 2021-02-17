using System;
using System.Collections.Generic;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenis
{
    public interface IGerenciadorPontucao
    {
        public void AtualizarPontuacao(Jogador jogador1, Jogador jogador2, string NomeJogadorMaiorPontuacao);
        public string ObterNomeJogadorVencedor(Jogador jogador1, Jogador jogador2);
    }
}
