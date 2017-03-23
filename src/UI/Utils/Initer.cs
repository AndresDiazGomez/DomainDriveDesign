using Domain.Common;
using Domain.Management;
using Infrastructure.Data;
using System.Configuration;

namespace UI.Utils
{
    public static class Initer
    {
        public static void Init()
        {
            SessionFactory.Init(ConfigurationManager.ConnectionStrings["DDDInPractice"].ConnectionString);
            HeadOfficeInstance.Init(new HeadOfficeRepository());
            DomainEvents.Init();
        }
    }
}
