using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sramski.Interfaces;
using Sramski.DataMock;

namespace Sramski.BL
{
    public class Base
    {
        private static Base Instance;
        private IDAO Data;

        public static Base GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Base();
            }
            return Instance;
        }

        private Base()
        {
            InitDataObject();
        }

        void InitDataObject()
        {
            Data = new DAOMock();
        }

        public IDAO GetDataObject()
        {
            return Data;
        }
    }
}
