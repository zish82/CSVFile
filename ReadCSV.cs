using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CSVFILE.Models;
using NotVisualBasic.FileIO;

namespace CSVFILE
{
    public class ReadCSV ////This should be a service as well with something like IReadCSV and If possible inject CSVTextField..parser into this
    {
        //public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        //{
        //    DataTable csvData = new DataTable();

        //    try
        //    {

        //        using (CsvTextFieldParser csvReader = new CsvTextFieldParser(csv_file_path))
        //        {
        //            csvReader.SetDelimiter(',');
        //            csvReader.HasFieldsEnclosedInQuotes = true;
        //            string[] colFields = csvReader.ReadFields();
        //            foreach (string column in colFields)
        //            {
        //                DataColumn datecolumn = new DataColumn(column);
        //                datecolumn.AllowDBNull = true;
        //                csvData.Columns.Add(datecolumn);
        //            }
        //            InsertDatatoDB InsertDatatoDB = new InsertDatatoDB();
        //            List<Stock> Stocks = new List<Stock>();
        //            while (!csvReader.EndOfData)
        //            {
        //                string[] fieldData = csvReader.ReadFields();
        //                Stock Stock = new Stock();
        //                //foreach (var item in fieldData)
        //                //{
        //                //    Stock.Product = item.ToString();
        //                //    //Stock.Price = item.ToString();
        //                //}
        //                Stock.Product = fieldData[0];
        //                Stock.ProductCode = fieldData[1];
        //                Stock.Price = Convert.ToDecimal(fieldData[2]);

        //                Stocks.Add(Stock);
        //                //Making empty value as null
        //                for (int i = 0; i < fieldData.Length; i++)
        //                {
        //                    if (fieldData[i] == "")
        //                    {
        //                        fieldData[i] = null;
        //                    }
        //                }
        //                csvData.Rows.Add(fieldData);
                        
        //            }
        //            InsertDatatoDB.insertDatatoDBStock(Stocks);
        //        }
               
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return csvData;
        //}
        public void GetDataTabletFromCSVFile(string csv_file_path) ////Method name is get but it doesn't return anything, it should return the data
        {
            DataTable csvData = new DataTable();

            try
            {

                using (CsvTextFieldParser csvReader = new CsvTextFieldParser(csv_file_path))//What is this parser, is this a library coming from VisualBasic, that will be a no no as well, there should be similar library in C# 
                {
                    csvReader.SetDelimiter(',');
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }//There should always be an empty line after barckets for code readability                    
                    InsertDatatoDB InsertDatatoDB = new InsertDatatoDB();
                    List<Stock> Stocks = new List<Stock>();
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        Stock Stock = new Stock();
                        
                        Stock.Product = fieldData[0];
                        Stock.ProductCode = fieldData[1];
                        Stock.Price = Convert.ToDecimal(fieldData[2]);

                        Stocks.Add(Stock);
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;////Why are you doing this, this doesn't look right to make empty values null for no reason
                            }
                        }
                        csvData.Rows.Add(fieldData);

                    }
                    InsertDatatoDB.insertDatatoDBStock(Stocks); //You should not be doing 2 things, remember Single Responsibility Principle, 1 class should do 1 thing
                }

            }
            catch (Exception ex)/////Empty exception block is a no no, that means you are consuming exceptions and your program will never know what happened
            {
            }
            //return csvData;
        }
    }
}
