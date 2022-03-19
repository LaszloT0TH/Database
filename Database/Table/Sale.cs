using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Sale
    {
        private static int _saleId;
        private string _number;
        private int _costumerId;
        private int _salesId;
        private int _carNumber;
        private DateTime _date;

        public Sale(int costumerId, int salesId, int carNumber, DateTime date)
        {
            string storedId = null;
            if (File.Exists("aisale")) storedId = File.ReadAllText("aisale");
            if (storedId == null || storedId.Length < 0) storedId = "0";
            _saleId = Convert.ToInt32(storedId) + 1;
            File.WriteAllText("aisale", _saleId.ToString());
            this._number = _saleId.ToString();
            CostumerId = costumerId;
            SalesId = salesId;
            CarNumber = carNumber;
            Date = date;
        }

        public static int SaleId { get => _saleId; set => _saleId = value; }
        public string Number { get => _number; set => _number = value; }
        public int CostumerId { get => _costumerId; set => _costumerId = value; }
        public int SalesId { get => _salesId; set => _salesId = value; }
        public int CarNumber { get => _carNumber; set => _carNumber = value; }
        public DateTime Date { get => _date; set => _date = value; }
    }
}
