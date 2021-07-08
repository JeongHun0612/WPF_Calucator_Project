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
            void calculation(string m_selectedOperator)
            {
                selectedOperator = m_selectedOperator;
                if (resultPreviewLabel.Content != null && !isCalu)
                {
                    isCalu = true;
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
                        case "×":
                            resultNumber = SimpleMath.Multiple(firstNumber, secondNumber);
                            break;
                        case "÷":
                            resultNumber = SimpleMath.Divide(firstNumber, secondNumber);
                            break;
                    }
                    resultPreviewLabel.Content = resultNumber.ToString() + m_selectedOperator;
                    resultLabel.Content = resultNumber.ToString();
                    firstNumber = resultNumber;
                }
                else
                {
                    isCalu = true;
                    resultPreviewLabel.Content = resultLabel.Content.ToString() + m_selectedOperator;
                    double.TryParse(resultLabel.Content.ToString(), out firstNumber);
                }
                progressResultLabelContent = null;
            }
            if (sender == plusBtn) calculation("+");
            if (sender == minusBtn) calculation("-");
            if (sender == multBtn) calculation("×");
            if (sender == divideBtn) calculation("÷");
        }
        private void AllClearBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            progressResultLabelContent = null;
            resultPreviewLabel.Content = null;
            firstNumber = 0.0;
            secondNumber = 0.0;
            selectedOperator = null;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            progressResultLabelContent = null;
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resultBtn_Click(object sender, RoutedEventArgs e)
        {
            if (resultPreviewLabel.Content != null && !isCalu)
            {
                isCalu = true;
                double.TryParse(resultLabel.Content.ToString(), out secondNumber);

                switch (selectedOperator)
                {
                    case "+":
                        resultNumber = SimpleMath.Add(firstNumber, secondNumber);
                        break;
                    case "-":
                        resultNumber = SimpleMath.Subtract(firstNumber, secondNumber);
                        break;
                    case "×":
                        resultNumber = SimpleMath.Multiple(firstNumber, secondNumber);
                        break;
                    case "÷":
                        resultNumber = SimpleMath.Divide(firstNumber, secondNumber);
                        break;
                }
                resultPreviewLabel.Content = firstNumber.ToString() + selectedOperator + secondNumber.ToString() + "=";
                resultLabel.Content = resultNumber.ToString();
                firstNumber = resultNumber;
            }
            else
            {
                resultPreviewLabel.Content = resultLabel.Content + "=";
            }
            progressResultLabelContent = null;
        }

        private void dotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender == dotBtn)
            {
                if (resultLabel.Content.ToString().Contains(".") == false)
                {
                    progressResultLabelContent = resultLabel.Content + ".";
                    resultLabel.Content += ".";
                }
            }
        }
    }
}

