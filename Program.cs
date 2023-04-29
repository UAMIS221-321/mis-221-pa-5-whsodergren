//main
using mis_221_pa_5_whsodergren;

Trainers[] trainers = new Trainers[100];
TrainerUtility trainerUtility = new TrainerUtility(trainers);

Listings[] listings = new Listings[100];
ListingUtility listingUtility = new ListingUtility(listings, trainers);

Transactions[] transactions =  new Transactions[100];
TransactionUtility transactionUtility = new TransactionUtility(transactions);

Reports report = new Reports(transactions, trainers, listings);
transactionUtility.GetAllTransactionsFromFile();


bool exit = false;
while (!exit) {
    Console.Clear();

    System.Console.WriteLine("Welcome to Train Like a Champion - Personal Fitness\nIf you are an Employee Press 1\nIf you are a Customer Press 2\nIf you would like to Exit the Application Press 3.");
    int menuChoice = int.Parse(Console.ReadLine());

    switch(menuChoice) {
        case 1:
            EmployeeMenu();
            break;
        case 2:
            CustomerMenu();
            break;
        case 3:
            exit = true;
            break;
        default:
            System.Console.WriteLine("Invalid choice. Please try again.");
            break;

    }
}


void  EmployeeMenu() {

    bool exit = false;
    while(!exit) {
        Console.Clear();
        System.Console.WriteLine("Welcome to the Employee Menu!\nEnter 1 to Add a trainer\nEnter 2 to Edit a Trainer's information\nEnter 3 to Delete a Trainer from the System\nEnter 4 to View Current Trainers\nEnter 5 to Add a Listing\nEnter 6 to Edit Listing Information\nEnter 7 to Delete a Listing\nEnter 8 to View Current Listings\nEnter 9 to Access the Reports Menu\nEnter 10 to Return to the Main Menu");
        int menuChoice = int.Parse(Console.ReadLine());

        switch(menuChoice) {
            case 1:
                trainerUtility.AddTrainer();
                PauseAction();
                break;
            case 2:
                trainerUtility.EditTrainer();
                PauseAction();
                break;
            case 3:
                trainerUtility.DeleteTrainer();
                PauseAction();
                break;
            case 4:
                trainerUtility.GetAllTrainersFromFile();
                trainerUtility.PrintAllTrainers();
                PauseAction();
                break;
            case 5:
                listingUtility.AddListing();
                PauseAction();
                break;
            case 6:
                listingUtility.EditListing();
                PauseAction();
                break;
            case 7:
                listingUtility.DeleteListing();
                PauseAction();
                break;
            case 8:
                listingUtility.GetAllListingsFromFile();
                listingUtility.PrintAllListings();
                PauseAction();
                break;
            case 9:
                ViewReports();
                break;
            case 10:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
                    
        
        }
    }
}




void CustomerMenu() {
    bool exit = false;
    while(!exit) {
        Console.Clear();
        System.Console.WriteLine("Welcome to the Customer Menu!\nEnter 1 to View Available Training Session\nEnter 2 to Book a Training Session\nEnter 3 to Return to the Main Menu");
        int menuChoice = int.Parse(Console.ReadLine());

        switch(menuChoice) {
            case 1:
                transactionUtility.ViewAvailableSessions();
                PauseAction();
                break;
            case 2:
                transactionUtility.BookSession();
                PauseAction();
                break;
            case 3:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
                    
        
        }
    }

}






void ViewReports() {
    bool exit = false;
    while(!exit) {
        Console.Clear();
        System.Console.WriteLine("Report Menu\nEnter 1 to View Individual Customer Sessions\nEnter 2 to View Historical Customer Sessions\nEnter 3 to View a Historical Revenue Report\nEnter 4 to Return to the Main Menu");
        int menuChoice = int.Parse(Console.ReadLine());

        switch(menuChoice) {
            case 1:
                report.ViewIndividualSessions();
                PauseAction();
                break;
            case 2:
                report.ViewHistoricalSessions();
                PauseAction();
                break;
            case 3:
                report.ViewHistoricalRevenue();
                PauseAction();
                break;
            case 4:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
                    
        
        }
    }
}







static void PauseAction() {
     System.Console.WriteLine("Press Any Key to Continue");
    Console.ReadKey();
}







