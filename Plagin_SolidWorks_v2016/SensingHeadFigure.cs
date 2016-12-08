using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;


using ParametrFigure;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace Plagin_SolidWorks_v2016
{
    class SensingHeadFigure
    {
        private SldWorks _SwApp;

        public SensingHeadFigure(SldWorks SwApp)
        {
            _SwApp = SwApp;
        }

       // SldWorks SwApp; // отвечает за получение обекта в солиде
        IModelDoc2 swModel; // создаем  (деталь чертеж и т.д.) 

        public void BuildNewDocSW()
        {
            NewFileSW newdoc = new NewFileSW(_SwApp, swModel);
            swModel=newdoc.Build;
        }

        public void BuildNewCylinder(double radius, double height, string name, string type, double x, double y, double z,bool dir)
        {
            Cylinder cylinder = new Cylinder(radius, height, swModel, name, type, x, y, z, dir);
            swModel = cylinder.Build;
        }

        public void BuildExtrusion(bool dir, double radiusPolygon, int numberPolygon, double deepPolygon)
        {
            Extrusion extrutionCylinder = new Extrusion(swModel, dir, radiusPolygon, numberPolygon, deepPolygon);
            swModel = extrutionCylinder.Build;
        }

        public void BuildRounding(double radiiArray0, double dist2Array0, double conicRhosArray0, bool setBackArray0, int pointArray0, int pointRhoArray0)
        {
            Rounding roundingEdge = new Rounding(swModel,radiiArray0, dist2Array0, conicRhosArray0, setBackArray0, pointArray0, pointRhoArray0);
            swModel = roundingEdge.Build;
        }



    }
}
