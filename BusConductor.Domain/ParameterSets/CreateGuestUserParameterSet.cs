using BusConductor.Domain.Entities;

namespace BusConductor.Domain.ParameterSets
{
    public class CreateGuestUserParameterSet
    {
        public Role GuestRole { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public User CurrentUser { get; set; }

        public static CreateGuestUserParameterSet MapFrom(MakePendingBookingParameterSet makePendingBookingParameterSet)
        {
            var createGuestUserParameterSet = new CreateGuestUserParameterSet();
            createGuestUserParameterSet.GuestRole = makePendingBookingParameterSet.GuestRole;
            createGuestUserParameterSet.Forename = makePendingBookingParameterSet.Forename;
            createGuestUserParameterSet.Surname = makePendingBookingParameterSet.Surname;
            createGuestUserParameterSet.AddressLine1 = makePendingBookingParameterSet.AddressLine1;
            createGuestUserParameterSet.AddressLine2 = makePendingBookingParameterSet.AddressLine2;
            createGuestUserParameterSet.AddressLine3 = makePendingBookingParameterSet.AddressLine3;
            createGuestUserParameterSet.Town = makePendingBookingParameterSet.Town;
            createGuestUserParameterSet.County = makePendingBookingParameterSet.County;
            createGuestUserParameterSet.PostCode = makePendingBookingParameterSet.PostCode;
            createGuestUserParameterSet.Email = makePendingBookingParameterSet.Email;
            createGuestUserParameterSet.TelephoneNumber = makePendingBookingParameterSet.TelephoneNumber;
            createGuestUserParameterSet.CurrentUser = makePendingBookingParameterSet.CurrentUser;
            return createGuestUserParameterSet;
        }
    }
}
