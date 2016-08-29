namespace SemanticUx.Components
{
    public class Scripts : ComponentBase
    {
        public void Add(string filename)
        {
            Add(new Script
            {
                Src = filename
            });
        }       
    }
}
