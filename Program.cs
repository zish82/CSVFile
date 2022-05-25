using CSVFILE.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace CSVFILE
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string csv_file_path = @"G:\CSVFileCSharp\CSV-Import-to-Database-Csharp\stock_list.csv";
            ReadCSV ReadCSV = new ReadCSV();
            
            ReadCSV.GetDataTabletFromCSVFile(csv_file_path);
            
            GetStockList GetStockList = new GetStockList();
            List<Stock> stocks = GetStockList.getStockList();
            foreach (var item in stocks)
            {
                Console.WriteLine("{0} {1} {2}", item.Product, item.ProductCode, item.Price);
            }
            Console.ReadLine();
        }
    }
}
