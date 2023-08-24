using System.Data.SqlClient;
using System.Data;
using TallerSiriWeb.Models;

namespace TallerSiriWeb.Datos
{
    public class PresmoDatos
    {
        public List<PrestamoModel> Listar()
        {
            var lista = new List<PrestamoModel>();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("listarPrestamos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new PrestamoModel()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            idlibro = Convert.ToInt32(dr["idlibro"]),
                            iduser = Convert.ToInt32(dr["iduser"]),
                            fechainicio = dr["fechainicio"].ToString(),
                            fechafin = dr["fechafin"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public PrestamoModel Obtener(int id)
        {
            var libro = new PrestamoModel();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("obtenerPrestamo", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        libro.id = Convert.ToInt32(dr["id"]);
                        libro.idlibro = Convert.ToInt32(dr["idlibro"]);
                        libro.iduser = Convert.ToInt32(dr["iduser"]);
                        libro.fechainicio = dr["fechainicio"].ToString();
                        libro.fechafin = dr["fechafin"].ToString();

                    }
                }
            }
            return libro;
        }

        public bool Guardar(PrestamoModel prestamo)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("guardarPrestamo", conexion);
                    cmd.Parameters.AddWithValue("idlibro", prestamo.idlibro);
                    cmd.Parameters.AddWithValue("iduser", prestamo.iduser);
                    cmd.Parameters.AddWithValue("fechainicio", prestamo.fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", prestamo.fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }

            return respuesta;
        }

        public bool Editar(PrestamoModel prestamo)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("editarPrestamo", conexion);
                    cmd.Parameters.AddWithValue("id", prestamo.id);
                    cmd.Parameters.AddWithValue("idlibro", prestamo.idlibro);
                    cmd.Parameters.AddWithValue("iduser", prestamo.iduser);
                    cmd.Parameters.AddWithValue("fechainicio", prestamo.fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", prestamo.fechafin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("eliminarPrestamo", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }

            return respuesta;
        }
    }
}
