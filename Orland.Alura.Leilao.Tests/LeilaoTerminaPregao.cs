using Orland.Alura.Leilao.Core;
using System;
using Xunit;

namespace Orland.Alura.Leilao.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1100, 1200, new double[] { 800, 1000, 1200, 1500 })]
        public void GanhadorEhOValorSuperioMaisProximoDadoLeilaoNessaModalidade(double valorDefinido, double valorEsperado, double[] lances)
        {
            //Arange
            IModalidadeLeilao modalidade = new ModalidadeSuperiorMaisProximo(valorDefinido);
            var leilao = new Core.Leilao("Van Gogh", modalidade);
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

        [Theory]
        [InlineData(new double[] { 800 }, 800)]
        [InlineData(new double[] { 800, 1000, 1200, 1500 }, 1500)]
        [InlineData(new double[] { 800, 500, 900, 700 }, 900)]
        public void LeilaoComLancesRetornaOMaiorLance(double[] lances, double valorEsperado)
        {
            //Arange
            IModalidadeLeilao modalidade = new ModalidadeMaiorValor();
            var leilao = new Core.Leilao("Van Gogh", modalidade);
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
        public void LeilaoNaoIniciadoLancaInvalidOperationException()
        {
            IModalidadeLeilao modalidade = new ModalidadeMaiorValor();
            var leilao = new Core.Leilao("Van Gogh", modalidade);
            //Act

            var excecaoObtida = Assert.Throws<InvalidOperationException>(
                                        () =>
                                        leilao.TerminaPregao()
                                        );
            var mensagem = "Leilão não iniciado não pode ser terminado.";

            //Assert
            Assert.Equal(mensagem, excecaoObtida.Message);
        }

        [Fact]
        public void LeilaoSemLancesRetornaZero()
        {
            IModalidadeLeilao modalidade = new ModalidadeMaiorValor();
            var leilao = new Core.Leilao("Van Gogh", modalidade);

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
