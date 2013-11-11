using BusConductor.Application.Requests.Booking;
using BusConductor.Domain.ParameterSets;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Application.ParameterSetMappers.Booking
{
    public class MakePendingParameterSetMapper : IMakePendingParameterSetMapper
    {
        private readonly IBusRepository _busRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IVoucherRepository _voucherRepository;

        public MakePendingParameterSetMapper(
            IBusRepository busRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IVoucherRepository voucherRepository)
        {
            _busRepository = busRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _voucherRepository = voucherRepository;
        }

        public MakePendingBookingParameterSet Map(MakePendingRequest request)
        {
            //todo: replace this with tool that copies similar parameters?
            var parameterSet = new MakePendingBookingParameterSet();
            parameterSet.PickUp = request.PickUp;
            parameterSet.DropOff = request.DropOff;
            parameterSet.Forename = request.Forename;
            parameterSet.Surname = request.Surname;
            parameterSet.AddressLine1 = request.AddressLine1;
            parameterSet.AddressLine2 = request.AddressLine2;
            parameterSet.AddressLine3 = request.AddressLine3;
            parameterSet.TelephoneNumber = request.Town;
            parameterSet.County = request.County;
            parameterSet.PostCode = request.PostCode;
            parameterSet.Email = request.Email;
            parameterSet.TelephoneNumber = request.TelephoneNumber;
            parameterSet.Town = request.Town;
            parameterSet.IsMainDriver = request.IsMainDriver;
            parameterSet.DrivingLicenceNumber = request.DrivingLicenceNumber;
            parameterSet.DriverForename = request.DriverForename;
            parameterSet.DriverSurname = request.DriverSurname;
            parameterSet.NumberOfAdults = request.NumberOfAdults;
            parameterSet.NumberOfChildren = request.NumberOfChildren;
            parameterSet.VoucherCode = request.VoucherCode;
            parameterSet.Bus = _busRepository.GetById(request.BusId);
            parameterSet.Voucher = !string.IsNullOrEmpty(request.VoucherCode) ? _voucherRepository.GetByCode(request.VoucherCode) : null;
            parameterSet.CurrentUser = _userRepository.GetByUsername("Application");
            parameterSet.GuestRole = _roleRepository.GetByName("Guest");
            return parameterSet;
        }
    }
}
