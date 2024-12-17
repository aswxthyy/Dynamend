﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamend.Desktop.Models
{
    internal class ServiceReport
    {

        public int ServiceId { get; set; }
        public int VehicleId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string EngineOperation { get; set; }
        public string ShiftOperation { get; set; }
        public string ClutchAndBrake { get; set; }
        public string Steering { get; set; }
        public string GrilleAndTrimAndRoofRack { get; set; }
        public string DoorsAndHoodAndDecklidAndTailGate { get; set; }
        public string BodyPanelsAndBumpers { get; set; }
        public string GlassAndOutsideMirrors { get; set; }
        public string ExteriorLights { get; set; }
        public string AirBagAndSafetyBelts { get; set; }
        public string AudioAndAlarmsSystems { get; set; }
        public string HeatANdVentAndACDeFogAndDeposit { get; set; }
        public string InteriorAmenities { get; set; }


    }
}
