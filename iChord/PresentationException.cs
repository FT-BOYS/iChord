﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iChord
{
    public class PresentationException : System.Exception
    {
        public PresentationException (string s) : base(s) { }
    }
}