﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public interface IAttackable
    {
        public void TakeDamage(Attack attack);
    }
}
