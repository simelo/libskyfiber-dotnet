﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Skyapi.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class BalancePair : IEquatable<BalancePair>, IValidatableObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="confirmed"></param>
        /// <param name="predicted"></param>
        public BalancePair(BalanceConfirm confirmed = default(BalanceConfirm),
            BalancePredict predicted = default(BalancePredict))
        {
            Confirmed = confirmed;
            Predicted = predicted;
        }

        /// <summary>
        /// Gets or Sets Confirmed
        /// </summary>
        [DataMember(Name = "confirmed", EmitDefaultValue = true)]
        public BalanceConfirm Confirmed { get; set; }

        /// <summary>
        /// Gets or Sets Predicted
        /// </summary>
        [DataMember(Name = "predicted", EmitDefaultValue = true)]
        public BalancePredict Predicted { get; set; }


        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BalancePair {\n");
            sb.Append("  confirmed: ").Append(Confirmed).Append("\n");
            sb.Append("  predicted: ").Append(Predicted).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as BalancePair);
        }

        /// <summary>
        /// Returns true if BalancePair instances are equal
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool Equals(BalancePair input)
        {
            if (input == null)
            {
                return false;
            }

            return Confirmed != null && Confirmed.Equals(input.Confirmed) &&
                   (Predicted.Equals(input.Predicted) || Predicted != null);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (Confirmed != null)
                    hashCode = hashCode * 59 + Confirmed.GetHashCode();
                if (Predicted != null)
                    hashCode = hashCode * 59 + Predicted.GetHashCode();
                return hashCode;
            }
        }


        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}