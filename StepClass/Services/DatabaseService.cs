
using Microsoft.Data.SqlClient;

namespace StepClass.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;


        public DatabaseService(string _connectionString) {
        
                this._connectionString = _connectionString;
        }


        public async Task<List<T>> GetQueryAsync<T>(string procedure,Func<SqlDataReader, T> mapper,
            params SqlParameter[] parameters)
        {

            var result = new List<T>();

            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand(procedure, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if(parameters.Length > 0)
                command.Parameters.AddRange(parameters);

            try
            {
                await connection.OpenAsync();
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Add(mapper(reader));
                }
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<T>().ToList();
            }
            
             
        }


        public async Task<T> QuerySingleAsync<T> (string procedure,Func<SqlDataReader, T> mapper,
            params SqlParameter[] parameters)
        {

            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand(procedure, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if(parameters.Length > 0)
                command.Parameters.AddRange(parameters);
            try
            {
                await connection.OpenAsync();
                await using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return mapper(reader);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }


        public async Task<int> ExecuteAsync(string storedPrpecudure,params SqlParameter[] parameters)
        {
            await using var conection = new SqlConnection(_connectionString);

            await using var command = new SqlCommand(storedPrpecudure, conection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (parameters.Length > 0)
                command.Parameters.AddRange(parameters);

            await conection.OpenAsync();
           return  await command.ExecuteNonQueryAsync();

        }
    }


}
