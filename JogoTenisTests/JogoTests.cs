using JogoTenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenisTests
{
    [TestClass]
    public class JogoTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogadores não podem ter o mesmo nome.")]
        public void Jogo_JogadoresComMesmoNome_ThrowException()
        {
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("DANILO");

            var gerenciadorPontuacaoAleatoria = new GerenciadorPontuacaoAleatoria();
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            var telaJogo = new GerenciadorTelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Gerenciador de pontuação aleatória esta nulo!")]
        public void Jogo_PontuacaoAleatoriaJogoNulo_ThrowException()
        {
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");

            GerenciadorPontuacaoAleatoria gerenciadorPontuacaoAleatoria = null;
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            var telaJogo = new GerenciadorTelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Gerenciador de pontuação do jogo esta nulo!")]
        public void Jogo_PontuacaoJogoNulo_ThrowException()
        {
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");

            var gerenciadorPontuacaoAleatoria = new GerenciadorPontuacaoAleatoria();
            GerenciadorPontuacaoJogo gerenciadorPontuacaoJogo = null;
            var telaJogo = new GerenciadorTelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Gerenciador de tela do jogo esta nulo!")]
        public void Jogo_TelaJogoNulo_ThrowException()
        {
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");

            var gerenciadorPontuacaoAleatoria = new GerenciadorPontuacaoAleatoria();
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            GerenciadorTelaJogo telaJogo = null;

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogador1 não informado!")]
        public void Jogo_Jogador1NaoInformado_ThrowException()
        {
            Jogador jogador1 = null;
            var jogador2 = new Jogador("GODOY");

            var gerenciadorPontuacaoAleatoria = new GerenciadorPontuacaoAleatoria();
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            var telaJogo = new GerenciadorTelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogador2 não informado!")]
        public void Jogo_Jogador2NaoInformado_ThrowException()
        {
            var jogador1 = new Jogador("DANILO");
            Jogador jogador2 = null;

            var gerenciadorPontuacaoAleatoria = new GerenciadorPontuacaoAleatoria();
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            var telaJogo = new GerenciadorTelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);
        }

        [TestMethod]
        public void Jogo_Jogador1SempreFazPontos_Jogador1Vence()
        {
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");

            var gerenciadorPontuacaoAleatoria = new Fake_Jogador1SempreVence();
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            var telaJogo = new Fake_TelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);

            var vencedor = gerenciadorJogo.Jogar();
            Assert.AreEqual(jogador1.Nome, vencedor);
        }

        [TestMethod]
        public void Jogo_Jogador2SempreFazPontos_Jogador2Vence()
        {
            var jogador1 = new Jogador("DANILO");
            var jogador2 = new Jogador("GODOY");

            var gerenciadorPontuacaoAleatoria = new Fake_Jogador2SempreVence();
            var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
            var telaJogo = new Fake_TelaJogo();

            var gerenciadorJogo = new GerenciadorJogo(
                gerenciadorPontuacaoAleatoria,
                gerenciadorPontuacaoJogo,
                telaJogo,
                jogador1,
                jogador2);

            var vencedor = gerenciadorJogo.Jogar();
            Assert.AreEqual(jogador2.Nome, vencedor);
        }
    }
    public class Fake_Jogador1SempreVence : IGerenciadorPontuacaoAleatoria
    {
        public string ObterPontucaoPorJogador(Jogador jogador1, Jogador jogador2)
        {
            return jogador1.Nome;
        }
    }

    public class Fake_Jogador2SempreVence : IGerenciadorPontuacaoAleatoria
    {
        public string ObterPontucaoPorJogador(Jogador jogador1, Jogador jogador2)
        {
            return jogador2.Nome;
        }
    }

    public class Fake_TelaJogo : IGerenciadorTelaJogo
    {
        public void AguardarInteracao()
        {
            return;
        }

        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void ExibirPontuacao(string jogador1, Pontos pontosJogador1, string jogador2, Pontos pontosJogador2)
        {
            Console.WriteLine($"{jogador1} - {pontosJogador1}{jogador2} - {pontosJogador2}");
        }

        public void LimparTela()
        {
            return;
        }

        public void MensagemDestacada(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }

}
