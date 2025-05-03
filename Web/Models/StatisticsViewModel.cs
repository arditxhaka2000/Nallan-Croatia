namespace Web.Models
{
    public class StatisticsViewModel
    {
        public StatisticsViewModel() { }

        public string Chart17Names { get; set; }
        public string Chart17Percentages { get; set; }
        public decimal TotalPercentageProjectDone { get; internal set; }
    }
}
