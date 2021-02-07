using API.Interfaces;
using API.POCOs;
using CsvHelper;
using LinqToDB.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class FileService : IFileService
    {
        public IConfiguration configuration { get; }

        public FileService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Load(string fileName)
        {
            var csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "COVID19 cases.csv");

            // Read CSV as a dataset of strings
            var rowCases = ReadCsvFile(csvFilePath);

            // Convert to a typed dataset
            var typedCases = rowCases.Select( r => new TypedCase {  
                X = ConvertToDecimal(r.X),
                Y = ConvertToDecimal(r.Y),
                case_code = r.case_code,
                confirmation_date = ConvertToDateTime(r.confirmation_date),
                municipality_code = r.municipality_code,
                municipality_name = r.municipality_name,
                age_bracket = r.age_bracket,
                gender = r.gender,
                object_id = ConvertToInteger(r.object_id)
            }).ToList();

            // Upload to the SQL table
            var rowsCopied = BulkCopy(typedCases, configuration.GetSection("CovidDB").Value, "Cases");
        }

        private decimal? ConvertToDecimal(string s)
        {
            decimal number;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        private int? ConvertToInteger(string s)
        {
            int number;
            if (int.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        private DateTime? ConvertToDateTime(string s)
        {
            DateTime dateTime;
            if (DateTime.TryParse(s, out dateTime))
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }

        private List<RowCase> ReadCsvFile(string csvFilePath)
        {
            List<RowCase> rowCases = new List<RowCase>();

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                rowCases = csv.GetRecords<RowCase>().ToList();
            }

            return rowCases;
        }

        private long BulkCopy(List<TypedCase> typedCases, string connectionString, string tableName)
        {
            using (var db = new DataConnection("SqlServer2019", connectionString))
            {
                var bulkCopyOptions = new BulkCopyOptions
                {
                    SchemaName = "dbo",
                    TableName = tableName,
                    MaxBatchSize = 10000,
                    BulkCopyType = BulkCopyType.ProviderSpecific
                };

                var result = db.BulkCopy(bulkCopyOptions, typedCases);

                return result.RowsCopied;
            }
        }
    }
}
