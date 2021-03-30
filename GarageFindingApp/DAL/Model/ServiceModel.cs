using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class ServiceModel
    {
        private static ServiceModel _instance;
        public static ServiceModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ServiceModel();
            }
            return _instance;
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public int GarageId { get; set; }
        public string Intime { get; set; }
    }
}