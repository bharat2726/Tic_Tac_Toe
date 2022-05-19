//Author : Group 6
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(_00))
                vm.Move("_00");
            else if (sender.Equals(_01))
                vm.Move("_01");
            else if (sender.Equals(_02))
                vm.Move("_02");
            else if (sender.Equals(_10))
                vm.Move("_10");
            else if (sender.Equals(_11))
                vm.Move("_11");
            else if (sender.Equals(_12))
                vm.Move("_12");
            else if (sender.Equals(_20))
                vm.Move("_20");
            else if (sender.Equals(_21))
                vm.Move("_21");
            else
                vm.Move("_22");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.StartGame();
        }
    }
}
