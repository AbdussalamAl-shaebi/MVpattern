using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LibraryMVpattern.Services;

namespace LibraryMVpattern.Models
{
    class BookModel:Services.DataBaseOprations
    {
        public override string StoredProcedureName => "spBooks";

       public int Id { get; set; }
       public string Name { get; set; }

        public override List<KeyValue> GetSqlParameters()
        {
            return new List<KeyValue>()
                {
                    new KeyValue("@BookId", Id),
                    new KeyValue("@BookName", Name),
            };

        }

        public override List<DataBaseOprations> ListFromDataTable(DataTable dt)
        {
            try
            {
                List<DataBaseOprations> books = new List<DataBaseOprations>();

                foreach (DataRow row in dt.Rows)
                {
                    BookModel book = new BookModel();
                    book.Id = int.Parse(row["BookId"].ToString());
                    book.Name = row["BookName"].ToString();
                    books.Add(book);
                }
                return books;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
