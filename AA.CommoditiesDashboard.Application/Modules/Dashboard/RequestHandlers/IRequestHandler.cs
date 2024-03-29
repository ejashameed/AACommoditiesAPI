﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.RequestHandlers
{
    public interface IRequestHandler<TCommand, TResponse>
    {
        Task<TResponse> Handle(TCommand command);
    }
}
