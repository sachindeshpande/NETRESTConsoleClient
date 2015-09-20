/* Options:
Date: 2015-09-19 20:15:48
Version: 4.044
BaseUrl: http://localhost:58518/api

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using TMOWebApp.ServiceModel;


namespace TMOWebApp.ServiceModel
{

    public partial class PeakData
    {
        public PeakData()
        {
            intensityValues = new double[]{};
        }

        public virtual double startScan { get; set; }
        public virtual double endScan { get; set; }
        public virtual double[] intensityValues { get; set; }
    }

    [Route("/getpeaks")]
    public partial class PeakFinderInput
        : IReturn<PeakFinderOutput>
    {
        public PeakFinderInput()
        {
            xicData = new List<XICDataPoint>{};
        }

        public virtual List<XICDataPoint> xicData { get; set; }
    }

    public partial class PeakFinderOutput
    {
        public PeakFinderOutput()
        {
            peaklist = new List<PeakData>{};
        }

        public virtual List<PeakData> peaklist { get; set; }
    }

    [Route("/datatest")]
    public partial class TestData
        : IReturn<TestResponse>
    {
        public virtual string paramName { get; set; }
        public virtual double paramValue { get; set; }
    }

    public partial class TestResponse
    {
        public virtual string valueName { get; set; }
        public virtual double value { get; set; }
    }

    public partial class XICDataPoint
    {
        public virtual int scanNumber { get; set; }
        public virtual double intensity { get; set; }
    }
}

