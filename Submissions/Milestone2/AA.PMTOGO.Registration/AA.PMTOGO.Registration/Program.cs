﻿using AA.PMTOGO.LoggerDAO;
using AA.PMTOGO.Logging.Implementations;
using AA.PMTOGO.Models;
using AA.PMTOGO.RegistrationDAO;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using RegistrationDataAccess.DataAccess;
//using RegistrationDataAccess.Models;
using System.Text.RegularExpressions;

namespace AA.PMTOGO.Registration;


public class Program
{

    //private static User createUser()
    //{

    //    Console.Write("Email:");
    //    string email = Console.ReadLine();

    //    string username = email;
    //    Console.WriteLine("Your username is:" + username);

    //    string password = null;
    //    while (password is null) {
    //        Console.Write("Password:");
    //        string pass = Console.ReadLine();
    //        if (validatePass(pass))
    //        {
    //            password = pass;
    //            break;
    //        }
            
    //    }
    //    var usr = new User()
    //    {
    //        UserName = username,
    //        Email = email,
    //        Password = password,
    //    };
    //    Console.WriteLine("You have sucessfully registered.");
    //    return usr;

    //}
    //public static EntityEntry addUser(User usr)
    //{
    //    using(var context = new UserContext())
    //    {
    //        var ret = context.Users.Add(usr);
    //        context.SaveChanges();
    //        return ret;
    //    }
    //}
    //public static EntityEntry removeUser(User usr)
    //{
    //    using (var context = new UserContext())
    //    {
    //        var ret = context.Users.Remove(usr);
    //        context.SaveChanges();
    //        return ret;
    //    }
    //}
    //public static bool validateUser(User usr)
    //{

    //    using (var context = new UserContext())
    //    {
    //        var foundEmail = context.Users.Find(usr.Email);
    //        if (foundEmail == null)
    //        {
    //            return true;
    //        }
    //        Console.WriteLine("That username is taken.");
    //        return false;
    //    }
    //}
    //public static bool validatePass(string pass)
    //{
    //    if (Regex.IsMatch(pass, @"^[a-zA-Z0-9_!@,.\s]+$") is false)
    //    {
    //        Console.Write("Password is invalid! Try again. \n");
    //        return false;
    //    }
    //    if (pass.Length <= 8)
    //    {
    //        Console.Write("Password is invalid! Try again. \n");
    //        return false;
    //    }

        
    //    return true;
    //}

    //public static void Menu()
    //{
    //    string menu = "\n\nOptions:\n(1) Sign Up\n(3) Exit\n";
    //    bool Continue = true;
    //    while (Continue)
    //    {
    //        Console.WriteLine(menu);
    //       // Console.Write("Enter you choice:");
    //        switch (Console.ReadLine())
    //        {
    //            case "1":   //signUp
    //                createUser();
    //                break;
    //            case "3":
    //                Continue = false;
    //                break;
    //        }
    //    }
    //}
    public static void Main(string[] args)
    {
        var usrRegister = new SqlRegistrationDAO();
        var logr = new DatabaseLogger("registration", new SqlLogger());
        //logr.Log("info", "general_check", "Testing the Logger");


        string email = "absolanki772@gmail.com";
        string password = "trees";
        var dob = new SqlDateTime(1999, 06, 11);

        try
        {
            usrRegister.AddUser(email,password, dob);
        }

        catch (SqlException e)
        {
            if (e.Number == 2627)
            {
                Console.WriteLine("Account with following email:{1}, already exists.", email);
                logr.Log("info", "registration", "Account with following email:{email}, already exists.");
            }
        }


        //Menu();
    }
}

