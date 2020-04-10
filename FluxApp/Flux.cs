using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Spire.Xls;

namespace Akış
{
    public partial class Flux : Form
    {
        public Flux(){
            InitializeComponent();
            this.label5.Text = ((MainWindow)System.Windows.Application.Current.MainWindow).combo1;
            this.Icon = new System.Drawing.Icon("Renault.ico");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text != "" || this.textBox2.Text != "" || this.textBox3.Text != "" || this.textBox4.Text != "" || this.textBox5.Text != "") {
                //write the new data to the excel file
                Excel.Application excelApp = new Excel.Application();
                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                Spire.Xls.Worksheet worksheet;
                excelApp.Visible = false;

                workbook.LoadFromFile(System.IO.Path.GetFullPath("Data.xlsm"));
                worksheet = (Spire.Xls.Worksheet)workbook.Worksheets["Sayfa1"];

                int selectedRow = 0;    //row number of the selected tool
            
                for(int i=1; i <= worksheet.Range.RowCount ; i++)
                {
                    if ((worksheet.Range["A" + i.ToString()]).Value == this.label5.Text)
                    {
                        selectedRow = i;
                        break;
                    }
                }

                if(this.textBox1.Text != "")
                    (worksheet.Range["C" + selectedRow.ToString()]).Value2 = this.textBox1.Text;
                if (this.textBox2.Text != "")
                    (worksheet.Range["D" + selectedRow.ToString()]).Value2 = this.textBox2.Text + " gün";
                if (this.textBox3.Text != "")
                    (worksheet.Range["B" + selectedRow.ToString()]).Value2 = this.textBox3.Text;
                if (this.textBox4.Text != "")
                    (worksheet.Range["E" + selectedRow.ToString()]).Value2 = this.textBox4.Text;
                if (this.textBox5.Text != "")
                    (worksheet.Range["F" + selectedRow.ToString()]).Value2 = this.textBox5.Text;

                //workbook.SaveAs(System.IO.Path.GetFullPath("..\\..\\Resources\\Data.xlsm"), XlFileFormat.xlWorkbookDefault, Missing.Value, Missing.Value,
                //                 false, false, XlSaveAsAccessMode.xlShared, false, false, Missing.Value,
                //                 Missing.Value, Missing.Value);
                //workbook.Close(true, Missing.Value, Missing.Value);
                workbook.SaveToFile(System.IO.Path.GetFullPath("Data.xlsm"), FileFormat.Version2016);

                excelApp.Quit();

                //update the Window1
                //Window1.CountryName.Content = this.textBox1.Text;
            

                this.Close();


                //close Window1 after the update 
                this.Tag = "";
                foreach (System.Windows.Window win in System.Windows.Application.Current.Windows)
                {
                    if(win.Tag != null)
                        if (win.Tag.ToString() == "FluxWindow")
                            win.Close();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Eksik bilgi girdiniz!", "Hata!");
            }
        }

    }
}
