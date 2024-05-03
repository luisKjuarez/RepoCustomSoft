using Modelos;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Infraestructura.Repositorios.implementacion
{
    public class DocumentoRepositoryImpl : IDocumentoRepository
    {

        public DocumentoRepositoryImpl()
        {
            //  this.conn = new NpgsqlConnection(this.connStr);
            this.conn = new NpgsqlConnection("Host=localhost;Port=5432; Database=test; Username=postgres; Password=1Bienfacil!");

        }

        public NpgsqlConnection conn;
        public string connStr="";
        public int Delete(int entity)
        {
            return 0;
        }

        public List<TdDocumento> GetAll()
        {
            List<TdDocumento> list = new List<TdDocumento>();

            this.conn.Open();
            DataTable dtResults = new DataTable();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = " select * from  \"examen\".\"SELECT_DOCUMENTOS\" ()";


                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(dtResults);
                foreach (DataRow rw in dtResults.Rows)
                {
                    TdDocumento docum = new TdDocumento();


                    for (int col = 0; col < dtResults.Columns.Count; col++)
                    {
                        docum.Id = (int)rw[0];
                        docum.Nombre = (string?)rw[1];
                        docum.Ruta = (string?)rw[2];
                        docum.IdVenta = (int)rw[3];
                    }


                    list.Add(docum);
                }

                this.conn.Close();
            }



            return list;
        }

        public TdDocumento GetById(long id)
        {
            TdDocumento docu = new  TdDocumento();

            this.conn.Open();
            DataTable dtResults = new DataTable();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = " select * from  \"examen\".\"SELECT_DOCUMENTO_BY_ID\" (:p_id)";

                command.Parameters.AddWithValue(":p_id", unchecked((int)id));

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(dtResults);
                foreach (DataRow rw in dtResults.Rows)
                {
                    TdDocumento docum = new TdDocumento();


                    for (int col = 0; col < dtResults.Columns.Count; col++)
                    {
                        docum.Id = (int)rw[0];
                        docum.Nombre = (string?)rw[1];
                        docum.Ruta = (string?)rw[2];
                        docum.IdVenta = (int)rw[3];
                    }


                    docu = docum;
                }

                this.conn.Close();
            }



            return docu;
        }

        public int Insert(TdDocumento entity)
        {
            int res = 0;
            this.conn.Open();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = "\"examen\".\"SP_INS_DOCUMENTO\"";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(":p_nombre", entity.Nombre);
                command.Parameters.AddWithValue(":p_ruta", entity.Ruta);
                command.Parameters.AddWithValue(":p_id_venta", entity.IdVenta);
                 NpgsqlParameter outParm = new NpgsqlParameter(":resultado", NpgsqlDbType.Integer)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outParm);

                command.ExecuteNonQuery();
                res = (int)outParm.Value;
            }
            this.conn.Close();
            return res;
        }

        public int Update(TdDocumento entity)
        {
            int res = 0;
            this.conn.Open();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = "\"examen\".\"SP_UPD_DOCUMENTO\"";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(":p_id", entity.Id); 
                command.Parameters.AddWithValue(":p_nombre", entity.Nombre);
                command.Parameters.AddWithValue(":p_ruta", entity.Ruta);
                command.Parameters.AddWithValue(":p_id_venta", entity.IdVenta);
                NpgsqlParameter outParm = new NpgsqlParameter(":resultado", NpgsqlDbType.Integer)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outParm);

                command.ExecuteNonQuery();
                res = (int)outParm.Value;

            }
            this.conn.Close();
            return res;
        }

        public List<TdDocumento> getAllByIdVenta(int idVenta)
        {
            List<TdDocumento> list = new List<TdDocumento>();

            this.conn.Open();
            DataTable dtResults = new DataTable();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = " select * from  \"examen\".\"SELECT_DOCUMENTO_BY_VENTA\" (:p_id)";

                command.Parameters.AddWithValue(":p_id", idVenta);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(dtResults);
                foreach (DataRow rw in dtResults.Rows)
                {
                    TdDocumento docum = new TdDocumento();


                    for (int col = 0; col < dtResults.Columns.Count; col++)
                    {
                        docum.Id = (int)rw[0];
                        docum.Nombre = (string?)rw[1];
                        docum.Ruta = (string?)rw[2];
                        docum.IdVenta = (int)rw[3];
                    }


                    list.Add(docum);
                }

                this.conn.Close();
            }



            return list;
        }
    }
}
