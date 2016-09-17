using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Tests
{
    public class DefaultHtmlBuilderTests
    {
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
                .StartWith("<test>")
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
                .Be("<test>");
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
                .Be("<test class=\"active\"></test>");
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
                .Be("<test></test>");
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
                .Be("<test class=\"red\"></test>");
        }

        [HtmlTag("test")]
        private class FullHtmlTagSubject : ComponentBase
        {
        }

        [HtmlTag("test", IsEmpty = true)]
        private class EmptyHtmlTagSubject : ComponentBase
        {
        }

        private class NakedHtmlTagSubject : ComponentBase
        {
        }

        [HtmlTag("test")]
        private class NamedHtmlClassSubject : ComponentBase
        {
            [HtmlClass("active")]
            public bool Active { get; set; }
        }

        [HtmlTag("test")]
        private class EnumHtmlClassSubject : ComponentBase
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


    }
}
