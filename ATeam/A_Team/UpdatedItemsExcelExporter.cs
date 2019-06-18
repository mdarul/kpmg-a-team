using System;
using System.Collections.Generic;
using A_Team.Data;
using A_Team.Interfaces;
using OfficeOpenXml;
using System.IO;



namespace A_Team
{
    public class UpdatedItemsExcelExporter
    {
        public static void Export(List<JiraItem> items)
        {
            using (var package = CreateExcelPackage(items))
            {
                var fileInfo = new FileInfo("jiraUpdatedItems.xlsx");
                package.SaveAs(fileInfo);
            }
        }

        public static ExcelPackage CreateExcelPackage(List<JiraItem> items)
        {
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "Updated jira subjects";
            package.Workbook.Properties.Author = "KPMG";
            package.Workbook.Properties.Subject = "Updated jira subjects";
            package.Workbook.Properties.Keywords = "Jira";

            var worksheet = package.Workbook.Worksheets.Add("JiraItems");

            worksheet.Cells[1, 1].Value = "Country";
            worksheet.Cells[1, 2].Value = "Status";

            int i = 2;
            foreach (var jiraItem in items)
            {
                var formattedName = Enum.GetName(typeof(JiraStatusEnum), jiraItem.status).Replace("_", " ");

                worksheet.Cells[i, 1].Value = jiraItem.Country;
                worksheet.Cells[i, 2].Value = formattedName;
            }

            return package;
        }
    }
}
