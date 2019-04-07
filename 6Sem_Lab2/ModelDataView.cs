using System.Windows.Forms.DataVisualization.Charting;

namespace _6Sem_Lab2
{
    class ModelDataView
    {
        public ObservableModelData modelDatas = null;
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
            //chart.Series[2].Points.DataBindXY(md2., md2.NodeValues);
            //chart.Series[3].Points.DataBindXY(md2.Nodes, md2.NodeValues);
        }
    }
}
