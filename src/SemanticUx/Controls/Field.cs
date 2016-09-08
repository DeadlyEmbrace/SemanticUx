using System.Collections.Generic;
using SemanticUx.Attributes;
using SemanticUx.Components;

namespace SemanticUx.Controls
{
    public interface IField
    {
        string PlaceHolder { get; set; }
        InputType Type { get; set; }
        FieldValidationdRuleSet ValidationRules { get; }
    }

    [HtmlTag("div")]
    [HtmlClass("field")]
    public class Field : ControlBase, IField
    {
        public Field()
            : this(null)
        {
        }

        public Field(IComponent parent)
            : base(parent)
        {
            // TODO how can label not be rendered if it has no content
            label = new Label(this);
            input = new Components.Input(this);
            Prefix = null;
        }

        public string PlaceHolder
        {
            get
            {
                return input.PlaceHolder;
            }
            set
            {
                input.PlaceHolder = value;
            }
        }

        public FieldValidationdRuleSet ValidationRules
            => _validationRules ?? (_validationRules = new FieldValidationdRuleSet(this));

        public bool HasValidationRules => _validationRules != null;

        [HtmlContent]
        public string Label { get; set; }

        public InputType Type
        {
            get
            {
                return input.Type;
            }
            set
            {
                input.Type = value;
            }
        }

        protected Components.Input input;

        protected FieldValidationdRuleSet _validationRules;

        protected Label label;
    }

    public class FieldValidationdRuleSet : List<FieldValidationRule>
    {
        public FieldValidationdRuleSet(IField field)
        {
            Field = field;
        }

        public new IField Add(FieldValidationRule fieldValidationRule)
        {
            base.Add(fieldValidationRule);
            return Field;
        }

        public void Add(string type, string prompt)
        {
            Add(new FieldValidationRule
            {
                Type = type,
                Prompt = prompt
            });
        }

        private IField Field { get; }
    }

    public class FieldValidationRule
    {
        public string Type { get; set; }
        public string Prompt { get; set; }
    }

    public enum CreditCardType
    {
        Visa,
        MasterCard
    }
}
