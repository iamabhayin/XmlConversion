namespace XmlConversion
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    internal class ConvertToDataTable
    {
        readonly static string dataTableName = "Table1";
        public static DataTable ToDataTable(string _xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(_xml));
            DataTable dataTable = new DataTable(doc.FirstChild.Name);
            try
            {

                XmlNode node = doc.FirstChild.FirstChild;
                XmlNode childNode = doc.FirstChild;
                foreach (XmlNode columna in node.ChildNodes)
                {
                    dataTable.Columns.Add(columna.Name, typeof(String));
                }
                foreach (XmlNode cNode in childNode.ChildNodes)
                {
                    List<string> values = new List<string>();
                    foreach (XmlNode Columna in cNode.ChildNodes)
                    { 
                        values.Add(Columna.InnerText);
                    }
                    dataTable.Rows.Add(values.ToArray());
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
