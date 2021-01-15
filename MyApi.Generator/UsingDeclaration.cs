namespace MyApi.Generator
{

    public class UsingDeclaration
    {
        public string Item { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UsingDeclaration other && Item == other.Item;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode();
        }
    }
}
