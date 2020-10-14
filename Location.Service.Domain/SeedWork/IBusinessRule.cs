﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Location.Service.Domain.SeedWork
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
