using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WMCassignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        inputDataGridList tableInput { get; set; }
        string inputData { get; set; }
        string BinaryOut { get; set; }
        public class outputDataGrid
        {
            public string Binary_Equivalent { get; set; }
            public int ASCII_Value { get; set; }
            public char Input_Character  { get; set; }
            public outputDataGrid(char c, int ascii, string b)
            {
                Input_Character = c;
                ASCII_Value = ascii;
                Binary_Equivalent = b;
            }
        }

        public class inputDataGrid
        {
            public char Input_Character { get; set; }
            public int ASCII_Value { get; set; }
            public string Binary_Equivalent { get; set; }
            public inputDataGrid(char c, int ascii , string b)
            {
                Input_Character = c;
                ASCII_Value = ascii;
                Binary_Equivalent = b;
            }
        }

        public class inputDataGridList
        {
            public List<inputDataGrid> data { get; set; }
            public inputDataGridList()
            {
                data = new List<inputDataGrid>();
            }
            public void addData(char c, int Ascii, string Binary)
            {
                data.Add(new inputDataGrid(c, Ascii, Binary));
            }

            public List<inputDataGrid> toTableData()
            {
                return data;
            }
        }

        public class outputDataGridList
        {
            public List<outputDataGrid> data { get; set; }
            public outputDataGridList()
            {
                data = new List<outputDataGrid>();
            }
            public void addData(char c, int Ascii, string Binary)
            {
                data.Add(new outputDataGrid(c, Ascii, Binary));
            }

            public List<outputDataGrid> toTableData()
            {
                return data;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                inputData = inputTextbox.Text;

                tableInput = new inputDataGridList();
                 BinaryOut = "";
                foreach (var c in inputData)
                {
                    tableInput.addData(c, c, Convert.ToString(c, 2).PadLeft(8, '0'));
                    BinaryOut += Convert.ToString(c, 2).PadLeft(8, '0');
                    
                }

                sendTable.ItemsSource = tableInput.data;

                binOutput.Text = BinaryOut;

                binInput.Text = BinaryOut;

                outputDataGridList tableOutput = new outputDataGridList();
                int i = 0;
                foreach (var c in inputData)
                {
                    tableOutput.addData(tableInput.data[i].Input_Character, tableInput.data[i].ASCII_Value, tableInput.data[i].Binary_Equivalent);
                    i++;
                }
                receiveTable.ItemsSource = tableOutput.data;

                outputTextbox.Text = inputData;

            }));

            
        }
    }
}
