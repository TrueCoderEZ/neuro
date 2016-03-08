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
        double Weight;
        public Neuron(Neuron tPrev, params Neuron[] tNext)
        {
            Prev = tPrev;
            Next = tNext;
        }
        public Neuron(params Neuron[] tNext)
        {
            Next = tNext;
        }
    }
}
