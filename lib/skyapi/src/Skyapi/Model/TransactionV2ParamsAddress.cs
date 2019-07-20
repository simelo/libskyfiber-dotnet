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
    /// TransactionV2ParamsAddress
    /// </summary>
    [DataContract]
    public partial class TransactionV2ParamsAddress :  IEquatable<TransactionV2ParamsAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionV2ParamsAddress" /> class.
        /// </summary>
        /// <param name="hoursSelection">hoursSelection.</param>
        public TransactionV2ParamsAddress(TransactionV2ParamsAddressHoursSelection hoursSelection = default(TransactionV2ParamsAddressHoursSelection))
        {
            this.HoursSelection = hoursSelection;
        }
        
        /// <summary>
        /// Gets or Sets HoursSelection
        /// </summary>
        [DataMember(Name="hours_selection", EmitDefaultValue=false)]
        public TransactionV2ParamsAddressHoursSelection HoursSelection { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionV2ParamsAddress {\n");
            sb.Append("  HoursSelection: ").Append(HoursSelection).Append("\n");
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
            return this.Equals(input as TransactionV2ParamsAddress);
        }

        /// <summary>
        /// Returns true if TransactionV2ParamsAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionV2ParamsAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionV2ParamsAddress input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.HoursSelection == input.HoursSelection ||
                    (this.HoursSelection != null &&
                    this.HoursSelection.Equals(input.HoursSelection))
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
                if (this.HoursSelection != null)
                    hashCode = hashCode * 59 + this.HoursSelection.GetHashCode();
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