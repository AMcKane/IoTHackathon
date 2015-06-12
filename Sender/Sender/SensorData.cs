using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sender
{
    public class SensorData
    {
        public string SensorName { get; set; }
        public int XVal { get; set; }
        public int YVal { get; set; }
        public int ZVal { get; set; }
        public DateTime EventTime { get; set; }
        public string DeviceId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public SensorData()
        {
            
        }

        public SensorData(string sensorDataString)
        {
            //this =  JsonConvert.DeserializeObject(typeof<SensorData>, sensorDataString);

        }
    }
}
