using Microsoft.EntityFrameworkCore;
using RegistrationDataAccess.DataAccess;
using RegistrationDataAccess.Models;

Console.Write("Username:");
string username = Console.ReadLine();

// TODO: Check if the user exists already
var foundUser = context.Users.Find(username);
if (foundUser == null)
{
    Console.Write("Email:");
    string email = Console.ReadLine();

    Console.Write("Password:");
    string password = Console.ReadLine();

    var usr = new User()
    {
        UserName = username,
        Email = email,
        Password = password
    };

    var entityentry = context.Users.Add(usr);
    context.SaveChanges();

    // TODO: Succesful Log up message
    Console.WriteLine("You have sucessfully registered.");

//MainMenu();

//void MainMenu()
//{
//    using (var context = new UserContext())
//    {
//        string menu = "Options:\n(1) Sign Up\n(2)Empty the datastore\n(3) Exit\n";

//        while (true)
//        {
//            Console.WriteLine(menu);
//            Console.Write("Enter you choice:");


//            switch (Console.ReadLine())
//            {

//                case "1":


//                        return ;
//                    }
//                    Console.WriteLine("That username is taken.");
//                    return ;


//                case "2":

//                    EmptyDataStore(context);

//                    return ;

//                case "3":
//                    break;
//                    return ;
//            }
//        }

//        int choice = Convert.ToInt32(Console.ReadLine());

//        Console.Write("Do you want to sign up:");
//        string Continue = Console.ReadLine();

//        foreach (var usr in context.Users.ToList())
//        {
//            Console.WriteLine("{0}\n{1}\n{2} ",usr.UserName, usr.Email, usr.Password);
//        }
//    }

//    void EmptyDataStore(UserContext context)
//    {
//        foreach (var usr in context.Users)
//        {
//            context.Users.Remove(usr);
//        }
//    }

//}