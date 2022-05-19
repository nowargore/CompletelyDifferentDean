using CompletelyDifferentDean.Model.Enums;

namespace CompletelyDifferentDean.Model
{
    public class ControlTestResult
    {
        public int ID { get; set; }

        public Student Student { get; set; }
        public ControlTest Test { get; set; }

        public bool WasPassed { get; set; }
        public Grade Grade { get; set; }
    }
}
