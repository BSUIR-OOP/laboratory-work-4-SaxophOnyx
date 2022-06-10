using System.Text;

namespace DependencyLab.Classes
{
    public class Outer
    {
        public Inner Inner { get; }

        StringBuilder Builder { get; }


        public Outer(Inner inner, StringBuilder builder)
        {
            Inner = inner;
            Builder = builder;
        }
    }
}
