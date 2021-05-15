using Orland.Alura.Leilao.Core;
using Xunit;

namespace Orland.Alura.Leilao.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(new double[] { 800 }, 800)]
        [InlineData(new double[] { 800, 1000, 1200, 1500 },  1500)]
        [InlineData(new double[] { 800, 500, 900, 700 },  900)]
        public void LeilaoComLancesRetornaOMaiorLance(double[] lances, double valorEsperado)
        {
            //Arange
            var leilao = new Core.Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                if (i % 2 == 0)
                    leilao.RecebeLance(joao, lances[i]);
                else
                    leilao.RecebeLance(maria, lances[i]);
            }

            //Act
            leilao.TerminaPregao();


            //Assert
            var retorno = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, retorno);
        }

        [Fact]
        public void LeilaoSemLancesRetornaZero()
        {
            var leilao = new Core.Leilao("Van Gogh");

            leilao.IniciaPregao();

            //Act
            leilao.TerminaPregao();


            //Assert
            var esperado = 0;
            var retorno = leilao.Ganhador.Valor;

            Assert.Equal(esperado, retorno);
        }
    }
}
