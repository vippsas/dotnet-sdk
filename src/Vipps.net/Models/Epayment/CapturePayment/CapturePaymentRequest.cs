﻿using System.Text.Json.Serialization;

namespace Vipps.Models.Epayment.CapturePayment
{
    public class CapturePaymentRequest : VippsRequest
    {
        [property: JsonPropertyName("modificationAmount")]
        public ModificationAmount ModificationAmount { get; private set; }
    }

    public class ModificationAmount
    {
        [property: JsonPropertyName("currency")]
        public string Currency { get; private set; }

        [property: JsonPropertyName("value")]
        public int Value { get; private set; }
    }
}
