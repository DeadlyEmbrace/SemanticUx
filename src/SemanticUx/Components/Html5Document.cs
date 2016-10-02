using SemanticUx.Attributes;

namespace SemanticUx.Components
{
    [HtmlTag("html")]
    [HtmlDocType("html")]
    public class Html5Document : ComponentBase
    {
        public Html5Document()
        {
            title = new Title(this);
            StyleSheets = new StyleSheets();
            Scripts = new Scripts();
            
            Head = new Head();
            Head.Add(StyleSheets);
            Head.Add(Scripts);
            Components.Add(Head);

            Body = new Body();
            Components.Add(Body);
        }

        public string Title { get; set; }

        public StyleSheets StyleSheets { get; }

        public Scripts Scripts { get; }

        public IComponent Head { get; }

        public IComponent Body { get; }

        protected Title title;
    }
}
