/* 
 * Skycoin REST API.
 *
 * Skycoin is a next-generation cryptocurrency.
 *
 * The version of the OpenAPI document: 0.27.0
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
    /// BlockVerboseSchemaBody
    /// </summary>
    [DataContract]
    public partial class BlockVerboseSchemaBody :  IEquatable<BlockVerboseSchemaBody>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockVerboseSchemaBody" /> class.
        /// </summary>
        /// <param name="txns">txns.</param>
        public BlockVerboseSchemaBody(List<Object> txns = default(List<Object>))
        {
            this.Txns = txns;
        }
        
        /// <summary>
        /// Gets or Sets Txns
        /// </summary>
        [DataMember(Name="txns", EmitDefaultValue=false)]
        public List<Object> Txns { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlockVerboseSchemaBody {\n");
            sb.Append("  Txns: ").Append(Txns).Append("\n");
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
            return this.Equals(input as BlockVerboseSchemaBody);
        }

        /// <summary>
        /// Returns true if BlockVerboseSchemaBody instances are equal
        /// </summary>
        /// <param name="input">Instance of BlockVerboseSchemaBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BlockVerboseSchemaBody input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Txns == input.Txns ||
                    this.Txns != null &&
                    input.Txns != null &&
                    this.Txns.SequenceEqual(input.Txns)
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
                if (this.Txns != null)
                    hashCode = hashCode * 59 + this.Txns.GetHashCode();
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
