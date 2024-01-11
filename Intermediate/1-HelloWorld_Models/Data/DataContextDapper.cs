using Dapper;
using Microsoft.Data.SqlClient;

namespace HelloWorld.Data;

public class DataContextDapper
{
    private readonly string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=true;TrustServerCertificate=true";

    public IEnumerable<T> LoadData<T>(string sql)
    {
        var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Query<T>(sql);
    }
    public T LoadDataSingle<T>(string sql)
    {
        var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.QuerySingle<T>(sql);
    }

    public bool ExecuteSqlWithPayload<T>(string sql, T payload)
    {
        var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Execute(sql, payload) > 0;
    }
    public int ExecuteSqlWithRowCount(string sql)
    {
        var dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Execute(sql);
    }
}
