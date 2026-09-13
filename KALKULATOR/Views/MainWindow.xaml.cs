using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using KALKULATOR.Views;
using KALKULATOR.Services;


namespace KALKULATOR.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool colors = false;
        private string selectedZone;
        public Brush colorbutton = Brushes.Black;
        public Brush colorbackground = Brushes.Black;
        public Brush colorfont = Brushes.LightSteelBlue;
        public MainWindow()
        {
            InitializeComponent();
            ColorZone.SelectedIndex = 0;
            ChangeAllButtonsColor(colorbutton);
            ChangeAllButtonsTextColor(colorfont);
            this.Background = colorbackground;
        }

        public MainWindow(Brush bg, Brush btn, Brush font)
        {
            InitializeComponent();
            ColorZone.SelectedIndex = 0;
            ChangeAllButtonsColor(btn);
            ChangeAllButtonsTextColor(font);
            this.Background = bg;

        }


        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            ResultDisplay.Text += ((Button)sender).Content.ToString();
        }

   
        private void OpButton_Click(object sender, RoutedEventArgs e)
        {
            
            ResultDisplay.Text += ((Button)sender).Content.ToString();
        }

      
        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            string oldText = ResultDisplay.Text; 
            Calculate();                          
            string result = ResultDisplay.Text;    

 
            SaveToLog($"{oldText}={result}");
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            string logPath = "calculator_log.txt";

            if (File.Exists(logPath))
            {
                string history = File.ReadAllText(logPath);
                MessageBox.Show(history, "История вычислений");
            }
            else
            {
                MessageBox.Show("История пуста");
            }
        }
        private void ClearLog_Click(object sender, RoutedEventArgs e)
        {
            string logPath = "calculator_log.txt";

            if (File.Exists(logPath))
            {
                File.Delete(logPath); 
                MessageBox.Show("История очищена");
            }
        }

        private void SaveToLog(string newtext)
        {
            string logPath = "calculator_log.txt"; 

            using (StreamWriter writer = File.AppendText(logPath))
            {
                writer.WriteLine($"{DateTime.Now}: {newtext}");
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultDisplay.Text = "";
        }

     
        private void Calculate()
        {
            try
            {
                string text = ResultDisplay.Text;
                text = text.Replace(",", ".");

              
                if (string.IsNullOrWhiteSpace(text))
                {
                    ResultDisplay.Text = "0";
                    return;
                }

              
                var result = new DataTable().Compute(text, null);
                ResultDisplay.Text = result.ToString();
            }
            catch
            {
                ResultDisplay.Text = "Ошибка";
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            EngineerCalculator engineerWindow = new EngineerCalculator(colorbackground, colorbutton, colorfont);
            engineerWindow.Show();
            this.Close();
        }



        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!colors)
            {
                colorz.Visibility = Visibility.Visible;
                colors = true;
            }
            else
            {
                colorz.Visibility = Visibility.Collapsed;
                colors = false;
            }
        }
        private void ColorZone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = ColorZone.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                selectedZone = selectedItem.Content.ToString();
            }
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            Button clickedbtn = sender as Button;
            string newColor = clickedbtn.Name;
            Brush color = Brushes.DarkGray;
            switch (newColor)
            {
                case ("Red"):
                    color = Brushes.Red;
                    break;
                case ("Blue"):
                    color = Brushes.Blue;
                    break;
                case ("Green"):
                    color = Brushes.Green;
                    break;
                case ("White"):
                    color = Brushes.White;
                    break;
                case ("Black"):
                    color = Brushes.Black;
                    break;
                case ("Yellow"):
                    color = Brushes.Yellow;
                    break;
                case ("Cyan"):
                    color = Brushes.Cyan;
                    break;
                case ("Gray"):
                    color = Brushes.Gray;
                    break;
                case ("Purple"):
                    color = Brushes.Purple;
                    break;
            }
            if (selectedZone == "Фон")
            {

                this.Background = color;
                colorbackground = color;
            }
            else if (selectedZone == "Текст")
            {
                ChangeAllButtonsTextColor(color);
                colorfont = color;
            }
            else
            {
                ChangeAllButtonsColor(color);
                colorbutton = color;
            }

        }

        private void ChangeAllButtonsColor(Brush color)
        {
            B1.Background = color;
            B2.Background = color;
            B3.Background = color;
            B4.Background = color;
            B5.Background = color;
            B6.Background = color;
            B7.Background = color;
            B8.Background = color;
            B9.Background = color;
            B0.Background = color;
            BPlus.Background = color;
            BMinus.Background = color;
            BMult.Background = color;
            BDiv.Background = color;
            BDot.Background = color;
            BColor.Background = color;
            BHistory.Background = color;
            BChange.Background = color;
            ClearLogButton.Background = color;
            BEqual.Background = color;
            BClear.Background = color;
            ResultDisplay.Background = color;
        }

        private void ChangeAllButtonsTextColor(Brush color)
        {
            B1.Foreground = color;
            B2.Foreground = color;
            B3.Foreground = color;
            B4.Foreground = color;
            B5.Foreground = color;
            B6.Foreground = color;
            B7.Foreground = color;
            B8.Foreground = color;
            B9.Foreground = color;
            B0.Foreground = color;
            BPlus.Foreground = color;
            BMinus.Foreground = color;
            BMult.Foreground = color;
            BDiv.Foreground = color;
            BDot.Foreground = color;
            BEqual.Foreground = color;
            BClear.Foreground = color;
            BColor.Foreground = color;
            BHistory.Foreground = color;
            BChange.Foreground = color;
            ClearLogButton.Foreground = color;
            ResultDisplay.Foreground = color;
            B1.BorderBrush = color;
            B2.BorderBrush = color;
            B3.BorderBrush = color;
            B4.BorderBrush = color;
            B5.BorderBrush = color;
            B6.BorderBrush = color;
            B7.BorderBrush = color;
            B8.BorderBrush = color;
            B9.BorderBrush = color;
            B0.BorderBrush = color;
            BPlus.BorderBrush = color;
            BMinus.BorderBrush = color;
            BMult.BorderBrush = color;
            BDiv.BorderBrush = color;
            BDot.BorderBrush = color;
            BEqual.BorderBrush = color;
            BClear.BorderBrush = color;
            BColor.BorderBrush = color;
            BHistory.BorderBrush = color;
            BChange.BorderBrush = color;
            ClearLogButton.BorderBrush = color;
            ResultDisplay.BorderBrush = color;
        }
    }
}
