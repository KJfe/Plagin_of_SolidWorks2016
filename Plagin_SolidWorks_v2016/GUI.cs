using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametrFigure;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using Plagin_SolidWorks_v2016;



namespace ParametrFigure
{
    public class GUI:ViewModelBase
    {
        private bool bCreate;
        SldWorks SwApp; // отвечает за получение обекта в солиде
                        // IModelDoc2 swModel; // создаем  (деталь чертеж и т.д.)

        /// <summary>
        /// Открытие SolidWorks v2016
        /// </summary>
        private ICommand _openSW;
        public ICommand OpenSW
        {
            get
            {
                return _openSW ?? (_openSW = new RelayCommand(() =>
                {
                    // убиваем солид если запущен
                    Process[] processes = Process.GetProcessesByName("SLDWORKS 2016");
                    foreach (Process process in processes)
                    {
                        process.CloseMainWindow();
                        process.Kill();
                    }

                    // запуск солид
                    //Guid myGuid1 = new Guid("F16137AD-8EE8-4D2A-8CAC-DFF5D1F67522");
                    object processSW = Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
                    SwApp = (SldWorks)processSW;
                    SwApp.Visible = true;
                    BOpenSW = true;

                    bCreate = true;

                }));
            }
        }

        /// <summary>
        /// Закрытие SolidWorks v2016
        /// </summary>
        private ICommand _closeSW;
        public ICommand CloseSW
        {
            get
            {
                return _closeSW ?? (_closeSW = new RelayCommand(() =>
                {
                    if (bCreate == true)
                    {
                        SwApp.ExitApp();
                        SwApp = null;
                        BOpenSW = false;
                    }

                }));
            }
        }
        /// <summary>
        /// Открыт ли SolidWorks v2016
        /// </summary>
        private bool _bOpenSW;
        public bool BOpenSW
        {
            get
            {
                return _bOpenSW;
            }
            set
            {
                _bOpenSW = value;
                RaisePropertyChanged(() => BOpenSW);

            }
        }

        /// <summary>
        /// Сделана ли деталь
        /// в SolidWorks v2016
        /// </summary>
        private bool _bCreate;
        public bool BCreate
        {
            get
            {
                return _bCreate;
            }
            set
            {
                _bCreate = value;
                RaisePropertyChanged(() => BCreate);

            }
        }


 

        /// <summary>
        /// Получение значений с TextBox
        /// </summary>
        private double HeightHead { get; set; }
        private double RadiusHead { get; set; }
        private double RadiusOfPolygon { get; set; }
        private double DeepPolygon { get; set; }
        private double NumberPolygon { get; set; }
        private double RadiusMounting { get; set; }

        private ICommand _createFigure;
        public ICommand CreateFigure
        {
            get
            {
                return _createFigure ?? (_createFigure = new RelayCommand(() =>
                {
                    /*SensingHead Head = new SensingHead(height: HeightHead, radius: RadiusHead);
                    foreach (object myVar in Head.ObjectParametrFigure)
                    {
                        //Res += Convert.ToDouble(myVar);


                    }*/

                    SensingHeadFigure SensingHead = new SensingHeadFigure(SwApp);
                    SensingHead.BuildNewDocSW();
                    SensingHead.BuildNewCylinder(0.03, 0.05, "Спереди", "PLANE", 0, 0, 0, false);
                    SensingHead.BuildNewCylinder(0.025, 0.015, "Sketch1", "SKETCH", 0, 0, 0.05, false);// test
                    //_swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 4, null, 0);                                                                       //  8.21274659045912E-03
                    //SensingHead.BuildExtrusion(dir: true, radiusPolygon: 28, numberPolygon: 6, deepPolygon: 50);
                    //SensingHead.BuildExtrusion(false, 18, 4, 20);

                }));
            }
        }

        

    }
}
