using System.Windows;

namespace Task_20
{
  
    public partial class LaodAnimal : Window
    {
        public LaodAnimal()
        {
            InitializeComponent();
        }


        private void Button_Click1(object sender, RoutedEventArgs e)
        {          
            if (ListLoad.SelectedItem != null)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Не был выбран файл!!!");
            }         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
