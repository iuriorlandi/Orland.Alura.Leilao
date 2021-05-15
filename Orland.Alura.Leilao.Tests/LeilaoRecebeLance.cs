using Orland.Alura.Leilao.Core;
using System.Linq;
using Xunit;

namespace Orland.Alura.Leilao.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(2, new double[] { 500, 600 })]
        [InlineData(1, new double[] { 600 })]
        [InlineData(5, new double[] { 500, 600, 2000, 600, 500 })]
        private void LeilaoFinalizadoNaoPermiteNovosLances(int qtdEsperada, double[] lances)
        {
            //Arange
            var leilao = new Core.Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                if(i%2 == 0)
                    leilao.RecebeLance(joao, lances[i]);
                else
                    leilao.RecebeLance(maria, lances[i]);
            }

            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(joao, 1000);

            var qtdObitida = leilao.Lances.Count();
            //Assert
            Assert.Equal(qtdEsperada, qtdObitida);
        }

        [Fact]
        private void LancesConsecutivosDoMesmoInteressadoAceitaApenasOPrimeiro()
        {
            //Arange
            var leilao = new Core.Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(joao, 1000);

            //Act
            leilao.RecebeLance(joao, 1200);

            //Assert
            leilao.TerminaPregao();
            var qtdObitida = leilao.Lances.Count();
            var qtdEsperada = 1;

            Assert.Equal(qtdEsperada, qtdObitida);
        }
    }
}
