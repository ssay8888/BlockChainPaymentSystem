using System.Collections.Generic;

namespace BlockChainPaymentSystem.Constants.CultureCommon
{
    public class CultureCoupon
    {
        public int Id { get; set; }
        public int AccId { get; set; }
        public string PinNumber { get; set; }
        public bool IsChecked { get; set; } = false;
        public int Amount { get; set; } = 0;
        public CultureCoupon(int id_, int accid, string pinNumber_, bool checked_, int amount_)
        {
            Id = id_;
            AccId = accid;
            PinNumber = pinNumber_;
            IsChecked = checked_;
            Amount = amount_;
        }
        public CultureCoupon()
        {

        }
    }
}
