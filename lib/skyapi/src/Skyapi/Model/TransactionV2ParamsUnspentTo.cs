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
    /// TransactionV2ParamsUnspentTo
    /// </summary>
    [DataContract]
    public partial class TransactionV2ParamsUnspentTo :  IEquatable<TransactionV2ParamsUnspentTo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionV2ParamsUnspentTo" /> class.
        /// </summary>
        /// <param name="address">address.</param>
        /// <param name="coins">coins.</param>
        public TransactionV2ParamsUnspentTo(string address = default(string), string coins = default(string))
        {
            this.Address = address;
            this.Coins = coins;
        }
        
        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Coins
        /// </summary>
        [DataMember(Name="coins", EmitDefaultValue=false)]
        public string Coins { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionV2ParamsUnspentTo {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Coins: ").Append(Coins).Append("\n");
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
            return this.Equals(input as TransactionV2ParamsUnspentTo);
        }

        /// <summary>
        /// Returns true if TransactionV2ParamsUnspentTo instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionV2ParamsUnspentTo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionV2ParamsUnspentTo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Coins == input.Coins ||
                    (this.Coins != null &&
                    this.Coins.Equals(input.Coins))
                );
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
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Coins != null)
                    hashCode = hashCode * 59 + this.Coins.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
