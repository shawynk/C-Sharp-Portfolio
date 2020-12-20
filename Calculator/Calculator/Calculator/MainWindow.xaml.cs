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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double previous_Answer = 0.0;
        private char operator_Selected = ';';
        private const int MAX_DECIMALS = 12;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enter_value(string value)
        {
            if (Answer.Content.ToString().Equals("0")) Answer.Content = value;
            else if ((Answer.Content.ToString() + value).Length < MAX_DECIMALS) Answer.Content = Answer.Content.ToString() + value;
        }

        private void clear_Entry()
        {
            decimal_Point_Btn.IsEnabled = true;
            Answer.Content = 0;
        }

        private void disable_Operators()
        {
            divide_Btn.IsEnabled = multiply_Btn.IsEnabled = add_Btn.IsEnabled = subtract_Btn.IsEnabled = power_Btn.IsEnabled = false;
        }

        private void enable_Operators()
        {
            divide_Btn.IsEnabled = multiply_Btn.IsEnabled = add_Btn.IsEnabled = subtract_Btn.IsEnabled = power_Btn.IsEnabled = true;
        }

        private void process_Operator(char op)
        {
            previous_Answer = Double.Parse(Answer.Content.ToString());
            clear_Entry();
            operator_Selected = op;
            disable_Operators();
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            enter_value("0");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            enter_value("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            enter_value("2");
        }
        
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            enter_value("3");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            enter_value("4");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            enter_value("5");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            enter_value("6");
        }
        
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            enter_value("7");
        }
        
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            enter_value("8");
        }
        
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            enter_value("9");
        }

        private void Button_Click_Change_Sign(object sender, RoutedEventArgs e)
        {
            Answer.Content = (double)Answer.Content * -1;
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            process_Operator('/');
        }

        private void Button_Click_00(object sender, RoutedEventArgs e)
        {
            if (!Answer.Content.ToString().Equals("0") && (Answer.Content.ToString() + "00").ToString().Length < MAX_DECIMALS) Answer.Content = Answer.Content.ToString() + "00";
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            process_Operator('*');
        }

        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if (Answer.Content.ToString().IndexOf(".") == -1) Answer.Content = Answer.Content + ".";
            decimal_Point_Btn.IsEnabled = false;
            
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            clear_Entry();
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            process_Operator('-');
        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            process_Operator('+');
        }

        private void Button_Click_Power(object sender, RoutedEventArgs e)
        {
            process_Operator('^');
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {

            // perform equation
            switch (operator_Selected)
            {
                case '*':
                    Answer.Content = Math.Round(previous_Answer * Double.Parse(Answer.Content.ToString()), MAX_DECIMALS);
                    break;
                case '/':
                    Answer.Content = Math.Round(previous_Answer / Double.Parse(Answer.Content.ToString()), MAX_DECIMALS);
                    break;
                case '+':
                    Answer.Content = Math.Round(previous_Answer + Double.Parse(Answer.Content.ToString()), MAX_DECIMALS);
                    break;
                case '-':
                    Answer.Content = Math.Round(previous_Answer - Double.Parse(Answer.Content.ToString()), MAX_DECIMALS);
                    break;
                case '^':
                    Answer.Content = Math.Round(Math.Pow(previous_Answer, Double.Parse(Answer.Content.ToString())), MAX_DECIMALS);
                    break;
            }

            operator_Selected = ';';
            // enable operators
            enable_Operators();
        }
    }
}
