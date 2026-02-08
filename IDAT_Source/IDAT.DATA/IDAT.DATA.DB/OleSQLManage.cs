using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace IDAT.DATA.DB;

public class OleSQLManage : ISQLManagement
{
	private static string ConnectionString;

	private static Hashtable parameterCache = Hashtable.Synchronized(new Hashtable());

	public void SetDBConnectionString(string ConString)
	{
		ConnectionString = ConString;
	}

	public DbDataReader GetExecuteReader(string sqlQuery)
	{
		OleDbConnection oleDbConnection = new OleDbConnection(ConnectionString);
		OleDbCommand oleDbCommand = new OleDbCommand();
		try
		{
			PrepareCommand(oleDbConnection, oleDbCommand, CommandType.Text, (OleDbTransaction)null, sqlQuery, (IDataParameter[])null);
			return oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			oleDbConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType)
	{
		OleDbConnection oleDbConnection = new OleDbConnection(ConnectionString);
		OleDbCommand oleDbCommand = new OleDbCommand();
		try
		{
			PrepareCommand(oleDbConnection, oleDbCommand, commandType, (OleDbTransaction)null, sqlQuery, (IDataParameter[])null);
			return oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			oleDbConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public DbDataReader GetExecuteReader(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OleDbConnection oleDbConnection = new OleDbConnection(ConnectionString);
		OleDbCommand oleDbCommand = new OleDbCommand();
		try
		{
			PrepareCommand(oleDbConnection, oleDbCommand, commandType, null, sqlQuery, parameters);
			return oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch (Exception ex)
		{
			oleDbConnection.Close();
			throw new Exception(ex.Message);
		}
	}

	public object GetExecuteScalar(string sqlQuery)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, CommandType.Text, (OleDbTransaction)null, sqlQuery, (IDataParameter[])null);
		return oleDbCommand.ExecuteScalar();
	}

	public object GetExecuteScalar(string sqlQuery, CommandType commandType)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, commandType, (OleDbTransaction)null, sqlQuery, (IDataParameter[])null);
		return oleDbCommand.ExecuteScalar();
	}

	public object GetExecuteScalar(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, commandType, null, sqlQuery, parameters);
		object result = oleDbCommand.ExecuteScalar();
		oleDbCommand.Parameters.Clear();
		return result;
	}

	public int ExecuteNonQuery(string sqlQuery)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, CommandType.Text, (OleDbTransaction)null, sqlQuery, (IDataParameter[])null);
		return oleDbCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, CommandType commandType)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, commandType, (OleDbTransaction)null, sqlQuery, (IDataParameter[])null);
		return oleDbCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, commandType, null, sqlQuery, parameters);
		return oleDbCommand.ExecuteNonQuery();
	}

	public int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using (new OleDbConnection(ConnectionString))
		{
			PrepareCommand((OleDbConnection)transaction.Connection, oleDbCommand, CommandType.Text, (OleDbTransaction)transaction, sqlQuery, (IDataParameter[])null);
			return oleDbCommand.ExecuteNonQuery();
		}
	}

	public int ExecuteNonQuery(string sqlQuery, IDbTransaction transaction, params IDataParameter[] parameters)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using (new OleDbConnection(ConnectionString))
		{
			PrepareCommand((OleDbConnection)transaction.Connection, oleDbCommand, CommandType.Text, (OleDbTransaction)transaction, sqlQuery, parameters);
			return oleDbCommand.ExecuteNonQuery();
		}
	}

	public DataTable GetExecuteTable(string sqlQuery)
	{
		using OleDbConnection selectConnection = new OleDbConnection(ConnectionString);
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sqlQuery, selectConnection);
		DataSet dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, "Table");
		return dataSet.Tables["Table"];
	}

	public DataTable GetExecuteTable(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, commandType, null, sqlQuery, parameters);
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
		for (int i = 0; i < parameters.Length; i++)
		{
			OleDbParameter value = (OleDbParameter)parameters[i];
			oleDbDataAdapter.SelectCommand.Parameters.Add(value);
		}
		DataSet dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, "Table");
		return dataSet.Tables["Table"];
	}

	public DataSet GetExecuteDataSet(string sqlQuery)
	{
		using OleDbConnection selectConnection = new OleDbConnection(ConnectionString);
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sqlQuery, selectConnection);
		DataSet dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, "Table");
		return dataSet;
	}

	public DataSet GetExecuteDataSet(string sqlQuery, CommandType commandType, params IDataParameter[] parameters)
	{
		OleDbCommand oleDbCommand = new OleDbCommand();
		using OleDbConnection connection = new OleDbConnection(ConnectionString);
		PrepareCommand(connection, oleDbCommand, commandType, null, sqlQuery, parameters);
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
		for (int i = 0; i < parameters.Length; i++)
		{
			OleDbParameter value = (OleDbParameter)parameters[i];
			oleDbDataAdapter.SelectCommand.Parameters.Add(value);
		}
		DataSet dataSet = new DataSet();
		oleDbDataAdapter.Fill(dataSet, "Table");
		return dataSet;
	}

	private static void PrepareCommand(OleDbConnection Connection, OleDbCommand Command, CommandType commandType, OleDbTransaction DBTransaction, string sqlQuery, params IDataParameter[] parameters)
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
				OleDbParameter value = (OleDbParameter)parameters[i];
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
		OleDbParameter[] array = (OleDbParameter[])parameterCache[cacheKey];
		if (array == null)
		{
			return null;
		}
		OleDbParameter[] array2 = new OleDbParameter[array.Length];
		int i = 0;
		for (int num = array2.Length; i < num; i++)
		{
			array2[i] = (OleDbParameter)((ICloneable)array[i]).Clone();
		}
		return array2;
	}
}
