using Xunit;
using System;
using Orland.Alura.Leilao.Core;

namespace Orland.Alura.Leilao.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void ValorNegativoLancaArgumentException()
        {
            //Arrage
            //Assert
            Assert.Throws<ArgumentException>(
                //Act
                () => new Lance(null, -100)
                );
        }
    }
}
