using Microsoft.Practices.Unity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL
{
    //static because we only need 1 container
    public static class DIContainer
    {
        //the kernel is the master factory
        public static UnityContainer Container = new UnityContainer();

        static DIContainer()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"].ToString();

            //Tell ninject that IChoiceGetter should resolve to RnadomChoice
            if (chooserType == "Random")
            {
                InjectionMethod injectionMethod = new InjectionMethod("ChoiceBehavior", new RandomChoice());

                Container.RegisterType<GameManager3>(injectionMethod);
            }
            else if (chooserType == "PrefersRock")
            {
                InjectionMethod injectionMethod = new InjectionMethod("ChoiceBehavior", new PrefersRockChoice());

                Container.RegisterType<GameManager2>(injectionMethod);
            }
                
            else
                throw new Exception("Chooser key in app.config not set properly!");
        }
    }
}
