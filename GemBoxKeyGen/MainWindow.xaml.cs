using System;
using System.Collections.Generic;
using System.Linq;
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
using GemBox.Crack;
namespace GemBoxKeyGen
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ProductSoftWare> productVersions = new List<ProductSoftWare>()
            {
                new ProductSoftWare(){ Name="GemBox.Spreadsheet 4.3",ChooseValue=3},
                new ProductSoftWare(){ Name="GemBox.Spreadsheet 4.1",ChooseValue=1},
                new ProductSoftWare(){ Name="GemBox.Document 2.9",ChooseValue=2},
            };
            VersionComboBox.ItemsSource = productVersions;
            VersionComboBox.SelectedIndex = 0;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && e.OriginalSource != SerialKeyText)
            {
                Close();
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SerialKey = string.Empty;
            switch(VersionComboBox.SelectedIndex)
            {
                case 0:
                    SerialKey = GemBox.Crack.KeyGen.CreateSpreadSheetLicense(1);
                    break;
                case 1:
                    SerialKey = GemBox.Crack.KeyGen.CreateSpreadSheetLicense();
                    break;
                case 2:
                    SerialKey = GemBox.Crack.KeyGen.CreateWordLicense();
                    break;
            }
            SerialKeyText.Text = SerialKey;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            About about = new About();
            about.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            about.ShowDialog();
            e.Handled = true;
        }
    }

    public class ProductSoftWare
    {
        public string Name { get; set; }
        public int ChooseValue { get; set; }
    }
}
