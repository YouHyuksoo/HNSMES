using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace IDAT.DATA.DB;

public class ORACLESQLManage : ISQLManagement
{
	private static string ConnectionString;

	private static Hashtable parameterCache = Hashtable.Synchronized(new Hashtable());

	public void SetDBConnectionString(string ConString)
	{
		ConnectionString = ConString;
	}

	public DbDataReader GetExecuteReader(string sqlQuery)
	{
		OracleConnection oracleConnection = new OracleConnection(ConnectionString);
		OracleCommand oracleCommand = new OracleCommand();
		try
		{
			PrepareCommand(oracleConnection, oracleCommand, CommandType.Text, (OracleTransaction)null, sqlQuery, (IDataParameter[])null);
			return oracleCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			oracleConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType)
	{
		OracleConnection oracleConnection = new OracleConnection(ConnectionString);
		OracleCommand oracleCommand = new OracleCommand();
		try
		{
			PrepareCommand(oracleConnection, oracleCommand, commandType, (OracleTransaction)null, sqlQuery, (IDataParameter[])null);
			return oracleCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			oracleConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OracleConnection oracleConnection = new OracleConnection(ConnectionString);
		OracleCommand oracleCommand = new OracleCommand();
		try
		{
			PrepareCommand(oracleConnection, oracleCommand, commandType, null, sqlQuery, parameters);
			return oracleCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			oracleConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public object GetExecuteScalar(string sqlQuery)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using OracleConnection connection = new OracleConnection(ConnectionString);
		PrepareCommand(connection, oracleCommand, CommandType.Text, (OracleTransaction)null, sqlQuery, (IDataParameter[])null);
		return oracleCommand.ExecuteScalar();
	}

	public object GetExecuteScalar(string sqlQuery, CommandType commandType)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using OracleConnection connection = new OracleConnection(ConnectionString);
		PrepareCommand(connection, oracleCommand, commandType, (OracleTransaction)null, sqlQuery, (IDataParameter[])null);
		return oracleCommand.ExecuteScalar();
	}

	public object GetExecuteScalar(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using OracleConnection connection = new OracleConnection(ConnectionString);
		PrepareCommand(connection, oracleCommand, commandType, null, sqlQuery, parameters);
		object result = oracleCommand.ExecuteScalar();
		oracleCommand.Parameters.Clear();
		return result;
	}

	public int ExecuteNonQuery(string sqlQuery)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using OracleConnection connection = new OracleConnection(ConnectionString);
		PrepareCommand(connection, oracleCommand, CommandType.Text, (OracleTransaction)null, sqlQuery, (IDataParameter[])null);
		return oracleCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, CommandType commandType)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using OracleConnection connection = new OracleConnection(ConnectionString);
		PrepareCommand(connection, oracleCommand, commandType, (OracleTransaction)null, sqlQuery, (IDataParameter[])null);
		return oracleCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using OracleConnection connection = new OracleConnection(ConnectionString);
		PrepareCommand(connection, oracleCommand, commandType, null, sqlQuery, parameters);
		return oracleCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using (new OracleConnection(ConnectionString))
		{
			PrepareCommand((OracleConnection)transaction.Connection, oracleCommand, CommandType.Text, (OracleTransaction)transaction, sqlQuery, (IDataParameter[])null);
			return oracleCommand.ExecuteNonQuery();
		}
	}

	public int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction, params IDataParameter[] parameters)
	{
		OracleCommand oracleCommand = new OracleCommand();
		using (new OracleConnection(ConnectionString))
		{
			PrepareCommand((OracleConnection)transaction.Connection, oracleCommand, CommandType.Text, (OracleTransaction)transaction, sqlQuery, parameters);
			return oracleCommand.ExecuteNonQuery();
		}
	}

	public DataTable GetExecuteTable(string sqlQuery)
	{
		using OracleConnection selectConnection = new OracleConnection(ConnectionString);
		OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlQuery, selectConnection);
		DataSet dataSet = new DataSet();
		oracleDataAdapter.Fill(dataSet, "Table");
		return dataSet.Tables["Table"];
	}

	public DataSet GetExecuteDataSet(string sqlQuery)
	{
		using OracleConnection selectConnection = new OracleConnection(ConnectionString);
		OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlQuery, selectConnection);
		DataSet dataSet = new DataSet();
		oracleDataAdapter.Fill(dataSet, "Table");
		return dataSet;
	}

	public DataSet GetExecuteDataSet(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		using OracleConnection selectConnection = new OracleConnection(ConnectionString);
		OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sqlQuery, selectConnection);
		for (int i = 0; i < parameters.Length; i++)
		{
			SqlParameter value = (SqlParameter)parameters[i];
			oracleDataAdapter.SelectCommand.Parameters.Add(value);
		}
		DataSet dataSet = new DataSet();
		oracleDataAdapter.Fill(dataSet, "Table");
		return dataSet;
	}

	private static void PrepareCommand(OracleConnection Connection, OracleCommand Command, CommandType commandType, OracleTransaction DBTransaction, string sqlQuery, params IDataParameter[] parameters)
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
