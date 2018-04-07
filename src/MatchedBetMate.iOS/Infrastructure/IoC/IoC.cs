using System;
using System.Collections.Generic;
using MatchedBetMate.iOS.Business.Factory;
using MatchedBetMate.iOS.Business.Interfaces.Clients;
using MatchedBetMate.iOS.Business.Interfaces.Factory;
using MatchedBetMate.iOS.Business.Interfaces.Providers;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Business.Interfaces.Strategy;
using MatchedBetMate.iOS.Business.Services;
using MatchedBetMate.iOS.Business.Strategy;
using MatchedBetMate.iOS.Infrastructure.Clients;
using MatchedBetMate.iOS.Infrastructure.Providers;
using MatchedBetMate.iOS.Infrastructure.SecureStorage;
using TinyIoC;

namespace MatchedBetMate.iOS.Infrastructure.IoC
{
    public static class IoC
    {
        public static TinyIoCContainer Container { get; private set; }
        public static void Initialise()
        {
            Container = TinyIoCContainer.Current;
            var container = Container;

            container.Register<IHttpClient, HttpClient>();
            container.Register<IWebApiConfigurationProvider, WebApiConfigurationProvider>();
            
            RegisterServices(container);
            RegisterFactories(container);
            RegisterStrategies(container);
        }

        private static void RegisterServices(TinyIoCContainer container)
        {
            container.Register<ICredentialsService, CredentialsService>();
            container.Register<IAuthenticationService, AuthenticationService>();
            container.Register<IBetCalculationService, BetCalculationService>();
            container.Register<IBetService, BetService>();
        }

        private static void RegisterFactories(TinyIoCContainer container)
        {
            container.Register<IBetCalcaulatorStrategyFactory, BetCalculatorStrategyFactory>();
        }

        private static void RegisterStrategies(TinyIoCContainer container)
        {
            container.RegisterMultiple(typeof(IBetCalculatorStrategy), new List<Type>
            {
                typeof(NormalBetCalculatorStrategy),
                typeof(FreeBetSnrCalculatorStrategy),
                typeof(FreeBetSrCalculatorStrategy)
            });
        }
    }
}