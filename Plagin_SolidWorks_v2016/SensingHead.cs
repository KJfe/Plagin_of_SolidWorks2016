using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametrFigure
{
    /// <summary>
    /// Класс реализуйющий объект Торцевых головок
    /// </summary>
    class SensingHead:IParametrFigure
    {
        private double _height;
        private double _radius;

        public SensingHead(double height, double radius)
        {
            _height = height;
            _radius = radius;
        }


        public object[] ObjectParametrFigure
        {
            get
            {
                object[] _parametrFigyre = { _height, _radius };
                return _parametrFigyre;
            }
        }
    }
}
