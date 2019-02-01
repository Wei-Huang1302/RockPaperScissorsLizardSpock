using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockPaperScissorsLizardSpock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameVM gvm = new GameVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = gvm;
        }
        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            gvm.SelectRock();
            gvm.GetGameResult();
        }
        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            gvm.SelectPaper();
            gvm.GetGameResult();
        }
        private void Scissors_Click(object sender, RoutedEventArgs e)
        {
            gvm.SelectScissors();
            gvm.GetGameResult();
        }
        private void Spock_Click(object sender, RoutedEventArgs e)
        {
            gvm.SelectSpock();
            gvm.GetGameResult();
        }
        private void Lizard_Click(object sender, RoutedEventArgs e)
        {
            gvm.SelectLizard();
            gvm.GetGameResult();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            gvm.StartGame();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            gvm.ResetEverything();
        }
    }
}
