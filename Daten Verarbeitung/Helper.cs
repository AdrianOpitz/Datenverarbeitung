using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Daten_Verarbeitung
{
    internal class Helper
    {
        public static string file;
        public static DataTable DataTableFromTextFile( string location, char delimiter = ';' )
        {
            DataTable result;
            location = file;

            string[] LineArray = File.ReadAllLines( location );
            result = FromDataTable(LineArray, delimiter);
            return result;

        }

        private static DataTable FromDataTable(string[] LineArray, char delimiter)
        {
            DataTable dt = new DataTable();

            AddColumnToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);
            
            return dt;

        }

        private static void AddRowToTable(string[] valueCollaction, char delimiter, ref DataTable dt)
        {
            for ( int i = 0; i < valueCollaction.Length; i++ )
            {
                string[] values = valueCollaction[i].Split(delimiter);
                DataRow dr = dt.NewRow();
                for ( int j = 0; j < values.Length; j++ )
                {
                    dr[j] = values[j];
                }

                dt.Rows.Add(dr);
            }
        }

        private static void AddColumnToTable(string[] columnCollectio, char delimiter, ref DataTable dt)
        {
            string[] columns = columnCollectio[0].Split(delimiter);
            foreach ( string columnName in columns )
            {
                DataColumn dc = new DataColumn (columnName, typeof(string));
            }
            
        }
    }
}
