using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data.Repositories;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "OrderTest":
                    return new OrderManager(new OrderTestRepository());
                case "OrderActive":
                    return new OrderManager(new ProductionFlooringRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
