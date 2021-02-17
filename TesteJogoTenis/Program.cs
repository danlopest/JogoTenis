using JogoTenis;
using System;
using TesteJogoTenis.Models;

namespace TesteJogoTenis
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var jogador1 = new Jogador("Danilo");
                var jogador2 = new Jogador("Godoy");

                var resultadoJogoAleatorio = new GerenciadorPontuacaoAleatoria();
                var gerenciadorPontuacaoJogo = new GerenciadorPontuacaoJogo();
                var telaJogo = new GerenciadorTelaJogo();

                var gerenciadorJogo = new GerenciadorJogo(resultadoJogoAleatorio, gerenciadorPontuacaoJogo, telaJogo, jogador1, jogador2);

                gerenciadorJogo.Jogar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
