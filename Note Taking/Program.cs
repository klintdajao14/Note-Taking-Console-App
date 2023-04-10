using Note_Taking_App;
using System.Text.RegularExpressions;

class Program
{
    static void Main(String[] args)
    {

        var arrUsers = new Users[]
        {
            new Users("klint","klint"),
            new Users("lalaine", "lj")
        };

        Console.WriteLine("Welcome to Note Taking App!");

        while (true)
        {
            Console.Write("[1]Login [2]Signup: ");
            int prompt = Convert.ToInt32(Console.ReadLine());

            if (prompt == 1 || prompt == 2)
            {
                switch (prompt)
                {
                    case 1:
                        Console.Write("Enter your username: ");
                        var username = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var password = Console.ReadLine();
                        bool isFound = false;
                        foreach (Users user in arrUsers)
                        {
                            if (username == user.username && password == user.password)
                            {
                                Console.WriteLine("[1] Write a Note \n[2]Check Notes \n[3] Exit");
                                Console.Write("Choice: ");
                                int choice = Convert.ToInt32(Console.ReadLine());


                                while (choice != 3)
                                {
                                    switch (choice)
                                    {
                                        case 1:
                                            Console.WriteLine("New Note: ");
                                            string note = Console.ReadLine();
                                            if (string.IsNullOrEmpty(note)) break;
                                            if (user.notes == null)
                                            {
                                                user.notes = new string[] { note };
                                            }
                                            else
                                            {
                                                string[] newNotes = new string[user.notes.Length + 1];
                                                user.notes.CopyTo(newNotes, 0);
                                                newNotes[newNotes.Length - 1] = note;
                                                user.notes = newNotes;
                                            }
                                            Console.WriteLine("Notes saved successfully!");
                                            Console.WriteLine("OPTIONS\n[1] Write a Note \n[2]Check Notes \n[3] Exit");
                                            Console.Write("Choice: ");
                                            choice = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        case 2:
                                            Console.WriteLine("Your saved notes:");
                                            if (user.notes != null)
                                            {
                                                for (int i = 1; i <= user.notes.Length;i++)
                                                {
                                                    Console.WriteLine($"NOTE {i}: {user.notes[i-1]}");
                                                }
                                            }
                                            Console.WriteLine("OPTIONS\n[1] Write a Note \n[2]Check Notes \n[3] Exit");
                                            Console.Write("Choice: ");
                                            choice = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        case 3:
                                            Console.WriteLine("Program exitted");
                                            Environment.Exit(0);
                                            break;

                                    }
                                }
                              
                                isFound = true;
                                break;
                            }
                        }
                        if (!isFound)
                        {
                            Console.WriteLine("Invalid Username or Password");   
                        }
                        break;
                    case 2:
                        Console.Write("Enter your username: ");
                        var registerUsername = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        var registerPassword = Console.ReadLine();


                        var newUser = new Users(registerUsername, registerPassword);
                        Array.Resize(ref arrUsers, arrUsers.Length + 1);

                        arrUsers[arrUsers.Length - 1] = newUser;
                        Console.WriteLine($"Registration successful! User: {registerUsername} Password: {registerPassword} ID: {newUser.id}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input. Program will now exit.");
                break;
            }


        }
    }
}
