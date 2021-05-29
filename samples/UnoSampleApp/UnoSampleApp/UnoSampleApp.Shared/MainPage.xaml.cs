namespace UnoSampleApp
{
    using System.Collections.Generic;
    using System.Linq;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.BasicGridView.ItemsSource = this.cats;
            this.BaseExample.ItemsSource = this.cats;
        }

        // List of cats
        private readonly List<string> cats = new List<string>()
        {
            "Abyssinian",
            "Aegean",
            "Bobtail",
            "Curl",
            "Ringtail",
            "Shorthair",
            "Wirehair",
            "Aphrodite Giant",
            "Arabian Mau"
        };

        // Handle text change and present suitable items
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            string[] splitText = sender.Text.ToLower().Split(' ');
            var suitableItems = (from cat in this.cats
                let found = splitText.All(key => cat.ToLower().Contains(key))
                where found
                select cat).ToList();

            if (suitableItems.Count == 0)
            {
                suitableItems.Add("No results found");
            }

            sender.ItemsSource = suitableItems;
        }

        // Handle user selecting an item, in our case just output the selected item.
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender,
            AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }
    }
}