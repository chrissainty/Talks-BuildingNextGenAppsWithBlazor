using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazoredRepairs.Client.Features.Shared.Chart
{
    public class ChartData
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<DataSet> Datasets { get; set; } = new List<DataSet>();
    }

    public class DataSet
    {
        public string Label { get; set; }
        public List<int> Data { get; set; } = new List<int>();
        public List<string> BackgroundColor { get; set; } = new List<string>();
        public List<string> BorderColor { get; set; } = new List<string>();
        public int BorderWidth { get; set; }
    }
}
