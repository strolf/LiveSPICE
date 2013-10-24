﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyMath;

namespace Circuit
{
    /// <summary>
    /// This component isn't useful. It is present for completeness.
    /// </summary>
    [CategoryAttribute("Standard")]
    [DisplayName("Wire")]
    public class Conductor : TwoTerminal
    {
        public Conductor() { Name = "_1"; }

        public override void Analyze(ModifiedNodalAnalysis Mna) 
        {
            Expression i = Mna.AddNewUnknown("i" + Name);
            Anode.i = i;
            Cathode.i = -i;

            Mna.AddEquation(Anode.V, Cathode.V);
        }

        public static void Analyze(ModifiedNodalAnalysis Mna, Terminal A, Terminal B)
        {
            Expression i = Mna.AddNewUnknown("i" + A.Name + B.Name);
            A.i = i;
            B.i = -i;

            Mna.AddEquation(A.V, B.V);
        }
        
        protected override void DrawSymbol(SymbolLayout Sym) { Sym.AddWire(Anode, Cathode); }
    }
}