using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GarageFindingApp.DAL.Model;

namespace GarageFindingApp.DAL.Gateway
{
    public class UserListGateway
    {
        private static UserListGateway _instance;
        private SqlConnection con;
        private SqlCommand cmd;
        private BaseClass baseClass;

        public UserListGateway()
        {
            baseClass=BaseClass.GetInstance();
            con=new SqlConnection(baseClass.Connection);
        }
        public static UserListGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserListGateway();
            }
            return _instance;
        }
        internal bool Insert(UserListModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO UserList(UserId,Name,Email,MobileNo,UserType,Gender,Dob,GarageName,District,Thana,Location,Address,Password,Picture,Status,Intime,Lat,Long) VALUES(@UserId,@Name,@Email,@MobileNo,@UserType,@Gender,@Dob,@GarageName,@District,@Thana,@Location,@Address,@Password,@Picture,@Status,@Intime,@Lat,@Long)", con);
                cmd.Parameters.AddWithValue("@UserId", ob.UserId);
                cmd.Parameters.AddWithValue("@Name", ob.Name);
                cmd.Parameters.AddWithValue("@Email", ob.Email);
                cmd.Parameters.AddWithValue("@MobileNo", ob.MobileNo);
                cmd.Parameters.AddWithValue("@UserType", ob.UserType);
                cmd.Parameters.AddWithValue("@Gender", ob.Gender);
                cmd.Parameters.AddWithValue("@Dob", ob.Dob);
                cmd.Parameters.AddWithValue("@GarageName", ob.GarageName);
                cmd.Parameters.AddWithValue("@District", ob.District);
                cmd.Parameters.AddWithValue("@Thana", ob.Thana);
                cmd.Parameters.AddWithValue("@Location", ob.Location);
                cmd.Parameters.AddWithValue("@Address", ob.Address);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@Picture", ob.Picture);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
                cmd.Parameters.AddWithValue("@Intime", ob.Intime);
                cmd.Parameters.AddWithValue("@Lat", ob.Lat);
                cmd.Parameters.AddWithValue("@Long", ob.Long);

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
        internal bool UpdateStatus(UserListModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE UserList SET Status=@Status WHERE UserId=@UserId", con);
                cmd.Parameters.AddWithValue("@Status", ob.Status);
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
        internal bool UpdateProfile(UserListModel ob)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("UPDATE UserList SET Name=@Name,MobileNo=@MobileNo,Gender=@Gender,Dob=@Dob,GarageName=@GarageName,District=@District,Thana=@Thana,Location=@Location,Address=@Address,Password=@Password,Picture=@Picture,Lat=@Lat,Long=@Long WHERE UserId=@UserId", con);
                cmd.Parameters.AddWithValue("@Name", ob.Name);
                cmd.Parameters.AddWithValue("@MobileNo", ob.MobileNo);
                cmd.Parameters.AddWithValue("@Gender", ob.Gender);
                cmd.Parameters.AddWithValue("@Dob", ob.Dob);
                cmd.Parameters.AddWithValue("@GarageName", ob.GarageName);
                cmd.Parameters.AddWithValue("@District", ob.District);
                cmd.Parameters.AddWithValue("@Thana", ob.Thana);
                cmd.Parameters.AddWithValue("@Location", ob.Location);
                cmd.Parameters.AddWithValue("@Address", ob.Address);
                cmd.Parameters.AddWithValue("@Password", ob.Password);
                cmd.Parameters.AddWithValue("@Picture", ob.Picture);
                cmd.Parameters.AddWithValue("@Lat", ob.Lat);
                cmd.Parameters.AddWithValue("@Long", ob.Long);
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