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
    class NewFileSW:IBuildFigure
    {
        private SldWorks _SwApp;
        private IModelDoc2 _swModel;

        public NewFileSW(SldWorks SwApp, IModelDoc2 swModel)
        {
            _SwApp = SwApp;
            _swModel = swModel;
        }

        public IModelDoc2 Build
        {
            get
            {
                _SwApp.NewPart();//создание нового файла в solidworks

                _swModel = _SwApp.IActiveDoc2;

                ModelDoc2 swDoc = null;
                swDoc = (ModelDoc2)_SwApp.ActiveDoc;
                return _swModel;
            }
            
        }

        /*public IModelDoc2 FileSW()
        {
            _SwApp.NewPart();//создание нового файла в solidworks

            _swModel = _SwApp.IActiveDoc2;

            ModelDoc2 swDoc = null;
            swDoc = (ModelDoc2)_SwApp.ActiveDoc;
            return _swModel;
        }*/
    }
}
