using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventsManager.Models.Enums;
using EventsManager.Models.Records.Base;

namespace EventsManager.Models.Records
{
    public class EventRecord : Record
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public string Abstract { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        
        public PublicationStatus PublicationStatus { get; set; }

        #region Implementation of IValidatableObject

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate!= null && EndDate != null && StartDate > EndDate)
            {
                yield return new ValidationResult("Start Date must not be earlier than End Data",
                    new string [] {/*nameof(StartDate), nameof(EndDate)*/});
            }
        }

        #endregion

    }

}
