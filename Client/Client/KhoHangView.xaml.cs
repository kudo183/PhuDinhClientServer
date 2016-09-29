using Client.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for KhoHangView.xaml
    /// </summary>
    public partial class KhoHangView : UserControl
    {
        public KhoHangViewModel ViewModel { get; set; }
        public KhoHangView()
        {
            InitializeComponent();

            var designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime == true)
            {
                return;
            }

            Loaded += KhoHangView_Loaded;
            Unloaded += KhoHangView_Unloaded;

            ViewModel = new KhoHangViewModel();
        }

        private void KhoHangView_Unloaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("KhoHangView Unloaded");
            ViewModel.Unload();
        }

        private void KhoHangView_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("KhoHangView Loaded");

            ViewModel.Load();

            DataContext = ViewModel;
        }

        private void EditableGridView_Click(object sender, RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;
            if (button == null)
                return;

            if (button.Tag == null)
                return;

            var buttonName = button.Tag.ToString();
            switch (buttonName)
            {
                case "btnSave":
                    Console.WriteLine("Save");
                    ViewModel.Save();
                    break;
                case "btnCancel":
                    Console.WriteLine("Cancel");
                    ViewModel.Load();
                    break;
            }
        }
    }
}
