using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Models
{
    public delegate void DelegueEvenement(string s);
    internal class Evenement
    {

        public event DelegueEvenement MyEvent;

        protected virtual void DeclencheEvenement()
        {
            if (MyEvent != null) MyEvent("Evenement Declenche");
        }

        public void LancerEvenement()
        {
            DeclencheEvenement();
        }

    }
}
