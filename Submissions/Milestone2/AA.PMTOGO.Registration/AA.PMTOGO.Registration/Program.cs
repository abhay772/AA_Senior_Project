using RegistrationDataAccess.DataAccess;
using RegistrationDataAccess.Models;

namespace AA.PMTOGO.Registration
{
    public class Program
    {
        public static void Main(string[] args)
        {


            //using (var context = new UserContext())
            //{
            //    string menu = "\n\nOptions:\n(1) Sign Up\n(2) Empty the datastore\n(3) Exit\n";
            //    bool Continue = true;
            //    while (Continue)
            //    {
            //        Console.WriteLine(menu);
            //        Console.Write("Enter you choice:");


            //        switch (Console.ReadLine())
            //        {

            //            case "1":
            //                Console.Write("Username:");
            //                string username = Console.ReadLine();

            //                // TODO: Check if the user exists already
            //                var foundUser = context.Users.Find(username);

            //                if (foundUser == null)
            //                {
            //                    Console.Write("Email:");
            //                    string email = Console.ReadLine();

            //                    Console.Write("Password:");
            //                    string password = Console.ReadLine();

            //                    var usr = new User()
            //                    {
            //                        UserName = username,
            //                        Email = email,
            //                        Password = password
            //                    };

            //                    var entityentry = context.Users.Add(usr);
            //                    context.SaveChanges();

            //                    // TODO: Succesful Log up message
            //                    Console.WriteLine("You have sucessfully registered.");

            //                }
            //                else
            //                {
            //                    Console.WriteLine("That username is taken.");
            //                }
            //                break;

            //            case "2":

            //                EmptyDataStore(context);

            //                break;

            //            case "3":
            //                Continue = false;
            //                break;
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

        }
    }
}