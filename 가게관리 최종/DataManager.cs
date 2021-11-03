using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 가게관리_최종
{
    class DataManager
    {
        public static List<Product> Products = new List<Product>(); //객체를 생성한다.
        public static List<User> Users = new List<User>();
        public static List<Reservation> Reservations = new List<Reservation>();

        static DataManager()
        {
            Load();
        }

        public static void Load() //파일로 부터 가져온다
        {
            try
            {
                string productsOutput = File.ReadAllText(@"./Products.xml");
                XElement productsXElement = XElement.Parse(productsOutput);

                Products = (from item in productsXElement.Descendants("product") //product 단위로 하나씩 가져오겠다
                            select new Product()
                            {
                                Isbn = item.Element("isbn").Value,
                                ProductName = item.Element("productName").Value, //xml작성된 알파벳과 같아야함
                                Company = item.Element("company").Value,
                                Price = int.Parse(item.Element("price").Value),
                                Amount = int.Parse(item.Element("amount").Value),
                                IsNeeded = item.Element("isNeeded").Value != "0" ? true : false,
                                Reservation = item.Element("reservation").Value != "0" ? true : false,
                                At = DateTime.Parse(item.Element("at").Value)
                            }).ToList<Product>();


                string usersOutput = File.ReadAllText(@"./Users.xml");
                XElement usersXElement = XElement.Parse(usersOutput);

                Users = (from item in usersXElement.Descendants("users") //user 단위로 하나씩 가져오겠다.
                         select new User()
                         {
                             Id = item.Element("id").Value,
                             Name = item.Element("name").Value,
                             Attend = item.Element("attend").Value != "0" ? true : false,
                             AttendTime = DateTime.Parse(item.Element("attendTime").Value)
                         }).ToList<User>();

                string reservationsOutput = File.ReadAllText(@"./Reservations.xml");
                XElement reservationsXElement = XElement.Parse(reservationsOutput);

                Reservations = (from item in usersXElement.Descendants("reservations") //user 단위로 하나씩 가져오겠다.
                         select new Reservation()
                         {
                             Isbn = item.Element("isbn").Value,
                             ProductName = item.Element("productName").Value,
                             Name = item.Element("name").Value,
                             BuyName = item.Element("buyName").Value,
                             Buy = item.Element("attend").Value != "0" ? true : false,
                             PickUp =DateTime.Parse(item.Element("pickUp").Value)
                         }).ToList<Reservation>();
            }
            catch(FileNotFoundException ex)
            {
                Save();
            }

        }

        public static void Save()
        {
            string productsOutput = "";
            productsOutput += "<products> \n"; //줄바꿈은 보기편함을 위해 넣는다.
            foreach (var item in Products)
            {
                productsOutput += "<product> \n"; //여는 상품태그//

                productsOutput += "<isbn>" + item.Isbn + "</isbn> \n";
                productsOutput += "<productName>" + item.ProductName + "</productName> \n";
                productsOutput += "<price>" + item.Price + "</price> \n";
                productsOutput += "<company>" + item.Company + "</company> \n";
                productsOutput += "<amount>" + item.Amount + "</amount> \n";
                productsOutput += "<isNeeded>" + (item.IsNeeded ? 1 : 0) + "</isNeeded> \n";
                productsOutput += "<reservation>" + (item.Reservation ? 1 : 0) + "</reservation> \n";
                productsOutput += "<at>" + item.At.ToLongDateString() + "</at> \n";

                productsOutput += "</product> \n"; //닫는 상품태그//
            }
            productsOutput += "</products> ";

            string usersOutput = "";
            usersOutput += "<users> \n";
            foreach (var item in Users)
            {
                usersOutput += "<user> \n"; //여는 근무자 태그//

                usersOutput += "<id> \n" + item.Id + "</id> \n";
                usersOutput += "<name> \n" + item.Name + "</name> \n";
                usersOutput += "<account> \n" + (item.Attend ? 1 : 0) + "</attend> \n";
                usersOutput += "<accountTime> \n" + item.AttendTime.ToLongDateString() + "</accountTime> \n";

                usersOutput += "</user> \n"; //닫는 근무자 태그//
            }
            usersOutput += "</users> \n";
            File.WriteAllText(@"./Products.xml", productsOutput);
            File.WriteAllText(@"./Users.xml", usersOutput);

        }
    }
}
