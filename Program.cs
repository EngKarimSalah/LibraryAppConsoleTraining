namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System Storage - Version 2
            string[] titles = new string[100];
            string[] authors = new string[100];
            string[] isbns = new string[100];
            bool[] available = new bool[100];
            string[] borrowers = new string[100];
            string[] categories = new string[100]; // NEW
            int[] borrowCount = new int[100]; // NEW
            double[] lateFees = new double[100]; // NEW

            int lastIndex = 0;

            // Seed Data with new fields
            titles[lastIndex] = "MATH";
            authors[lastIndex] = "HASNA";
            isbns[lastIndex] = "111";
            available[lastIndex] = true;
            borrowers[lastIndex] = "";
            categories[lastIndex] = "Science"; // NEW
            borrowCount[lastIndex] = 5; // NEW
            lateFees[lastIndex] = 0; // NEW

            lastIndex++;

            titles[lastIndex] = "Algorithms";
            authors[lastIndex] = "HOOR";
            isbns[lastIndex] = "222";
            available[lastIndex] = true;
            borrowers[lastIndex] = "";
            categories[lastIndex] = "Computer Science"; // NEW
            borrowCount[lastIndex] = 8; // NEW
            lateFees[lastIndex] = 0; // NEW

            lastIndex++;

            titles[lastIndex] = "Sciences";
            authors[lastIndex] = "NOOR";
            isbns[lastIndex] = "333";
            available[lastIndex] = false;
            borrowers[lastIndex] = "Karim";
            categories[lastIndex] = "Science"; // NEW
            borrowCount[lastIndex] = 3; // NEW
            lateFees[lastIndex] = 0; // NEW

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("===== Library Management System V2 =====");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. List All Available Books");
                Console.WriteLine("6. Transfer Book");
                Console.WriteLine("7. View Most Popular Books"); // NEW
                Console.WriteLine("8. Search Books by Category"); // NEW
                Console.WriteLine("9. Calculate Total Late Fees"); // NEW
                Console.WriteLine("10. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: // Add New Book
                        lastIndex++;

                        Console.Write("Title: ");
                        titles[lastIndex] = Console.ReadLine();

                        Console.Write("Author: ");
                        authors[lastIndex] = Console.ReadLine();

                        Console.Write("ISBN: ");
                        isbns[lastIndex] = Console.ReadLine();

                        Console.Write("Category: "); // NEW
                        categories[lastIndex] = Console.ReadLine();

                        available[lastIndex] = true;
                        borrowers[lastIndex] = "";
                        borrowCount[lastIndex] = 0; // NEW
                        lateFees[lastIndex] = 0; // NEW

                        Console.WriteLine("Book added successfully!");
                        break;

                    case 2: // Borrow Book - UPDATED
                        Console.Write("Enter ISBN or Title: ");
                        string borrowInput = Console.ReadLine();

                        bool borrowFound = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == borrowInput || isbns[i] == borrowInput)
                            {
                                borrowFound = true;

                                if (available[i] == true)
                                {
                                    Console.Write("Borrower name: ");
                                    borrowers[i] = Console.ReadLine();
                                    available[i] = false;
                                    borrowCount[i]++; // NEW - Increment borrow count
                                    lateFees[i] = 0; // NEW - Initialize late fees

                                    Console.WriteLine("Book borrowed successfully!");
                                    Console.WriteLine("This book has been borrowed " + borrowCount[i] + " times"); // NEW
                                }
                                else
                                {
                                    Console.WriteLine("Book already borrowed by: " + borrowers[i]);
                                }

                                break;
                            }
                        }

                        if (borrowFound == false)
                        {
                            Console.WriteLine("Book not found");
                        }

                        break;

                    case 3: // Return Book - UPDATED
                        Console.Write("Enter ISBN or Title: ");
                        string returnInput = Console.ReadLine();

                        bool returnFound = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == returnInput || isbns[i] == returnInput)
                            {
                                returnFound = true;

                                if (available[i] == false) // Check if book is actually borrowed
                                {
                                    Console.Write("Is the book returned late? (yes/no): "); // NEW
                                    string isLate = Console.ReadLine().ToLower();

                                    if (isLate == "yes")
                                    {
                                        Console.Write("Enter number of days late: "); // NEW
                                        int daysLate = int.Parse(Console.ReadLine());
                                        double feePerDay = 0.5;
                                        lateFees[i] = daysLate * feePerDay; // NEW - Calculate late fee

                                        Console.WriteLine("Late fee calculated: " + lateFees[i] + " OMR"); // NEW
                                    }
                                    else
                                    {
                                        Console.WriteLine("Book returned on time"); // NEW
                                        lateFees[i] = 0;
                                    }

                                    borrowers[i] = "";
                                    available[i] = true;
                                    Console.WriteLine("Book returned successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("This book was not borrowed");
                                }

                                break;
                            }
                        }

                        if (returnFound == false)
                        {
                            Console.WriteLine("Book not found");
                        }

                        break;

                    case 4: // Search Book
                        Console.Write("Enter ISBN or Title: ");
                        string searchInput = Console.ReadLine();

                        bool searchFound = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (titles[i] == searchInput || isbns[i] == searchInput)
                            {
                                searchFound = true;

                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Book Title: " + titles[i]);
                                Console.WriteLine("Author: " + authors[i]);
                                Console.WriteLine("ISBN: " + isbns[i]);
                                Console.WriteLine("Category: " + categories[i]); // NEW
                                Console.WriteLine("Available: " + available[i]);
                                Console.WriteLine("Times Borrowed: " + borrowCount[i]); // NEW
                                if (available[i] == false)
                                {
                                    Console.WriteLine("Current Borrower: " + borrowers[i]);
                                }
                                Console.WriteLine("----------------------------------------");

                                break;
                            }
                        }

                        if (searchFound == false)
                        {
                            Console.WriteLine("Book not found");
                        }

                        break;

                    case 5: // List All Available Books
                        Console.WriteLine("Available Books:");
                        Console.WriteLine("----------------------------------------");

                        bool hasAvailable = false;
                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (available[i] == true)
                            {
                                Console.WriteLine("Title: " + titles[i] + " | Author: " + authors[i] + " | ISBN: " + isbns[i] + " | Category: " + categories[i]);
                                hasAvailable = true;
                            }
                        }

                        if (hasAvailable == false)
                        {
                            Console.WriteLine("No books available at the moment");
                        }

                        break;

                    case 6: // Transfer Book
                        Console.Write("Enter current borrower name: ");
                        string firstBorrower = Console.ReadLine();

                        Console.Write("Enter new borrower name: ");
                        string secondBorrower = Console.ReadLine();

                        bool firstBorrowerFound = false;
                        int firstBorrowerIndex = 0;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (firstBorrower == borrowers[i])
                            {
                                firstBorrowerIndex = i;
                                firstBorrowerFound = true;
                                break;
                            }
                        }

                        if (firstBorrowerFound == false)
                        {
                            Console.WriteLine("Current borrower name not found");
                        }
                        else
                        {
                            borrowers[firstBorrowerIndex] = secondBorrower;
                            Console.WriteLine("Book transferred successfully!");
                            Console.WriteLine("Book '" + titles[firstBorrowerIndex] + "' is now borrowed by " + secondBorrower);
                        }

                        break;

                    case 7: // NEW - View Most Popular Books
                        Console.WriteLine("Most Popular Books (by borrow count):");
                        Console.WriteLine("----------------------------------------");

                        // Simple sorting by displaying in order
                        for (int count = 100; count >= 0; count--) // Start from highest possible count
                        {
                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (borrowCount[i] == count)
                                {
                                    Console.WriteLine("ISBN: " + isbns[i] + " | Title: " + titles[i] + " | Author: " + authors[i] + " | Category: " + categories[i] + " | Times Borrowed: " + borrowCount[i]);
                                }
                            }
                        }

                        break;

                    case 8: // NEW - Search Books by Category
                        Console.Write("Enter category name: ");
                        string searchCategory = Console.ReadLine();

                        bool categoryFound = false;

                        Console.WriteLine("Books in category '" + searchCategory + "':");
                        Console.WriteLine("----------------------------------------");

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (categories[i].ToLower() == searchCategory.ToLower())
                            {
                                categoryFound = true;
                                string availabilityStatus = available[i] ? "Available" : "Borrowed";
                                Console.WriteLine("ISBN: " + isbns[i] + " | Title: " + titles[i] + " | Author: " + authors[i] + " | Status: " + availabilityStatus);
                            }
                        }

                        if (categoryFound == false)
                        {
                            Console.WriteLine("No books found in this category");
                        }

                        break;

                    case 9: // NEW - Calculate Total Late Fees
                        Console.WriteLine("Late Fees Report:");
                        Console.WriteLine("1. System-wide total");
                        Console.WriteLine("2. Individual borrower");
                        Console.Write("Choose option: ");
                        int feeOption = int.Parse(Console.ReadLine());

                        if (feeOption == 1)
                        {
                            // System-wide total
                            double totalFees = 0;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                totalFees += lateFees[i];
                            }

                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Total late fees collected: " + totalFees + " OMR");
                        }
                        else if (feeOption == 2)
                        {
                            // Individual borrower
                            Console.Write("Enter borrower name: ");
                            string borrowerName = Console.ReadLine();

                            double borrowerFees = 0;
                            bool borrowerFoundForFees = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (borrowers[i] == borrowerName || (borrowers[i] == "" && lateFees[i] > 0))
                                {
                                    // Check if this borrower had late fees
                                    borrowerFees += lateFees[i];
                                    borrowerFoundForFees = true;
                                }
                            }

                            Console.WriteLine("----------------------------------------");
                            if (borrowerFoundForFees == true)
                            {
                                Console.WriteLine("Late fees for " + borrowerName + ": " + borrowerFees + " OMR");
                            }
                            else
                            {
                                Console.WriteLine("No late fees found for this borrower");
                            }
                        }

                        break;

                    case 10: // Exit
                        Console.WriteLine("Exiting program...");
                        Console.WriteLine("Thank you for using Library Management System!");
                        Console.WriteLine("----------------------------------------");
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
