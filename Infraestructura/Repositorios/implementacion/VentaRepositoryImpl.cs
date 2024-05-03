using Modelos;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Excepciones; 
namespace Infraestructura.Repositorios.implementacion
{
    public class VentaRepositoryImpl : IVentaRepository
    {
        public VentaRepositoryImpl()
        {
            //  this.conn = new NpgsqlConnection(this.connStr);
            this.conn = new NpgsqlConnection("Host=localhost;Port=5432; Database=test; Username=postgres; Password=1Bienfacil!");

        }

        public NpgsqlConnection conn;
        public string connStr;
        public int Delete(int venta)
        {

            this.conn.Open();
            int res = 0;
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = "\"examen\".\"SP_DEL_VENTA\"";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(":p_id", venta);
 
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

        public List<TdVenta> GetAll()
        {

            List<TdVenta> list = new List<TdVenta>();

            this.conn.Open();
            DataTable dtResults = new DataTable();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = " select * from  \"examen\".\"SELECT_VENTAS\" ()";


                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(dtResults);
                foreach (DataRow rw in dtResults.Rows)
                {
                    TdVenta venta = new TdVenta();


                    for (int col = 0; col < dtResults.Columns.Count; col++)
                    {
                        venta.IdVenta = (int)rw[0];
                        venta.FechaVenta = DateOnly.FromDateTime((DateTime)rw[1]);
                        venta.Descripcion = (string)rw[2];
                     }


                    list.Add(venta);
                }

                this.conn.Close();
            }



            return list;
        }

        public TdVenta GetById(long id)
        {
            TdVenta res = null;

            this.conn.Open();
            DataTable dtResults = new DataTable();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = " select * from  \"examen\".\"SELECT_VENTAS_BY_ID\" (:p_id)";
                command.Parameters.AddWithValue(":p_id", unchecked((int)id) );


                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(dtResults);
                foreach (DataRow rw in dtResults.Rows)
                {
                    TdVenta venta = new TdVenta();


                    for (int col = 0; col < dtResults.Columns.Count; col++)
                    {
                        venta.IdVenta = (int)rw[0];
                        venta.FechaVenta = DateOnly.FromDateTime((DateTime)rw[1]);
                        venta.Descripcion = (string)rw[2];
                    }
                    res = venta;
                    
                }

                this.conn.Close();
            }



            return res;
        }

        public int Insert(TdVenta entity)
        {
            
                this.conn.Open();
                int res = 0;
            string resMsg;
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = this.conn;
                    command.CommandText = "\"examen\".\"SP_INS_VENTA\"";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(":p_fecha", entity.FechaVenta);
                    command.Parameters.AddWithValue(":p_descripcion", entity.Descripcion);

                    NpgsqlParameter outParm = new NpgsqlParameter(":resultado", NpgsqlDbType.Varchar)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outParm);

                    command.ExecuteNonQuery();
                    resMsg= (string)outParm.Value;
                }
                this.conn.Close();
            
            return res;
        }
        public int Update(TdVenta entity)
        {
            int res = 1;
            string msgRes;
            this.conn.Open();
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                command.Connection = this.conn;
                command.CommandText = "\"examen\".\"SP_UPD_VENTA\"";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(":p_id", entity.IdVenta);
                command.Parameters.AddWithValue(":p_fecha", entity.FechaVenta);
                command.Parameters.AddWithValue(":p_descripcion", entity.Descripcion);
                 NpgsqlParameter outParm = new NpgsqlParameter(":resultado", NpgsqlDbType.Varchar)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outParm);

                command.ExecuteNonQuery();
                msgRes = (string)outParm.Value;
                
            }
            return res;
            this.conn.Close();
        }
    }
}
