using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using FrontendModule.Templates;
using System.Collections.ObjectModel;

namespace FrontendModule
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<object> itemSource;

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


        public ObservableCollection<object> ItemSource
        {
            get => itemSource;
            set
            {
                if (itemSource == value) return;
                itemSource = value;
                OnPropertyChanged(nameof(ItemSource));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            ItemSource = new ObservableCollection<object> { "Item1", "Item2", "Item3", "Item4", "Item5", "Item6", "Item7", "Item8", "Item9", "Item10", "Item11", "Item12" };
            SomeItemSorce = new ObservableCollection<object> { };
            SetItemSource();
            BindingContext = this;
        }

        private async void PopupCarousel(object sender, EventArgs e)
        {
            var arrImage = new string[] { "sport1.jpg", "sport2.jpg", "sport3.jpg", "sport4.jpg" };
            var popup = new PopupCarousel(arrImage);

            await this.ShowPopupAsync(popup);
        }

        private async void LoadIncrementally(object sender, EventArgs e)
        {
            await LoadingIncrementally();
            // await TheCollectionView.ScrollToAsync(0, TheCollectionView.ContentSize.Height, true);
            await ParentScrollView.ScrollToAsync(0, ParentScrollView.ContentSize.Height, true);
        }

        public Task LoadingIncrementally()
        {
            int LastItemIndex = SomeItemSorce.Count;
            for (int i = LastItemIndex; i < LastItemIndex + 4 && i < ItemSource.Count; i++)
            {
                SomeItemSorce.Add(ItemSource[i]);
                if (SomeItemSorce.Count == ItemSource.Count) LoadMoreVisible = false;
            }
            SomeItemSorce = SomeItemSorce.ToObservableCollection();

            return Task.CompletedTask;
        }

        private void SetItemSource()
        {

            if (ItemSource.Count > 4) LoadMoreVisible = true;

            for (int i = 0; i < 4 && i < ItemSource.Count; i++)
            {
                SomeItemSorce.Add(ItemSource[i]);
                if (SomeItemSorce.Count == ItemSource.Count) LoadMoreVisible = false;
            }

            // SomeItemSorce = SomeItemSorce.ToObservableCollection();
        }
    }
}
