using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Models;

namespace storage_miercuri
{
    class Program
    {
        private static CloudTableClient tableClient;

        private static CloudTable studentsTable;
        static void Main(string[] args)
        {
            Task.Run(async () => { await Initialize(); })
            .GetAwaiter()
            .GetResult();
        }

        static async Task Initialize()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=azurestoragemiercuri;AccountKey=I3xTBoRvUkybbNpjF2XMCLKucrgaTVNnDyUgtfxGgw+RXcpR4v/8lE2soqPoGFazoL6/NLHoVzanb3y9tgJpow==;EndpointSuffix=core.windows.net";

            var account = CloudStorageAccount.Parse(storageConnectionString);
            tableClient = account.CreateCloudTableClient();

            studentsTable = tableClient.GetTableReference("studenti");

            await studentsTable.CreateIfNotExistsAsync();

            //await AddNewStudent();
            await GetAllStudents();
        }

        private static async Task AddNewStudent()
        {
            var student = new StudentEntity("UVT","1990916456218");
            student.FirstName = "Adrian";
            student.LastName = "Ducu";
            student.Email = "Ducu777@gmail.com";
            student.Year = 1;
            student.PhoneNumber = "0719618400";
            student.Faculty = "MPT";

            var InsertOperation = TableOperation.Insert(student);

            await studentsTable.ExecuteAsync(InsertOperation);
            
        }

        public static async Task GetAllStudents()
        {
            Console.WriteLine("Universitate\tCNP\tNume\tEmail\tNumar telefon\tAn");
            TableQuery<StudentEntity> query = new TableQuery<StudentEntity>();

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<StudentEntity> resultSegment = await studentsTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach(StudentEntity entity in resultSegment.Results)
                {
                    Console.WriteLine("{0}\t{1}\t{2} {3}\t{4}\t{5}\t{6}", entity.PartitionKey, entity.RowKey, entity.FirstName, entity.LastName, entity.Email, entity.Year, entity.PhoneNumber, entity.Faculty);
                }    
            } while(token!=null);
        }
    }
}
