using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InventoryModel.Classes
{
    public class Categories
    {
        //public int SrNo { get; set; }
        [DisplayName("Category ID")]
        public int CatID { get; set; }
        [DisplayName("Categories")]
        public string CatDesc { get; set; }
    }

    public class Brands
    {
        //public int SrNo { get; set; }
        [DisplayName("Brand ID")]
        public int BrandID { get; set; }
        [DisplayName("Brands")]
        public string BrandName { get; set; }
    }

    public class Dealers
    {
        //public int SrNo { get; set; }
        [DisplayName("Dealer ID")]
        public int DealerID { get; set; }
        [DisplayName("Dealer Name")]
        public string DealerName { get; set; }
        [DisplayName("Dealer Contact")]
        public string DealerPhoneNum { get; set; }
        [DisplayName("Dealer Address")]
        public string DealerAddress { get; set; }
    }

    public class ItemData
    {
        //public int SrNo { get; set; }
        [DisplayName("Item ID")]
        public int ItemID { get; set; }
        [DisplayName("Model Number")]
        public string ModelNumber { get; set; }
        [DisplayName("IMEI")]
        public string IMEI { get; set; }
        [DisplayName("Category ID")]
        public int CatID { get; set; }
        [DisplayName("Category")]
        public string CatDesc { get; set; }
        [DisplayName("Brand ID")]
        public int BrandID { get; set; }
        [DisplayName("Brand")]
        public string BrandName { get; set; }
        [DisplayName("Dealer ID")]
        public int DealerID { get; set; }
        [DisplayName("Dealer Name")]
        public string DealerName { get; set; }
        [DisplayName("Buy Date")]
        public DateTime BuyDate { get; set; }
        [DisplayName("Buy Price")]
        public double BuyPrice { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("Customer Address")]
        public string CustAddress { get; set; }
        [DisplayName("Customer Contact")]
        public string CustPhoneNum { get; set; }
        [DisplayName("Sell Date")]
        public DateTime SellDate { get; set; }
        [DisplayName("Sell Price")]
        public double SellPrice { get; set; }
    }

    public class SearchCriteria
    {
        public string ShowAll { get; set; }
        public int ItemID { get; set; }
        public int CatID { get; set; }
        public int BrandID { get; set; }
        public int DealerID { get; set; }
        public DateTime BuyFromDate { get; set; }
        public DateTime BuyToDate { get; set; }
        public DateTime SellFromDate { get; set; }
        public DateTime SellToDate { get; set; }
        public string BuyFromPrice { get; set; }
        public string BuyToPrice { get; set; }
        public string SellFromPrice { get; set; }
        public string SellToPrice { get; set; }
    }

    public class UserData
    {
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("User Type")]
        public string UserType { get; set; }
    }
}
