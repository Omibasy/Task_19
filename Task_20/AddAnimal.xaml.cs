using System.Windows;

namespace Task_20
{
    public partial class AddAnimal : Window
    {
        public AddAnimal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
