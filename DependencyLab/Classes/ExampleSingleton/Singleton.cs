namespace DependencyLab.Classes
{
    public class Singleton
    {
        public Inner Inner { get; }


        public Singleton(Inner inner)
        {
            Inner = inner;
        }
    }
}
