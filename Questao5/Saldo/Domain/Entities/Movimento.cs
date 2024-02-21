﻿namespace Saldo.Domain.Entities
{
    public class Movimento
    {
        public string Id { get; set; }

        public int IdContaCorrente { get; set; }

        public DateTime DataMovimento { get; set; }

        public char TipoMovimento { get; set; }

        public decimal Valor { get; set; }
    }
}
