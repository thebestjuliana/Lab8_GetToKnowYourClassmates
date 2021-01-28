using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab8_GetToKnowYourClassmates
{
    class Program
    {
        //Juliana Sheehan
        //Provides info on students in a class
        //Prompts user to ask about students
        //gibes proper responses according to usersubmitted information
        //account for invalid user inputs with exceptions
        //try to IndexOutOfRangeException and FormatException
        //Include more than 2 pieces of info about the student
        //Allow the user to search for a student by name as well as number. 
        static void Main(string[] args)
        {
            List<string> students = new List<string>();
            students.Add("juliana sheehan");
            students.Add("jeffrey wohlfield");
            students.Add("grace seymore");
            students.Add("nick d'oria");
            students.Add("wendi magee");
            students.Add("ramon guarnes");
            students.Add("joshua carolin");
            students.Add("jeremiah wyeth");
            students.Add("nathaniel davis");
            students.Add("antonio manzari");
            students.Add("tommy waalkes");
            students.Add("josh gallentin");
            students.Add("stephen jedlicki");

            List<string> homeTown = new List<string>();
            homeTown.Add("Denver, CO");
            homeTown.Add("Detroit, MI");
            homeTown.Add("Mesa, AZ");
            homeTown.Add("Canton, MI");
            homeTown.Add("Detroit, MI");
            homeTown.Add("Tigard, OR");
            homeTown.Add("Novi, MI");
            homeTown.Add("Crystal, MI");
            homeTown.Add("Berkley, MI");
            homeTown.Add("Beverley Hills, MI");
            homeTown.Add("Raleigh, NC");
            homeTown.Add("Baldwin, MI");
            homeTown.Add("The Moon");

            List<string> favFood = new List<string>();
            favFood.Add("Tacos");
            favFood.Add("Steak");
            favFood.Add("Sweet Potato Fries");
            favFood.Add("Tacos");
            favFood.Add("Salami");
            favFood.Add("Burgers");
            favFood.Add("Naleśiki");
            favFood.Add("Burgers");
            favFood.Add("Steak");
            favFood.Add("Focacia Barese");
            favFood.Add("Chicken Curry");
            favFood.Add("Falafel");
            favFood.Add("Moon Cakes");

            List<string> pet = new List<string>();
            pet.Add("would like a dog");
            pet.Add("'s pets are unknown");
            pet.Add("has a dog");
            pet.Add("has cats");
            pet.Add("has a dog");
            pet.Add("'s pets are unknown");
            pet.Add("'s pets are unknown");
            pet.Add("'s pets are unknown");
            pet.Add("has cats and dogs");
            pet.Add("'s pets are unknown");
            pet.Add("'s pets are unknown");
            pet.Add("'s pets are unknown");
            pet.Add("'s pets are unknown");




            bool running = true;

            while (running == true)
            {
                int numberOfStudents = students.Count;

                ///Identify which Student they want to know about
                Console.WriteLine($"Which student would you like to learn more about (1-{numberOfStudents} or full name)?");
                int indexOfRequestedStudent = WhichStudentValidation(students);
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                string requestedStudent = myTI.ToTitleCase(students[indexOfRequestedStudent]);
                string hometownOfRequestedStudent = homeTown[indexOfRequestedStudent];
                string favFoodOfRequestedStudent = favFood[indexOfRequestedStudent];
                string petOfRequestedStudent = pet[indexOfRequestedStudent];



                Console.WriteLine($"Student {indexOfRequestedStudent + 1} is {requestedStudent}.");


                Console.WriteLine($"What would you like to know about {requestedStudent} (enter 'hometown' or 'favorite food' or 'pets')");
                int interestedIn = InterestValidation();


                TellMeAboutThem(interestedIn, requestedStudent, hometownOfRequestedStudent, favFoodOfRequestedStudent, petOfRequestedStudent);
                bool validAnswer = false;
                while (validAnswer == false)
                {
                    Console.WriteLine("Would you like to know about another student?");

                    try
                    {
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            validAnswer = true;
                        }
                        else if (answer == "n")
                        {
                            Console.WriteLine("goodbye!");
                            running = false;
                            break;
                        }
                        else
                        {
                            throw new Exception("Invalid response.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Would you like to know about another student? y/n");
                        continue;
                    }
                }
                

            }
        }

        public static int WhichStudentValidation(List<string> students)
        {
            while (true)
            {
                string userInput = Console.ReadLine().ToLower();
                int studentNumber;
                bool inputIsNumber = int.TryParse(userInput, out studentNumber);
                int numberOfStudents = students.Count;
                bool inputGreaterThanStudents = studentNumber > numberOfStudents || studentNumber < 1;
                bool nameExists = students.Contains(userInput);

                try
                {
                    if (inputGreaterThanStudents)
                    {
                        throw new Exception("Index Out of Range");

                    }
                    if (inputIsNumber)

                    {
                        return studentNumber - 1;
                    }

                    if (nameExists)
                    {
                        return students.IndexOf(userInput);

                    } 
                    else
                    {
                        throw new Exception("That Student Does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("lets's try again");
                    continue;
                }

            }

        }

        public static int InterestValidation()
        {
            
            while (true)
            {
                string interest = Console.ReadLine().ToLower();

                try
                {
                    if (string.IsNullOrEmpty(interest))
                    {
                        throw new Exception("Please enter an Interest");
                    }
                    if (interest == "hometown")
                    {
                        return 1;
                    }
                    else if (interest == "favorite food")
                    {
                        return 2;
                    }
                    else if(interest == "pets")
                    {
                        return 3;
                    }
                    else
                    {
                        throw new Exception("That is not a valid Interest");

                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter 'hometown' or 'favorite food'");
                    continue;
                }

            }
        }

        public static void TellMeAboutThem(int interest, string requestedStudent, string hometownOfRequestedStudent, string favFoodOfRequestedStudent, string petOfRequestedStudent)
        {

            while (true)
            {
                if (interest == 1)
                {
                    Console.WriteLine($"{requestedStudent} is from {hometownOfRequestedStudent}.");
                }
                else if (interest == 2)
                {
                    Console.WriteLine($"{requestedStudent}'s favorite food is {favFoodOfRequestedStudent}.");
                }
                else if (interest == 3)
                {
                    Console.WriteLine($"{requestedStudent} {petOfRequestedStudent}.");
                }
            
                Console.WriteLine($"Would you like to know more about {requestedStudent}(y/n)");
                string answer = Console.ReadLine().ToLower();
                try
                {
                    if (answer == "y")
                    {
                        Console.WriteLine("hometown or favorite food or pets");
                        interest = InterestValidation();
                        TellMeAboutThem(interest, requestedStudent, hometownOfRequestedStudent, favFoodOfRequestedStudent, petOfRequestedStudent);
                        break;
                    }
                    else if (answer == "n")
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Invalid response.");
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("try again");
                }
            }
        }
    }
}
