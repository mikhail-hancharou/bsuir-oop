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

namespace BankingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                string login = logBox.Text.Trim();
                string passw = pasBox.Password.Trim();

                if (login.Length > 5)
                {
                    pasBox.Background = Brushes.Transparent;
                    logBox.ToolTip = "Lenght should be less than or equal to 5";
                    logBox.Background = Brushes.Red;
                }
                else if (login.Length == 0)
                {
                    pasBox.Background = Brushes.Transparent;
                    logBox.ToolTip = "Enter your login";
                    logBox.Background = Brushes.Red;
                }
                else if (passw.Length > 5)
                {
                    logBox.Background = Brushes.Transparent;
                    pasBox.ToolTip = "Lenght should be less than or equal to 5";
                    pasBox.Background = Brushes.Red;
                }
                else if (passw.Length == 0)
                {
                    logBox.Background = Brushes.Transparent;
                    pasBox.ToolTip = "Enter your password";
                    pasBox.Background = Brushes.Red;
                }
                else
                {
                    logBox.ToolTip = "";
                    logBox.Background = Brushes.Transparent;
                    pasBox.ToolTip = "";
                    pasBox.Background = Brushes.Transparent;

                    MessageBox.Show("Entering completed O_o");
                }
            }
        }
    }
}
