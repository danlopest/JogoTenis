using JogoTenis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteJogoTenis.Models;

namespace JogoTenisTests
{
    [TestClass]
    public class JogadorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogadores não podem ser nulos ou vazios!")]
        public void Jogador1_JogadoNomeVazio_ThrowException()
        {
            var jogador1 = new Jogador("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogadores não podem ser nulos ou vazios!")]
        public void Jogador1_JogadorNomeNulo_ThrowException()
        {
            var jogador1 = new Jogador(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogadores não podem ser nulos ou vazios!")]
        public void Jogador2_JogadoNomeVazio_ThrowException()
        {
            var jogador2 = new Jogador("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jogadores não podem ser nulos ou vazios!")]
        public void Jogador2_JogadorNomeNulo_ThrowException()
        {
            var jogador2 = new Jogador(null);
        }
    }
}
