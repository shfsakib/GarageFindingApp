using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class LocationGateway
    { 
        private SqlConnection con;
        private SqlCommand cmd;
        private BaseClass baseClass;

        public LocationGateway()
        {
            baseClass = BaseClass.GetInstance();
            con = new SqlConnection(baseClass.Connection);
        }
        private static LocationGateway _instance;
        public static LocationGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LocationGateway();
            }
            return _instance;
        }
        internal bool Insert(LocationModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Location(LocationName,ThanaId,Intime) VALUES(@LocationName,@ThanaId,@Intime)", con);
                cmd.Parameters.AddWithValue("@LocationName", ob.LocationName);
                cmd.Parameters.AddWithValue("@ThanaId", ob.ThanaId);
                cmd.Parameters.AddWithValue("@Intime", ob.Intime);

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
        internal bool Update(LocationModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Location SET LocationName=@LocationName,ThanaId=@ThanaId  WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@LocationName", ob.LocationName);
                cmd.Parameters.AddWithValue("@ThanaId", ob.ThanaId);
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