using ElectricityCost.Core;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectricityCost.WpfApp
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

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(PowerTextBox.Text, out int powerConsumption))
            {
                MessageBox.Show("Palun sisestage kehtiv võimsustarbimine (W)");
                return;
            }

            if (powerConsumption <= 0)
            {
                MessageBox.Show("Energiatarbimine peab olema suurem kui 0");
                return;
            }

            if (!double.TryParse(UsageHoursTextBox.Text, out double usageHours))
            {
                MessageBox.Show("Palun sisestage kehtivad kasutustunnid");
                return;
            }

            if (usageHours < 0 || usageHours > 24)
            {
                MessageBox.Show("Kasutustundide arv peab olema vahemikus 0–24");
                return;
            }

            if (!double.TryParse(EnergyPriceTextBox.Text, out double energyPrice))
            {
                MessageBox.Show("Palun sisestage kehtiv energiahind (€/kWh). Näiteks: 0,0504 = 5,04 senti");
                return;
            }

            if (energyPrice < 0)
            {
                MessageBox.Show("Energia hind ei saa olla negatiivne");
                return;
            }

            double result = ElectricityCostCalculator.Calculate(powerConsumption, usageHours, energyPrice);

            CostTextBox.Text = result.ToString("F2");
        }
    }
}