using Orland.Alura.Leilao.Core;
using Xunit;

namespace Orland.Alura.Leilao.Tests
{
    public class LeilaoTeste
    {
        [Fact]
        public void TesteLeilaoComVariosLances()
        {
            //Arange
            var leilao = new Core.Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.RecebeLance(maria, 600);
            leilao.RecebeLance(joao, 500);
            

            //Act
            leilao.TerminaPregao();


            //Assert
            var esperado = 600.0;
            var retorno = leilao.Ganhador.Valor;

            Assert.Equal(esperado, retorno);
        }      
        
        [Fact]
        public void TesteLeilaoComUmLance()
        {
            //Arange
            var leilao = new Core.Leilao("Van Gogh");
            var joao = new Interessada("João", leilao);
            leilao.RecebeLance(joao, 500);

            //Act
            leilao.TerminaPregao();


            //Assert
            var esperado = 500.0;
            var retorno = leilao.Ganhador.Valor;

            Assert.Equal(esperado, retorno);
        }
    }
}
