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

namespace LottoApp
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

        public int Count { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int userNumber1 = 0;
            int userNumber2 = 0;

            if (int.TryParse(userInput1.Text, out userNumber1))
            {
                error1.Content = "";
            }
            else
            {
                error1.Content = "Błedne dane";
                userNumber1 = 0;
            }

            if (int.TryParse(userInput2.Text, out userNumber2))
            {
                error2.Content = "";
            }
            else
            {
                error2.Content = "Błedne dane";
                userNumber2 = 0;
            }

            if (userNumber1 != 0 && userNumber2 != 0 && userNumber1 <= userNumber2)
            {
                var number = RandomNumberNoRepetitions(userNumber1, userNumber2);

                for (int i = 0; i <= number.Count - 1; i++)
                {
                    result.Text += (i == 0 ? Count + ")\t" : "") + (i == 0 ? "" : "\t") + number[i]
                        + (i != number.Count - 1 ? ", " : Environment.NewLine + Environment.NewLine);
                }
                Count++;
            }
            else
            {
                error1.Content = "Za duża liczba";
            }
        }

        private void Button_Click_Clean(object sender, RoutedEventArgs e)
        {
            Count = 0;
            result.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public int RandomNumber(int maxNumber, int minNumber = 1)
        {
            var rng = new Random();
            return rng.Next(minNumber, maxNumber + 1);
        }

        public List<int> RandomNumberNoRepetitions(int howManyNumbers, int maxNumber)
        {
            List<int> result = new List<int>();
            while (result.Count != howManyNumbers)
            {
                var number = RandomNumber(maxNumber);

                if (!result.Contains(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}
