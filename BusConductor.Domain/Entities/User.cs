using System;
using System.Text.RegularExpressions;
using BusConductor.Domain.Common;
using BusConductor.Domain.ParameterSets;

namespace BusConductor.Domain.Entities
{
    public class User : Entity<Guid> //n,
    {
        private string _username;
        private Guid _roleId;
        private Role _role;
        private string _forename;
        private string _surname;
        private string _addressLine1;
        private string _addressLine2;
        private string _addressLine3;
        private string _town;
        private string _county;
        private string _postCode;
        private string _email;
        private string _telephoneNumber;

        public virtual string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public virtual Guid RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public virtual Role Role
        {
            get { return _role; }
            set { _role = value; }
        }

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

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public virtual string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

        public virtual string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }

        public virtual string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }

        public virtual string AddressLine3
        {
            get { return _addressLine3; }
            set { _addressLine3 = value; }
        }

        public virtual string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        public virtual string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public virtual string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        public static User Create(string username, Role role, User currentUser)
        {
            var user = new User();
            user._id = Guid.NewGuid();
            user._username = username;
            user._role = role;
            user._createdOn = DateTime.Now;
            user.CreatedById = currentUser.Id.Value; //todo: is this really right?
            user._createdBy = currentUser;
            user._deleted = false;
            return user;
        }

        public static ValidationMessageCollection ValidateCreateGuest(CreateGuestUserParameterSet parameterSet)
        {
            var validationMessages = new ValidationMessageCollection();

            if (string.IsNullOrEmpty(parameterSet.Forename))
            {
                validationMessages.AddError("Forename", "Forename is required.");
            }
            else
            {
                if (parameterSet.Forename.Length > 50) validationMessages.AddError("Forename", "Forename must be 50 characters or less.");
            }

            if (string.IsNullOrEmpty(parameterSet.Forename))
            {
                validationMessages.AddError("Surname", "Surname is required.");
            }
            else
            {
                if (parameterSet.Surname.Length > 50) validationMessages.AddError("Surname", "Surname must be 50 characters or less.");
            }

            if (string.IsNullOrEmpty(parameterSet.AddressLine1))
            {
                validationMessages.AddError("AddressLine1", "Address line 1 is required.");
            }
            else
            {
                if (parameterSet.AddressLine1.Length > 50) validationMessages.AddError("AddressLine1", "Address line 1 must be 50 characters or less.");
            }

            if (parameterSet.AddressLine2 != null && parameterSet.AddressLine2.Length > 50) validationMessages.AddError("AddressLine2", "Address line 2 must be 50 characters or less.");
            if (parameterSet.AddressLine3 != null && parameterSet.AddressLine3.Length > 50) validationMessages.AddError("AddressLine3", "Address line 3 must be 50 characters or less.");
            
            if (string.IsNullOrEmpty(parameterSet.Town))
            {
                validationMessages.AddError("Town", "Town is required.");
            }
            else
            {
                if (parameterSet.Town.Length > 50) validationMessages.AddError("Town", "Town must be 50 characters or less.");
            }

            if (parameterSet.County != null && parameterSet.County.Length > 50) validationMessages.AddError("County", "County must be 50 characters or less.");

            var rxPostCode =
                new Regex(
                    @"^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$");

            if (string.IsNullOrEmpty(parameterSet.PostCode))
            {
                validationMessages.AddError("PostCode", "Post code is required.");
            }
            else
            {
                if (!rxPostCode.IsMatch(parameterSet.PostCode)) validationMessages.AddError("PostCode", "Post code is not valid.");
            }

            if (string.IsNullOrEmpty(parameterSet.Email))
            {
                validationMessages.AddError("Email", "Email is required.");
            }
            else if (parameterSet.Email.Length > 50)
            {
                validationMessages.AddError("Email", "Email must be 50 characters or less.");
            }
            else
            {
                var rxNonStrictEmail = new Regex(@"[A-Za-z0-9\.-_\+]+@[A-Za-z0-9\.-_\+]+");
                if (!rxNonStrictEmail.IsMatch(parameterSet.Email)) validationMessages.AddError("Email", "Email is not valid.");
            }

            if (string.IsNullOrEmpty(parameterSet.TelephoneNumber))
            {
                validationMessages.AddError("TelephoneNumber", "Telephone number is required.");
            }
            else
            {
                if (parameterSet.TelephoneNumber.Length > 50) validationMessages.AddError("TelephoneNumber", "Telephone number must be 50 characters or less.");
            }

            return validationMessages;
        }

        public static User CreateGuest(CreateGuestUserParameterSet parameterSet)
        {
            var user = new User();
            user._id = Guid.NewGuid();
            user._username = String.Format("Guest{0}", user.Id.ToString().Replace("-", ""));
            user._role = parameterSet.GuestRole;
            user._forename = parameterSet.Forename;
            user._surname = parameterSet.Surname;
            user._addressLine1 = parameterSet.AddressLine1;
            user._addressLine2 = parameterSet.AddressLine2;
            user._addressLine3 = parameterSet.AddressLine3;
            user._town = parameterSet.Town;
            user._county = parameterSet.County;
            user._postCode = parameterSet.PostCode;
            user._email = parameterSet.Email;
            user._telephoneNumber = parameterSet.TelephoneNumber;
            user._createdOn = DateTime.Now;
            user._createdById = parameterSet.CurrentUser.Id.Value; //todo: is this really right?
            user._createdBy = parameterSet.CurrentUser;
            user._deleted = false;
            return user;
        }
    }
}
