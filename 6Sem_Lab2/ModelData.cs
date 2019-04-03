using System;
using System.Linq;
using System.ComponentModel;

namespace _6Sem_Lab2
{
    class ModelData : IDataErrorInfo
    {
        static double pMin = 0.0;
        static double pMax = 0.0;
        void F(int n, double p)
        {}

        public int NodeCount { get; set; }
        public double Parameter { get; set; }
        public double[] Nodes { get; set; }
        public double[] NodeValues { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string message = string.Empty;
                switch (columnName)
                {
                    case "Parameter":
                        if (pMin > Parameter || Parameter > pMax)
                        {
                            message = "P value is offbounds!";
                        }
                        break;
                    case "NodeCount":
                        if (NodeCount < 3)
                        {
                            message = "Node count is less than 3!";
                        }
                        break;
                    default:
                        break;
                }
                return message;
            }
        }

        public ModelData(int node_count, double p)
        {
            NodeCount = node_count;
            Parameter = p;
        }

        public double[] XinBounds(double x1, double x2) => (from node in Nodes
                                                            where x1 < node && node < x2
                                                            select node) as double[];
        public double[] YinBounds(double x1, double x2) => (from nodeVal in NodeValues
                                                            where x1 < nodeVal && nodeVal < x2
                                                            select nodeVal) as double[];
    }
}
