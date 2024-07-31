using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace CompleteCalculaitor
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string Num1 = "";
        string Num2 = "";
        double numFLoat1 = 0f;
        double numFLoat2 = 0f;
        double res = 0f;
        bool isNum2 = false;
        char operation = ' ';


        public MainPage()
        {
            this.InitializeComponent();
        }

        
        private void numberClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int buttonText = int.Parse(button.Content.ToString());

            if (!isNum2)
            {
                switch (buttonText)
                {
                    case 1:
                        Num1 += "1";
                        break;
                    case 2:
                        Num1 += "2";
                        break;
                    case 3:
                        Num1 += "3";
                        break;
                    case 4:
                        Num1 += "4";
                        break;
                    case 5:
                        Num1 += "5";
                        break;
                    case 6:
                        Num1 += "6";
                        break;
                    case 7:
                        Num1 += "7";
                        break;
                    case 8:
                        Num1 += "8";
                        break;
                    case 9:
                        Num1 += "9";
                        break;
                    case 0:
                        Num1 += "0";
                        break;
                    default:
                        ContentText.Text = "Qualcosa è andato storto!";
                        break;

                }
                ContentText.Text = Num1;
            }
            else
            {
                switch (buttonText)
                {
                    case 1:
                        Num2 += "1";
                        break;
                    case 2:
                        Num2 += "2";
                        break;
                    case 3:
                        Num2 += "3";
                        break;
                    case 4:
                        Num2 += "4";
                        break;
                    case 5:
                        Num2 += "5";
                        break;
                    case 6:
                        Num2 += "6";
                        break;
                    case 7:
                        Num2 += "7";
                        break;
                    case 8:
                        Num2 += "8";
                        break;
                    case 9:
                        Num2 += "9";
                        break;
                    case 0:
                        Num2 += "0";
                        break;
                    default:
                        ContentText.Text = "Qualcosa è andato storto!";
                        break;

                }
                ContentText.Text = Num2;
            }


        }

        private void onOperatorClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            char carattere = char.Parse(btn.Content.ToString());
            operation = carattere;
            isNum2 = true;
            ContentText.Text += operation;
        }

        private void onResultClick(object sender, RoutedEventArgs e)
        {
            try
            {
                numFLoat1 = double.Parse(Num1.ToString());
                numFLoat2 = double.Parse(Num2.ToString());
                switch(operation)
                {
                    case '+':
                        res = numFLoat1+numFLoat2;
                        break;
                    case '-':
                        res = numFLoat1 - numFLoat2;
                        break;
                    case 'X':
                        res = numFLoat1 * numFLoat2;
                        break;
                    case '÷':
                        res = numFLoat1 / numFLoat2;
                        break;
                    case '%':
                        res = numFLoat1 / 100 * numFLoat2;
                        break;
                    default:
                        ContentText.Text = "Qualcosa è andato storto!";
                        break;


                }

                txtCronologia.Text += $"\n{Num1}{operation}{Num2}={res}";
                ContentText.Text = res.ToString();
                isNum2 = false;
                Num1 = res.ToString();
                Num2 = "";

            }
            catch(Exception ex)
            {
                ContentText.Text = $"Qualcosa è andato storto!\tErrore: {ex.Message}";
            }
        }


        private void onAClick(object sender, RoutedEventArgs e)
        {
            ContentText.FontSize = 502;
            isNum2 = false;
            Num1 = "";
            Num2 = "";
            operation = ' ';
            ContentText.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                numFLoat1 = double.Parse(Num1.ToString());
                numFLoat2 = double.Parse(Num2.ToString());

                if (isNum2)
                {
                    Num2 = Math.Sqrt(numFLoat2).ToString(CultureInfo.InvariantCulture);
                    ContentText.Text = Num2.ToString();


                }
                else
                {
                    Num1 = Math.Sqrt(numFLoat1).ToString(CultureInfo.InvariantCulture);
                    ContentText.Text = Num2;
                }
            }
            catch(Exception ex)
            {
                ContentText.FontSize = 14;
                ContentText.Text = $"Qualcosa è andato storto: {ex.Message}\nPer favore seleziona il tasto CE per continuare...";
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isNum2)
            {
                Num1 = Num1.Remove(Num1.Length-1);
                ContentText.Text = Num1;
            }
            else
            {
                Num2 = Num2.Remove(Num2.Length - 1);
                ContentText.Text = Num2;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!isNum2)
            {
                double.TryParse(Num1.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out numFLoat1);
                Num1 = Math.Pow(numFLoat1, 2).ToString();
                ContentText.Text = Num1;
            }
            else
            {
                double.TryParse(Num2.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out numFLoat2);
                Num2 = Math.Pow(numFLoat2, 2).ToString();
                ContentText.Text = Num2;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!isNum2)
            {
                double.TryParse(Num1.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out numFLoat1);
                Num1 = (1/numFLoat1).ToString();
                ContentText.Text = Num1;
            }
            else
            {
                double.TryParse(Num2.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out numFLoat2);
                Num2 = (1/numFLoat2).ToString();
                ContentText.Text = Num2;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!isNum2)
            {
                if (Num1[0] != '-')
                {
                    Num1 = "-" + Num1;
                }
                else
                {
                    Num1.Remove(0);
                }
                ContentText.Text = Num1;
            }
            else
            {
                if (Num2[0] != '-')
                {
                    Num2 = "-" + Num2;
                }
                else
                {
                    Num2.Remove(0);
                }
                ContentText.Text = Num2;
            }
        }
    }
}
