using Domain.Repository;

namespace Domain.Management
{
    public static class HeadOfficeInstance
    {
        private const long HeadOfficeId = 1;
        private static IHeadOfficeRepository _headOfficeRepository;

        public static HeadOffice Instance { get; private set; }

        public static void Save()
        {
            _headOfficeRepository.Save(Instance);
        }

        public static void Init(IHeadOfficeRepository repository)
        {
            _headOfficeRepository = repository;
            Instance = _headOfficeRepository.GetById(HeadOfficeId);
        }
    }
}
