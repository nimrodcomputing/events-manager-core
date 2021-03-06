﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EventsManager.Models.Records.Base
{
    public  class Record : IValidatableObject
    {
        // by default, properties have an order of -1
        // this is the belt and braces way of making sure the id is generated first
        [JsonProperty("id", Order = -99)]
        public Guid Id { get; set; }

        #region Implementation of IValidatableObject

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new ValidationResult[0];
        }

        #endregion

    }
}
