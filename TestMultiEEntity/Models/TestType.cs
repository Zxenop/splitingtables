using TestMultiEEntity.Enum;


namespace TestMultiEEntity.Models
{
    public abstract class TestType
    {
        public int Id { get; private set; }
        public TypeMarcheEnum Type { get; private set; }

        public TestForme Forme { get; private set; }
    }
}
