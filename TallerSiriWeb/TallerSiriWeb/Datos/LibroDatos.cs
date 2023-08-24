using TallerSiriWeb.Models;
using System.Data.SqlClient;
using System.Data;
namespace TallerSiriWeb.Datos
{
    public class LibroDatos
    {
        public List<LibroModel> Listar()
        {
            var lista = new List<LibroModel>();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("listarLibros", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new LibroModel()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            titulo = dr["titulo"].ToString(),
                            autor = dr["autor"].ToString(),
                            genero = dr["genero"].ToString(),
                            fechapublicacion = dr["fechapublicacion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }
        public LibroModel Obtener(int id)
        {
            var libro = new LibroModel();

            var cnx = new Conexion();

            using (var conexion = new SqlConnection(cnx.GetStringSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("obtenerLibro", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        libro.id = Convert.ToInt32(dr["id"]);
                        libro.titulo = dr["titulo"].ToString();
                        libro.autor = dr["autor"].ToString();
                        libro.genero = dr["genero"].ToString();
                        libro.fechapublicacion = dr["fechapublicacion"].ToString();

                    }
                }
            }
            return libro;
        }

        public bool Guardar(LibroModel libro)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("guardarLibro", conexion);
                    cmd.Parameters.AddWithValue("titulo", libro.titulo);
                    cmd.Parameters.AddWithValue("autor", libro.autor);
                    cmd.Parameters.AddWithValue("genero", libro.genero);
                    cmd.Parameters.AddWithValue("fechapublicacion", libro.fechapublicacion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta=false;

            }

            return respuesta;
        }

        public bool Editar(LibroModel libro)
        {
            bool respuesta;

            try
            {

                var cnx = new Conexion();

                using (var conexion = new SqlConnection(cnx.GetStringSql()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("editarlibro", conexion);
                    cmd.Parameters.AddWithValue("id", libro.id);
                    cmd.Parameters.AddWithValue("titulo", libro.titulo);
                    cmd.Parameters.AddWithValue("autor", libro.autor);
                    cmd.Parameters.AddWithValue("genero", libro.genero);
                    cmd.Parameters.AddWithValue("fechapublicacion", libro.fechapublicacion);
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

                    SqlCommand cmd = new SqlCommand("eliminarlibro", conexion);
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
