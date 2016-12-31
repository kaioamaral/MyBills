using domain.Model.Contracts.Enumerators;
using System;

namespace domain.Model.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Observations { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Public { get; set; }
        public string Reference { get; set; }
        public BillStatus Status { get; set; }
    }
}
