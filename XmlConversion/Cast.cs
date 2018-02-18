using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConversion
{
    public class Cast
    {
        public Cast()
        {

        }

        public static DataTable ToDataTable(string xml)
        {
            var dataTable = ConvertToDataTable.ToDataTable(xml);
            return dataTable;
        }
    }
}
