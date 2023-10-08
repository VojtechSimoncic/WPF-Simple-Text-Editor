using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Text_Editor
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

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Documents|*.txt";
            if(saveFile.ShowDialog() == true)
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                sw.Write(textBox.Text);
                sw.Close();
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"";
            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = "Text documents|*.txt";

            bool? result = fileDialog.ShowDialog();

            if(result == true)
            {
                textBox.Text = File.ReadAllText(fileDialog.FileName);
            }
        }

        private void FontSizeComboBox(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem != null)
            {
                string selectedFontSize = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
                if (int.TryParse(selectedFontSize, out int fontSize))
                {
                    textBox.FontSize = fontSize;
                }
            }
        }
    }
}
