using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace FrontendModule.Templates;

public partial class CollectionTemplate : ContentView
{
    public static readonly BindableProperty ButtonTextProperty =
           BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(CollectionTemplate), string.Empty);
    
    public static readonly BindableProperty InitialValueProperty =
           BindableProperty.Create(nameof(InitialValue), typeof(string), typeof(CollectionTemplate), string.Empty);

    public static readonly BindableProperty ItemSourceProperty =
           BindableProperty.Create(nameof(ItemSource), typeof(ObservableCollection<object>), typeof(CollectionTemplate), new ObservableCollection<object>());

    private ObservableCollection<object> someItemSorce;

    private bool loadMoreVisible = false;

    public bool LoadMoreVisible
    {
        get => loadMoreVisible;
        set
        {
            if (loadMoreVisible == value) return;
            loadMoreVisible = value;
            OnPropertyChanged(nameof(LoadMoreVisible));
        }
    }

    public string ButtonText
    {
        get { return (string)GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }
    
    public string InitialValue
    {
        get { return (string)GetValue(InitialValueProperty); }
        set { SetValue(InitialValueProperty, value); }
    }

    public ObservableCollection<object> ItemSource
    {
        get { return (ObservableCollection<object>)GetValue(ItemSourceProperty); }
        set
        {
            SetValue(ItemSourceProperty, value);
            OnPropertyChanged(nameof(ItemSource));
        }
    }
    public ObservableCollection<object> SomeItemSorce
    {
        get => someItemSorce;
        set
        {
            if (someItemSorce == value) return;
            someItemSorce = value;
            OnPropertyChanged(nameof(SomeItemSorce));
        }
    }

    public CollectionTemplate()
    {
        InitializeComponent();
        SetItemSource();
        BindingContext = this;
    }
    private int StringToInt(string s)
    {
        if (int.TryParse(s, out int intValue))
        {
            return intValue;
        }
        return 0;
    }
    private async void LoadIncrementally(object sender, EventArgs e)
    {
        await LoadingIncrementally();
        await TheCollectionView.ScrollToAsync(0, TheCollectionView.ContentSize.Height, true);
    }
    public Task LoadingIncrementally()
    {
        int LastItemIndex = SomeItemSorce.Count;
        for (int i = LastItemIndex; i < LastItemIndex + StringToInt(InitialValue) && i < ItemSource.Count; i++)
        {
            SomeItemSorce.Add(ItemSource[i]);
            if (SomeItemSorce.Count == ItemSource.Count) LoadMoreVisible = false;
        }
        SomeItemSorce = SomeItemSorce.ToObservableCollection();

        return Task.CompletedTask;
    }
    private void SetItemSource()
    {
        if(ItemSource.Count > StringToInt(InitialValue)) LoadMoreVisible = true;
        ObservableCollection<object> SomeItemSorce = new() { };

        for (int i = 0; i < StringToInt(InitialValue) && i < ItemSource.Count; i++)
        {
            SomeItemSorce.Add(ItemSource[i]);
            if (SomeItemSorce.Count == ItemSource.Count) LoadMoreVisible = false;
        }

        // SomeItemSorce = SomeItemSorce.ToObservableCollection();
    }
}