using APITareas.Models.MisModelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITareas.Models.Services
{
    public class ColaboradorServicios
    {

        private readonly string _connectionString;

        public ColaboradorServicios(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MiConexion");
        }

        public async Task<List<SPColaboradorListarCLS>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PA_LIST_COLABORADORES", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<SPColaboradorListarCLS>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private SPColaboradorListarCLS MapToValue(SqlDataReader reader)
        {
            return new SPColaboradorListarCLS()
            {
                COLABORADOR_ID = (int)reader["COLABORADOR_ID"],
                NOMBRE = reader["NOMBRE"].ToString(),
            };
        }
    }
}
