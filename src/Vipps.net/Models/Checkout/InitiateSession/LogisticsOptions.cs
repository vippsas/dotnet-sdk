using System.ComponentModel.DataAnnotations;

namespace Vipps.Models.Checkout.InitiateSession
{
    public enum LogisticsBrand
    {
        POSTEN,
        POSTNORD,
        PORTERBUDDY,
        INSTABOX,
        HELTHJEM,
        OTHER
    }

    public enum PostenLogisticsType
    {
        MAILBOX,
        PICKUP_POINT,
        HOME_DELIVERY
    }

    public enum PostnordLogisticsType
    {
        PICKUP_POINT,
        HOME_DELIVERY
    }

    public enum HelthjemLogisticsType
    {
        HOME_DELIVERY,
        PICKUP_POINT
    };

    public enum InstaboxLogisticsType
    {
        HOME_DELIVERY,
        PICKUP_POINT
    }

    public enum PorterbuddyLogisticsType
    {
        HOME_DELIVERY
    }

    public class LogisticsOptionBase
    {
        public LogisticsOptionBase(Amount amount, string id)
        {
            Id = id;
            Amount = amount;
        }

        [Required]
        public Amount Amount;

        [Required]
        public string Id;

        public int Priority { get; set; }

        public bool IsDefault { get; set; }

        public string Description { get; set; }
    }

    public class PostenLogisticsOption : LogisticsOptionBase
    {
        public PostenLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public PostenLogisticsType Type { get; set; }
        public string CustomType { get; set; }
    }

    public class PostnordLogisticsOption : LogisticsOptionBase
    {
        public PostnordLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public PostnordLogisticsType Type { get; set; }
        public string CustomType { get; set; }
    }

    public class PorterbuddyLogisticsOption : LogisticsOptionBase
    {
        public PorterbuddyLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public PorterbuddyLogisticsType Type { get; set; }
        public string CustomType { get; set; }
    }

    public class InstaboxLogisticsOption : LogisticsOptionBase
    {
        public InstaboxLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public InstaboxLogisticsType Type { get; set; }
        public string CustomType { get; set; }
    }

    public class HelthjemLogisticsOption : LogisticsOptionBase
    {
        public HelthjemLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public HelthjemLogisticsType Type { get; set; }
        public string CustomType { get; set; }
    }

    public class OtherLogisticsOption : LogisticsOptionBase
    {
        public OtherLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        [Required]
        public string Title { get; set; }
    }
}
