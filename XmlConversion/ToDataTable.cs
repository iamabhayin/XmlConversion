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
    internal class ToDataTable
    {
        readonly static string dataTableName = "Table1";
        public static DataTable BuildDataTableFromXml(string XMLString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(XMLString));
            DataTable Dt = new DataTable(dataTableName);
            try
            {

                XmlNode NodoEstructura = doc.FirstChild.FirstChild;
                //  Table structure (columns definition) 
                foreach (XmlNode columna in NodoEstructura.ChildNodes)
                {
                    Dt.Columns.Add(columna.Name, typeof(String));
                }

                XmlNode Filas = doc.FirstChild;
                //  Data Rows 
                foreach (XmlNode Fila in Filas.ChildNodes)
                {
                    List<string> Valores = new List<string>();
                    foreach (XmlNode Columna in Fila.ChildNodes)
                    {
                        Valores.Add(Columna.InnerText);
                    }
                    Dt.Rows.Add(Valores.ToArray());
                }
            }
            catch (Exception)
            {

            }

            return Dt;
        }
    }
}
