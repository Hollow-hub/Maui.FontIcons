namespace Hollow.Maui.FontIcons;

public class DuoToneIcon : Grid
{
  private static readonly Color defaultLayer1Color = Colors.White;
  private static readonly Color defaultLayer2Color = Colors.Black;
  private static readonly double defaultIconSize = 8d;

  private Label layer1;
  private Label layer2;

  public Color Layer1Color
  {
    get => (Color)GetValue(Layer1ColorProperty);
    set => SetValue(Layer1ColorProperty, value);
  }

  public string FontFamily
  {
    get => layer1.FontFamily;
    set
    {
      layer1.FontFamily = value;
      layer2.FontFamily = value;
    }
  }

  public Color Layer2Color
  {
    get => (Color)GetValue(Layer2ColorProperty);
    set => SetValue(Layer2ColorProperty, value);
  }

  public double IconSize
  {
    get => (double)GetValue(IconSizeProperty);
    set => SetValue(IconSizeProperty, value);
  }

  public string Icon
  {
    get => (string)GetValue(IconProperty);
    set => SetValue(IconProperty, value);
  }

  public static readonly BindableProperty Layer1ColorProperty =
    BindableProperty.Create(nameof(Layer1Color), typeof(Color),
      typeof(DuoToneIcon), defaultLayer1Color,
      propertyChanged: OnLayer1ColorPropertyChanged);

  private static void OnLayer1ColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    => ((DuoToneIcon)bindable).UpdateLayer1Color((Color)newValue);

  public static readonly BindableProperty Layer2ColorProperty =
    BindableProperty.Create(nameof(Layer2Color), typeof(Color),
      typeof(DuoToneIcon), defaultLayer2Color,
      propertyChanged: OnLayer2ColorPropertyChanged);

  private static void OnLayer2ColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    => ((DuoToneIcon)bindable).UpdateLayer2Color((Color)newValue);

  public static readonly BindableProperty IconSizeProperty =
    BindableProperty.Create(nameof(IconSize), typeof(double),
      typeof(DuoToneIcon), defaultIconSize,
      propertyChanged: OnIconSizePropertyChanged);

  private static void OnIconSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    => ((DuoToneIcon)bindable).UpdateIconSize((double)newValue);

  public static readonly BindableProperty IconProperty =
    BindableProperty.Create(nameof(Icon), typeof(string),
      typeof(DuoToneIcon), string.Empty,
      propertyChanged: OnIconPropertyChanged);

  private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    => ((DuoToneIcon)bindable).UpdateIcon(newValue?.ToString() ?? string.Empty);

  private void UpdateIconSize(double iconSize)
  {
    layer1.FontSize = iconSize;
    layer2.FontSize = iconSize;
  }

  private void UpdateIcon(string icon)
  {
    layer1.Text = $"{icon}#";
    layer2.Text = $"{icon}##";
  }

  private void UpdateLayer1Color(Color c)
    => layer1.TextColor = c;

  private void UpdateLayer2Color(Color c)
    => layer2.TextColor = c;

  public DuoToneIcon()
  {
    layer1 = GetLabel();
    layer2 = GetLabel();

    UpdateLayer1Color(defaultLayer1Color);
    UpdateLayer2Color(defaultLayer2Color);

    Children.Add(layer1);
    Children.Add(layer2);
  }

  private static Label GetLabel()
    => new()
    {
      HorizontalOptions = LayoutOptions.Fill,
      VerticalOptions = LayoutOptions.Fill,
      HorizontalTextAlignment = TextAlignment.Center,
      VerticalTextAlignment = TextAlignment.Center,
      FontSize = defaultIconSize,
      BackgroundColor = Colors.Transparent,
    };
}
