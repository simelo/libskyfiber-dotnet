/* 
 * Skycoin REST API.
 *
 * Skycoin is a next-generation cryptocurrency.
 *
 * The version of the OpenAPI document: 0.26.0
 * Contact: contact@skycoin.net
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using Newtonsoft.Json;
using NUnit.Framework;
using Skyapi.Client;
using Skyapi.Api;
using RestSharp;

namespace Skyapi.Test.Api
{
    /// <summary>
    ///  Class for testing DefaultApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class DefaultApiTests
    {
        private DefaultApi _instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            _instance = new DefaultApi(Utils.GetNodeHost());
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
        }

        /// <summary>
        /// Test an instance of DefaultApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            Assert.IsInstanceOfType(typeof(DefaultApi), _instance, "instance is a DefaultApi");
        }


        /// <summary>
        /// Test AddressCount
        /// </summary>
        [Test]
        public void AddressCountTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.AddressCount(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.AddressCount(_instance);
            }
        }

        /// <summary>
        /// Test AddressUxouts
        /// </summary>
        [Test]
        public void AddressUxoutsTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.AddressUxouts(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                if (Utils.LiveDisableNetworking())
                {
                    LiveTest.AddressUxouts(_instance);
                }
                else
                {
                    Console.WriteLine("Skipping slow ux out tests when networking disabled");
                }
            }
        }

        /// <summary>
        /// Test ApiV1RawtxGet
        /// </summary>
        [Test]
        public void ApiV1RawtxGetTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.ApiRawTxGet(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.ApiRawTxGet(instance: _instance);
            }
        }

        /// <summary>
        /// Test ApiV2MetricsGet
        /// </summary>
        [Test]
        public void ApiV2MetricsGetTest()
        {
            //Only with API-SETS PROMETHEUS is active.
            try
            {
                var response = _instance.ApiV2MetricsGet();
                Assert.IsInstanceOf<string>(response, "response is string");
                Assert.IsNotNull(response);
                if (Utils.GetTestMode() == "stable") Assert.True(response.Contains("last_block_seq 180"));
            }
            catch (ApiException err)
            {
                Assert.AreEqual(403, err.ErrorCode,
                    "Endpoint Not tested. Endpoint are disable : Api-sets PROMETHEUS could be disabled." +
                    " Try to enable it.");
            }
        }

        /// <summary>
        /// Test BalanceGet
        /// </summary>
        [Test]
        public void BalanceGetTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Balance(_instance, Method.GET);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Balance(Method.GET, instance: _instance);
            }
        }

        /// <summary>
        /// Test BalancePost
        /// </summary>
        [Test]
        public void BalancePostTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Balance(_instance, Method.POST);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Balance(Method.POST, _instance);
            }
        }

        /// <summary>
        /// Test Block
        /// </summary>
        [Test]
        public void BlockTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Block(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Block(_instance);
            }
        }

        /// <summary>
        /// Test BlockchainMetadata
        /// </summary>
        [Test]
        public void BlockchainMetadataTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.BlockchainMetadata(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.BlockchainMetadata(_instance);
            }
        }

        /// <summary>
        /// Test BlockchainProgress
        /// </summary>
        [Test]
        public void BlockchainProgressTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.BlockChainProgress(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.BlockChainProgress(_instance);
            }
        }

        /// <summary>
        /// Test Blocks
        /// </summary>
        [Test]
        public void BlocksTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Blocks(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Blocks(_instance);
            }
        }

        /// <summary>
        /// Test CoinSupply
        /// </summary>
        [Test]
        public void CoinSupplyTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.CoinSupply(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.CoinSupply(_instance);
            }
        }

        /// <summary>
        /// Test Csrf
        /// </summary>
        [Test]
        public void CsrfTest()
        {
            //Only with _useCsrf==true
            if (Utils.UseCsrf())
            {
                var response = _instance.Csrf();
                Assert.IsNotNull(response.CsrfToken);
                Assert.True(response.CsrfToken.Length >= 235);
            }
        }

        /// <summary>
        /// Test DataDELETE
        /// </summary>
        [Test]
        public void DataDeleteTest()
        {
            if (!Utils.GetTestMode().Equals("stable"))
            {
                return;
            }

            if (Utils.UseCsrf()) _instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(_instance));
            _instance.DataPOST(type: "txid", key: "key1", val: "val1");
            var result = _instance.DataGET(type: "txid");
            _instance.DataPOST(type: "txid", key: "keytodel", val: "valtodel");
            _instance.DataDELETE(type: "txid", key: "keytodel");
            Assert.AreEqual(result, _instance.DataGET("txid"));
        }

        /// <summary>
        /// Test DataGET
        /// </summary>
        [Test]
        public void DataGetTest()
        {
            if (!Utils.GetTestMode().Equals("stable"))
            {
                return;
            }

            var allresult = new {data = new {key1 = "val1", key2 = "val2"}};
            var singleresult = new {data = "val1"};
            if (Utils.UseCsrf()) _instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(_instance));
            _instance.DataPOST(type: "txid", key: "key1", val: "val1");
            _instance.DataPOST(type: "txid", key: "key2", val: "val2");
            //Varify all results.
            Assert.AreEqual(JsonConvert.SerializeObject(allresult),
                JsonConvert.SerializeObject(_instance.DataGET(type: "txid")));
            //Verify a single result.
            Assert.AreEqual(JsonConvert.SerializeObject(singleresult),
                JsonConvert.SerializeObject(_instance.DataGET(type: "txid", key: "key1")));
        }

        /// <summary>
        /// Test DataPOST
        /// </summary>
        [Test]
        public void DataPostTest()
        {
            if (!Utils.GetTestMode().Equals("stable"))
            {
                return;
            }

            if (Utils.UseCsrf()) _instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(_instance));
            _instance.DataPOST(type: "client", key: "key1", val: "val1");
        }

        /// <summary>
        /// Test DefaultConnections
        /// </summary>
        [Test]
        public void DefaultConnectionsTest()
        {
            var connections = _instance.DefaultConnections();
            Assert.IsNotEmpty(connections);
            connections.Sort();
            Utils.CheckGoldenFile("network-default-peers.golden", connections, connections.GetType());
        }

        /// <summary>
        /// Test Health
        /// </summary>
        [Test]
        public void HealthTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Health(instance: _instance);
            }
            else if (Utils.GetTestMode().Equals("live"))

            {
                LiveTest.Health(_instance);
            }
        }

        /// <summary>
        /// Test LastBlocks
        /// </summary>
        [Test]
        public void LastBlocksTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.LastBlocks(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.LastBlock(_instance);
            }
        }

        /// <summary>
        /// Test NetworkConnection and NetworkConnections
        /// </summary>
        [Test]
        public void NetworkConnectionTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.NetworkConnection(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.NetworkConnection(instance: _instance);
            }
        }

        /// <summary>
        /// Test NetworkConnectionsDisconnect
        /// </summary>
        [Test]
        public void NetworkConnectionsDisconnectTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.NetworkConnectionDisconnect(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.NetworkConnectionDisconnect(instance: _instance);
            }
        }

        /// <summary>
        /// Test NetworkConnectionsExchange
        /// </summary>
        [Test]
        public void NetworkConnectionsExchangeTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.NetworkConnectionExchange(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.NetworkConnectionExchange(_instance);
            }
        }

        /// <summary>
        /// Test NetworkConnectionsTrust
        /// </summary>
        [Test]
        public void NetworkConnectionsTrustTest()
        {
            var connections = _instance.NetworkConnectionsTrust();
            Assert.IsNotEmpty(connections);
            connections.Sort();
            Utils.CheckGoldenFile("network-trusted-peers.golden", connections, connections.GetType());
        }

        /// <summary>
        /// Test OutputsGet
        /// </summary>
        [Test]
        public void OutputsGetTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                if (Utils.DbNoUnconfirmed())
                {
                    StableTest.NoUnconfirmedOutputs(Method.GET, _instance);
                }
                else
                {
                    StableTest.Outputs(Method.GET, _instance);
                }
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Outputs(Method.GET, _instance);
            }
        }

        /// <summary>
        /// Test OutputsPost
        /// </summary>
        [Test]
        public void OutputsPostTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                if (Utils.DbNoUnconfirmed())
                {
                    StableTest.NoUnconfirmedOutputs(Method.POST, _instance);
                }
                else
                {
                    StableTest.Outputs(Method.POST, _instance);
                }
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Outputs(Method.POST, _instance);
            }
        }

        /// <summary>
        /// Test PendingTxs
        /// </summary>
        [Test]
        public void PendingTxsTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                if (Utils.DbNoUnconfirmed())
                {
                    StableTest.NoUnconfirmedPendingTxs(_instance);
                }
                else
                {
                    StableTest.PendingTxs(_instance);
                }
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.PendingTxs(_instance);
            }
        }

        /// <summary>
        /// Test ResendUnconfirmedTxns
        /// </summary>
        [Test]
        public void ResendUnconfirmedTxnsTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.ResendUnconfirmedTxns(instance: _instance);
            }
            else if (Utils.GetTestMode().Equals("live"))

            {
                LiveTest.ResendUnconfirmedTxns(_instance);
            }
        }

        /// <summary>
        /// Test Richlist
        /// </summary>
        [Test]
        public void RichlistTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.RichList(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.RichList(_instance);
            }
        }

        /// <summary>
        /// Test Transaction
        /// </summary>
        [Test]
        public void TransactionTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Transaction(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Transaction(_instance);
            }
        }

        /// <summary>
        /// Test TransactionInject
        /// </summary>
        [Test]
        public void TransactionInjectTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.TransactionInject(_instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                if (Utils.LiveDisableNetworking())
                {
                    LiveTest.TransactionInjectDisableNetworking(_instance);
                }
                else
                {
                    LiveTest.TransactionInjectEnableNetworking(_instance);
                }
            }
        }

        /// <summary>
        /// Test TransactionPost
        /// </summary>
        [Test]
        public void TransactionPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //TransactionV2ParamsAddress transactionV2ParamsAddress = null;
            //var response = instance.TransactionPost(transactionV2ParamsAddress);
            //Assert.IsInstanceOf<InlineResponse2008> (response, "response is InlineResponse2008");
        }

        /// <summary>
        /// Test TransactionPostUnspent
        /// </summary>
        [Test]
        public void TransactionPostUnspentTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //TransactionV2ParamsUnspent transactionV2ParamsUnspent = null;
            //var response = instance.TransactionPostUnspent(transactionV2ParamsUnspent);
            //Assert.IsInstanceOf<InlineResponse2008> (response, "response is InlineResponse2008");
        }

        /// <summary>
        /// Test TransactionRaw
        /// </summary>
        [Test]
        public void TransactionRawTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string txid = null;
            //var response = instance.TransactionRaw(txid);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test TransactionVerify
        /// </summary>
        [Test]
        public void TransactionVerifyTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //TransactionVerifyRequest transactionVerifyRequest = null;
            //var response = instance.TransactionVerify(transactionVerifyRequest);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test TransactionsGet
        /// </summary>
        [Test]
        public void TransactionsGetTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Transactions(method: Method.GET, instance: _instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Transactions(Method.GET, _instance);
            }
        }

        /// <summary>
        /// Test TransactionsPost
        /// </summary>
        [Test]
        public void TransactionsPostTest()
        {
            if (Utils.GetTestMode().Equals("stable"))
            {
                StableTest.Transactions(method: Method.POST, instance: _instance);
            }
            else if (Utils.GetTestMode().Equals("live"))
            {
                LiveTest.Transactions(Method.POST, _instance);
            }
        }

        /// <summary>
        /// Test Uxout
        /// </summary>
        [Test]
        public void UxoutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string uxid = null;
            //var response = instance.Uxout(uxid);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test VerifyAddress
        /// </summary>
        [Test]
        public void VerifyAddressTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Object address = null;
            //var response = instance.VerifyAddress(address);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test Version
        /// </summary>
        [Test]
        public void VersionTest()
        {
            var result = _instance.Version();
            Assert.AreEqual("v0.26.0", result.Branch);
            Assert.AreEqual("ff754084df0912bc0d151529e2893ca86618fb3f", result.Commit);
            Assert.AreEqual("0.26.0", result.Version);
        }

        /// <summary>
        /// Test Wallet
        /// </summary>
        [Test]
        public void WalletTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.Wallet(id);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletBalance
        /// </summary>
        [Test]
        public void WalletBalanceTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.WalletBalance(id);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletCreate
        /// </summary>
        [Test]
        public void WalletCreateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string seed = null;
            //string label = null;
            //int? scan = null;
            //bool? encrypt = null;
            //string password = null;
            //var response = instance.WalletCreate(seed, label, scan, encrypt, password);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletDecrypt
        /// </summary>
        [Test]
        public void WalletDecryptTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string password = null;
            //var response = instance.WalletDecrypt(id, password);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletEncrypt
        /// </summary>
        [Test]
        public void WalletEncryptTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string password = null;
            //var response = instance.WalletEncrypt(id, password);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletFolder
        /// </summary>
        [Test]
        public void WalletFolderTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string addr = null;
            //var response = instance.WalletFolder(addr);
            //Assert.IsInstanceOf<InlineResponse2007> (response, "response is InlineResponse2007");
        }

        /// <summary>
        /// Test WalletNewAddress
        /// </summary>
        [Test]
        public void WalletNewAddressTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string num = null;
            //string password = null;
            //var response = instance.WalletNewAddress(id, num, password);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletNewSeed
        /// </summary>
        [Test]
        public void WalletNewSeedTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string entropy = null;
            //var response = instance.WalletNewSeed(entropy);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletRecover
        /// </summary>
        [Test]
        public void WalletRecoverTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string seed = null;
            //string password = null;
            //var response = instance.WalletRecover(id, seed, password);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletSeed
        /// </summary>
        [Test]
        public void WalletSeedTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string password = null;
            //var response = instance.WalletSeed(id, password);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletSeedVerify
        /// </summary>
        [Test]
        public void WalletSeedVerifyTest()
        {
            if (Utils.UseCsrf())
            {
                _instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(_instance));
            }

            _instance.Configuration.AddDefaultHeader("Content-Type", "application/json");
            //Test with correct seed
            var result =
                _instance.WalletSeedVerify(
                    "nut wife logic sample addict shop before tobacco crisp bleak lawsuit affair");
            Assert.NotNull(result);
            //test with incorrect seed
            Assert.Throws<ApiException>(() => _instance.WalletSeedVerify("nut"));
        }

        /// <summary>
        /// Test WalletTransaction
        /// </summary>
        [Test]
        public void WalletTransactionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //WalletTransactionRequest walletTransactionRequest = null;
            //var response = instance.WalletTransaction(walletTransactionRequest);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }

        /// <summary>
        /// Test WalletTransactionSign
        /// </summary>
        [Test]
        public void WalletTransactionSignTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //WalletTransactionSignRequest walletTransactionSignRequest = null;
            //var response = instance.WalletTransactionSign(walletTransactionSignRequest);
            //Assert.IsInstanceOf<InlineResponse2009> (response, "response is InlineResponse2009");
        }

        /// <summary>
        /// Test WalletTransactions
        /// </summary>
        [Test]
        public void WalletTransactionsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //var response = instance.WalletTransactions(id);
            //Assert.IsInstanceOf<InlineResponse2006> (response, "response is InlineResponse2006");
        }

        /// <summary>
        /// Test WalletUnload
        /// </summary>
        [Test]
        public void WalletUnloadTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //instance.WalletUnload(id);
        }

        /// <summary>
        /// Test WalletUpdate
        /// </summary>
        [Test]
        public void WalletUpdateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string id = null;
            //string label = null;
            //var response = instance.WalletUpdate(id, label);
            //Assert.IsInstanceOf<string> (response, "response is string");
        }

        /// <summary>
        /// Test Wallets
        /// </summary>
        [Test]
        public void WalletsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.Wallets();
            //Assert.IsInstanceOf<List<Object>> (response, "response is List<Object>");
        }
    }
}