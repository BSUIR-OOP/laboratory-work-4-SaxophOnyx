namespace DependencyLab.Classes
{
    public class EndCycle
    {
        public BeginCycle Begin { get; }


        public EndCycle(BeginCycle begin)
        {
            Begin = begin;
        }
    }
}
