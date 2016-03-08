using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuro
{
    class Neuron
    {
        Neuron Prev;
        Neuron[] Next;
        double SignalSum = 0;
        public double Weight { get; set; }
        public Neuron(Neuron tPrev, Neuron[] tNext, double tWeight = 1)
        {
            Prev = tPrev;
            Next = tNext;
        }
        public Neuron(Neuron[] tNext, double tWeight = 1)
        {
            Next = tNext;
        }
        public Neuron()
        {
            Weight = 0;
        }

    }
}
