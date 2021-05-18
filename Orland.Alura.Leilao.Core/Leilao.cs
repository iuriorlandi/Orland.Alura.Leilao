using System;
using System.Collections.Generic;
using System.Linq;

namespace Orland.Alura.Leilao.Core
{
    public class Leilao
    {
        private Interessada _ultimoCliente;
        private IList<Lance> _lances;
        private IModalidadeLeilao _moddalidade;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca, IModalidadeLeilao modalidade)
        {
            Peca = peca;
            _lances = new List<Lance>();
            _moddalidade = modalidade;
            Estado = EstadoLeilao.LeilaoCriado;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (LanceEhValido(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        private bool LanceEhValido(Interessada cliente)
        {
            return cliente != _ultimoCliente && Estado == EstadoLeilao.LeilaoEmAndamento;
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
                throw new InvalidOperationException("Leilão não iniciado não pode ser terminado.");

            Ganhador = _moddalidade.DefinirGanhadorLeilao(this);
            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
