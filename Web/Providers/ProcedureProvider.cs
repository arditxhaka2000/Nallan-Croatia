using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Providers
{
    public class ProcedureProvider
    {
        private readonly IConfiguration _configuration;
        public DataSet dataReport = new DataSet("GetReport");

        public ProcedureProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public DataSet readProcedure(string nameprocedure)
        {
            string connString = _configuration.GetConnectionString("DefaultConnection");
            dataReport = new DataSet("GetReport");
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand sqlComm = new SqlCommand(nameprocedure, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(dataReport);
            }
            return dataReport;
        }
        public DataSet readProcedureWithParameters(string nameprocedure, string from, string to,int MunicipalityId,string RoleName)
        {
            string connString = _configuration.GetConnectionString("DefaultConnection");
            dataReport = new DataSet("GetReport");
            from = from != null ? Convert.ToDateTime(from).ToString("yyyy-MM-dd") : null;
            to = to != null ? Convert.ToDateTime(to).ToString("yyyy-MM-dd") : null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand sqlComm = new SqlCommand(nameprocedure, conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@From", from);
                sqlComm.Parameters.AddWithValue("@To", to);
                sqlComm.Parameters.AddWithValue("@MunicipalityId", MunicipalityId);
                sqlComm.Parameters.AddWithValue("@Admin", RoleName);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(dataReport);
            }
            return dataReport;


            //public List<StatsViewModel> GetRows()
            //{

            //}
        }

        public DynamicRowAndColumns getProcedure(string nameprocedure, string from, string to,int MunicipalityId, string RoleName)
        {
            var model = new DynamicRowAndColumns();
            List<string> _dataCol = new List<string>();
            List<dynamic> _dataRows = new List<dynamic>();

            //readProcedure(nameprocedure);
            readProcedureWithParameters(nameprocedure, from, to,MunicipalityId,RoleName);

            //TableColumns
            DataTable tables_cols = dataReport.Tables[0];
            foreach (var item in tables_cols.Columns)
            {
                _dataCol.Add(item.ToString());
            }

            //TableRows
            DataTable tables_2 = dataReport.Tables[0];

            dynamic expando = new ExpandoObject();
            var obj = expando as IDictionary<String, object>;

            foreach (DataRow item in tables_2.Rows)
            {
                string[] array = new string[tables_2.Columns.Count];
                int i = 0;
                foreach (var items in item.ItemArray)
                {
                    array[i] = items.ToString();
                    i++;
                }
                _dataRows.Add(array);

            }

            dataReport.Clear();

            model.Cols = _dataCol;
            model.Rows = _dataRows;
            return model;
        }


    }


    public class DynamicRowAndColumns
    {
        public List<string> Cols { get; set; }
        public List<dynamic> Rows { get; set; }

        public string From { get; set; }
        public string To { get; set; }
    }
}
