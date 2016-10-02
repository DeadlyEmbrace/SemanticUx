using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using SemanticUx.Attributes;
using SemanticUx.Components;
using SemanticUx.Controls;

namespace SemanticUx.Tests
{
    public class DefaultHtmlBuilderTests
    {
        [Test]
        public void BuildsWithSpecifiedHtmlTag()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new DivHtmlTagSubject();

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .StartWith("<div class=\"ui\">")
                .And.EndWith("</div>");
        }

        [Test]
        public void BuildsFullHtmlTag()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new FullHtmlTagSubject();

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .StartWith("<test class=\"ui\">")
                .And.EndWith("</test>");
        }

        [Test]
        public void BuildsEmptyHtmlTag()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new EmptyHtmlTagSubject();

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("<test class=\"ui\">");
        }

        [Test]
        public void BuildsNakedHtmlTag()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new NakedHtmlTagSubject();

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("");
        }

        [Test]
        public void BuildsNamedHtmlClassWhenTrue()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new NamedHtmlClassSubject
            {
                Active = true
            };

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("<test class=\"ui active\"></test>");
        }

        [Test]
        public void DoesNotBuildNamedHtmlClassWhenFalse()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new NamedHtmlClassSubject
            {
                Active = false
            };

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("<test class=\"ui\"></test>");
        }

        [Test]
        public void BuildsEnumHtmlClass()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new EnumHtmlClassSubject
            {
                Color = EnumHtmlClassSubject.SubjectColor.Red
            };

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("<test class=\"ui red\"></test>");
        }

        [Test]
        public void BuildsStringHtmlClass()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new StringHtmlClassSubject
            {
                Size = StringHtmlClassSubject.SubjectSize
            };

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("<test class=\"ui huge\"></test>");
        }

        [Test]
        public void BuildsWithDefaultClassPrefix()
        {
            // arrange 
            var sut = new DefaultHtmlBuilder();
            var subject = new DefaultPrefixedHtmlClassSubject();

            // act
            var result = sut.Build(subject);

            // assert
            result.Should()
                .Be("<test class=\"ui test\"></test>");
        }

        [HtmlTag("div")]
        private class DivHtmlTagSubject : ControlBase
        {
        }

        [HtmlTag("test")]
        private class FullHtmlTagSubject : ControlBase
        {
        }

        [HtmlTag("test", IsEmpty = true)]
        private class EmptyHtmlTagSubject : ControlBase
        {
        }

        private class NakedHtmlTagSubject : ControlBase
        {
        }

        [HtmlTag("test")]
        private class NamedHtmlClassSubject : ControlBase
        {
            [HtmlClass("active")]
            public bool Active { get; set; }
        }

        [HtmlTag("test")]
        private class EnumHtmlClassSubject : ControlBase
        {
            [HtmlClass()]
            public SubjectColor Color { get; set; }

            public enum SubjectColor
            {
                Blue,
                Green,
                Red
            }
        }

        [HtmlTag("test")]
        private class StringHtmlClassSubject : ControlBase
        {
            [HtmlClass]
            public string Size { get; set; }

            public const string SubjectSize = "huge";
        }

        [HtmlTag("test")]
        [HtmlClass("test")]
        private class DefaultPrefixedHtmlClassSubject : ControlBase
        {
        }

        [HtmlTag("test")]
        [HtmlClass("test")]
        private class NonPrefixedHtmlClassSubject : ControlBase
        {
            public NonPrefixedHtmlClassSubject()
            {
                Prefix = null;
            }
        }

        [HtmlTag("test")]
        [HtmlClass("test")]
        private class CustomPrefixedHtmlClassSubject : ControlBase
        {
            public CustomPrefixedHtmlClassSubject()
            {
                Prefix = "test";
            }
        }


    }
}
