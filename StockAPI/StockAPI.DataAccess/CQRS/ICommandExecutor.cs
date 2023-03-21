﻿using StockAPI.DataAccess.CQRS.Commands;

namespace StockAPI.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
