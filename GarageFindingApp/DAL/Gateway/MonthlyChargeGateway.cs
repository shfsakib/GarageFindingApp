using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class MonthlyChargeGateway
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private BaseClass baseClass;

        public MonthlyChargeGateway()
        {
            baseClass = BaseClass.GetInstance();
            con = new SqlConnection(baseClass.Connection);
        }
        private static MonthlyChargeGateway _instance;
        public static MonthlyChargeGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MonthlyChargeGateway();
            }
            return _instance;
        }
        internal bool Insert(MonthlyChargeModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO MonthlyCharge(GarageId,Month,BkashNo,TransactionNo,Amount,PaymentTime,Status) VALUES(@GarageId,@Month,@BkashNo,@TransactionNo,@Amount,@PaymentTime,@Status)", con);
                cmd.Parameters.AddWithValue("@GarageId", ob.GarageId);
                cmd.Parameters.AddWithValue("@Month", ob.Month);
                cmd.Parameters.AddWithValue("@BkashNo", ob.BkashNo);
                cmd.Parameters.AddWithValue("@TransactionNo", ob.TransactionNo);
                cmd.Parameters.AddWithValue("@Amount", ob.Amount);
                cmd.Parameters.AddWithValue("@PaymentTime", ob.PaymentTime);
                cmd.Parameters.AddWithValue("@Status", ob.Status);

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
        internal bool Delete(MonthlyChargeModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("DELETE FROM MonthlyCharge WHERE ChargeId=@ChargeId", con);
                cmd.Parameters.AddWithValue("@ChargeId", ob.ChargeId);

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
        internal bool UpdateStatus(MonthlyChargeModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE MonthlyCharge SET Status=@Status WHERE ChargeId=@ChargeId", con);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@ChargeId", ob.ChargeId);

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