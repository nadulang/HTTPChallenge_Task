using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IronWebScraper;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

namespace HTTPChallenge
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //    var result = await Employees.employeesData();

            //    Console.WriteLine("Employees that has salary more than 15 Million are : ");
            //    List<string> salary = new List<string>();
            //    foreach (var k in result)
            //    {
            //        if (k.Salary > 15000000)
            //        {
            //            salary.Add(k.First_name + k.Last_name);
            //        }
            //    }
            //    Console.WriteLine(String.Join(",", salary));
            //    Console.WriteLine(" ");

            //    Console.WriteLine("Employees that life in Jakarta are : ");
            //    List<string> jkt = new List<string>();
            //    foreach (var k in result)
            //    {
            //        foreach (var l in k.Addresses)
            //        {
            //            if (l.City == "DKI Jakarta")
            //            {
            //                jkt.Add(k.First_name + k.Last_name);
            //            }
            //        }

            //    }
            //    var JKT = jkt.Distinct();
            //    Console.WriteLine(String.Join(",", JKT));
            //    Console.WriteLine(" ");

            //    Console.WriteLine("Employees that born on March are : ");
            //    List<string> born = new List<string>();
            //    foreach (var k in result)
            //    {
            //        var A = Convert.ToInt32((k.Birthday).Substring(5, 2));
            //        if (A == 3)
            //        {
            //            born.Add(k.First_name + k.Last_name);
            //        }
            //    }

            //    Console.WriteLine(String.Join(",", born));
            //    Console.WriteLine(" ");

            //    Console.WriteLine("Employees that absences in October 2019 are : ");
            //    List<int> Absences = new List<int>();

            //    List<string> Nama = new List<string>();
            //    foreach (var k in result)
            //    {
            //        int count = 0;
            //        foreach (var l in k.Presence_list)
            //        {
            //            var A = Convert.ToInt32(l.Substring(5, 2));
            //            if (A == 10)
            //            {
            //                count++;
            //            }
            //        }
            //        Absences.Add(count);

            //        Nama.Add(k.First_name + k.Last_name);

            //    }
            //    Console.WriteLine(String.Join(",", Nama));
            //    Console.WriteLine(String.Join(",", Absences));
            //    Console.WriteLine(" ");

            // var result = await Get();

            // Console.WriteLine(await Nomor3.No3());

            // var scrape = new BlogScraper();
            // await scrape.StartAsync();

        }
    }

        public class Fetcher
        {
            static HttpClient client = new HttpClient();

            public static async Task<string> Get(string link)
            {
                return await client.GetStringAsync(link);
            }
            public static async void Delete(string link)
            {
                await client.DeleteAsync(link);
            }

            public static async void Post(string link, HttpContent data)
            {
                await client.PostAsync(link, data);
            }

            public static async void Put(string link, HttpContent data)
            {
                await client.PutAsync(link, data);
            }

            public static async void Patch(string link, HttpContent data)
            {
                await client.PatchAsync(link, data);
            }
        }


        public class Employees
        {
            public static async Task<List<Employees1>> employeesData()
            {
                var client = new HttpClient();
                var json2 = await client.GetStringAsync("https://mul14.github.io/data/employees.json");
                var data2 = JsonConvert.DeserializeObject<List<Employees1>>(json2);
                return data2;
            }
        }


        public class Address
        {
            public string Label { get; set; }
            public string Addresses { get; set; }
            public string City { get; set; }
        }

        public class Phone
        {
            public string Label { get; set; }
            public string Phones { get; set; }
        }

        public class Department
        {
            public string Name { get; set; }
        }

        public class Position
        {
            public string Name { get; set; }
        }

        public class Employees1
        {
            public int Id { get; set; }
            public string Avatar_url { get; set; }
            public string Employee_id { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Birthday { get; set; }
            public List<Address> Addresses { get; set; }
            public List<Phone> Phones { get; set; }
            public List<string> Presence_list { get; set; }
            public int Salary { get; set; }
            public Department Department { get; set; }
            public Position Position { get; set; }
        }


        public class Users
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public Address1 Address { get; set; }
            public string Phone { get; set; }
            public string Website { get; set; }
            public Companies Company { get; set; }
        }

        public class Address1
        {
            public string Street { get; set; }
            public string Suite { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public Geo Geo { get; set; }
        }

        public class Geo
        {
            public string Lat { get; set; }
            public string Lng { get; set; }
        }

        public class Companies
        {
            public string Name { get; set; }
            public string CatchPhrase { get; set; }
            public string Bs { get; set; }
        }

        public class Posts
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
        public class numberThree : Posts
        {
            public Users User { get; set; }
        }

        public class Nomor3
        {
            public static async Task<string> No3()
            {

                var client = new HttpClient();
                var resource = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
                var resource1 = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

                var result = new List<numberThree>();

                var user1 = JsonConvert.DeserializeObject<List<Users>>(resource);
                var post = JsonConvert.DeserializeObject<List<Posts>>(resource1);

                foreach (var i in post)
                {
                    var abcd = user1.Where(x => x.Id == i.UserId).FirstOrDefault();
                    if (abcd != null)
                    {
                        result.Add(new numberThree
                        {
                            UserId = i.UserId,
                            Id = i.Id,
                            Title = i.Title,
                            Body = i.Body,
                            User = new Users
                            {
                                Id = abcd.Id,
                                Name = abcd.Name,
                                Username = abcd.Username,
                                Email = abcd.Email,
                                Address = new Address1
                                {
                                    Street = abcd.Address.Street,
                                    Suite = abcd.Address.Suite,
                                    City = abcd.Address.City,
                                    Zipcode = abcd.Address.Zipcode,
                                    Geo = new Geo
                                    {
                                        Lat = abcd.Address.Geo.Lat,
                                        Lng = abcd.Address.Geo.Lng
                                    }
                                },
                                Phone = abcd.Phone,
                                Website = abcd.Website,
                                Company = new Companies
                                {
                                    Name = abcd.Company.Name,
                                    CatchPhrase = abcd.Company.CatchPhrase,
                                    Bs = abcd.Company.Bs
                                }
                            }
                        });
                    }

                }

                var text = JsonConvert.SerializeObject(result);
                return text;

            }

        }


        //public class MovieDB : WebScraper
        //{
        //    public override void Init()
        //    {
        //        LoggingLevel = WebScraper.LogLevel.All;
        //        Request("https://www.themoviedb.org/", Parse);
        //    }

        //    public override string Parse(Response response)
        //    {
        //        foreach (var k in response.Css(""))
        //        {
        //            string title = k.TextContentClean;
        //            return title;
        //        }
        //    }
        //}





        //public class CGV : WebScraper
        //{
        //    public override void Init()
        //    {
        //        License.LicenseKey = "LicenseKey";
        //        this.LoggingLevel = WebScraper.LogLevel.All;
        //        this.WorkingDirectory = AppSetting.GetAppRoot() + @"\MovieSample\Output\";
        //        this.Request("https://www.cgv.id/en/movies/now_playing/", Parse);
        //    }
        //    public override void Parse(Response response)
        //    {
        //        foreach (var Divs in response.Css("movie-list-body > div"))
        //        {
        //            if (Divs.Attributes["class"] != "clearfix")
        //            {
        //                var movie = new Movie();
        //                var movie.Id = CoDivs.GetAttribute("movie-list-body");
        //                var link = Divs.Css("a")[0];
        //                movie.Title = link.TextContentClean;
        //                movie.URL = link.Attributes["href"];
        //                Scrape(movie, "Movie.Jsonl");
        //            }
        //        }
        //    }
        //}

        //public class Movie
        //{
        //    public int ID { get; set; }
        //    public string Title { get; set; }
        //    public string URL { get; set; }
        //}
    

}