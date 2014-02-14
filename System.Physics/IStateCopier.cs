﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Physics
{
    public interface IStateCopier<T>
    {
        void CopyStateTo(T element);
    }
}
