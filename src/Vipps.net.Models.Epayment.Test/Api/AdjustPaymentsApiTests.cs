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
    ///  Class for testing AdjustPaymentsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class AdjustPaymentsApiTests : IDisposable
    {
        private AdjustPaymentsApi instance;

        public AdjustPaymentsApiTests()
        {
            instance = new AdjustPaymentsApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of AdjustPaymentsApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' AdjustPaymentsApi
            //Assert.IsType<AdjustPaymentsApi>(instance);
        }

        /// <summary>
        /// Test CancelPayment
        /// </summary>
        [Fact]
        public void CancelPaymentTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string reference = null;
            //string merchantSerialNumber = null;
            //string ocpApimSubscriptionKey = null;
            //string idempotencyKey = null;
            //string vippsSystemName = null;
            //string vippsSystemVersion = null;
            //string vippsSystemPluginName = null;
            //string vippsSystemPluginVersion = null;
            //CancelModificationRequest cancelModificationRequest = null;
            //var response = instance.CancelPayment(reference, merchantSerialNumber, ocpApimSubscriptionKey, idempotencyKey, vippsSystemName, vippsSystemVersion, vippsSystemPluginName, vippsSystemPluginVersion, cancelModificationRequest);
            //Assert.IsType<ModificationResponse>(response);
        }

        /// <summary>
        /// Test CapturePayment
        /// </summary>
        [Fact]
        public void CapturePaymentTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string reference = null;
            //string merchantSerialNumber = null;
            //string ocpApimSubscriptionKey = null;
            //string idempotencyKey = null;
            //string vippsSystemName = null;
            //string vippsSystemVersion = null;
            //string vippsSystemPluginName = null;
            //string vippsSystemPluginVersion = null;
            //CaptureModificationRequest captureModificationRequest = null;
            //var response = instance.CapturePayment(reference, merchantSerialNumber, ocpApimSubscriptionKey, idempotencyKey, vippsSystemName, vippsSystemVersion, vippsSystemPluginName, vippsSystemPluginVersion, captureModificationRequest);
            //Assert.IsType<ModificationResponse>(response);
        }

        /// <summary>
        /// Test RefundPayment
        /// </summary>
        [Fact]
        public void RefundPaymentTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string reference = null;
            //string merchantSerialNumber = null;
            //string ocpApimSubscriptionKey = null;
            //string idempotencyKey = null;
            //string vippsSystemName = null;
            //string vippsSystemVersion = null;
            //string vippsSystemPluginName = null;
            //string vippsSystemPluginVersion = null;
            //RefundModificationRequest refundModificationRequest = null;
            //var response = instance.RefundPayment(reference, merchantSerialNumber, ocpApimSubscriptionKey, idempotencyKey, vippsSystemName, vippsSystemVersion, vippsSystemPluginName, vippsSystemPluginVersion, refundModificationRequest);
            //Assert.IsType<ModificationResponse>(response);
        }
    }
}
