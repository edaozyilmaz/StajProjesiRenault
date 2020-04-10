using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Akış
{
    class ExcelData
    {
        public DataView Data
        {
            get
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook;
                Excel.Worksheet worksheet;
                Excel.Range range;
                excelApp.Visible = false;

                //get data from the excel file
                workbook = excelApp.Workbooks.Open(System.IO.Path.GetFullPath("Data.xlsm"));   //path of the excel file
                worksheet = (Excel.Worksheet)workbook.Sheets["Sayfa1"];

                int column = 0;
                int row = 1;

                range = worksheet.UsedRange;
                DataTable dt = new DataTable();
                dt.Columns.Add("toolName");
                dt.Columns.Add("country");
                dt.Columns.Add("flux");
                dt.Columns.Add("dayNumber");
                dt.Columns.Add("companyName");
                dt.Columns.Add("referenceNo");

                int[] selectedRow = new int[range.Rows.Count];
                int selectedRowNumber = 1;

                for (row = 1; row <= range.Rows.Count; row++)
                {
                    string temp = (range.Cells[row, 1] as Excel.Range).Value2 != null ? (range.Cells[row, 1] as Excel.Range).Value2.ToString() : "";
                    string refNo = (range.Cells[row, 6] as Excel.Range).Value2 != null ? (range.Cells[row, 6] as Excel.Range).Value2.ToString() : "";

                    if (((MainWindow)Application.Current.MainWindow).comboBox1.Text !="--Parça Seçiniz--" && ((MainWindow)Application.Current.MainWindow).comboBox1.Text == temp)
                    {
                        selectedRow[selectedRowNumber] = row;
                        selectedRowNumber++;
                        break;
                    }
                    else if (((MainWindow)Application.Current.MainWindow).referenceNo.Text != "" && ((MainWindow)Application.Current.MainWindow).referenceNo.Text == refNo)
                    {
                        selectedRow[selectedRowNumber] = row;
                        selectedRowNumber++;
                        break;
                    }
                }


                for (int a = 1; a <= selectedRowNumber-1; a++)
                {
                    DataRow dr = dt.NewRow();
                    for (column = 1; column <= range.Columns.Count; column++)
                    {
                        dr[column - 1] = (range.Cells[selectedRow[a], column] as Excel.Range).Value2 != null ? (range.Cells[selectedRow[a], column] as Excel.Range).Value2.ToString() : "";

                        
                        //string temp = (range.Cells[row, column] as Excel.Range).Value2.ToString();
                        //MessageBox.Show(temp);

                    }

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

                workbook.Close(true, Missing.Value, Missing.Value);
                excelApp.Quit();

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);


                return dt.DefaultView;
            }
        }
    }
}
