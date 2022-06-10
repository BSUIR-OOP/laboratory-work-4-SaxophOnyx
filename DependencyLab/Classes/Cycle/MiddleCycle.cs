namespace DependencyLab.Classes
{
    public class MiddleCycle
    {
        public EndCycle End { get; }


        public MiddleCycle(EndCycle end)
        {
            End = end;
        }
    }
}
