using System;

namespace Excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"sandbox_test.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
        }
    }
}
