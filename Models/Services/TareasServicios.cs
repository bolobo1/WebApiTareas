using APITareas.Models.MisModelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITareas.Models.Services {
    public class TareasServicios {

        private readonly string _connectionString;

        public TareasServicios(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("MiConexion");
        }

        public async Task<List<SPTareasListarCLS>> GetAll() 
        {
            using (SqlConnection sql = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = new SqlCommand("PA_LIST_TAREAS", sql)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<SPTareasListarCLS>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private SPTareasListarCLS MapToValue(SqlDataReader reader) {
            return new SPTareasListarCLS() {

                TAREAS_ID = (int)reader["TAREAS_ID"],
                TAREAS_DESCRIPCION = reader["TAREAS_DESCRIPCION"].ToString(),
                TAREAS_ESTADO = reader["TAREAS_ESTADO"].ToString(),
                TAREAS_PRIORIDAD = reader["TAREAS_PRIORIDAD"].ToString(),
                TAREAS_FECHA_INICIO = (DateTime)reader["TAREAS_FECHA_INICIO"],
                TAREA_FECHA_FIN = (DateTime)reader["TAREA_FECHA_FIN"],
                TAREAS_NOTAS = reader["TAREAS_NOTAS"].ToString(),
                COLABORADOR_ID = (int)reader["COLABORADOR_ID"],
                NOMBRE = reader["NOMBRE"].ToString(),
            };
        }



        public async Task<SPTareasListarIdCLS> GetById(int TAREAS_ID) {
            using (SqlConnection sql = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = new SqlCommand("PA_LIST_TAREAS_ID", sql)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_ID", TAREAS_ID));
                    SPTareasListarIdCLS response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            response = MapToValueId(reader);
                        }
                    }
                    return response;
                }
            }
        }

        private SPTareasListarIdCLS MapToValueId(SqlDataReader reader)
        {
            return new SPTareasListarIdCLS()
            {

                TAREAS_ID = (int)reader["TAREAS_ID"],
                TAREAS_DESCRIPCION = reader["TAREAS_DESCRIPCION"].ToString(),
                TAREAS_ESTADO = reader["TAREAS_ESTADO"].ToString(),
                TAREAS_PRIORIDAD = reader["TAREAS_PRIORIDAD"].ToString(),
                TAREAS_FECHA_INICIO = (DateTime)reader["TAREAS_FECHA_INICIO"],
                TAREA_FECHA_FIN = (DateTime)reader["TAREA_FECHA_FIN"],
                TAREAS_NOTAS = reader["TAREAS_NOTAS"].ToString(),
                COLABORADOR_ID = (int)reader["COLABORADOR_ID"]
            };
        }
        public async Task<int> Insert(SPTareaCreateCLS value) {
            using (SqlConnection sql = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = new SqlCommand("PA_CREATE_TAREA", sql)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_DESCRIPCION", value.TAREAS_DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_ESTADO", value.TAREAS_ESTADO));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_PRIORIDAD", value.TAREAS_PRIORIDAD));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_FECHA_INICIO", value.TAREAS_FECHA_INICIO));
                    cmd.Parameters.Add(new SqlParameter("@TAREA_FECHA_FIN", value.TAREA_FECHA_FIN));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_NOTAS", value.TAREAS_NOTAS));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_COLABORADOR", value.TAREAS_COLABORADOR));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    var exito = 1;
                    return exito;
                }
            }
        }

        public async Task<int>  Update(SPTareaUpdate value) {
            using (SqlConnection sql = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = new SqlCommand("PA_UPDATE_TAREA", sql)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_ID", value.TAREAS_ID));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_DESCRIPCION", value.TAREAS_DESCRIPCION));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_ESTADO", value.TAREAS_ESTADO));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_PRIORIDAD", value.TAREAS_PRIORIDAD));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_FECHA_INICIO", value.TAREAS_FECHA_INICIO));
                    cmd.Parameters.Add(new SqlParameter("@TAREA_FECHA_FIN", value.TAREA_FECHA_FIN));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_NOTAS", value.TAREAS_NOTAS));
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_COLABORADOR", value.COLABORADOR_ID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    var exito = 1;
                    return exito;
                }
            }
        }

        public async Task DeleteById(int TAREAS_ID) {
            using (SqlConnection sql = new SqlConnection(_connectionString)) {
                using (SqlCommand cmd = new SqlCommand("PA_DELETE_TAREA", sql)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TAREAS_ID", TAREAS_ID));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

    }
}
