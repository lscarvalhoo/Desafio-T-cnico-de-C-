﻿using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;

namespace Movimento.Domain.Interfaces.Repositories
{
    public interface IMovimentoRepository
    {
        public CriarMovimentoResponse NovoMovimento(Movimentacao movimentacao);
    }
}
