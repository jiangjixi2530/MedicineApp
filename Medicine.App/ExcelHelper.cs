using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace Medicine.App
{
    /// <summary>
    /// EXCEL操作帮助类
    /// </summary>
    public class ExcelHelper
    {
        private IWorkbook workBook;
        private string filePath;
        /// <summary>
        /// 当前打开的Excel
        /// </summary>
        public IWorkbook WorkBook => workBook;
        public bool OpenExcel(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workBook = CreateWorkbook(fileStream);
            }
            this.filePath = filePath;
            return true;

        }
        /// <summary>
        /// 创建工作簿对象
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private IWorkbook CreateWorkbook(Stream stream)
        {
            try
            {
                return new XSSFWorkbook(stream); //07
            }
            catch
            {
                return new HSSFWorkbook(stream); //03
            }

        }
        /// <summary>
        /// 导出工作簿到DataTable
        /// </summary>
        /// <param name="sheetIndex"></param>
        /// <returns></returns>
        public DataTable ExportToDateTable(int sheetIndex = 0)
        {
            return ExportToDataTable(workBook.GetSheetAt(sheetIndex));
        }
        /// <summary>
        /// 把Sheet中的数据转换为DataTable
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private DataTable ExportToDataTable(ISheet sheet)
        {
            DataTable dt = new DataTable();

            //默认，第一行是字段
            IRow headRow = sheet.GetRow(0);

            //设置datatable字段
            for (int i = headRow.FirstCellNum, len = headRow.LastCellNum; i < len; i++)
            {
                dt.Columns.Add(headRow.Cells[i].StringCellValue);
            }
            //遍历数据行
            for (int i = (sheet.FirstRowNum + 1), len = sheet.LastRowNum + 1; i < len; i++)
            {
                IRow tempRow = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                //遍历一行的每一个单元格
                for (int r = 0, j = tempRow.FirstCellNum, len2 = tempRow.LastCellNum; j < len2; j++, r++)
                {

                    ICell cell = tempRow.GetCell(j);

                    if (cell != null)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.String:
                                dataRow[r] = cell.StringCellValue;
                                break;
                            case CellType.Numeric:
                                dataRow[r] = cell.NumericCellValue;
                                break;
                            case CellType.Boolean:
                                dataRow[r] = cell.BooleanCellValue;
                                break;
                            default:
                                dataRow[r] = "";
                                break;
                        }
                    }
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        /// <summary>
        /// Excel中默认第一张Sheet导出到集合
        /// </summary>
        /// <param name="fields">Excel各个列，依次要转换成为的对象字段名称</param>
        /// <returns></returns>
        public IList<T> ExcelToList<T>(int sheetIndex = 0) where T : class, new()
        {
            return ExportToList<T>(workBook.GetSheetAt(sheetIndex));
        }
        /// <summary>
        /// Sheet中的数据转换为List集合
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private IList<T> ExportToList<T>(ISheet sheet) where T : class, new()
        {
            IList<T> list = new List<T>();
            DataTable dt = ExportToDataTable(sheet);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                T s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        public void ImportToExcel<T>(IList<T> list, string sheetName)
        {
            ISheet sheet = workBook.GetSheet(sheetName);
            if (sheet == null)
            {
                sheet = workBook.CreateSheet(sheetName);
            }
            var headRow = sheet.CreateRow(0);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            for (int i = 0; i < plist.Count; i++)
            {
                ICell cell = headRow.CreateCell(i);
                cell.SetCellValue(plist[i].Name);
            }
            for (int i = 1; i <= list.Count; i++)
            {
                IRow row = sheet.CreateRow(i);
                for (int j = 0; j < plist.Count; j++)
                {
                    ICell cell = row.CreateCell(j);
                    var o = plist[j].GetValue(list[i - 1], null);
                    if (o != null)
                        cell.SetCellValue(o.ToString());
                }
            }
            using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workBook.Write(fileStream);
                fileStream.Close();
            }
        }
    }
}
