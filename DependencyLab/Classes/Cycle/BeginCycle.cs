namespace DependencyLab.Classes
{
    public class BeginCycle
    {
        public MiddleCycle Middle { get; }


        public BeginCycle(MiddleCycle middle)
        {
            Middle = middle;
        }
    }
}
