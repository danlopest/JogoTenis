using System;
using System.Collections.Generic;
using System.Text;
using TesteJogoTenis.Models;

namespace JogoTenis
{
    public class GerenciadorJogo
    {
        private readonly IGerenciadorPontuacaoAleatoria _servicoPontuacaoAleatoria;
        private readonly IGerenciadorPontucao _gerenciadorPontucao;
        private readonly IGerenciadorTelaJogo _telaJogo;

        private readonly Jogador _jogador1;
        private readonly Jogador _jogador2;

        public GerenciadorJogo(
            IGerenciadorPontuacaoAleatoria servicoPontuacaoAleatoria,
            IGerenciadorPontucao gerenciadorPontuacao,
            IGerenciadorTelaJogo telaJogo,
            Jogador jogador1,
            Jogador jogador2)
        {
            _jogador1 = jogador1 ?? throw new ArgumentException("Jogador1");
            _jogador2 = jogador2 ?? throw new ArgumentException("Jogador2");
            _servicoPontuacaoAleatoria = servicoPontuacaoAleatoria ?? throw new ArgumentException("servicoPontuacaoAleatoria");
            _gerenciadorPontucao = gerenciadorPontuacao ?? throw new ArgumentException("gerenciadorPontuacao");
            _telaJogo = telaJogo ?? throw new ArgumentException("telaJogo");

            if(_jogador1.Nome == _jogador2.Nome)
                throw new ArgumentException("Os jogadores não podem ter o mesmo nome!");
        }

        public string Jogar()
        {
            _telaJogo.LimparTela();
            var boasVindas = $"TESTE JOGO DE TENIS POTTENCIAL - DANILO LOPES\n\n>||{_jogador1.Nome} x {_jogador2.Nome}||<";

            _telaJogo.MensagemDestacada(boasVindas);
            var nomeVencedor = "";

            while (true)
            {
                PontuacaoAtual();

                _telaJogo.ExibirMensagem("Pressione qualquer tecla para jogar...");
                _telaJogo.AguardarInteracao();
                _telaJogo.LimparTela();

                var pontuacaoNomeVencedor = _servicoPontuacaoAleatoria.ObterPontucaoPorJogador(_jogador1, _jogador2);
                _telaJogo.ExibirMensagem($"\n{pontuacaoNomeVencedor} fez ponto.");

                _gerenciadorPontucao.AtualizarPontuacao(_jogador1, _jogador2, pontuacaoNomeVencedor);

                nomeVencedor = _gerenciadorPontucao.ObterNomeJogadorVencedor(_jogador1, _jogador2);

                if (!String.IsNullOrEmpty(nomeVencedor))
                    break;
            }

            _telaJogo.ExibirMensagem($"{nomeVencedor} VENCEU!!!\n");
            return nomeVencedor;

        }

        private void PontuacaoAtual()
        {
            if(_jogador1.Pontuacao == Pontos.Quarenta && _jogador2.Pontuacao == Pontos.Quarenta)
            {
                _telaJogo.ExibirMensagem("EMPATE!");
            }
            else if(_jogador1.Pontuacao == Pontos.Vantagem)
            {
                _telaJogo.ExibirMensagem($"VANTAGEM {_jogador1.Nome}!");
            }
            else if (_jogador2.Pontuacao == Pontos.Vantagem)
            {
                _telaJogo.ExibirMensagem($"VANTAGEM {_jogador2.Nome}!");
            }

            var mensagemPontuacao = $"{_jogador1.Nome} - {_jogador1.Pontuacao}\n{_jogador2.Nome} - {_jogador2.Pontuacao}";
            _telaJogo.ExibirPontuacao(_jogador1.Nome, _jogador2.Pontuacao, _jogador2.Nome, _jogador2.Pontuacao);
        }
    }
}
