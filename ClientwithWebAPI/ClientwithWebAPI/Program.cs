using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientwithWebAPI
{
    class Program
    {

        static string url = "http://localhost:59866/api/";

        //LIST OF STUDENTS
        static void Main1()
        {
            IEnumerable<Student> list = null;

            using(var client= new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("Students");
                responseTask.Wait();


                //To store the result
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Student>>();
                    list = readTask.Result;
                }
                else
                {

                    //If ERROR RESPONSE RECEIVED
                    Console.WriteLine("No records Found");
                    list = Enumerable.Empty<Student>();
                }

                foreach(Student stu in list)
                {
                    Console.WriteLine(stu.StudentId+"  "+stu.Name + "    " + stu.JavaMarks + "  " + stu.DotNetMarks);
                }

                Console.ReadLine();
            }

        }

        //GETTING SINGLE STUDENT
        static void Main2()
        {

           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("Students/1");
                responseTask.Wait();

                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Student>();
                    Student stu = readTask.Result;

                    Console.WriteLine(stu.StudentId + "  " + stu.Name + "  " + stu.JavaMarks + " " + stu.DotNetMarks);
                }
                else
                {
                    Console.WriteLine("Record not found");
                    
                }

                Console.ReadLine();           }
        }




        //POST 
        public static void Main3()
        {
            using(var client=new HttpClient())
            {

                client.BaseAddress = new Uri(url);

                var studstr = "{\"StudentId\":4,\"Name\":\"Sandeep\",\"JavaMarks\":89,\"DotNetMarks\":95 }";
                HttpContent content = new StringContent(studstr, Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync("Students", content);
                responseTask.Wait();

                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Error");
                }
                Console.ReadLine();
            }
        }


        //PUT
        static void Main4()
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var studstr = "{\"StudentId\":4,\"Name\":\"Rahul\",\"JavaMarks\":80,\"DotNetMarks\":90}";
                HttpContent content = new StringContent(studstr, Encoding.UTF8, "application/json");
                var responseTask = client.PutAsync("Students/4",content);
                responseTask.Wait();


                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Updated successfully");
                }
                else
                {
                    Console.WriteLine("Error");
                }

                Console.ReadLine();
            }
        }


        //DELETE

        static void Main()
        {

            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.DeleteAsync("Students/4");
                responseTask.Wait();

                var result = responseTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Error");
                }

                Console.ReadLine();
            }

        }


    }
}
