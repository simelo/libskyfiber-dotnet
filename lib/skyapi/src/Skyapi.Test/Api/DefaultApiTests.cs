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
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using Skyapi.Client;
using Skyapi.Api;
using Skyapi.Model;
using skycoin;

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
        internal DefaultApi Instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            Instance = new DefaultApi(Utils.GetNodeHost());
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
                var response = Instance.ApiV2MetricsGet();
                Assert.IsInstanceOf<string>(response, "response is string");
                Assert.IsNotNull(response);
                if (Utils.GetTestMode().Equals("stable")) Assert.True(response.Contains("last_block_seq 180"));
            }
            catch (ApiException err)
            {
                Assert.AreEqual(403, err.ErrorCode,
                    "Endpoint Not tested. Endpoint are disable : Api-sets PROMETHEUS could be disabled." +
                    " Try to enable it.");
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
                var response = Instance.Csrf();
                Assert.IsNotNull(response.CsrfToken);
                Assert.True(response.CsrfToken.Length >= 235);
            }
        }

        /// <summary>
        /// Test DefaultConnections
        /// </summary>
        [Test]
        public void DefaultConnectionsTest()
        {
            var connections = Instance.DefaultConnections();
            Assert.IsNotEmpty(connections);
            connections.Sort();
            Utils.CheckGoldenFile("network-default-peers.golden", connections, connections.GetType());
        }


        /// <summary>
        /// Test NetworkConnectionsTrust
        /// </summary>
        [Test]
        public void NetworkConnectionsTrustTest()
        {
            var connections = Instance.NetworkConnectionsTrust();
            Assert.IsNotEmpty(connections);
            connections.Sort();
            Utils.CheckGoldenFile("network-trusted-peers.golden", connections, connections.GetType());
        }

        /// <summary>
        /// Test VerifyAddress
        /// </summary>
        [Test]
        public void VerifyAddressTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            var testCases = new[]
            {
                new
                {
                    name = "valid address",
                    golden = "verify-address.golden",
                    adds = new Address("7cpQ7t3PZZXvjTst8G7Uvs7XH4LeM8fBPD"),
                    errCode = 200,
                    errMsg = ""
                },
                new
                {
                    name = "invalid address",
                    golden = "",
                    adds = new Address("7apQ7t3PZZXvjTst8G7Uvs7XH4LeM8fBPD"),
                    errCode = 422,
                    errMsg = "Invalid checksum"
                },
                new
                {
                    name = "missing address",
                    golden = "",
                    adds = new Address(""),
                    errCode = 400,
                    errMsg = "address is required"
                }
            };
            foreach (var tc in testCases)
            {
                if (Utils.UseCsrf())
                {
                    Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(instance: Instance));
                }

                if (tc.errCode != 200)
                {
                    var errRaw = Assert.Throws<ApiException>(() => Instance.VerifyAddress(tc.adds));
                    dynamic err = JsonConvert.DeserializeObject(errRaw.Message.Substring(28));
                    Assert.AreEqual(tc.errCode, errRaw.ErrorCode, tc.name);
                    Assert.AreEqual(tc.errMsg, err.error.message.ToString(), tc.name);
                }
                else
                {
                    Assert.DoesNotThrow(() =>
                        {
                            dynamic result = Instance.VerifyAddress(tc.adds);
                            Utils.CheckGoldenFile(tc.golden, result.data, result.GetType());
                        }
                        , tc.name);
                }
            }
        }

        /// <summary>
        /// Test Version
        /// </summary>
        [Test]
        public void VersionTest()
        {
            var result = Instance.Version();
            Assert.IsNotEmpty(result.Branch);
            Assert.IsNotEmpty(result.Commit);
            Assert.IsNotEmpty(result.Version);
        }

        /// <summary>
        /// Test Wallet
        /// </summary>
        [Test]
        public void WalletTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            if (Utils.UseCsrf())
            {
                Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(Instance));
            }

            var walletType = new[]
            {
                "deterministic", "bip44", //"xpub"
            };

            foreach (var wt in walletType)
            {
                // Create a wallet
                var walletCreateTuple = Utils.CreateWallet(Instance, wt);
                var wallet = walletCreateTuple.Item1;
                var clean = walletCreateTuple.Item3;

                // Confirms the wallet can be acquired
                var w1 = Instance.Wallet(wallet.Meta.Id);
                Assert.AreEqual(wallet, w1);
                clean();
            }
        }

        /// <summary>
        /// Test WalletCreate.Ignore that Test.Error:Error getting response stram (ReadDone2): ReceiveFailure.   
        /// </summary>
        [Test]
        public void WalletCreateTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }


            var seedStr = new _GoString_();
            var err = skycoin.skycoin.SKY_bip39_NewDefaultMnemomic(seedStr);
            Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
            var mnemonicSeed = seedStr.p;

            var testCases = new[]
            {
                new
                {
                    name = "deterministic encrypted",
                    seed = "fooseed2",
                    xpub = "",
                    seedPassphrase = "",
                    type = "deterministic",
                    encrypt = true,
                },
                new
                {
                    name = "deterministic unencrypted",
                    seed = "fooseed2",
                    xpub = "",
                    seedPassphrase = "",
                    type = "deterministic",
                    encrypt = false,
                },
//                new
//                {
//                    name = "bip44 with seed passphrase encrypted",
//                    seed = mnemonicSeed,
//                    xpub = "",
//                    seedPassphrase = "foobar",
//                    type = "bip44",
//                    encrypt = true,
//                },
//                new
//                {
//                    name = "bip44 without seed passphrase encrypted",
//                    seed = mnemonicSeed,
//                    xpub = "",
//                    seedPassphrase = "",
//                    type = "bip44",
//                    encrypt = true,
//                },
//                new
//                {
//                    name = "bip44 with seed passphrase unencrypted",
//                    seed = mnemonicSeed,
//                    xpub = "",
//                    seedPassphrase = "foobar",
//                    type = "bip44",
//                    encrypt = false,
//                },
//                new
//                {
//                    name = "bip44 without seed passphrase unencrypted",
//                    seed = mnemonicSeed,
//                    xpub = "",
//                    seedPassphrase = "",
//                    type = "bip44",
//                    encrypt = false,
//                },
//                new
//                {
//                    name = "xpub wallet",
//                    seed = "",
//                    xpub =
//                        "xpub6CkxdS1d4vNqqcnf9xPgqR5e2jE2PZKmKSw93QQMjHE1hRk22nU4zns85EDRgmLWYXYtu62XexwqaET33XA28c26NbXCAUJh1xmqq6B3S2v",
//                    seedPassphrase = "",
//                    type = "xpub",
//                    encrypt = false,
//                },
            };

            foreach (var tc in testCases)
            {
                var pass = "";
                if (tc.encrypt)
                {
                    pass = "pwd";
                }

                var createWalletTuple = Utils.CreateWallet(instance: Instance, type: tc.type, seed: tc.seed,
                    seedPassphase: tc.seedPassphrase, pass: pass, encrypt: tc.encrypt, xpub: tc.xpub);
                var wallet = createWalletTuple.Item1;
                var clean = createWalletTuple.Item3;
                var walletDir = Utils.GetWalletDir(Instance);

                // Confirms the wallet does exist
                var walletPath = walletDir + "/" + wallet.Meta.Id;

                if (!File.Exists(walletPath))
                {
                    Assert.Fail($"Wallet {walletPath} doesn't exist");
                }

                // Loads the wallet and confirms that the wallet has the same seed
                var wl = skycoin.skycoin.new_Wallet__HandlePtr();
                err = skycoin.skycoin.SKY_wallet_Load(walletPath, wl);
                Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                var entryLenGoUint32Ptr = skycoin.skycoin.new_GoUint32Ptr();
                err = skycoin.skycoin.SKY_api_Handle_GetWalletEntriesCount(wl, entryLenGoUint32Ptr);
                Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                Assert.AreEqual(wallet.Entries.Count, skycoin.skycoin.GoUint32Ptr_value(entryLenGoUint32Ptr), tc.name);
                var wlType = new _GoString_();
                err = skycoin.skycoin.SKY_wallet_Wallet_Type(wl, wlType);
                Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                Assert.AreEqual(wallet.Meta.Type, wlType.p, tc.name);

                if (tc.encrypt)
                {
                    var encryptCharPtr = skycoin.skycoin.new_CharPtr();
                    err = skycoin.skycoin.SKY_wallet_Wallet_IsEncrypted(wl, encryptCharPtr);
                    Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                    Assert.True(skycoin.skycoin.CharPtr_value(encryptCharPtr) == 1, tc.name);
                    var seedGoString = new _GoString_();
                    err = skycoin.skycoin.SKY_api_Handle_GetWalletSeed(wl, seedGoString);
                    Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                    Assert.IsEmpty(seedGoString.p);
                    //Assert.IsEmpty( lw.SeedPassphrase())
                }
                else
                {
                    var encryptCharPtr = skycoin.skycoin.new_CharPtr();
                    err = skycoin.skycoin.SKY_wallet_Wallet_IsEncrypted(wl, encryptCharPtr);
                    Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                    Assert.False(skycoin.skycoin.CharPtr_value(encryptCharPtr) == 1, tc.name);
                    var seedGoString = new _GoString_();
                    err = skycoin.skycoin.SKY_api_Handle_GetWalletSeed(wl, seedGoString);
                    Assert.AreEqual(skycoin.skycoin.SKY_OK, err, tc.name);
                    Assert.AreEqual(tc.seed, seedGoString.p, tc.name);
                    //Assert.AreEquals(tc.seedPassphrase, lw.SeedPassphrase())  
                }

                for (var i = 0; i < wallet.Entries.Count; i++)
                {
                    Assert.AreEqual(wallet.Entries[i].Address, Utils.GetAddressOfWalletEntries(i, wl), tc.name);
                    Assert.AreEqual(wallet.Entries[i].PublicKey, Utils.GetPubKeyOfWalletEntries(i, wl), tc.name);

                    if (tc.encrypt || tc.type.Equals("xpub"))
                    {
//                        require.True(t, lw.GetEntryAt(i).Secret.Null())
                    }
                    else
                    {
//                        require.False(t, lw.GetEntryAt(i).Secret.Null())
                    }

                    switch (tc.type)
                    {
                        case "bip44":
                            Assert.NotNull(wallet.Entries[i].ChildNumber, tc.name);
                            Assert.AreEqual(i, wallet.Entries[i].ChildNumber, tc.name);
                            Assert.NotNull(wallet.Entries[i].Change, tc.name);
//                            Assert.AreEqual(bip44.ExternalChainIndex, wallet.Entries[i].Change);
                            break;
                        case "xpub":
                            Assert.NotNull(wallet.Entries[i].ChildNumber, tc.name);
                            Assert.AreEqual(i, wallet.Entries[i].ChildNumber, tc.name);
                            Assert.Null(wallet.Entries[i].Change, tc.name);
                            break;
                        default:
                            Assert.AreEqual(0, wallet.Entries[i].ChildNumber, tc.name);
                            Assert.AreEqual(0, wallet.Entries[i].Change, tc.name);
                            break;
                    }
                }

                clean();
            }
        }

        /// <summary>
        /// Test WalletDecrypt.Ignore that Test.Error:Error getting response stram (ReadDone2): ReceiveFailure.
        /// </summary>
        [Test]
        public void WalletDecryptTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            var walletType = new[]
            {
                "deterministic",
                //  "bip44",
                // "xpub"
            };

            foreach (var wt in walletType)
            {
                var createWalletTuple = Utils.CreateWallet(instance: Instance, type: wt, pass: "pwd", encrypt: true);
                var seed = createWalletTuple.Item2;
                var wallet = createWalletTuple.Item1;
                var clean = createWalletTuple.Item3;
                // Decrypt wallet with different password, must fail
                var errApiExeption = Assert.Throws<ApiException>(() => Instance.WalletDecrypt(wallet.Meta.Id, "pwd1"));
                Assert.AreEqual(400, errApiExeption.ErrorCode);
                Assert.True(errApiExeption.Message.Contains("400 Bad Request - invalid password"));
                // Decrypt wallet with no password, must fail
                errApiExeption = Assert.Throws<ApiException>(() => Instance.WalletDecrypt(wallet.Meta.Id, ""));
                Assert.AreEqual(400, errApiExeption.ErrorCode);
                Assert.True(errApiExeption.Message.Contains("400 Bad Request - missing password"));
                //Decrypt wallet with correct password
                Assert.DoesNotThrow(() =>
                    {
                        var dw = Instance.WalletDecrypt(wallet.Meta.Id, "pwd");
                        Assert.IsEmpty(dw.Meta.CryptoType);
                        Assert.False(dw.Meta.Encrypted);

                        //Load wallet from file
                        var walletDir = Instance.WalletFolder().Address;
                        var walletPath = walletDir + "/" + wallet.Meta.Id;

                        if (!File.Exists(walletPath))
                        {
                            Assert.Fail($"Wallet {walletPath} doesn't exist");
                        }

                        var lw = skycoin.skycoin.new_Wallet__HandlePtr();
                        var err = skycoin.skycoin.SKY_wallet_Load(walletPath, lw);
                        Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                        var walletSeed = new _GoString_();
                        err = skycoin.skycoin.SKY_api_Handle_GetWalletSeed(lw, walletSeed);
                        Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                        Assert.AreEqual(seed, walletSeed.p);
                        var entriesCount = skycoin.skycoin.new_GoUint32Ptr();

                        err = skycoin.skycoin.SKY_api_Handle_GetWalletEntriesCount(lw, entriesCount);
                        Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                        var len = skycoin.skycoin.GoUint32Ptr_value(entriesCount);
                        Assert.AreEqual(1, len);

                        var lwLastSeed = new _GoString_();
                        switch (wt)
                        {
                            case "deterministic":
                                //Confirm the last seed matches
                                var seedSlice = new GoSlice();
                                seedSlice.convertString(walletSeed);

                                var lseedSlice = new GoSlice();
                                var seckeys = new cipher_SecKeys();
                                err = skycoin.skycoin.SKY_cipher_GenerateDeterministicKeyPairsSeed(seedSlice, 1,
                                    lseedSlice, seckeys);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                lwLastSeed = new _GoString_();
                                var lseed = new _GoString_();
                                err = skycoin.skycoin.SKY_api_Handle_GetWalletLastSeed(lw, lwLastSeed);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                skycoin.skycoin.SKY_base58_Hex2Base58(lseedSlice, lseed);
                                //lseed=hex.EncodeToString(lseedSlice)
//                                Assert.AreEqual(lseed.p, lwLastSeed.p);

                                //Confirm that the first address is derived from the private key
                                var cipherPubkey = new cipher_PubKey();
                                err = skycoin.skycoin.SKY_cipher_PubKeyFromSecKey(seckeys.getAt(0), cipherPubkey);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                var cipherAddress = new cipher__Address();
                                err = skycoin.skycoin.SKY_cipher_AddressFromPubKey(cipherPubkey, cipherAddress);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                var wAddrs = new _GoString_();
                                err = skycoin.skycoin.SKY_cipher_Address_String(cipherAddress, wAddrs);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                Assert.AreEqual(wallet.Entries[0].Address, wAddrs.p);
                                Assert.AreEqual(Utils.GetAddressOfWalletEntries(0, lw),
                                    wallet.Entries[0].Address);
//                                Assert.IsEmpty(lw.xpub());
                                break;
                            case "bip44":
                                err = skycoin.skycoin.SKY_api_Handle_GetWalletLastSeed(lw, lwLastSeed);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                Assert.IsEmpty(lwLastSeed.p);
//                                Assert.IsEmpty(lw.xpub());
                                break;
                            case "xpub":
                                var lwSeed = new _GoString_();
                                err = skycoin.skycoin.SKY_api_Handle_GetWalletSeed(lw, lwSeed);
                                Assert.IsEmpty(lwSeed.p);
                                err = skycoin.skycoin.SKY_api_Handle_GetWalletLastSeed(lw, lwLastSeed);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                Assert.IsEmpty(lwLastSeed.p);
                                //Assert.IsNotEmpty(lw.xpub());
                                break;
                            default:

                                Assert.Fail($"unhandled wallet type{wt}");
                                break;
                        }
                    }
                );

                clean();
            }
        }

        /// <summary>
        /// Test WalletEncrypt.Ignore that Test.Error:Error getting response stram (ReadDone2): ReceiveFailure.
        /// </summary>
        [Test]
        public void WalletEncryptTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            // Create a unencrypted wallet

            var walletTypes = new[]
            {
                "deterministic",
                //  "bip44",
                //    "xpub"
            };
            foreach (var wt in walletTypes)
            {
                var createWalletTuple = Utils.CreateWallet(instance: Instance, type: wt);
                var wallet = createWalletTuple.Item1;
                var clean = createWalletTuple.Item3;

                //Encrypt the wallet
                var rlt = Instance.WalletEncrypt(wallet.Meta.Id, "pwd");
                Assert.IsNotEmpty(rlt.Meta.CryptoType);
                Assert.True(rlt.Meta.Encrypted);

                //Encrypt the wallet again, should returns error

                var errApiException = Assert.Throws<ApiException>(() => Instance.WalletEncrypt(wallet.Meta.Id, "pwd"));
                Assert.AreEqual(400, errApiException.ErrorCode);
                Assert.True(errApiException.Message.Contains("400 Bad Request - wallet is encrypted"));

                //Confirm that no sensitive data do exist in wallet file
                var walletDir = Instance.WalletFolder().Address;
                var walletPath = walletDir + "/" + wallet.Meta.Id;

                if (!File.Exists(walletPath))
                {
                    Assert.Fail($"Wallet {walletPath} doesn't exist");
                }

                var lw = skycoin.skycoin.new_Wallet__HandlePtr();
                var err = skycoin.skycoin.SKY_wallet_Load(walletPath, lw);
                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                //loadWalletSeed
                var lwSeed = new _GoString_();
                err = skycoin.skycoin.SKY_api_Handle_GetWalletSeed(lw, lwSeed);
                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                Assert.IsEmpty(lwSeed.p);

                //loadWalletLastSeed
                var lwLastSeed = new _GoString_();
                err = skycoin.skycoin.SKY_api_Handle_GetWalletLastSeed(lw, lwLastSeed);
                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                Assert.IsEmpty(lwLastSeed.p);

//                //loadWalletSecrets
//                var lwLastSecrets = new _GoString_();
//                //I need get wallet.Secrets() for this test
//                skycoin.skycoin.SKY_api_Handle_GetWalletMeta(lw, lwLastSeed);
//                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
//                Assert.IsEmpty(lwLastSecrets.p);
                
                // Decrypts the wallet, and confirms that the seed and address
                // entries are the same as it was before being encrypted.
                var dw = Instance.WalletDecrypt(wallet.Meta.Id, "pwd");
                Assert.AreEqual(wallet,dw);
                
                clean();
            }
        }

        /// <summary>
        /// Test WalletFolder
        /// </summary>
        [Test]
        public void WalletFolderTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }


            Assert.DoesNotThrow(() =>
            {
                var folderName = Instance.WalletFolder();
                Assert.NotNull(folderName);
                Assert.IsNotEmpty(folderName.Address);
            });
        }

        /// <summary>
        /// Test WalletNewAddress
        /// </summary>
        [Test]
        public void WalletNewAddressTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            var seedStr = new _GoString_();
            var err = skycoin.skycoin.SKY_bip39_NewDefaultMnemomic(seedStr);
            Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
            var mainSeed = seedStr.p;
            var testCases = new[]
            {
                new
                {
                    name = "deterministic",
                    seed = mainSeed,
                    seedPassphrase = "",
                    walletType = "deterministic"
                },
                new
                {
                    name = "bip44 without seed passphrase",
                    seed = mainSeed,
                    seedPassphrase = "",
                    walletType = "bip44"
                },
                new
                {
                    name = "bip44 with seed passphrase",
                    seed = mainSeed,
                    seedPassphrase = "foobar",
                    walletType = "bip44"
                },
            };
            foreach (var tc in testCases)
            {
                for (var i = 1; i < 30; i++)
                {
                    var name = $"{tc.name} generate {i} addresses";
                    Assert.DoesNotThrow(() =>
                    {
                        var encrypt = false;
                        var pass = "";
                        if (i == 2)
                        {
                            encrypt = true;
                            pass = "pwd";
                        }

                        var cw = Utils.CreateWallet(instance: Instance, type: tc.walletType, seed: tc.seed,
                            seedPassphase: tc.seedPassphrase, pass: pass, encrypt: encrypt);
                        var w = cw.Item1;
                        var clean = cw.Item3;
                        dynamic addrs = Instance.WalletNewAddress(w.Meta.Id, i, pass);
                        switch (tc.walletType)
                        {
                            case "deterministic":
                                var seckeys = new cipher_SecKeys();
                                var seeds = new GoSlice();
                                seeds.convertString(seedStr);

                                err = skycoin.skycoin.SKY_cipher_GenerateDeterministicKeyPairs(seeds, i + 1,
                                    seckeys);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                List<string> As = new List<string>();
                                for (int j = 0; j < seckeys.count; j++)
                                {
                                    var cipherAddress = new cipher__Address();
                                    err = skycoin.skycoin.SKY_cipher_AddressFromSecKey(seckeys.getAt(j), cipherAddress);
                                    Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                    var address = new _GoString_();
                                    err = skycoin.skycoin.SKY_cipher_Address_String(cipherAddress, address);
                                    Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                    As.Add(address.p);
                                }

                                Assert.AreEqual(addrs.addresses.Count, As.Count - 1);
                                for (int j = 0; j < addrs.addresses.Count; j++)
                                {
                                    Assert.AreEqual(As[j + 1], addrs.addresses[j].ToString());
                                }

                                break;
                            case "bip44":
                                var ss = new GoSlice();
                                err = skycoin.skycoin.SKY_bip39_NewSeed(tc.seed, tc.seedPassphrase, ss);
                                Assert.AreEqual(skycoin.skycoin.SKY_OK, err);
                                //Require bip44NewCoin
                                break;
                            default:
                                Assert.Fail($"unhandled wallet type {tc.walletType}");
                                break;
                        }

                        clean();
                    });
                    break;
                }
            }
        }

        /// <summary>
        /// Test WalletNewSeed
        /// </summary>
        [Test]
        public void WalletNewSeedTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            var testCases = new[]
            {
                new
                {
                    name = "entropy 128",
                    entropy = "128",
                    cantwords = 12,
                    errCode = 200,
                    errMsg = ""
                },
                new
                {
                    name = "entropy 256",
                    entropy = "256",
                    cantwords = 24,
                    errCode = 200,
                    errMsg = ""
                },
                new
                {
                    name = "entropy 100",
                    entropy = "100",
                    cantwords = 12,
                    errCode = 400,
                    errMsg = "Error calling WalletNewSeed: 400 Bad Request - entropy length must be 128 or 256\n"
                }
            };

            foreach (var tc in testCases)
            {
                if (tc.errCode != 200)
                {
                    var err = Assert.Throws<ApiException>(() => Instance.WalletNewSeed(tc.entropy));
                    Assert.AreEqual(tc.errCode, err.ErrorCode, tc.name);
                    Assert.AreEqual(tc.errMsg, err.Message, tc.name);
                }
                else
                {
                    dynamic newseed = Instance.WalletNewSeed(tc.entropy);
                    Assert.True(newseed.seed.ToString().Split(' ').Length == tc.cantwords, tc.name);

                    // should generate a different seed each time
                    dynamic newseed2 = Instance.WalletNewSeed(tc.entropy);
                    Assert.AreNotEqual(newseed.seed.ToString(), newseed2.seed.ToString(), tc.name);
                }
            }
        }

        /// <summary>
        /// Test WalletRecover.Ignore that Test.Error:Error getting response stram (ReadDone2): ReceiveFailure.
        /// </summary>
        [Test]
        public void WalletRecoverTest()
        {
            if (!(Utils.GetTestMode().Equals("stable") || Utils.GetTestMode().Equals("live")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }
            
            // Create an encrypted wallet with some addresses pregenerated,
            // to make sure recover recovers the same number of addresses.
            
            
            

           
        }

        /// <summary>
        /// Test WalletSeed.Ignore that Test. Error:Error getting response stram (ReadDone2): ReceiveFailure.
        /// </summary>
        [Test]
        public void WalletSeedTest()
        {
            Assert.Ignore();
            var pass = "1234";
            if (!Instance.Wallets().Exists(wallet => wallet.Meta.Label.Equals("seed test.")))
            {
                var seed = Utils.GenString();
                if (Utils.UseCsrf())
                {
                    Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(Instance));
                }

                Instance.WalletCreate("deterministic", seed, "seed test.", encrypt: true, password: pass);
            }

            var walletseed = Instance.Wallets().Find(wallet => wallet.Meta.Label.Equals("seed test."));
            if (Utils.UseCsrf())
            {
                Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(Instance));
            }

            var err = Assert.Throws<ApiException>(() => Instance.WalletSeed(walletseed.Meta.Id, pass));
            Assert.AreEqual(403, err.ErrorCode);
            Assert.AreEqual("Error calling WalletSeed: 403 Forbidden - Endpoint is disabled\n", err.Message);
        }

        /// <summary>
        /// Test WalletSeedVerify
        /// </summary>
        [Test]
        public void WalletSeedVerifyTest()
        {
            if (Utils.UseCsrf())
            {
                Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(Instance));
            }

            //Test with correct seed
            var result =
                Instance.WalletSeedVerify(
                    "nut wife logic sample addict shop before tobacco crisp bleak lawsuit affair");
            Assert.NotNull(result);
            if (Utils.UseCsrf())
            {
                Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(Instance));
            }

            //test with incorrect seed
            Assert.Throws<ApiException>(() => Instance.WalletSeedVerify("nut"));
        }

        /// <summary>
        /// Test WalletUpdate
        /// </summary>
        [Test]
        public void WalletUpdateTest()
        {
            if (!(Utils.GetTestMode().Equals("live") || Utils.GetTestMode().Equals("stable")))
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            if (Utils.UseCsrf())
            {
                Instance.Configuration.AddApiKeyPrefix("X-CSRF-TOKEN", Utils.GetCsrf(Instance));
            }

            var testCases = new[]
            {
                "deterministic",
                "bip44",
                // "xpub"
            };
            foreach (var walletType in testCases)
            {
                var cw = Utils.CreateWallet(instance: Instance, type: walletType);
                var w = cw.Item1;
                var clean = cw.Item3;
                Assert.DoesNotThrow(() =>
                {
                    Instance.WalletUpdate(w.Meta.Id, "new wallet");
                    var w1 = Instance.Wallet(w.Meta.Id);
                    Assert.AreEqual(w1.Meta.Label, "new wallet");
                });
                clean();
            }
        }

        /// <summary>
        /// Test Wallets
        /// </summary>
        [Test]
        public void WalletsTest()
        {
            if (Utils.GetTestMode().Equals("live") && !Utils.DoLiveWallet())
            {
                return;
            }

            if (Utils.SkipWalletIfLive())
            {
                return;
            }

            var walletsType = new[]
            {
                "deterministic", "bip44", //"xpub"
            };
            //Creates 2 new wallets of each type
            var ws = new List<Wallet>();
            var cleanFunc = new List<Action>();
            for (int i = 0; i < 2; i++)
            {
                foreach (var wt in walletsType)
                {
                    var createWalletTuple = Utils.CreateWallet(instance: Instance, type: wt);
                    ws.Add(createWalletTuple.Item1);
                    cleanFunc.Add(createWalletTuple.Item3);
                }
            }

            //Get wallet from the node
            var wlts = Instance.Wallets();

            // Confirms the returned wallets contains the wallet we created.
            ws.ForEach(wc => { Assert.True(wlts.Exists(w => w.Equals(wc))); });

            //Clean created wallets
            foreach (var cln in cleanFunc)
            {
                cln();
            }
        }
    }
}