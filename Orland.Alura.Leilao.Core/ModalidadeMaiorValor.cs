using System.Linq;

namespace Orland.Alura.Leilao.Core
{
    public class ModalidadeMaiorValor : IModalidadeLeilao
    {
        public Lance DefinirGanhadorLeilao(Leilao leilao)
        {
           
            return leilao.Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .OrderBy(a => a.Valor)
                        .LastOrDefault();
        }
    }
}
