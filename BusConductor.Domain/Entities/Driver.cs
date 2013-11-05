using System;
using System.Linq;
using BusConductor.Domain.Common;
using BusConductor.Domain.ParameterSets;

namespace BusConductor.Domain.Entities
{
    public class Driver : Entity<Guid>
    {
        private string _forename;
        private string _surname;
        private string _drivingLicenceNumber;
        //todo: get minimum age for driver
        private DateTime _dateOfBirth;
        private Booking _booking;
        private bool _isMainDriver;

        public virtual string Forename
        {
            get { return _forename; }
            set { _forename = value; }
        }

        public virtual string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public virtual string DrivingLicenceNumber
        {
            get { return _drivingLicenceNumber; }
            set { _drivingLicenceNumber = value; }
        }

        public virtual DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public virtual Booking Booking
        {
            get { return _booking; }
            set { _booking = value; }
        }

        public virtual bool IsMainDriver
        {
            get { return _isMainDriver; }
            set { _isMainDriver = value; }
        }

        public static ValidationMessageCollection ValidateCreate(CreateDriverParameterSet parameterSet)
        {
            var validationMessages = new ValidationMessageCollection();

            if(string.IsNullOrEmpty(parameterSet.Forename))
            {
                validationMessages.AddError("Forename", "Forename is required.");
            }

            if (string.IsNullOrEmpty(parameterSet.Surname))
            {
                validationMessages.AddError("Surname", "Surname is required.");
            }

            if (string.IsNullOrEmpty(parameterSet.DrivingLicenceNumber))
            {
                validationMessages.AddError("DrivingLicenceNumber", "Driving licence number is required.");
            }

            if (!parameterSet.DateOfBirth.HasValue)
            {
                validationMessages.AddError("DateOfBirth", "Date of birth is required.");
            }

            if (parameterSet.DateOfBirth.HasValue && parameterSet.DateOfBirth.Value == default(DateTime))
            {
                validationMessages.AddError("DateOfBirth", "Date of birth is not valid.");
            }

            if (parameterSet.DateOfBirth.HasValue && parameterSet.DateOfBirth.Value.AddYears(25) > DateTime.Today)
            {
                validationMessages.AddError("DateOfBirth", "Driver must be 25 or over.");
            }

            if (parameterSet.Booking == null)
            {
                validationMessages.AddError("Booking", "Driver must refer to a booking.");
            }

            return validationMessages;
        }

        public static Driver Create(CreateDriverParameterSet parameterSet)
        {
            var validationMessages = ValidateCreate(parameterSet);
            if (validationMessages.Any()) throw new ValidationException(validationMessages);
            var driver = new Driver();
            driver._id = parameterSet.Id;
            driver._forename = parameterSet.Forename;
            driver._surname = parameterSet.Surname;
            driver._drivingLicenceNumber = parameterSet.DrivingLicenceNumber;
            driver._dateOfBirth = parameterSet.DateOfBirth.Value;   //Must be set, or will have been caught by exception.
            driver._booking = parameterSet.Booking;
            driver._isMainDriver = parameterSet.IsMainDriver;
            driver._createdBy = parameterSet.ApplicationUser;
            driver._createdOn = DateTime.Now;
            driver._deleted = false;
            return driver;
        }
    }
}
