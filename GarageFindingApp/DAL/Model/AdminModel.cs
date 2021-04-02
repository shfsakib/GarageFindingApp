using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class AdminModel
    {
        private static AdminModel _instance;
        public static AdminModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdminModel();
            }
            return _instance;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Picture { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string InTime { get; set; }
    }
}