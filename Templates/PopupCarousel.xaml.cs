using CommunityToolkit.Maui.Views;

namespace FrontendModule.Templates;

public partial class PopupCarousel : Popup
{
    private string[] itemsSource { get; set; }
    private bool isNextButtonVisible;
    private bool isPreviousButtonVisible;
    public string[] ItemsSource
    {
        get { return itemsSource; }
        set
        {
            if (itemsSource != value)
            {
                itemsSource = value;
                OnPropertyChanged(nameof(ItemsSource));
            }
        }
    }
    public bool IsNextButtonVisible
    {
        get { return isNextButtonVisible; }
        set
        {
            if (isNextButtonVisible != value)
            {
                isNextButtonVisible = value;
                OnPropertyChanged(nameof(IsNextButtonVisible));
            }
        }
    }
    public bool IsPreviousButtonVisible
    {
        get { return isPreviousButtonVisible; }
        set
        {
            if (isPreviousButtonVisible != value)
            {
                isPreviousButtonVisible = value;
                OnPropertyChanged(nameof(IsPreviousButtonVisible));
            }
        }
    }
    public PopupCarousel(string[] ImageSource)
    {
        InitializeComponent();
        ItemsSource = ImageSource;
        IsNextButtonVisible = (ItemsSource.Length - 1) > 0;
        IsPreviousButtonVisible = false;
        Carousel.PositionChanged += Carousel_PositionChanged;
        this.BindingContext = this;
    }
    private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
    {
        var currentItem = Carousel.CurrentItem;
        int currentIndex = Array.IndexOf(ItemsSource, currentItem);
        IsPreviousButtonVisible = currentIndex != 0;
        IsNextButtonVisible = currentIndex != (ItemsSource.Length - 1);
        if (currentIndex != -1)
            Carousel.Position = currentIndex;
    }
    private void OKButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
    private void NextCarousel(object sender, EventArgs e)
    {
        int nextPosition = Carousel.Position + 1;
        if (nextPosition < ItemsSource.Length) Carousel.ScrollTo(nextPosition);
    }

    private void PreviousCarousel(object sender, EventArgs e)
    {
        int previousPosition = Carousel.Position - 1;
        if (previousPosition >= 0) Carousel.ScrollTo(previousPosition);
    }
}