using JogoTenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteJogoTenis.Models;

namespace JogoTenisTests
{
    [TestClass]
    public class PontuacaoTests
    {
        public void AtualizarPontuacao_JogadorFazPonto_IncementacaoDePontuacao()
        {
            //Arrange
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");
            var gerenciadorPontuacao = new GerenciadorPontuacaoJogo();

            //Act / Assert
            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador1.Nome);
            Assert.AreEqual(Pontos.Quinze, jogador1.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador1.Nome);
            Assert.AreEqual(Pontos.Trinta, jogador1.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador1.Nome);
            Assert.AreEqual(Pontos.Quarenta, jogador1.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador2.Nome);
            Assert.AreEqual(Pontos.Quinze, jogador2.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador2.Nome);
            Assert.AreEqual(Pontos.Quarenta, jogador1.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador2.Nome);
            Assert.AreEqual(Pontos.Quarenta, jogador2.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador1.Nome);
            Assert.AreEqual(Pontos.Quarenta, jogador2.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador2.Nome);
            Assert.AreEqual(Pontos.Quarenta, jogador2.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador2.Nome);
            Assert.AreEqual(Pontos.Vantagem, jogador2.Pontuacao);

            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador2.Nome);
            Assert.AreEqual(Pontos.Jogo, jogador2.Pontuacao);

            //Assert
            jogador2.Pontuacao = Pontos.Quarenta;
            jogador1.Pontuacao = Pontos.Vantagem;
            gerenciadorPontuacao.AtualizarPontuacao(jogador1, jogador2, jogador1.Nome);
            Assert.AreEqual(Pontos.Jogo, jogador1.Pontuacao);
        }

        [TestMethod]
        public void ValidarVencedor_JogadorMarcaPontos_JogadorVencedor()
        {
            //Arrange
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");

            var gerenciadorPontuacao = new GerenciadorPontuacaoJogo();

            //Act / Assert
            jogador1.Pontuacao = Pontos.Quinze;
            jogador2.Pontuacao = Pontos.Zero;
            var winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Trinta;
            jogador2.Pontuacao = Pontos.Zero;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Quarenta;
            jogador2.Pontuacao = Pontos.Zero;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Zero;
            jogador2.Pontuacao = Pontos.Quinze;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Zero;
            jogador2.Pontuacao = Pontos.Trinta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Zero;
            jogador2.Pontuacao = Pontos.Quarenta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Zero;
            jogador2.Pontuacao = Pontos.Zero;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Quinze;
            jogador2.Pontuacao = Pontos.Quinze;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Trinta;
            jogador2.Pontuacao = Pontos.Trinta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Quarenta;
            jogador2.Pontuacao = Pontos.Quarenta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Vantagem;
            jogador2.Pontuacao = Pontos.Quarenta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Quarenta;
            jogador2.Pontuacao = Pontos.Vantagem;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual("", winner);

            jogador1.Pontuacao = Pontos.Jogo;
            jogador2.Pontuacao = Pontos.Zero;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador1.Nome, winner);

            jogador1.Pontuacao = Pontos.Jogo;
            jogador2.Pontuacao = Pontos.Quinze;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador1.Nome, winner);

            jogador1.Pontuacao = Pontos.Jogo;
            jogador2.Pontuacao = Pontos.Trinta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador1.Nome, winner);

            jogador1.Pontuacao = Pontos.Jogo;
            jogador2.Pontuacao = Pontos.Quarenta;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador1.Nome, winner);

            jogador1.Pontuacao = Pontos.Zero;
            jogador2.Pontuacao = Pontos.Jogo;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador2.Nome, winner);

            jogador1.Pontuacao = Pontos.Quinze;
            jogador2.Pontuacao = Pontos.Jogo;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador2.Nome, winner);

            jogador1.Pontuacao = Pontos.Trinta;
            jogador2.Pontuacao = Pontos.Jogo;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador2.Nome, winner);

            jogador1.Pontuacao = Pontos.Quarenta;
            jogador2.Pontuacao = Pontos.Jogo;
            winner = gerenciadorPontuacao.ObterNomeJogadorVencedor(jogador1, jogador2);
            Assert.AreEqual(jogador2.Nome, winner);

        }
    }
}
