using System;

namespace TesteJogoTenis.Models
{
    public class Jogador
    {
        public string Nome { get; set; }
        public Pontos Pontuacao { get; set; }
        public Jogador(string nome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome do jogador não pode ser vazio, nulo ou conter espaços!");
            Nome = nome;
        }
    }
}
