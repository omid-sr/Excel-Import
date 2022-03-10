using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Grand.Business.System.Utilities;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Excel = Microsoft.Office.Interop.Excel;
namespace ExcelTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var byteArray = File.ReadAllBytes(@"C:\Users\saremi\source\repos\Excel\ExcelTest\nullPrize.xlsx");
            using (var stream = new MemoryStream(byteArray))
            {
                var workbook = new XSSFWorkbook(stream);
                var worksheet = workbook.GetSheetAt(0);
                var list = new List<NullPirzesModel>();
                var manager = GetPropertyManager<NullPirzesModel>(worksheet);

                for (var iRow = 1; iRow < worksheet.PhysicalNumberOfRows; iRow++)
                {

                    manager.ReadFromXlsx(worksheet, iRow);
                    list.Add(new NullPirzesModel()
                    {
                        Code = manager.GetProperty("code").StringValue,
                        Description = manager.GetProperty("description").StringValue,
                        Title = manager.GetProperty("title").StringValue,
                        GroupId = manager.GetProperty("groupId").IntValue,
                        
                    });
                }
            }
        }

        public static PropertyManager<T> GetPropertyManager<T>(ISheet worksheet)
        {
            var properties = new List<PropertyByName<T>>();
            var poz = 0;
            while (true)
            {
                try
                {
                    var cell = worksheet.GetRow(0).Cells[poz];

                    if (cell == null || string.IsNullOrEmpty(cell.StringCellValue))
                        break;

                    poz += 1;
                    properties.Add(new PropertyByName<T>(cell.StringCellValue.ToLower()));
                }
                catch
                {
                    break;
                }
            }
            return new PropertyManager<T>(properties.ToArray());
        }


    }
}
