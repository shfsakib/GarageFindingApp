using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class RatingGateway
    {
        private BaseClass baseClass;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private RatingModel ratingModel;


        public RatingGateway()
        {
            baseClass = BaseClass.GetInstance(); 
            ratingModel = RatingModel.GetInstance();
            con = new SqlConnection(baseClass.Connection);
        }
        private static RatingGateway _instance;
        public static RatingGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RatingGateway();
            }
            return _instance;
        }
        internal bool InsertRating(RatingModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Rating(GarageId,UserId,Rate,Review,InTime) VALUES(@GarageId,@UserId,@Rate,@Review,@InTime)", con);
                cmd.Parameters.AddWithValue("@GarageId", ob.GarageId);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@Rate", ob.Rate);
                cmd.Parameters.AddWithValue("@Review", ob.Review);
                cmd.Parameters.AddWithValue("@InTime", ob.InTime);

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
        internal bool UpdateRate(RatingModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Rating SET Rate=@Rate,Review=@Review WHERE GarageId=@GarageId AND UserId=@UserId", con);
                cmd.Parameters.AddWithValue("@Rate", ob.Rate);
                cmd.Parameters.AddWithValue("@Review", ob.Review);
                cmd.Parameters.AddWithValue("@GarageId", ob.GarageId);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);

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