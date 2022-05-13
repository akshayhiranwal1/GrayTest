using GraysInt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.IO;

namespace Test
{
    public class TestContext : ITests
    {
        public decimal AddStringIfNumber(IEnumerable<string> input)
        {
            var result = input.Select(i =>
           {
               decimal no;
               if (decimal.TryParse(i, out no))
               {
                   return no;
               }
               else
                   return 0;
           }).ToList().Sum();

            return result;
        }

        public Task DeletePeopleWithLastNameAsync(string connectionString, string lastName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "delete from people where isnull(lastname,'') <> ''";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    return cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<string> DownloadFileAsync(string url)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the
            // requested URI contains a query.

            //client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            return Task.Run(() => s);
        }

        public Task<Dictionary<string, int>> GetCountOfPeopleInEachCityAsync(string connectionString)
        {
            string query = "select count(id) count, city from people group by city";
            throw new NotImplementedException();
        }

        public Task InsertPersonAsync(string connectionString, string lastName, string firstName, string address, string city)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "insert into people(lastname,firstname,address,city) values(" + "'" + lastName + "','" + firstName + "','" + address
                    + "','" + city + "')";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    return cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public void RemoveItemsFromCollection<T>(IList<T> collection, T item)
        {
            collection.Remove(item);
        }

        public IEnumerable<T> RemoveItemsInNewCollection<T>(IEnumerable<T> collection, T item)
        {
            var result = collection.ToList();
            foreach (var data in result)
            {
                if (data.Equals(item))
                    result.Remove(item);
            }

            return result.AsEnumerable();
        }

        public string RemoveNonAlphanumeric(string input)
        {
            var charArray = input.ToCharArray();

            var aplhanumericList = new List<char>() { '@', '#', '$', '$' };

            var charArryWithOutAlpha = charArray.Select(i => !aplhanumericList.Contains(i)).ToList();


            return string.Join("", charArryWithOutAlpha);
        }

        public IEnumerable<T> ReverseCollectionOrder<T>(IList<T> collection)
        {
            return collection.Reverse();
        }

        public IEnumerable<int> YieldPowersOf(int power)
        {
            
        }

        private int power(int a)
        {
            return power(a) * 2;
        }
    }
}
