using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class AdminGateway
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private BaseClass baseClass;

        public AdminGateway()
        {
            baseClass = BaseClass.GetInstance();
            con = new SqlConnection(baseClass.Connection);
        }
        private static AdminGateway _instance;
        public static AdminGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdminGateway();
            }
            return _instance;
        }
        internal bool Insert(AdminModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Admin(Name,Email,MobileNo,Gender,Dob,Picture,Password,Type,Status,InTime) VALUES(@Name,@Email,@MobileNo,@Gender,@Dob,@Picture,@Password,@Type,@Status,@InTime)", con);
                cmd.Parameters.AddWithValue("@Name", ob.Name);
                cmd.Parameters.AddWithValue("@Email", ob.Email);
                cmd.Parameters.AddWithValue("@MobileNo", ob.MobileNo);
                cmd.Parameters.AddWithValue("@Gender", ob.Gender);
                cmd.Parameters.AddWithValue("@Dob", ob.Dob);
                cmd.Parameters.AddWithValue("@Picture", ob.Picture);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@Type", ob.Type);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
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
        internal bool Update(AdminModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Admin SET Status=@Status WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
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
        internal bool UpdateProfile(AdminModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE Admin SET Name=@Name,MobileNo=@MobileNo,Gender=@Gender,Dob=@Dob,Picture=@Picture,Password=@Password WHERE Email=@Email", con);
                cmd.Parameters.AddWithValue("@Name", ob.Name);
                cmd.Parameters.AddWithValue("@MobileNo", ob.MobileNo);
                cmd.Parameters.AddWithValue("@Gender", ob.Gender);
                cmd.Parameters.AddWithValue("@Dob", ob.Dob);
                cmd.Parameters.AddWithValue("@Picture", ob.Picture);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@Email", ob.Email);

                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return result;
        }
    }
}