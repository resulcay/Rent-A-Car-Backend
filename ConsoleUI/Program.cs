using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            EfCarDal carDal = new EfCarDal();

            CarManager carManager = new CarManager(carDal);

            //foreach (var temp in carManager.FetchAll())
            //{
            //    Console.WriteLine(temp.Description);
            //}

            var result = carManager.FetchCarDetails();

            if (result.IsSuccess == true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.Id + " / " + c.BrandName + " / " + c.ColorName + " / " + c.ModelYear + " / $" + c.DailyPrice);
                }

                Console.WriteLine("\n" + result.Message);

            }
            //else
            //{
            //    Console.WriteLine("Error occured while retriving data!");
            //}

            //EfUserDal userDal = new EfUserDal();
            //UserManager userManager = new UserManager(userDal);

            //var result2 = userManager.FetchAllUsers();
            //if (result2.IsSuccess == true)
            //{
            //    foreach (var u in result2.Data)
            //    {
            //        Console.WriteLine(u.Id + " / " + u.FirstName + " / " + u.LastName + " / " + u.Email + " / " + u.Password);
            //    }
            //}

            //User user = new User()
            //{
            //    FirstName = "Hayri Can",
            //    LastName = "Efe",
            //    Email = "hayri@gmail.com",
            //    Password = "456872scv"
            //};
            //userDal.Add(user);



            #region DataBaseToCMD
            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\mylocal;Initial Catalog=Carrent;Integrated Security=True");

            //con.Open();

            //SqlCommand cmd = new SqlCommand("select Cars.Id,Cars.ModelYear,Cars.Description,Cars.DailyPrice,Colors.ColorName,Brands.BrandName from Cars inner join Brands  on Cars.BrandId=Brands.Id inner join Colors on Cars.ColorId=Colors.Id", con);

            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine(reader[0].ToString() + "   " + reader[1].ToString() + "   " + reader[2].ToString() + "   " + reader[3].ToString() + "   " + reader[4].ToString() + "   " + reader[5].ToString());
            //}

            //con.Close();
            #endregion

            #region CarOperations
            // EfCarDal efCarDal = new EfCarDal();

            //Car example = new Car()
            //{
            //    Id = 6,
            //    BrandId = 1,
            //    ColorId = 2,
            //    ModelYear = 2019,
            //    DailyPrice = 600,
            //    Description = "car4"
            //};

            //carDal.Update(example);

            #endregion

            #region BrandOperations
            //EfBrandDal brandDal = new EfBrandDal();

            //BrandManager brandManager = new BrandManager(brandDal);

            //foreach (var br in brandManager.FetchAll())
            //{
            //    Console.WriteLine(br.Id + " / " + br.BrandName);
            //}
            #endregion

            #region ColorOperations
            //Color color = new Color()
            //{
            //    Id = 11,
            //    // ColorName = "magenta",
            //};

            //EfColorDal colorDal = new EfColorDal();

            //colorDal.Delete(color);

            //ColorManager colorManager = new ColorManager(colorDal);

            //var x = colorManager.FetchById(1);
            //Console.WriteLine(x.ColorName);

            #endregion

        }
    }
}
