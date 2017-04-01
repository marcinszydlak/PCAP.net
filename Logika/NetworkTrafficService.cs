using Logic.Models;
using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NetworkTrafficService
    {
        public List<DeviceModel> GetAllDevices()
        {
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
            return allDevices.Select(x => new DeviceModel
            {
                Description = x.Description,
                Name = x.Name,
            }).ToList();
        }
    }
}
