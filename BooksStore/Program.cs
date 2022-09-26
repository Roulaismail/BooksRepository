using BooksDbContext.Models;
using BooksDbContext.Repositories;



namespace BooksStore
{
    internal class Program
    {
        
       

      public static InitialDBFromJson initialDBFromJson = new InitialDBFromJson();
      public static UsersRepository usersRepository = new UsersRepository();
      public static BooksRepository bookssRepository = new BooksRepository();


        static void Main(string[] args)
        {

            initialDBFromJson.InitalDB();
            Lb:
            Console.WriteLine("Enter UserName:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter PassWord:");
            string password=Console.ReadLine(); 
            User user=new User() { UserName=username,PassWord=password};
            bool isLogged=usersRepository.Login(user);

            if (isLogged)
            {
                Console.WriteLine("Login Success ");
                Console.WriteLine("Our Tasks are:");
                Console.WriteLine("1-View Total Informations");
                Console.WriteLine("2-View Book Information");
                Console.WriteLine("3-Delete Book");
                Console.WriteLine("4-Edit Book");

                while (true)
                {
                    Console.Write("Enter Your Task: ");
                    int taskNumber = Convert.ToInt32(Console.ReadLine());
                    switch (taskNumber)
                    {
                        case 1:
                            viewGeneralInformationsUI();
                            break;
                        case 2:
                            viewBookDetailsUI();
                            break;
                        case 3:
                            viewDeleteBookUI();
                            break;
                        case 4:
                            viewEditBookUI();
                            break;
                        default:
                            Console.WriteLine("Task Number Error");
                            break;
                    }
                    Console.WriteLine("If you need to stop press 0");
                    string? isStop=Console.ReadLine();
                    if (isStop=="0")
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Login Failed");
                goto Lb;
            }

        }
        public static void viewGeneralInformationsUI()
        {
            foreach (Book item in bookssRepository.GetBooks())
            {
                Console.WriteLine($"Id:{item.Id},title:{item.Title},Copies:{item.CopiesNumber}");
            }
            int totalCopies = bookssRepository.getTotalCopies();
            Console.WriteLine($"Total Copies:{totalCopies}");
        }
        public static void viewBookDetailsUI()
        {
            Console.WriteLine("Enter Book Id To View Details:");
            int BookId = Convert.ToInt32(Console.ReadLine());
            Book book = bookssRepository.getBookById(BookId);
            Console.WriteLine($"Id:{book.Id}, title:{book.Title},Auther:{book.AutherName},Description:{book.Description},Copies:{book.CopiesNumber}");
        }
        public static void viewDeleteBookUI()
        {
            Console.WriteLine("Enter Book Id To Remove:");
            int BookId = Convert.ToInt32(Console.ReadLine());
            bool isDeleted = bookssRepository.removeBook(BookId);
            if (isDeleted)
            {
                Console.WriteLine("Deleted SuccesFulley");
            }
            else
            {
                Console.WriteLine("Error in Deleting");
            }
        }
        public static void viewEditBookUI()
        {
            Console.WriteLine("Enter Book Id To Edit:");
            int BookId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Price");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Title");
            string? title = Console.ReadLine();
            bookssRepository.editBook(price, title, BookId);
        }
    }
}