using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OddeToFood.Web.App_Start
{
    public class ContainerConfig
    {
        //internal static void RegisterContainer()
        //{
        //    var builder = new ContainerBuilder();

        //    //para que detecte todos los controladores el mvcapp es de el global.asax
        //    builder.RegisterControllers(typeof(MvcApplication).Assembly);
        //    builder.RegisterType<InMemoryRestaurantData>()
        //            .As<IRestaurantData>()
        //            .SingleInstance();
        //    var container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container) );
        //}

        //internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        //{
        //    var builder = new ContainerBuilder();

        //    //para que detecte todos los controladores el mvcapp es de el global.asax
        //    builder.RegisterControllers(typeof(MvcApplication).Assembly);
        //    builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
        //    builder.RegisterType<InMemoryRestaurantData>()
        //            .As<IRestaurantData>()
        //            .SingleInstance();
        //    var container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //    httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        //}


        /// <summary>
        /// PARA usar DB 
        /// </summary>
        /// <param name="httpConfiguration"></param>
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            //para que detecte todos los controladores el mvcapp es de el global.asax
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>()
                    .As<IRestaurantData>()
                    .InstancePerRequest();

            //se debe configurar EN  WEBCONFIG
            /*  <connectionStrings>
                    <add name="OdeToFoodDBContext" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=OdeToFoodMVC;Integrated Security=SSPI" providerName="System.Data.SqlClient" />
                </connectionStrings>    */
            builder.RegisterType<OdeToFoodDBContext>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}