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

            var nameSpace = "Client.View";
            var viewTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => p.Namespace == nameSpace).OrderBy(p => p.Name);

            foreach (var viewType in viewTypes)
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
