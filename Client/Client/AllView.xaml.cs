using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for AllView.xaml
    /// </summary>
    public partial class AllView : UserControl
    {
        private Dictionary<string, UserControl> _views = new Dictionary<string, UserControl>();
        public AllView()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            var typeName = "Client.View." + button.Content + "View";
            if (_views.ContainsKey(typeName) == false)
            {
                var viewType = System.Type.GetType(typeName);
                _views[typeName] = System.Activator.CreateInstance(viewType) as UserControl;
            }

            brd.Child = _views[typeName];
        }
    }
}
