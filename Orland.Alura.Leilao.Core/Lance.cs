using System;

namespace Orland.Alura.Leilao.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor de um lance não pode ser negativo.");

            Cliente = cliente;
            Valor = valor;
        }
    }
}
