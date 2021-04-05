using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class MonthlyChargeModel
    {
        private static MonthlyChargeModel _instance;
        public static MonthlyChargeModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MonthlyChargeModel();
            }
            return _instance;
        }

        public int ChargeId { get; set; }
        public int GarageId { get; set; }
        public string Month { get; set; }
        public string BkashNo { get; set; }
        public string TransactionNo { get; set; }
        public double Amount { get; set; }
        public string PaymentTime { get; set; }
        public string Status { get; set; }
    }
}