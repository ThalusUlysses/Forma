using System;
using System.Text;
using Thalus.Forma.Fluent;

namespace Thalus.Forma.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupFluent f = new GroupFluent();

            // Build up an object using the fluent API

            GroupParam p = f.Id("MyId")
                .DisplayText("My Text")
                
                .Double("MyDouble")
                .Precison(5)
                .DisplayText("My Text")
                .AddRange(10.4, 2434.54)
                .Default(10.0)
                .Value(25.0)
                .Unit("simL", "mL")
                .AddToParams()
                .Int("MyIntId")
                .Default(1)
                .Value(1)
                .AddRange(1, 4)
                .Enum(1, "A")
                .Enum(2, "B")
                .Enum(3, "C")
                .Enum(4, "D")
                .AddToParams().Char("charId")
                .Value('C')
                .Regex("[A|B|C|D]")
                .Unit("siAu", "AU")
                .AddToParams()
                .Build();

            // Format it as CSV and parse it back
            Formatter.Csv.GroupFormatter csvFrmt = new Formatter.Csv.GroupFormatter(new Formatter.Csv.Formatter());

            var groupCsv = csvFrmt.Format(p);

            Console.WriteLine(groupCsv);

            Parser.Csv.GroupParser csvParser = new Parser.Csv.GroupParser();
            string text = "MYCOMMAND 1,23.5,\"The Command\",'c'";
            //string text = "FRAC 1,0.32,\"My fraction\",\'c\'";

            var csvGroupParam = csvParser.Parse(text);
            
            // Format it as json and parse it back
            Formatter.Json.GroupFormatter jsonFrmt = new Formatter.Json.GroupFormatter();

            var groupJson = jsonFrmt.Format(csvGroupParam);

            Console.WriteLine(groupJson);

            Parser.Json.GroupParser jsonParser = new Parser.Json.GroupParser();

            var jsonGroupParam = jsonParser.Parse(groupJson);
        }
    }
}
