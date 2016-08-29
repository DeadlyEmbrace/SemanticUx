namespace SemanticUx.Components
{
    public class StyleSheets : ComponentBase
    {
        public void Add(string filename)
        {
            Add(new StyleSheet
            {
                Href = filename
            });
        }
    }
}
