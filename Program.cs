namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] titles = new string[100];
            string[] authors = new string[100];
            string[] isbns = new string[100];
            bool[] available = new bool[100];
            string[] borrowers = new string[100];

            int lastIndex = 0; // Initialize lastIndex to -1 since no books are added yet

            titles[lastIndex] = "MATH";
            authors[lastIndex] = "HASNA ";
            isbns[lastIndex] = "111";
            available[lastIndex] = true;
            borrowers[lastIndex] = "";

            lastIndex++; //1

            titles[lastIndex] = "Algorithms";
            authors[lastIndex] = "HOOR";
            isbns[lastIndex] = "222";
            available[lastIndex] = true;
            borrowers[lastIndex] = "";


            lastIndex++; //2

            titles[lastIndex] = " Sciences";
            authors[lastIndex] = "NOOR ";
            isbns[lastIndex] = "333";
            available[lastIndex] = false;
            borrowers[lastIndex] = "Karim";




            bool exit = false;

            while (exit == false)
            {



                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7. Exit");
                Console.Write("Choose option: ");


                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        lastIndex++; //4

                        Console.Write("Title: ");
                        titles[lastIndex] = Console.ReadLine();

                        Console.Write("Author: ");
                        authors[lastIndex] = Console.ReadLine();

                        Console.Write("ISBN: ");
                        isbns[lastIndex] = Console.ReadLine();

                        available[lastIndex] = true;
                        borrowers[lastIndex] = "";

                        Console.WriteLine("Book added");
                        break;

                    case 2: //borrowing

                        Console.Write("Enter ISBN or Title: ");
                        string Input = Console.ReadLine();

                        //flag = false
                        //for()
                        {

                            //if found something
                            //flag = true

                            //do something

                            //break;
                        }

                        //flag == false
                        //print not found






                        bool Found = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == Input  || isbns[i]==Input )
                            { 
                                //book is found in system
                                Found = true;

                                if (available[i] == true)
                                {
                                    Console.Write("Borrower name: ");
                                    borrowers[i] = Console.ReadLine();
                                    available[i] = false;
                                    Console.WriteLine("Book borrowed successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Book already borrowed");
                                }

                                break;


                            }

                        }

                        if (Found == false)
                        {
                            Console.WriteLine("Book not found");
                        }



                        break;



                    case 3:


                        Console.Write("Enter ISBN or Title: ");
                        string input = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == input || isbns[i] == input)
                            {
                                //book is found in system
                                found = true;



                                    borrowers[i] = "";
                                    available[i] = true;
                                    Console.WriteLine("Book returned successfully");
                                


                                break;


                            }

                        }

                        if (found == false)
                        {
                            Console.WriteLine("Book not found");
                        }




                        break;










                    case 4:


                        Console.Write("Enter ISBN or Title: ");
                        string INPUT = Console.ReadLine();

                        bool FOUND = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == INPUT || isbns[i] == INPUT)
                            {
                                //book is found in system
                                FOUND = true;


                                Console.WriteLine("Book title: " + titles[i] + ", Book Author:" + authors[i] + ", Book ISBN:" +  isbns[i] + ", Book availability:" + available[i] );



                                break;


                            }

                        }

                        if (FOUND == false)
                        {
                            Console.WriteLine("Book not found");
                        }




                        break;











                    case 5: //print all availbel books

                            Console.WriteLine("Available Books:");

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (available[i] == true)
                                {
                                    Console.WriteLine("Title: " + titles[i] + " Author: " + authors[i] + " ISBN: " + isbns[i]);
                                }
                            }
                        

                        break;


                    case 6:


                        Console.Write("Enter first borrower name:");
                        string firstBorrower = Console.ReadLine();


                        Console.Write("Enter second borrower name:");
                        string secondBorrower = Console.ReadLine();


                        bool firstBorrowerFound = false;
                         int firstBorrowerIndex = 0;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (firstBorrower == borrowers[i])
                            {
                                firstBorrowerIndex = i; // مكان / رقم تواجد الشخص الاول


                                firstBorrowerFound = true;
                                break;

                            }
                        }
                        if (firstBorrowerFound == false)
                        {
                            Console.WriteLine("current borrower name not found");
                        }
                        else
                        {
                            bool secondBorrowerFound = false;
                            int secondBorrowerIndex = 0;
                            for (int i = 0; i < 100; i++)
                            {
                                if (secondBorrower == borrowers[i])
                                {
                                    secondBorrowerIndex = i;//مكان / رقم تواجد الشخص التانى

                                    secondBorrowerFound = true;
                                    break;

                                }
                            }
                            if (secondBorrowerFound == false)
                            {
                                Console.WriteLine("New borrower name not found");
                            }
                            else
                            {

                                string temp = "";

                                temp = borrowers[firstBorrowerIndex];

                                borrowers[firstBorrowerIndex] = borrowers[secondBorrowerIndex];

                                borrowers[secondBorrowerIndex] = temp;

                            }
                        }

                





                break;


                    case 7:

                        Console.WriteLine("Exiting program...");
                        Console.WriteLine("-----------------------------");
                        exit = true;

                        break;


                  default:

                        Console.WriteLine("Invalid option. Please try again.");

                        break;







                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }





        }
    }
}
