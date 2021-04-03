using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class BookServiceGateway
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private BaseClass baseClass;

        public BookServiceGateway()
        {
            baseClass = BaseClass.GetInstance();
            con = new SqlConnection(baseClass.Connection);
        }
        private static BookServiceGateway _instance;
        public static BookServiceGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookServiceGateway();
            }
            return _instance;
        }
        internal bool BookService(BookServiceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO BookService(BookId,GarageId,CustId,BookingDate,BookingTime,BkashNo,TransactionNo,Amount,Status,Intime,TokenId) VALUES(@BookId,@GarageId,@CustId,@BookingDate,@BookingTime,@BkashNo,@TransactionNo,@Amount,@Status,@Intime,@TokenId)", con);
                cmd.Parameters.AddWithValue("@BookId", ob.BookId);
                cmd.Parameters.AddWithValue("@GarageId", ob.GarageId);
                cmd.Parameters.AddWithValue("@CustId", ob.CustId);
                cmd.Parameters.AddWithValue("@BookingDate", ob.BookingDate);
                cmd.Parameters.AddWithValue("@BookingTime", ob.BookingTime);
                cmd.Parameters.AddWithValue("@BkashNo", ob.BkashNo);
                cmd.Parameters.AddWithValue("@TransactionNo", ob.TransactionNo);
                cmd.Parameters.AddWithValue("@Amount", ob.Amount);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@Intime", ob.Intime);
                cmd.Parameters.AddWithValue("@TokenId", ob.TokenId);

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
        internal bool Delete(BookServiceModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM BookService WHERE BookId=@BookId", con);
                cmd.Parameters.AddWithValue("@BookId", ob.BookId);

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