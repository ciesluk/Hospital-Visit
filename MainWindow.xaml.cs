using System.Windows;

namespace HospitalCharges
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM(); //instance of VM class

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm; // Associate object with view
        }

        private void TotalStay_Click(object sender, RoutedEventArgs e)
        {
            vm.CalcTotalCharges(); //Method in the VM class to calculate the total hospital stay
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            vm.Clear(); //Method in VM class to clear the textboxes and the results label
        }
    }
}
