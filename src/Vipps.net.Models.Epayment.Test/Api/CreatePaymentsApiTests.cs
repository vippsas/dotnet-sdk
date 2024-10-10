/*
 * ePayment API
 *
 * The ePayment API enables you to create Vipps MobilePay payments for online and in-person payments. See the [ePayment API Guide](https://developer.vippsmobilepay.com/docs/APIs/epayment-api) for more details.
 *
 * The version of the OpenAPI document: 1.6.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Vipps.net.Models.Epayment.Client;
using Vipps.net.Models.Epayment.Api;
// uncomment below to import models
//using Vipps.net.Models.Epayment.Model;

namespace Vipps.net.Models.Epayment.Test.Api
{
    /// <summary>
    ///  Class for testing CreatePaymentsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class CreatePaymentsApiTests : IDisposable
    {
        private CreatePaymentsApi instance;

        public CreatePaymentsApiTests()
        {
            instance = new CreatePaymentsApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of CreatePaymentsApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' CreatePaymentsApi
            //Assert.IsType<CreatePaymentsApi>(instance);
        }

        /// <summary>
        /// Test CreatePayment
        /// </summary>
        [Fact]
        public void CreatePaymentTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string idempotencyKey = null;
            //string ocpApimSubscriptionKey = null;
            //string merchantSerialNumber = null;
            //CreatePaymentRequest createPaymentRequest = null;
            //string? vippsSystemName = null;
            //string? vippsSystemVersion = null;
            //string? vippsSystemPluginName = null;
            //string? vippsSystemPluginVersion = null;
            //var response = instance.CreatePayment(idempotencyKey, ocpApimSubscriptionKey, merchantSerialNumber, createPaymentRequest, vippsSystemName, vippsSystemVersion, vippsSystemPluginName, vippsSystemPluginVersion);
            //Assert.IsType<CreatePaymentResponse>(response);
        }
    }
}
