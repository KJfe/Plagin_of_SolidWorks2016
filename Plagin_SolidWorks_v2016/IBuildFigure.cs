using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;

namespace Plagin_SolidWorks_v2016
{
    interface IBuildFigure
    {
        IModelDoc2 Build
        {
            get;
        }
        /*IModelDoc2 ModelDoc2
        {
            get;
        }*/
    }
}
