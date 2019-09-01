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
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Skyapi.Client.OpenAPIDateConverter;

namespace Skyapi.Model
{
    /// <summary>
    /// Transaction
    /// </summary>
    [DataContract]
    public partial class Transaction : IEquatable<Transaction>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction" /> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="txn">txn.</param>
        /// <param name="time">time.</param>
        ///     /// <param name="encodedTransaction">encodedTransaction.</param>
        public Transaction(TransactionStatus status = default(TransactionStatus),
            TransactionTxn txn = default(TransactionTxn), long? time = default(long?),
            string encodedTransaction = default(string))
        {
            this.Status = status;
            this.Txn = txn;
            this.Time = time;
            this.EncodedTransaction = encodedTransaction;
        }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Txn
        /// </summary>
        [DataMember(Name = "txn", EmitDefaultValue = false)]
        public TransactionTxn Txn { get; set; }

        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public long? Time { get; set; }

        /// <summary>
        /// Gets or Sets EncodedTransaction
        /// </summary>
        [DataMember(Name = "encoded_transaction", EmitDefaultValue = false)]
        public string EncodedTransaction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Transaction {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Txn: ").Append(Txn).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  EncodedTransaction: ").Append(EncodedTransaction).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Transaction);
        }

        /// <summary>
        /// Returns true if Transaction instances are equal
        /// </summary>
        /// <param name="input">Instance of Transaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Transaction input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                     this.Status.Equals(input.Status))
                ) &&
                (
                    this.Txn == input.Txn ||
                    (this.Txn != null &&
                     this.Txn.Equals(input.Txn))
                ) &&
                (
                    this.Time == input.Time ||
                    (this.Time != null &&
                     this.Time.Equals(input.Time))
                ) && (
                    this.EncodedTransaction == input.EncodedTransaction ||
                    (this.EncodedTransaction != null &&
                     this.EncodedTransaction.Equals(input.EncodedTransaction)));
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Txn != null)
                    hashCode = hashCode * 59 + this.Txn.GetHashCode();
                if (this.Time != null)
                    hashCode = hashCode * 59 + this.Time.GetHashCode();
                if (this.EncodedTransaction != null)
                    hashCode = hashCode * 59 + this.EncodedTransaction.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(
            ValidationContext validationContext)
        {
            yield break;
        }
    }
}