namespace Amoozeshgah.Core.Report
{
    public class ReportBank : IReportBank
    {
        public ReportBank()
        {
            DataSource = new object();
        }
        public string Name { get; set; }
        public object DataSource { get; set; }
    }
}