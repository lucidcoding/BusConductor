using NHibernate;

namespace BusConductor.Data.Common
{
    //todo: work out a way to test views so we can check urls.
    //todo: spinners?
    //todo: duplicate required, format and any simple validation into the annotations.
    //todo: move regular expressions into a library.

    //todo: validation:
    //1 a clever thing where it only subits the date if it can but valdidates everything else
    //2 can't lose focus of date if not valid format - then all in domain?
    //3 submit date as a string in request
    //4 don't allow manual editing of date.

    //todo: work out about email confirmation too. 
    //1 submit both to domain?
    //2 do clever thing in IValidatable

    //todo: booking: inherit from this? have overnight and day booking?
    //todo: booking: maybe pass the construction into a factory that takes the role repository as a domain? This is how we were going to handle this!

    //Doing confirm email validation in UI, rest in domain - straightforwqard because nothing in domain requires confirm email. would be different for date?
    //Mapping of request to parameters in application layer is done in a method in service implementation - easy to test because not passing around repositories etc, but is is SRP?

    //todo: popup calendars sun-sat, but main calendar mon-sun.
    //todo: month missing from main calendar.
    //todo: elmah
    //todo: eliminate setters from domain.
    //todo: unit tests on data layer?

    //todo: Migrate to EF http://blogs.msdn.com/b/wriju/archive/2013/08/23/using-repository-pattern-in-entity-framework.aspx
    //don't forget: Database.SetInitializer<Context>(null);

    public static class SessionFactoryFactory
    {
        public static ISessionFactory GetSessionFactory()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(SessionFactoryFactory).Assembly.GetName().Name);
            log4net.Config.XmlConfigurator.Configure();
            var sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }
    }
}
