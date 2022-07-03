using TestMultiEEntity.Enum;

namespace TestMultiEEntity.Models
{
    public abstract class TestForme
    {
        //On notera les privat set;
        public int Id { get; private set; }
        public FormEnum Forme { get; private set; }
        public string Label { get; private set; }
        public TestType Type { get; private set; }

        //Constructeur pour EF
        internal TestForme() { }

        public TestForme(string label, TestType type)
        {
            Label = label;
            Type = type;
        }
    }
}
