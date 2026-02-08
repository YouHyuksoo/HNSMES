using System.Data;
using System.Data.Common;

namespace IDAT.DATA.DB;

public interface ISQLManagement
{
	void SetDBConnectionString(string ConnectionString);

	DbDataReader GetExecuteReader(string sqlQuery);

	DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType);

	DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType, params IDataParameter[] parameters);

	object GetExecuteScalar(string sqlQuery);

	object GetExecuteScalar(string sqlQuery, CommandType commandType);

	object GetExecuteScalar(string sqlQuery, CommandType commandType, params IDataParameter[] parameters);

	int ExecuteNonQuery(string sqlQuery);

	int ExecuteNonQuery(string sqlQuery, CommandType commandType);

	int ExecuteNonQuery(string sqlQuery, CommandType commandType, params IDataParameter[] parameters);

	int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction);

	int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction, params IDataParameter[] parameters);

	DataTable GetExecuteTable(string sqlQuery);

	DataSet GetExecuteDataSet(string sqlQuery);

	DataSet GetExecuteDataSet(string sqlQuery, CommandType commandType, params IDataParameter[] parameters);

	void CacheParameters(string cacheKey, params IDataParameter[] parameters);

	DbParameter[] GetCachedParameters(string cacheKey);
}
