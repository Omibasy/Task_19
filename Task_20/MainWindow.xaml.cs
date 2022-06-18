using System.Windows;
using Task_20.ViewModel;


namespace Task_20
{

    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();  
         
        }

        private void btnClic_Click(object sender, RoutedEventArgs e)
        {
            AddAnimal addAnimal = new AddAnimal();

            addAnimal.DataContext = DataContext;

            addAnimal.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            LaodAnimal laodAnimal = new LaodAnimal();

            laodAnimal.DataContext = DataContext;

            laodAnimal.ShowDialog();;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveAnimal saveAnimal = new SaveAnimal();

            saveAnimal.DataContext = DataContext;
           
            saveAnimal.ShowDialog();           
        }
    }
}

