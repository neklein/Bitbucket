using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulePrototype.Models
{
    public class PullBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var pull = new PullDetails();

            pull.Promoter = request.Form["Promoter"];
            pull.Track = request.Form["Track"];

            int month = int.Parse(request.Form["month"]);
            int day = int.Parse(request.Form["day"]);
            int year = int.Parse(request.Form["year"]);

            pull.ScheduledDate = new DateTime(year, month, day);

            return pull;
        }
    }
}