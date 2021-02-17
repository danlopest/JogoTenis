using System;
using System.Collections.Generic;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenis
{
    public class GerenciadorTelaJogo: IGerenciadorTelaJogo
    {
        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
        public void LimparTela()
        {
            Console.Clear();
        }

        public void AguardarInteracao()
        {
            Console.ReadKey(true);
        }

        public void MensagemDestacada(string mensagem)
        {
            Console.WriteLine(
                $"#:::{ mensagem}:::\n\n");
        }
        public void ExibirPontuacao(string jogador1, Pontos pontosJogador1, string jogador2, Pontos pontosJogador2)
        {
            Console.WriteLine(
                $"##{jogador1} - {pontosJogador1}\n\n{jogador2} - {pontosJogador2}##");
        }
    }
}
