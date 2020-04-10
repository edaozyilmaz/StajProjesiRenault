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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Spire.Xls;
using Spire.Xls.Converter;
using System.Drawing;

namespace Akış
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        internal string combo1;
        public int rowCount;
        public MainWindow()
        {
            InitializeComponent();
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            Excel.Range range;
            excelApp.Visible = false;

            //get data from the excel file
            workbook = excelApp.Workbooks.Open(System.IO.Path.GetFullPath("Data.xlsm")); ;   //path of the excel file
            worksheet = (Excel.Worksheet)workbook.Sheets["Sayfa1"];

            int row = 1;

            range = worksheet.UsedRange;
            rowCount = range.Rows.Count;

            for (row = 2; row <= range.Rows.Count; row++)
            {
                if (comboBox1.Items.Contains((range.Cells[row, 1] as Excel.Range).Value2) == false)   
                    comboBox1.Items.Add((range.Cells[row, 1] as Excel.Range).Value2);
            }

            workbook.Close(true, Missing.Value, Missing.Value);
            excelApp.Quit();
        }

        private void MouseButtonEventHandler(object sender, RoutedEventArgs e)
        {
            if(comboBox1.Text == "--Parça Seçiniz--" && referenceNo.Text == "")
            {
                MessageBox.Show("Lütfen parça seçiniz..", "Hata!");
                comboBox1.Text = "--Parça Seçiniz--";
                referenceNo.Text = "";
            }
            else if(comboBox1.Text != "--Parça Seçiniz--" && referenceNo.Text != "")
            {
                MessageBox.Show("Lütfen parça adı ya da referans numarasından SADECE bir tanesini giriniz.", "Hata!");
                comboBox1.Text = "--Parça Seçiniz--";
                referenceNo.Text = "";
            }
            else 
            {
                this.Tag = "";
                Window1 subWindow = new Window1();
                if (subWindow.close == true)
                {
                    MessageBox.Show("Yanlış referans numarası.", "Hata!");
                }
                else
                {
                    combo1 = comboBox1.Text.ToString();
                    subWindow.Tag = "FluxWindow";
                    subWindow.Show();
                }
                comboBox1.Text = "--Parça Seçiniz--";
                referenceNo.Text = "";
            }
        }

        private void MouseButtonAddPath(object sender, RoutedEventArgs e)
        {
            if (this.enterCountry.Text != "" && this.enterDayNumber.Text != "" && this.enterFlux.Text != "" && this.enterCompanyName.Text != "" && this.enterToolName.Text != "" && this.enterReferenceNo.Text != "")
            {
                //write the new data to the excel file
                Excel.Application excelApp = new Excel.Application();
                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                Spire.Xls.Worksheet worksheet;
                excelApp.Visible = false;

                //workbook = excelApp.Workbooks.Open(System.IO.Path.GetFullPath("..\\..\\Resources\\Data.xlsm"), ReadOnly:false);   //path of the excel file
                workbook.LoadFromFile(System.IO.Path.GetFullPath("Data.xlsm"));
                worksheet = (Spire.Xls.Worksheet)workbook.Worksheets["Sayfa1"];

                int selectedRow = worksheet.Range.RowCount;
                selectedRow++;

                (worksheet.Range["A" + selectedRow.ToString()]).Value2 = enterToolName.Text;
                (worksheet.Range["B" + selectedRow.ToString()]).Value2 = enterCountry.Text;
                (worksheet.Range["C" + selectedRow.ToString()]).Value2 = enterFlux.Text;
                (worksheet.Range["D" + selectedRow.ToString()]).Value2 = enterDayNumber.Text + " gün";
                (worksheet.Range["E" + selectedRow.ToString()]).Value2 = enterCompanyName.Text;
                (worksheet.Range["F" + selectedRow.ToString()]).Value2 = enterReferenceNo.Text;

                //workbook.SaveAs(System.IO.Path.GetFullPath("..\\..\\Resources\\Data.xlsm"), XlFileFormat.xlOpenXMLTemplateMacroEnabled ,  Missing.Value, Missing.Value,
                //                 false, false, XlSaveAsAccessMode.xlShared, false, false, Missing.Value,
                //                 Missing.Value, Missing.Value);
                //workbook.SaveToFile("Data.xlsm",ExcelVersion.Version2016);
                workbook.SaveToFile(System.IO.Path.GetFullPath("Data.xlsm"), FileFormat.Version2016);
                
                //workbook.Close(true, Missing.Value, Missing.Value);
                excelApp.Quit();

                //add country name to the comboBox1
                comboBox1.Items.Add(enterToolName.Text);

                MessageBox.Show("Akış eklendi.");

                //clear the textBoxs
                enterCountry.Text = "";
                enterFlux.Text = "";
                enterDayNumber.Text = "";
                enterCompanyName.Text = "";
                enterToolName.Text = "";
                enterReferenceNo.Text = "";
            }
            else
            {
                MessageBox.Show("Eksik bilgi girdiniz!","Hata!");
            }
        }

        private void popUpScreen(object sender, RoutedEventArgs e)
        {
            if (popUp.IsOpen == false)
                popUp.IsOpen = true;
            else if (popUp.IsOpen == true)
                popUp.IsOpen = false;
        }

        private void popUpScreen1(object sender, RoutedEventArgs e)
        {
            if (popUp1.IsOpen == false)
                popUp1.IsOpen = true;
            else if (popUp1.IsOpen == true)
                popUp1.IsOpen = false;
        }

        private void popUpScreen2(object sender, RoutedEventArgs e)
        {
            if (popUp2.IsOpen == false)
                popUp2.IsOpen = true;
            else if (popUp2.IsOpen == true)
                popUp2.IsOpen = false;
        }

        private void popUpScreen3(object sender, RoutedEventArgs e)
        {
            if (popUp3.IsOpen == false)
                popUp3.IsOpen = true;
            else if (popUp3.IsOpen == true)
                popUp3.IsOpen = false;
        }

        private void popUpScreen4(object sender, RoutedEventArgs e)
        {
            if (popUp4.IsOpen == false)
                popUp4.IsOpen = true;
            else if (popUp4.IsOpen == true)
                popUp4.IsOpen = false;
        }

        private void popUpScreen5(object sender, RoutedEventArgs e)
        {
            if (popUp5.IsOpen == false)
                popUp5.IsOpen = true;
            else if (popUp5.IsOpen == true)
                popUp5.IsOpen = false;
        }

    }
}
