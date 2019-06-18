﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_Team.Interfaces
{
    interface IJiraInteractor
    {
        List<IJiraItem> GetItems();
        bool UpdateItems(List<IJiraItem> items);
    }
}