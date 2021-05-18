using System;
using System.Linq;

namespace Orland.Alura.Leilao.Core
{
    public class ModalidadeSuperiorMaisProximo : IModalidadeLeilao
    {
        private double _valorDefinido;

        public ModalidadeSuperiorMaisProximo(double valorDefinido)
        {
            _valorDefinido = valorDefinido;
        }
        public Lance DefinirGanhadorLeilao(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(l => l.Valor > _valorDefinido)
                .OrderBy(l => l.Valor)
                .FirstOrDefault();
        }
    }
}
