using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSP430_BSLprog
{
    [Serializable]
    public class BSLDevice  
    {
        private string deviceName;
        /// <summary>
        /// MSP430xyyyy string, for example MSP430G2553
        /// </summary>
        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }


        private int mainseg_address;
        /// <summary>
        /// Pointer to Main segment starting address. Most common is 0xC000.
        /// </summary>
        public int Mainseg_address
        {
            get { return mainseg_address; }
        }


        private int bsl_default_baudrate;
        /// <summary>
        /// Device speciffic baudrate. Most common is 9600
        /// </summary>
        public int Bsl_default_baudrate
        {
            get { return bsl_default_baudrate; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deviceName">MSP430xyyyy string, for example MSP430G2553</param>
        /// <param name="mainseg_address">Pointer to Main segment starting address. Most common is 0xC000.</param>
        /// <param name="bsl_default_baudrate">Device speciffic baudrate. Most common is 9600</param>
        public BSLDevice(string deviceName, int mainseg_address = 0xC000, int bsl_default_baudrate = 9600)
        {
            this.deviceName = deviceName;
            this.mainseg_address = mainseg_address;
            this.bsl_default_baudrate = bsl_default_baudrate;

        }


        /// <summary>
        /// Returns just a device name, for example "MSP430G2553"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return deviceName;
        }


    }
}
