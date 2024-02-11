namespace FrontendModule.Templates
{
    class GradientLabel : Label
    {
        public static readonly BindableProperty GradientDegreeProperty = BindableProperty.Create(
        propertyName: nameof(GradientDegree),
        returnType: typeof(string),
        declaringType: typeof(string),
        defaultValue: null);
        public string GradientDegree
        {
            get => (string)GetValue(GradientDegreeProperty);
            set => SetValue(GradientDegreeProperty, value);
        }
        public static readonly BindableProperty TextColor1Property = BindableProperty.Create(
        propertyName: nameof(TextColor1),
        returnType: typeof(Color),
        declaringType: typeof(Color),
        defaultValue: null);
        public Color TextColor1
        {
            get => (Color)GetValue(TextColor1Property);
            set => SetValue(TextColor1Property, value);
        }
        public static readonly BindableProperty TextColor2Property = BindableProperty.Create(
            propertyName: nameof(TextColor2),
            returnType: typeof(Color),
            declaringType: typeof(Color),
            defaultValue: null);
        public Color TextColor2
        {
            get => (Color)GetValue(TextColor2Property);
            set => SetValue(TextColor2Property, value);
        }
    }
}
