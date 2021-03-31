using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class RatingModel
    {
        private static RatingModel _instance;
        public static RatingModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RatingModel();
            }
            return _instance;
        }

        public int RateId { get; set; }
        public int GarageId { get; set; }
        public int UserId { get; set; }
        public int Rate { get; set; }
        public string Review { get; set; }
        public string InTime { get; set; }
    }
}