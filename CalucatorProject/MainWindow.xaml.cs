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

namespace CalucatorProject
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private double resultNumber = 0;
        private String selectedOperator = null;
        private String progressResultLabelContent = null;
        private bool isCalu = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multipleication,
            Division
        }

        public class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }
            public static double Subtract(double n1, double n2)
            {
                return n1 - n2;
            }
            public static double Multiple(double n1, double n2)
            {
                return n1 * n2;
            }
            public static double Divide(double n1, double n2)
            {
                return n1 / n2;
            }
        }
 
        private void numBtn_Click(object sender, RoutedEventArgs e)
        {
            Button[] numBtnArray = { zeroBtn, oneBtn, twoBtn, threeBtn, fourBtn, fiveBtn, sixBtn, sevenBtn, eightBtn, nightBtn };
            int selectedValue = 0;
            //if(selectedOperator != null) resultLabel.Content = "0";

            for (int i = 0; i < numBtnArray.Length; i++)
            {
                if (sender == numBtnArray[i])
                {
                    selectedValue = i;
                    progressResultLabelContent = (progressResultLabelContent == null) ? selectedValue.ToString() : progressResultLabelContent += selectedValue.ToString();
                    resultLabel.Content = progressResultLabelContent;
                }
            }
        }

        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender == plusBtn)
            {
                if (selectedOperator != null)
                {
                    secondNumber = int.Parse(resultLabel.Content.ToString());
                    resultPreviewLabel.Content += resultLabel.Content.ToString() + selectedOperator;

                    switch (selectedOperator)
                    {
                        case "+":
                            {
                                resultLabel.Content = SimpleMath.Add(firstNumber, secondNumber);
                                firstNumber = SimpleMath.Add(firstNumber, secondNumber);
                                break;
                            }
                        case "-":
                            {
                                resultLabel.Content = SimpleMath.Add(firstNumber, secondNumber);
                                break;
                            }
                        case "*":
                            {
                                resultLabel.Content = SimpleMath.Add(firstNumber, secondNumber);
                                break;
                            }
                        case "/":
                            {
                                resultLabel.Content = SimpleMath.Add(firstNumber, secondNumber);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                else
                {
                    selectedOperator = "+";
                    firstNumber = int.Parse(resultLabel.Content.ToString());
                    resultPreviewLabel.Content += resultLabel.Content.ToString() + selectedOperator;
                }
                progressResultLabelContent = null;
            }
            if (sender == minusBtn)
            {
                selectedOperator = "-";
            }
            if (sender == multBtn)
            {
                selectedOperator = "*";
            }
            if (sender == divideBtn)
            {
                selectedOperator = "/";
            }

        }
        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resultBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void dotBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
