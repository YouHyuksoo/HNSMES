using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace IDAT.DATA.DB;

public class MSSQLManage : ISQLManagement
{
	private static string ConnectionString;

	private static Hashtable parameterCache = Hashtable.Synchronized(new Hashtable());

	public void SetDBConnectionString(string ConString)
	{
		ConnectionString = ConString;
	}

	public DbDataReader GetExecuteReader(string sqlQuery)
	{
		SqlConnection sqlConnection = new SqlConnection(ConnectionString);
		SqlCommand sqlCommand = new SqlCommand();
		try
		{
			PrepareCommand(sqlConnection, sqlCommand, CommandType.Text, (SqlTransaction)null, sqlQuery, (IDataParameter[])null);
			return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			sqlConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType)
	{
		SqlConnection sqlConnection = new SqlConnection(ConnectionString);
		SqlCommand sqlCommand = new SqlCommand();
		try
		{
			PrepareCommand(sqlConnection, sqlCommand, commandType, (SqlTransaction)null, sqlQuery, (IDataParameter[])null);
			return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			sqlConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		SqlConnection sqlConnection = new SqlConnection(ConnectionString);
		SqlCommand sqlCommand = new SqlCommand();
		try
		{
			PrepareCommand(sqlConnection, sqlCommand, commandType, null, sqlQuery, parameters);
			return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			sqlConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public object GetExecuteScalar(string sqlQuery)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, CommandType.Text, (SqlTransaction)null, sqlQuery, (IDataParameter[])null);
		return sqlCommand.ExecuteScalar();
	}

	public object GetExecuteScalar(string sqlQuery, CommandType commandType)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, commandType, (SqlTransaction)null, sqlQuery, (IDataParameter[])null);
		return sqlCommand.ExecuteScalar();
	}

	public object GetExecuteScalar(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, commandType, null, sqlQuery, parameters);
		object result = sqlCommand.ExecuteScalar();
		sqlCommand.Parameters.Clear();
		return result;
	}

	public int ExecuteNonQuery(string sqlQuery)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, CommandType.Text, (SqlTransaction)null, sqlQuery, (IDataParameter[])null);
		return sqlCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, CommandType commandType)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, commandType, (SqlTransaction)null, sqlQuery, (IDataParameter[])null);
		return sqlCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, commandType, null, sqlQuery, parameters);
		return sqlCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using (new SqlConnection(ConnectionString))
		{
			PrepareCommand((SqlConnection)transaction.Connection, sqlCommand, CommandType.Text, (SqlTransaction)transaction, sqlQuery, (IDataParameter[])null);
			return sqlCommand.ExecuteNonQuery();
		}
	}

	public int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction, params IDataParameter[] parameters)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using (new SqlConnection(ConnectionString))
		{
			PrepareCommand((SqlConnection)transaction.Connection, sqlCommand, CommandType.Text, (SqlTransaction)transaction, sqlQuery, parameters);
			return sqlCommand.ExecuteNonQuery();
		}
	}

	public DataTable GetExecuteTable(string sqlQuery)
	{
		using SqlConnection selectConnection = new SqlConnection(ConnectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Table");
		return dataSet.Tables["Table"];
	}

	public DataTable GetExecuteTable(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, commandType, null, sqlQuery, parameters);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
		for (int i = 0; i < parameters.Length; i++)
		{
			SqlParameter value = (SqlParameter)parameters[i];
			sqlDataAdapter.SelectCommand.Parameters.Add(value);
		}
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Table");
		return dataSet.Tables["Table"];
	}

	public DataSet GetExecuteDataSet(string sqlQuery)
	{
		using SqlConnection selectConnection = new SqlConnection(ConnectionString);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Table");
		return dataSet;
	}

	public DataSet GetExecuteDataSet(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		SqlCommand sqlCommand = new SqlCommand();
		using SqlConnection connection = new SqlConnection(ConnectionString);
		PrepareCommand(connection, sqlCommand, commandType, null, sqlQuery, parameters);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
		for (int i = 0; i < parameters.Length; i++)
		{
			SqlParameter value = (SqlParameter)parameters[i];
			sqlDataAdapter.SelectCommand.Parameters.Add(value);
		}
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Table");
		return dataSet;
	}

	private static void PrepareCommand(SqlConnection Connection, SqlCommand Command, CommandType commandType, SqlTransaction DBTransaction, string sqlQuery, params IDataParameter[] parameters)
	{
		if (Connection.State != ConnectionState.Open)
		{
			Connection.Open();
		}
		Command.Connection = Connection;
		Command.CommandText = sqlQuery;
		Command.CommandType = commandType;
		if (DBTransaction != null)
		{
			Command.Transaction = DBTransaction;
		}
		if (parameters != null)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				SqlParameter value = (SqlParameter)parameters[i];
				Command.Parameters.Add(value);
			}
		}
	}

	public void CacheParameters(string cacheKey, params IDataParameter[] parameters)
	{
		parameterCache[cacheKey] = parameters;
	}

	public DbParameter[] GetCachedParameters(string cacheKey)
	{
		SqlParameter[] array = (SqlParameter[])parameterCache[cacheKey];
		if (array == null)
		{
			return null;
		}
		SqlParameter[] array2 = new SqlParameter[array.Length];
		int i = 0;
		for (int num = array2.Length; i < num; i++)
		{
			array2[i] = (SqlParameter)((ICloneable)array[i]).Clone();
		}
		return array2;
	}
}
