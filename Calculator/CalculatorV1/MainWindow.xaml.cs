using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double result = 0;
        Double num = 0;
        String currentOperator = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textResult.Text=="0")
            {
                textResult.Clear();
            }

            Button button = (Button)sender;
            Object currentInput = button.Content;
            if (currentOperator != "")
            {
                 num = num*10 + Double.Parse(currentInput.ToString());
            }
            textResult.Text += currentInput.ToString();
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
        }

        public void Operation_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            if (currentOperator == "")
            {
                currentOperator = button.Content.ToString();
                result = Double.Parse(textResult.Text);
            }
            else
            {
                switch (currentOperator)
                {
                    case "+":
                        result += num;
                        num = 0;
                        break;
                    case "--":
                        result -= num;
                        num = 0;
                        break;
                    case "x":
                        result *= num;
                        num = 0;
                        break;
                    case "/":
                        result /= num;
                        break;
                }
                currentOperator = button.Content.ToString();
            }
            textResult.Text += currentOperator;
        }

        public void Answer_Click(object sender, RoutedEventArgs e)
        {
            switch(currentOperator)
            {
                case "+":
                    result += num;
                    break;
                case "--":
                    result -= num;
                    break;
                case "x":
                    result *= num;
                    break;
                case "/":
                    result /= num;
                    break;
            }
            textResult.Text = result.ToString();
            currentOperator = "";
            num = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}