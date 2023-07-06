using Godrej_Korber_DAL.TataCummins;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_DAL.Common
{
    public class DashboardDL
    {


        DataTable dt = new DataTable();
        DataSet dtResult = new DataSet();
        OracleHelper oracle = new OracleHelper();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        List<OracleParameter> OracleParameters = new List<OracleParameter>();

        public readonly ILogger<DashboardDL> _logger;

        public DashboardDL(ILogger<DashboardDL> logger)
        {
            _logger = logger;
        }


        public DataTable GetDashboadCount()
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].ParameterName = "OCUR";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "DASHBOARD_COUNT", param);
                int rowcount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    _logger.LogInformation("Data Retrived Succesfully!!!  By These Procedure = DASHBOARD_COUNT");
                    _logger.LogInformation("The Rows You Got = " + rowcount);
                    return dt;
                }
                else
                {
                    _logger.LogError("Data Not Retrived!!! By These Procedure = DASHBOARD_COUNT");
                    _logger.LogInformation("The Rows You Got = " + rowcount);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dt;
            }

        }

        public DataTable GetPalletStatus()
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].ParameterName = "OCUR";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "PALLET_STATUS_DASHBOARD", param);
                int rowcount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    _logger.LogInformation("Data Retrived Succesfully!!!  By These Procedure = PALLET_STATUS_DASHBOARD");
                    _logger.LogInformation("The Rows You Got = " + rowcount);
                    return dt;
                }
                else
                {
                    _logger.LogError("Data Not Retrived!!! By These Procedure = PALLET_STATUS_DASHBOARD");
                    _logger.LogInformation("The Rows You Got = " + rowcount);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dt;
            }

        }

        public DataTable GetCraneStatus()
        {
            try
            {
                OracleParameter[] param = new OracleParameter[1];

                param[0] = new OracleParameter();
                param[0].ParameterName = "OCUR";
                param[0].OracleDbType = OracleDbType.RefCursor;
                param[0].Direction = ParameterDirection.Output;

                dt = oracle.ExecuteDataTable(oracle.GetConnection(), CommandType.StoredProcedure, "CRANE_COUNT", param);
                int rowcount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    _logger.LogInformation("Data Retrived Succesfully!!!  By These Procedure = CRANE_COUNT");
                    _logger.LogInformation("The Rows You Got = " + rowcount);
                    return dt;
                }
                else
                {
                    _logger.LogError("Data Not Retrived!!! By These Procedure = CRANE_COUNT");
                    _logger.LogInformation("The Rows You Got = " + rowcount);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception Occurs " + ex);
                return dt;
            }

        }
    }
}
