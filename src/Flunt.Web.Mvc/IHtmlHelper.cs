using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Flunt.Web.Mvc
{
    public interface IHtmlHelper
    {
        dynamic ViewBag { get; }

        ViewContext ViewContext { get; }
    }
}
