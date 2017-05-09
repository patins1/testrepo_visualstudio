using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GradeScoresNS
{
    public class GradeScoresProgram
    {
        static void Main(string[] args)
        {
            string path = args[0];
            GradeScoresProgram program = new GradeScoresProgram();
            List<String> result = program.sortRows(File.ReadLines(path).ToList<String>());
            
            string outPath = path.Insert(path.LastIndexOf("."),"-graded.");
            File.WriteAllLines(outPath, result);

            //result.ForEach(x => Console.WriteLine(x));
        }

        public List<String> sortRows(List<String> lines)
        {
            List<Row> rows = lines.ConvertAll(line => new Row(line));
            rows.Sort();
            return rows.ConvertAll(row => row.originalLine);
        }


    }

    ///
    ///Represents a parsed row
    ///
    class Row : IComparable<Row>
    {

        public string lastName { get; set; }

        public string firstName { get; set; }

        public int weight { get; set; }

        public string originalLine { get; set; }

        public Row(string originalLine)
        {
            this.originalLine = originalLine;
            string[] columns = originalLine.Split(new char[] { ',' });
            this.lastName = columns[0].Trim();
            this.firstName = columns[1].Trim();
            this.weight = Int32.Parse(columns[2].Trim());
        }

        public int CompareTo( Row y)
        {

            int result = y.weight.CompareTo(this.weight);
            if (result != 0)
            {
                return result;
            }
            result = this.lastName.CompareTo(y.lastName);
            if (result != 0)
            {
                return result;
            }
            result = this.firstName.CompareTo(y.firstName);
            return result;
        }

    }

}
