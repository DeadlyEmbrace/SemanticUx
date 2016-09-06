using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    [HtmlTag("div")]
    [HtmlClass("header")]
    public class Header : ControlBase
    {
        public Header(IComponent parent)
            : base(parent)
        {
        }

        [HtmlContent]
        public string Title { get; set; }

        [HtmlClass]
        public HeaderSize Size { get; set; }
    }

    [HtmlTag("h1")]
    public class H1 : ControlBase
    {
        public H1(string title)
        {
            Title = title;
        }

        [HtmlContent]
        public string Title { get; set; }
    }

    [HtmlTag("h2")]
    public class H2 : ControlBase
    {
        public H2(string title)
        {
            Title = title;
        }

        [HtmlContent]
        public string Title { get; set; }
    }

    [HtmlTag("h3")]
    public class H3 : ControlBase
    {
        public H3(string title)
        {
            Title = title;
        }

        [HtmlContent]
        public string Title { get; set; }
    }

    [HtmlTag("h4")]
    public class H4 : ControlBase
    {
        public H4(string title)
        {
            Title = title;
        }

        [HtmlContent]
        public string Title { get; set; }
    }

    [HtmlTag("h5")]
    public class H5 : ControlBase
    {
        public H5(string title)
        {
            Title = title;
        }

        [HtmlContent]
        public string Title { get; set; }
    }

    [HtmlTag("h6")]
    public class H6 : ControlBase
    {
        public H6(string title)
        {
            Title = title;
        }

        [HtmlContent]
        public string Title { get; set; }
    }

    public enum HeaderSize
    {
        _,
        Huge,
        Large,
        Medium,
        Small,
        Tiny
    }
}
