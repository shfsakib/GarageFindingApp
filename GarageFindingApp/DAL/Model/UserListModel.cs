using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class UserListModel
    {
        private static UserListModel _instance;
        public static UserListModel GetInstance()
        {
            if (_instance==null)
            {
                _instance=new UserListModel();
            }
            return _instance;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string UserType { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string GarageName { get; set; }
        public int District { get; set; }
        public int Thana { get; set; }
        public int Location { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
        public string Intime { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}