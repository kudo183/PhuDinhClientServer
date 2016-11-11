using System.Collections.Generic;
using System.Linq;
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

            var viewTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().ToList();
            
            foreach (var viewType in viewTypes.Where(p => p.Namespace == "Client.View.Report").OrderBy(p => p.Name))
            {
                sp.Children.Add(new Button()
                {
                    Content = "Report" + viewType.Name,
                    Tag = viewType
                });
            }

            foreach (var viewType in viewTypes.Where(p => p.Namespace == "Client.View").OrderBy(p => p.Name))
            {
                sp.Children.Add(new Button()
                {
                    Content = viewType.Name,
                    Tag = viewType
                });
            }
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            var viewType = button.Tag as System.Type;
            var typeName = viewType.Name;
            if (_views.ContainsKey(typeName) == false)
            {
                _views[typeName] = System.Activator.CreateInstance(viewType) as UserControl;
            }

            brd.Child = _views[typeName];
        }
    }
}
