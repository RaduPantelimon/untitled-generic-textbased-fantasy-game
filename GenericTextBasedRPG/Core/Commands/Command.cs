﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{
    internal abstract class Command
    {

        public Command()
        {

        }

        public abstract void Execute();
    }
}