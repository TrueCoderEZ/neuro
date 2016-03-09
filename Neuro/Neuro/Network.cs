using System;
using System.IO;

namespace Neuro
{
    class Network
    {
        public Neuron[] Neurons;
        bool Answ;
        double Limit = 0;
        int[,] Data;
        public Network(int[,] Weights, int[,] tData, double tLimit)
        {
            Neurons = new Neuron[Weights.GetLength(0) * Weights.GetLength(1)];
            for (int i = 0; i < Weights.GetLength(0); i++)
                for (int j = 0; j < Weights.GetLength(1); j++)
                    Neurons[i * j + j].Weight = Weights[i, j];
            Limit = tLimit;
            Data = tData;
        }
        public Network(int[,] tData, double tLimit)
        {
            Neurons = new Neuron[1500];
            for (int i = 0; i < Neurons.GetLength(0); i++)
                    Neurons[i] = new Neuron();
            Data = tData;
            Limit = tLimit;
        }
        public void SetDataAndLimit(int[,] tData, double tLimit)
        {
            Data = tData;
            Limit = tLimit;
        }
        double Sum()
        {
            double a = 0;
            for (int i = 0; i < Neurons.GetLength(0); i++)
                a += Neurons[i].Weight * Data[i % Data.GetLength(0), i / Data.GetLength(0)];
            return a;
        }
        double SumaryCount()
        {
            double a = 0;
            for (int i = 0; i < Neurons.GetLength(0); i++)
                a += Data[i % Data.GetLength(0), i / Data.GetLength(0)];
            return a;
        }
        public void Teach(bool tCorrect)
        {
            if(tCorrect)
                for (int i = 0; i < Neurons.GetLength(0); i++)
                    Neurons[i].Weight += Data[i % Data.GetLength(0), i / Data.GetLength(0)];
            else
                for (int i = 0; i < Neurons.GetLength(0); i++)
                    Neurons[i].Weight -= Data[i % Data.GetLength(0), i / Data.GetLength(0)];
        }

        public static void SaveAll(string fileName, Network[] NNs)
        {
            FileStream FS = new FileStream(fileName, FileMode.Create);
            StreamWriter SW = new StreamWriter(FS);
            if(NNs[0] != null)
                SW.WriteLine(NNs[0].Neurons.Length.ToString());
            else
                SW.WriteLine((1500).ToString());
            for (int x = 0; x < 10; x++)
            {
                if (NNs[x].Neurons != null)
                {
                    for (int i = 0; i < NNs[x].Neurons.Length; i++)
                        SW.Write(NNs[x].Neurons[i].Weight.ToString() + (i != NNs[x].Neurons.Length - 1 ? " " : ""));
                }
                else
                {
                    for (int i = 0; i < 1500; i++)
                        SW.Write((0).ToString() + (i != 1500 - 1 ? " " : ""));
                }
                SW.WriteLine();
            }
            SW.Close();
            FS.Close();
        }
        public void SaveToFile(string fileName)
        {
            FileStream FS = new FileStream(fileName, FileMode.Create);
            StreamWriter SW = new StreamWriter(FS);
            if (Neurons != null)
            {
                SW.WriteLine(Neurons.Length.ToString());
                for (int i = 0; i < Neurons.Length; i++)
                    SW.Write(Neurons[i].Weight.ToString() + (i != Neurons.Length - 1 ? " " : ""));
            }
            else
            {
                SW.WriteLine((1500).ToString());
                for(int i = 0; i < 1500; i++)
                    SW.Write((0).ToString() + (i != 1500 - 1 ? " " : ""));
            }
            SW.Close();
            FS.Close();
            //ImageSerializer.DrawFive(Neurons);
        }
        public static void ReadAll(string fileName, params Network[] NNs)
        {
            FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamReader SW = new StreamReader(FS);
            int b = Convert.ToInt32(SW.ReadLine());
            if (b != 0)
            {
                for (int x = 0; x < 10; x++)
                {
                    NNs[x].Neurons = new Neuron[b];
                    string[] a = SW.ReadLine().Split(' ');
                    for (int i = 0; i < b; i++)
                    {
                        NNs[x].Neurons[i] = new Neuron();
                        NNs[x].Neurons[i].Weight = Convert.ToInt32(a[i]);
                    }
                }
                SW.Close();
                FS.Close();
            }
            else
            {
                SW.Close();
                FS.Close();
                FileStream FSs = new FileStream(fileName, FileMode.Create);
                StreamWriter SWw = new StreamWriter(FSs);
                SWw.WriteLine((1500).ToString());
                for (int g = 0; g < 10; g++)
                {
                    for (int i = 0; i < 1500; i++)
                        SWw.Write((0).ToString() + (i != 1500 - 1 ? " " : ""));
                    SWw.Write("\n");
                }
                for (int x = 0; x < 10; x++)
                {
                    for (int i = 0; i < 1500; i++)
                    {
                        NNs[x].Neurons[i] = new Neuron();
                        NNs[x].Neurons[i].Weight = 0;
                    }
                }
                SWw.Close();
                FSs.Close();
            }
        }
        public void ReadFromFile(string fileName)
        {
            FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamReader SW = new StreamReader(FS);
            int b = Convert.ToInt32(SW.ReadLine());
            if (b != 0)
            {
                Neurons = new Neuron[b];
                string[] a = SW.ReadLine().Split(' ');
                for (int i = 0; i < b; i++)
                {
                    Neurons[i] = new Neuron();
                    Neurons[i].Weight = Convert.ToDouble(a[i]);
                }
                SW.Close();
                FS.Close();
            }
            else
            {
                SW.Close();
                FS.Close();
                FileStream FSs = new FileStream(fileName, FileMode.Create);
                StreamWriter SWw = new StreamWriter(FSs);
                SWw.WriteLine((1500).ToString());
                for (int i = 0; i < 1500; i++)
                    SWw.Write((0).ToString() + (i != 1500 - 1 ? " " : ""));

                for (int i = 0; i < 1500; i++)
                {
                    Neurons[i] = new Neuron();
                    Neurons[i].Weight = 0;
                }
                SWw.Close();
                FSs.Close();
            }
        }
        public bool Resolve()
        {
            if (Sum() > Limit)
                return true;
            else
                return false;
        }
        public double GetResult()
        {
            double answer = 0;
            answer = Sum() / SumaryCount();
            return answer;
        }

    }
    
}
/*
5
4 5 56 67 7 88 
*/
