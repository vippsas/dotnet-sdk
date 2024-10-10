/*
 * ePayment API
 *
 * The ePayment API enables you to create Vipps MobilePay payments for online and in-person payments. See the [ePayment API Guide](https://developer.vippsmobilepay.com/docs/APIs/epayment-api) for more details.
 *
 * The version of the OpenAPI document: 1.6.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Vipps.net.Models.Epayment.Model;
using Vipps.net.Models.Epayment.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace Vipps.net.Models.Epayment.Test.Model
{
    /// <summary>
    ///  Class for testing PaymentAdjustment
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class PaymentAdjustmentTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for PaymentAdjustment
        //private PaymentAdjustment instance;

        public PaymentAdjustmentTests()
        {
            // TODO uncomment below to create an instance of PaymentAdjustment
            //instance = new PaymentAdjustment();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of PaymentAdjustment
        /// </summary>
        [Fact]
        public void PaymentAdjustmentInstanceTest()
        {
            // TODO uncomment below to test "IsType" PaymentAdjustment
            //Assert.IsType<PaymentAdjustment>(instance);
        }

        /// <summary>
        /// Test the property 'ModificationAmount'
        /// </summary>
        [Fact]
        public void ModificationAmountTest()
        {
            // TODO unit test for the property 'ModificationAmount'
        }

        /// <summary>
        /// Test the property 'ModificationReference'
        /// </summary>
        [Fact]
        public void ModificationReferenceTest()
        {
            // TODO unit test for the property 'ModificationReference'
        }
    }
}
