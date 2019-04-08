using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace _6Sem_Lab2
{
    class ModelDataView : IDataErrorInfo
    {
        public ObservableModelData modelDatas = null;
        public double X1 { get; set; }
        public double X2 { get; set; }

        public string Error => throw new System.NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string message = string.Empty;
                switch (columnName)
                {
                    case "X1":
                        if (X1 < 0.0)
                        {
                            message = "Left bound is less than 0.0!";
                        }
                        if (X1 >= X2)
                        {
                            message = "Left bound is bigger than right bound!";
                        }
                        break;
                    case "X2":
                        if (X2 > 1.0)
                        {
                            message = "Right bound is bigger than 1.0!";
                        }
                        if (X2 <= X1)
                        {
                            message = "Right bound if less than left bound!";
                        }
                        break;
                    default:
                        break;
                }
                return message;
            }
        }

        public ModelDataView(ObservableModelData modelDatas)
        {
            this.modelDatas = modelDatas;
        }

        public void Draw(Chart chart, ModelData md1, ModelData md2)
        {
            Series series1 = chart.Series["md1NotScaled"];
            Series series2 = chart.Series["md2NotScaled"];
            series1.Points.DataBindXY(md1.Nodes, md1.NodeValues);
            series2.Points.DataBindXY(md2.Nodes, md2.NodeValues);
            series1.LegendText = "p = " + md1.Parameter.ToString();
            series2.LegendText = "p = " + md2.Parameter.ToString();
            Series series3 = chart.Series["md1Scaled"];
            Series series4 = chart.Series["md2Scaled"];
            series3.Points.DataBindXY(md1.XinBounds(X1, X2), md1.YinBounds(X1, X2));
            series4.Points.DataBindXY(md2.XinBounds(X1, X2), md2.YinBounds(X1, X2));
            for (int i = 0; i < series3.Points.Count; i++)
            {
                series3.Points[i].ToolTip =
                    "p = " + md1.Parameter.ToString() +
                    "\ny = " + series3.Points[i].YValues[0].ToString("F3");
            }
            for (int i = 0; i < series4.Points.Count; i++)
            {
                series4.Points[i].ToolTip =
                    "p = " + md2.Parameter.ToString() +
                    "\ny = " + series4.Points[i].YValues[0].ToString("F3");
            }
        }
    }
}
