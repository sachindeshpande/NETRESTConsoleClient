using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadWriteCsv;
using TMOWebApp.ServiceModel;


namespace ConsoleRESTClient
{
    public class ConsoleClient
    {
        
        //static void Main(string[] args)
        //{
        //    var client = new JsonServiceClient("http://sactmoapp5.azurewebsites.net/api");

        //    TestData data = new TestData{ paramName ="param1", paramValue = 10};
        //    TestResponse res = client.Post(data);

        //    Console.Out.WriteLine(res.valueName + " : " + res.value);

        //    Console.Read();

        //}

        static void Main(string[] args)
        {
            //var client = new JsonServiceClient("http://sactmoapp5.azurewebsites.net/api");
            var client = new JsonServiceClient("http://localhost:58518//api");

            //TestData data = new TestData { paramName = "param1", paramValue = 10 };
            //TestResponse res = client.Post(data);


            List<XICDataPoint> xicData = new List<XICDataPoint>();

            CsvRow row = new CsvRow();
            CsvFileReader reader = new CsvFileReader("C:\\temp\\XICData.csv");
            while (reader.ReadRow(row))
            {
                Console.Out.WriteLine(row[0] + " -> " + row[1]);
                int scanNumber;
                double intensity;

                if (int.TryParse(row[0], out scanNumber) && double.TryParse(row[1], out intensity))
                    xicData.Add(new XICDataPoint { scanNumber = scanNumber, intensity = intensity });
            }

            PeakFinderInput input = new PeakFinderInput { xicData = xicData };
            PeakFinderOutput res = client.Post(input);
            

            foreach (var peakData in res.peaklist)
            {
                Console.Out.WriteLine(peakData.startScan + " -> ", peakData.endScan);
                foreach (var intensity in peakData.intensityValues)
                {
                    Console.Out.WriteLine("Intensity = " + intensity);
                }
            }

            Console.Read();

        }

    }
}
