using System;
using System.Collections.Generic;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenis
{
    public interface IGerenciadorPontuacaoAleatoria
    {
        string ObterPontucaoPorJogador(Jogador jogador1, Jogador jogador2);
    }
}
