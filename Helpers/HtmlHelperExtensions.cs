﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Orchard.Mvc.Html;
using Orchard.Services;

namespace IDeliverable.Bits.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string ApplyHtmlFilters(this HtmlHelper htmlHelper, string text, string flavor)
        {
            var workContext = htmlHelper.GetWorkContext();
            var filters = workContext.Resolve<IEnumerable<IHtmlFilter>>();
            return filters.Aggregate(text, (t, filter) => filter.ProcessContent(t, flavor));
        }
    }
}