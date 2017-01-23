using System.Collections.Generic;

namespace Churras.ViewModels
{
    public class ChurrasViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Models.Churras> UpcommingChurras { get; set; }
        public string Heading { get; set; }
    }
}