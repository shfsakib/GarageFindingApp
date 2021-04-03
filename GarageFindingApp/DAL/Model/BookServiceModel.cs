using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageFindingApp.DAL.Model
{
    public class BookServiceModel
    {
        private static BookServiceModel _instance;
        public static BookServiceModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookServiceModel();
            }
            return _instance;
        }

        public int BookId { get; set; }
        public int GarageId { get; set; }
        public int CustId { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string BkashNo { get; set; }
        public string TransactionNo { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public string Intime { get; set; }
        public string TokenId { get; set; }
    }
}