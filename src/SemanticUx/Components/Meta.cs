namespace SemanticUx.Components
{
    public class Meta : ComponentBase
    {
        public Meta(string name, string content)
        {
            _name = name;
            _content = content;
        }
       
        public static implicit operator Meta(string keyValue)
        {
            var parts = keyValue.Split('=');
            return new Meta(parts[0], parts[1]);
        }

        private readonly string _name;
        private readonly string _content;
    }
}
