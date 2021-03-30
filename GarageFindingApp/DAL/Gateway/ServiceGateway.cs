using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class ServiceGateway
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private BaseClass baseClass;

        public ServiceGateway()
        {
            baseClass = BaseClass.GetInstance();
            con = new SqlConnection(baseClass.Connection);
        }
        private static ServiceGateway _instance;
        public static ServiceGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ServiceGateway();
            }
            return _instance;
        }
        internal bool Insert(ServiceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Service(ServiceName,Price,Intime,GarageId) VALUES(@ServiceName,@Price,@Intime,@GarageId)", con);
                cmd.Parameters.AddWithValue("@ServiceName", ob.ServiceName);
                cmd.Parameters.AddWithValue("@Price", ob.Price);
                cmd.Parameters.AddWithValue("@Intime", ob.Intime);
                cmd.Parameters.AddWithValue("@GarageId", ob.GarageId);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return result;
        }
        internal bool Update(ServiceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Service SET ServiceName=@ServiceName,Price=@Price WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@ServiceName", ob.ServiceName);
                cmd.Parameters.AddWithValue("@Price", ob.Price);
                cmd.Parameters.AddWithValue("@Id", ob.Id);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return result;
        }
        internal bool Delete(ServiceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM Service WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", ob.Id);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return result;
        }
    }
}