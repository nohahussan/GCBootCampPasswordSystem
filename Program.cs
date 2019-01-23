using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace PasswordSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Boolean repeat = false;
            List<string> listOfEmails = new List<string>();
            List<string> listOfPasswords = new List<string>();
            do
            {
                bool valid = true;
                do
                {   //do while loop to ensure the user input a valid password befor asking him to enter a valid email
                    try 
                    {
                        Console.Write("Please enter  a password with the follow requirements: \n\n" +
                            " . The password must be 5 or more characters long\n" +
                            " . The password must contain uppercase letters \n" +
                            " . The password must contain at least one number\n\n" +
                             " . Password : ");
                        string password = Console.ReadLine();
                        if (ValidPassword(password) == "-1")
                        {
                            valid = false;
                        }
                        else
                        {
                            listOfPasswords.Add(ValidPassword(password));
                            valid = true;
                        }
                    }
                    catch (Exception e)//Exception could be thrown from ReadLine()
                    {
                        if (e is IOException)
                        {
                            Console.WriteLine("An I / O error occurred");
                        }
                        else if (e is OutOfMemoryException)
                        {
                            Console.WriteLine("There is insufficient memory to allocate a buffer for the returned string");

                        }
                        else if (e is ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("The number of characters in the next line of characters is greater than MaxValue ");
                        }
                    }
                } while (valid == false);

                do
                {   //do while loop to ensure the user input a valid  email
                    try
                    {
                        Console.WriteLine();
                        Console.Write("Please enter an email with following components:\n\n" +
                                " . A name with 3 or more letters or numbers\n" +
                                " . A @ after the name \n" +
                                " . A Domain with 3 or more letters or numbers\n" +
                                " . A period after the domain\n" +
                                " . An ending with 2-3 characters \n\n" +
                                 " . Email : ");

                        string email = Console.ReadLine();
                        if (ValidEmail(email) == "-1")
                        {
                            valid = false;
                        }
                        else
                        {
                            listOfEmails.Add(ValidEmail(email));
                            valid = true;

                        }
                    }
                    catch (Exception e)//Exceptions could be thrown from ReadLine()
                    {
                        if (e is IOException)
                        {
                            Console.WriteLine("An I / O error occurred");
                        }
                        else if (e is OutOfMemoryException)
                        {
                            Console.WriteLine("There is insufficient memory to allocate a buffer for the returned string");

                        }
                        else if (e is ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("The number of characters in the next line of characters is greater than MaxValue ");
                        }
                    }
                } while (valid == false);

                repeat = Continue(repeat);
            } while (repeat);
       }

        public static string ValidPassword(string password)
        {
            try
            {
                if (password.Length < 5)
                {
                    throw new Exception("invalid password !! \n" +
                        "The password must be 5 or more characters long");
                }
                else if (!(Regex.IsMatch(password, "[A-Z]")))
                {
                    throw new Exception("invalid pasword !! \n" +
                        "The password must contain uppercase letters");
                }
                else if (!(Regex.IsMatch(password, @"\d+")))
                {
                    throw new Exception("\ninvalid pasword !! \n" +
                        "The password must contain at least one number\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "-1";
            }
            return password;//returning a valid password after checking it
        }

        public static string ValidEmail(string email)
        {
            try
            {
               if( Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") == false)
                    throw new Exception("\nunvalid email!! \n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "-1";
            }
            return email;//returning a valid email after checking it
        }

        public static Boolean Continue(Boolean repeat)
        {
            string userChoice;
            Console.WriteLine("would you like to continue adding more emails and passwords ?(y/n)");
            try
            {
                 userChoice = Console.ReadLine().ToLower();
                if(userChoice == "y" || userChoice == "n")
                {
                    repeat = (userChoice == "y") ? true : false;
                    return repeat;
                }
                else
                {
                    throw new Exception("unvalidinput!!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    } 
}






