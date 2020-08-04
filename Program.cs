using System;
using System.Text;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Con_tt
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Code Server");
             Console.WriteLine("Code Server");
             
           // AccessMGDB();
        }
        static void AccessMGDB()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Console.WriteLine("Hello World!");
            var client = new MongoClient("mongodb://app:Developer200@sqlsrv01.ezdc.gwsc:27017/admin?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var database = client.GetDatabase("Mlog");
            var collection = database.GetCollection<BsonDocument>("Burn_info");
            // var doc = new BsonDocument
            // {{"No","Code Server"},
            //       {"date",DateTime.Now.ToString() }
            // };
            //  collection.InsertOne(doc);

            var asQ = collection.AsQueryable().ToList();
            foreach (var eq in asQ)
            {
                string temp = eq[1].ToString();
                //string t=MyUrlDeCode(temp,Encoding.GetEncoding("GB2312"));
                Console.WriteLine(temp);
            }
        }

        public static string MyUrlDeCode(string str, Encoding encoding)
        {
            if (encoding == null)
            {
                Encoding utf8 = Encoding.UTF8;
                //首先用utf-8进行解码                    
                string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
                //将已经解码的字符再次进行编码.
                string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
                if (str == encode)
                    encoding = Encoding.UTF8;
                else
                    encoding = Encoding.GetEncoding("GB2312");
            }
            return HttpUtility.UrlDecode(str, encoding);
        }
    }
}
