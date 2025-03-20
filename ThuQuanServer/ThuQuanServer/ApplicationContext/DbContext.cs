using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace ThuQuanServer.ApplicationContext;

public class DbContext
{
    private readonly MySqlConnection _connection;
    private MySqlTransaction? _transaction;
    
    public DbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }

    public ICollection<T> GetData<T>(string query, params object?[] values)
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand(query, _connection);
            if (values.Length > 0)
            {
                for (var i = 0; i < values.Length; ++i)
                {
                    cmd.Parameters.AddWithValue($"@{i}", values[i]);
                }
            }
            var adapter = new MySqlDataAdapter(cmd);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            var collection = dataTable.AsEnumerable()
                .Select(row => MapRowToType<T>(row))
                .ToList();

            return collection;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }
    
    public int ExecuteNonQuery(string query, params object?[] values)
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand(query, _connection);
            if (values.Length > 0)
            {
                for (int i = 0; i < values.Length; ++i)
                {
                    cmd.Parameters.AddWithValue($"{i}", values[i]);
                }
            }
            
            if (cmd.Parameters.Count != values.Length)
            {
                throw new ArgumentException("The number of parameters does not match the number of placeholders in the query.");
            }
            
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }
    
    public int Add<T>(object? value)
    {
        // Get all properties of the object
        var props = value.GetType().GetProperties();
    
        // Get all column names and placeholders
        var tableName = typeof(T).Name;
        var colNames = string.Join(", ", props.Select(p => p.Name));
        var placeholders = string.Join(", ", props.Select(_ => "?"));
        string query = $"INSERT INTO {tableName} ({colNames}) VALUES ({placeholders})";
        Console.WriteLine(query);
    
        // Get all values of the object
        object?[] values = props.Select(p =>
        {
            if(p.GetValue(value)?.GetType() == typeof(DateTime))
            {
                return ((DateTime?)p.GetValue(value))?.ToString("yyyy-MM-dd");
            }
            return p.GetValue(value);
        }).ToArray();
        
        // test
        // return 1;
        
        _connection.Open();
        try
        {
            // Begin the transaction
            _transaction = _connection.BeginTransaction();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
        
        // Execute the query
        var result = ExecuteNonQuery(query, values);
        return result;
    }

    public int Update<T>(object? value, int id)
    {
        var tableName = typeof(T).Name;
        
        var props = value.GetType().GetProperties();
        
        var colNames = string.Join(", ", props
            .Where(p => p.GetValue(value) != null && p.GetValue(value)?.ToString() != "")
            .Select(p => $"{p.Name} = ?"));
        
        var query = $"UPDATE {tableName} SET {string.Join(", ", colNames)} WHERE Id = ?";
        Console.WriteLine(query);
        
        object?[] values = props.Select(p =>
        {
            if(p.GetValue(value)?.GetType() == typeof(DateTime))
            {
                return ((DateTime?)p.GetValue(value))?.ToString("yyyy-MM-dd");
            }
            return p.GetValue(value);
        }).Append(id).ToArray();

        Console.WriteLine(string.Join("\n", values));
        // return 0;
        
        _connection.Open();
        try
        {
            _transaction = _connection.BeginTransaction();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
        
        // Execute the query
        return ExecuteNonQuery(query, values); 
    }

    public bool SaveChange()
    {
        _connection.Open();
        try
        {
            _transaction?.Commit();
            return true;
        }
        catch (Exception e)
        {
            _transaction?.Rollback();
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }

    public int GetLastInsertId()
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", _connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _connection.Close();
        }
    }

    private static T MapRowToType<T>(DataRow row)
    {
        // Create an instance of the object
        var obj = Activator.CreateInstance<T>();
        
        // Get all properties of the object
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            if (row[property.Name] != DBNull.Value)
            {
                var value = Convert.ChangeType(row[property.Name], property.PropertyType);
                property.SetValue(obj, value);   
            }
        }
        return obj;
    }
}