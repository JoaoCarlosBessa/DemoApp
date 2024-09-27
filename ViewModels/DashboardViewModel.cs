using DemoApp.Models;
using DemoApp.Views;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;

namespace DemoApp.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private string _selectedTab;
        private int _currentPosition;
        public ObservableCollection<ContentView> ContentPages { get; set; }
        public ObservableCollection<OptionItem> OptionsIcons { get; set; }
        public DashboardViewModel()
        {
            ContentPages = new()
            {
                new Profile(),
                new Books(),
                new Chat(),
                new Feed(),
                new Configs(),
                new Menu()
            };
            OptionsIcons = [];
            LoadIcons();
            CurrentPosition = 0;
            SelectButton(0);
            ChangeTabCommand = new Command<string>(OnButtonClicked);
            SelectButtonCommand = new Command<int>(SelectButton);
        }
        public ICommand ChangeTabCommand { get; }
        public ICommand SelectButtonCommand { get; }
        public int CurrentPosition
        {
            get => _currentPosition;
            set
            {
                if (_currentPosition != value)
                {
                    _currentPosition = value;
                    OnPropertyChanged(nameof(CurrentPosition));
                }
            }
        }
        public string SelectedTab
        {
            get => _selectedTab;
            set
            {
                if (_selectedTab != value)
                {
                    _selectedTab = value;
                    OnPropertyChanged(nameof(SelectedTab));
                }
            }
        }
        private void OnButtonClicked(string page)
        {
            SelectedTab = page;

            switch (page)
            {
                case "Perfil":
                    CurrentPosition = 0;
                    break;
                case "Livros":
                    CurrentPosition = 1;
                    break;
                case "Chat":
                    CurrentPosition = 2;
                    break;
                case "Feed":
                    CurrentPosition = 3;
                    break;
                case "Config.":
                    CurrentPosition = 4;
                    break;
                case "Menu":
                    CurrentPosition = 5;
                    break;
                    //Adicionar mais um case quando uma nova opção de aba for adicionada
            }
        }
        private void SelectButton(int position)
        {
            foreach (var item in OptionsIcons)
            {
                item.IsSelected = item.Position == position;
                if (item.IsSelected)
                {
                    CurrentPosition = item.Position;
                }
            }
        }
        private void LoadIcons()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceNames = assembly.GetManifestResourceNames();

            foreach (var resourceName in resourceNames)
            {
                if (resourceName.EndsWith(".png"))
                {
                    var imagesource = resourceName.Remove(0, 25);

                    switch (imagesource)
                    {
                        case "user.png":
                            OptionItem optionItem = new() { ImageSource = imagesource, LabelText = "Perfil", Position = 0 };
                            OptionsIcons.Add(optionItem);
                            break;
                        case "books.png":
                            OptionItem optionItem1 = new() { ImageSource = imagesource, LabelText = "Livros", Position = 1 };
                            OptionsIcons.Add(optionItem1);
                            break;
                        case "chat.png":
                            OptionItem optionItem2 = new() { ImageSource = imagesource, LabelText = "Chat", Position = 2 };
                            OptionsIcons.Add(optionItem2);
                            break;
                        case "feed.png":
                            OptionItem optionItem3 = new() { ImageSource = imagesource, LabelText = "Feed", Position = 3 };
                            OptionsIcons.Add(optionItem3);
                            break;
                        case "gear.png":
                            OptionItem optionItem4 = new() { ImageSource = imagesource, LabelText = "Config.", Position = 4 };
                            OptionsIcons.Add(optionItem4);
                            break;
                        case "bars.png":
                            OptionItem optionItem5 = new() { ImageSource = imagesource, LabelText = "Menu", Position = 5 };
                            OptionsIcons.Add(optionItem5);
                            break;
                            //Adicionar um novo case caso uma nova aaba seja adicionada
                    }
                }
            }
        }
    }
}
