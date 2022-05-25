using CSVFILE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVFILE
{
    public class InsertDatatoDB //// you really need to format this class
    {
        public void insertDatatoDBStock(List<Stock> Stock)
        {
            try
            {
                using (CSVFILEContext db = new CSVFILEContext())
                {
                    db.AddRange(Stock);
                    db.SaveChanges();
                }
                    
               
            }
            catch (Exception)
            {

                throw; // again throwing exception, it's not good at all
            }
        }
    }
}
