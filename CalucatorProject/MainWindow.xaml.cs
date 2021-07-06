using System;
using System.Windows;
using System.Windows.Controls;

namespace CalucatorProject
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNumber = 0.0;
        private double secondNumber = 0.0;
        private double resultNumber = 0.0;
        private string selectedOperator = null;
        private string progressResultLabelContent = null;

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

            for (int i = 0; i < numBtnArray.Length; i++)
            {
                if (sender == numBtnArray[i])
                {
                    selectedValue = i;
                    progressResultLabelContent = (progressResultLabelContent == null) ? selectedValue.ToString() : progressResultLabelContent += selectedValue.ToString();
                    resultLabel.Content = progressResultLabelContent;
                }
            }

            isCalu = false;
        }

        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            void test(string m_operator)
            {
                if (!isCalu)
                {
                    isCalu = true;

                    if (resultPreviewLabel.Content == null)
                    {
                        double.TryParse(resultLabel.Content.ToString(), out firstNumber);
                    }
                    else
                    {
                        double.TryParse(resultLabel.Content.ToString(), out secondNumber);

                        string lastString = resultPreviewLabel.Content.ToString().Substring(resultPreviewLabel.Content.ToString().Length - 1);

                        switch (lastString)
                        {
                            case "+":
                                resultNumber = SimpleMath.Add(firstNumber, secondNumber);
                                break;
                            case "-":
                                resultNumber = SimpleMath.Subtract(firstNumber, secondNumber);
                                break;
                            case "*":
                                resultNumber = SimpleMath.Multiple(firstNumber, secondNumber);
                                break;
                            case "/":
                                resultNumber = SimpleMath.Divide(firstNumber, secondNumber);
                                break;
                        }
                        resultLabel.Content = resultNumber;
                        firstNumber = resultNumber;
                    }
                    resultPreviewLabel.Content += progressResultLabelContent + m_operator;
                    progressResultLabelContent = null;
                }
                else
                {
                    resultPreviewLabel.Content = resultPreviewLabel.Content.ToString().Substring(0, resultPreviewLabel.Content.ToString().Length - 1) + m_operator;
                }
            }


            if (sender == plusBtn)
            {
                selectedOperator = "+";
                test(selectedOperator);
            }

            if (sender == minusBtn)
            {
                selectedOperator = "-";
                test(selectedOperator);
            }
            if (sender == multBtn)
            {
                selectedOperator = "*";
                test(selectedOperator);
            }
            if (sender == divideBtn)
            {
                selectedOperator = "/";
                test(selectedOperator);
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
            double.TryParse(resultLabel.Content.ToString(), out secondNumber);

            string lastString = resultPreviewLabel.Content.ToString().Substring(resultPreviewLabel.Content.ToString().Length - 1);

            switch (lastString)
            {
                case "+":
                    resultNumber = SimpleMath.Add(firstNumber, secondNumber);
                    break;
                case "-":
                    resultNumber = SimpleMath.Subtract(firstNumber, secondNumber);
                    break;
                case "*":
                    resultNumber = SimpleMath.Multiple(firstNumber, secondNumber);
                    break;
                case "/":
                    resultNumber = SimpleMath.Divide(firstNumber, secondNumber);
                    break;
            }
            resultLabel.Content = resultNumber;
            resultPreviewLabel.Content = null;
        }

        private void dotBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
