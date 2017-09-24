[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CoffeeShop.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CoffeeShop.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace CoffeeShop.WebUI.App_Start
{
    using Logic.Coffee;
    using Logic.Coffee.Abstract;
    using Logic.Coffee.CoffeeTypes;
    using Logic.Coffee.CoffeeTypes.Factory;
    using Logic.Coffee.CoffeeTypes.PlovdivStoreSpecialTypes;
    using Logic.Coffee.CoffeeTypes.SofiaStoreSpecialTypes;
    using Logic.Coffee.Condimets;
    using Logic.Coffee.CondimetsDecorators.Factory;
    using Logic.Menu;
    using Logic.Menu.Abstract;
    using Logic.Stores;
    using Logic.Stores.Abstract;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Web.Common;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x => x
             .FromAssemblyContaining<ICoffee>()
             .SelectAllClasses()
             .BindAllInterfaces());

            kernel.Bind(x => x
            .FromAssemblyContaining<ICoffee>()
            .SelectAllInterfaces()
            .EndingWith("Factory")
            .BindToFactory());

            //kernel.Bind(x => x
            //.FromAssemblyContaining<IStore>()
            //.SelectAllClasses()
            //.InheritedFrom<IStore>()
            //.BindAllInterfaces()
            //.Configure((b, comp) => b.Named(comp.Name)));

            kernel.Bind<ICoffee>().To<Americano>().NamedLikeFactoryMethod((ICoffeeTypeFactory f) => f.GetAmericano(default(CoffeSizeType)));
            kernel.Bind<ICoffee>().To<Capuccino>().NamedLikeFactoryMethod((ICoffeeTypeFactory f) => f.GetCappucino(default(CoffeSizeType)));
            kernel.Bind<ICoffee>().To<Espresso>().NamedLikeFactoryMethod((ICoffeeTypeFactory f) => f.GetEspresso(default(CoffeSizeType)));
            kernel.Bind<ICoffee>().To<Latte>().NamedLikeFactoryMethod((ICoffeeTypeFactory f) => f.GetLatte(default(CoffeSizeType)));
            kernel.Bind<ICoffee>().To<Ristretto>().NamedLikeFactoryMethod((IPlovdivStoreCoffeeTypeFactory f) => f.GetRistretto(default(CoffeSizeType)));
            kernel.Bind<ICoffee>().To<Doppio>().NamedLikeFactoryMethod((ISofiaStoreCoffeeTypeFactory f) => f.GetDoppio(default(CoffeSizeType)));

            kernel.Bind<ICoffee>().To<Caramel>().NamedLikeFactoryMethod((ICondimentsFactory f) => f.GetCaramel(default(ICoffee)));
            kernel.Bind<ICoffee>().To<Chocolate>().NamedLikeFactoryMethod((ICondimentsFactory f) => f.GetChocolate(default(ICoffee)));
            kernel.Bind<ICoffee>().To<Cinnamon>().NamedLikeFactoryMethod((ICondimentsFactory f) => f.GetCinnamon(default(ICoffee)));
            kernel.Bind<ICoffee>().To<Milk>().NamedLikeFactoryMethod((ICondimentsFactory f) => f.GetMilk(default(ICoffee)));
            kernel.Bind<ICoffee>().To<WhippedCream>().NamedLikeFactoryMethod((ICondimentsFactory f) => f.GetWhippedCream(default(ICoffee)));

            var sofiaStoreStrategies = new Dictionary<string, Func<CoffeSizeType, ICoffee>>
            {
                { "Americano", kernel.Get<ICoffeeTypeFactory>().GetAmericano },
                { "Capuccino", kernel.Get<ICoffeeTypeFactory>().GetCappucino },
                { "Espresso", kernel.Get<ICoffeeTypeFactory>().GetEspresso },
                { "Latte", kernel.Get<ICoffeeTypeFactory>().GetLatte },
                { "Doppio", kernel.Get<ISofiaStoreCoffeeTypeFactory>().GetDoppio },
            };

            var plovdivStoreStrategies = new Dictionary<string, Func<CoffeSizeType, ICoffee>>
            {
                { "Americano", kernel.Get<ICoffeeTypeFactory>().GetAmericano },
                { "Capuccino", kernel.Get<ICoffeeTypeFactory>().GetCappucino },
                { "Espresso", kernel.Get<ICoffeeTypeFactory>().GetEspresso },
                { "Latte", kernel.Get<ICoffeeTypeFactory>().GetLatte },
                { "Ristretto", kernel.Get<IPlovdivStoreCoffeeTypeFactory>().GetRistretto },
            };

            var condimentsStrategies = new Dictionary<string, Func<ICoffee, ICoffee>>
            {
                { "Milk", kernel.Get<ICondimentsFactory>().GetMilk },
                { "Caramel", kernel.Get<ICondimentsFactory>().GetCaramel },
                { "Chocolate", kernel.Get<ICondimentsFactory>().GetChocolate },
                { "Cinnamon", kernel.Get<ICondimentsFactory>().GetCinnamon },
                { "Whipped cream", kernel.Get<ICondimentsFactory>().GetWhippedCream },
            };


            kernel.Bind<IDictionary<string, Func<CoffeSizeType, ICoffee>>>().ToConstant(sofiaStoreStrategies)
                .WhenInjectedInto<SofiaCoffeeStore>();
            kernel.Bind<IDictionary<string, Func<CoffeSizeType, ICoffee>>>().ToConstant(plovdivStoreStrategies)
                .WhenInjectedInto<PlovdivCoffeeStore>();
            kernel.Bind<IDictionary<string, Func<ICoffee, ICoffee>>>().ToConstant(condimentsStrategies)
                    .WhenInjectedInto<CoffeeStore>();

            kernel.Bind<ICoffeeStore>().To<SofiaCoffeeStore>()
                .When(x => HttpContext.Current.Request.QueryString["city"].Contains("Sofia")).InSingletonScope();
            kernel.Bind<IMenuProvider>().To<SofiaMenuProvider>()
    .When(x => HttpContext.Current.Request.QueryString["city"].Contains("Sofia")).InSingletonScope();

            kernel.Bind<ICoffeeStore>().To<PlovdivCoffeeStore>()
                .When(x => HttpContext.Current.Request.QueryString["city"].Contains("Plovdiv")).InSingletonScope();
            kernel.Bind<IMenuProvider>().To<PlovdivMenuProvider>()
     .When(x => HttpContext.Current.Request.QueryString["city"].Contains("Plovdiv")).InSingletonScope();

        }
    }
}
