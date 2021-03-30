using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class LocationModel
    {
        private static LocationModel _instance;
        public static LocationModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LocationModel();
            }
            return _instance;
        }

        public int Id { get; set; }
        public string LocationName { get; set; }
        public int ThanaId { get; set; }
        public string Intime { get; set; }
    }
}