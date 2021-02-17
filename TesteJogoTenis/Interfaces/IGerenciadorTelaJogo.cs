using TesteJogoTenis.Models;

namespace JogoTenis
{
    public interface IGerenciadorTelaJogo
    {
        public void ExibirMensagem(string mensagem);
        public void LimparTela();
        public void AguardarInteracao();
        public void MensagemDestacada(string mensagem);
        public void ExibirPontuacao(string jogador1, Pontos pontosJogador1, string jogador2, Pontos pontosJogador2);
    }
}
