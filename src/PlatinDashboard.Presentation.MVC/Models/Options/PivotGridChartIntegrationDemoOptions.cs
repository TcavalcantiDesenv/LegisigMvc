namespace PlatinDashboard.Presentation.MVC.Models.Options
{
    public class PivotGridChartIntegrationDemoOptions
    {
        public PivotGridChartIntegrationDemoOptions()
        {
            ChartType = DevExpress.XtraCharts.ViewType.Line;
            ShowRowGrandTotals = true;
        }
        public DevExpress.XtraCharts.ViewType ChartType { get; set; }
        public bool ShowColumnGrandTotals { get; set; }
        public bool GenerateSeriesFromColumns { get; set; }
        public bool ShowPointLabels { get; set; }
        public bool ShowRowGrandTotals { get; set; }
    }
}