using System.Text.Json.Serialization;

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

        [JsonRequired]
        public Amount Amount;

        [JsonRequired]
        public string Id;

        public int Priority { get; init; }

        public bool IsDefault { get; init; }

        public string? Description { get; init; }
    }

    public class PostenLogisticsOption : LogisticsOptionBase
    {
        public PostenLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public PostenLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public class PostnordLogisticsOption : LogisticsOptionBase
    {
        public PostnordLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public PostnordLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public class PorterbuddyLogisticsOption : LogisticsOptionBase
    {
        public PorterbuddyLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public PorterbuddyLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public class InstaboxLogisticsOption : LogisticsOptionBase
    {
        public InstaboxLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public InstaboxLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public class HelthjemLogisticsOption : LogisticsOptionBase
    {
        public HelthjemLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        public HelthjemLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public class OtherLogisticsOption : LogisticsOptionBase
    {
        public OtherLogisticsOption(Amount amount, string id)
            : base(amount, id) { }

        [JsonRequired]
        public string Title { get; init; }
    }
}
