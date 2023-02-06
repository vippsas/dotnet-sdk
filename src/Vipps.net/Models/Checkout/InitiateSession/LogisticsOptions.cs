using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

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
    };

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

    public record LogisticsOptionBase(Amount amount, string id)
    {
        [JsonRequired]
        public Amount Amount = amount;

        [JsonRequired]
        public string Id = id;

        public int Priority { get; init; }

        public bool IsDefault { get; init; }

        public string? Description { get; init; }
    }

    public record PostenLogisticsOption(Amount amount, string id) : LogisticsOptionBase(amount, id)
    {
        public PostenLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public record PostnordLogisticsOption(Amount amount, string id)
        : LogisticsOptionBase(amount, id)
    {
        public PostnordLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public record PorterbuddyLogisticsOption(Amount amount, string id)
        : LogisticsOptionBase(amount, id)
    {
        public PorterbuddyLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public record InstaboxLogisticsOption(Amount amount, string id)
        : LogisticsOptionBase(amount, id)
    {
        public InstaboxLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public record HelthjemLogisticsOption(Amount amount, string id)
        : LogisticsOptionBase(amount, id)
    {
        public HelthjemLogisticsType? Type { get; init; }
        public string? CustomType { get; init; }
    }

    public record OtherLogisticsOption(string title, Amount amount, string id)
        : LogisticsOptionBase(amount, id)
    {
        [JsonRequired]
        public string Title = title;
    }
}
