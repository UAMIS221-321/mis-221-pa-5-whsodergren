namespace mis_221_pa_5_whsodergren
{
    public class ListingUtility
    {
        private Listings[] listings;
        private Trainers[] trainers;

        public ListingUtility(Listings[] listings, Trainers[] trainers) {
            this.listings = listings;
            this.trainers = trainers;

        }


        public void AddListing() {
            Listings newListing = new Listings();
            TrainerUtility displayTrainers = new TrainerUtility(trainers);
            displayTrainers.GetAllTrainersFromFile();
            displayTrainers.PrintAllTrainers();
            try {
                newListing.SetListingId(GenerateListingId());
                System.Console.WriteLine("Please enter trainer name");
                newListing.SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter date of training session");
                newListing.SetSessionDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the time of the training session");
                newListing.SetSessionTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the cost of the session");
                newListing.SetSessionCost(decimal.Parse(Console.ReadLine()));
                System.Console.WriteLine("Is the session available, booked, completed, or canceled?");
                newListing.SetSessionStatus(Console.ReadLine());

                listings[Listings.GetCount()] = newListing;
                Listings.IncCount();

                Save();
                System.Console.WriteLine("Listing added!");
            }
            catch (FormatException e) {
                System.Console.WriteLine("Error: " + e.Message);
                System.Console.WriteLine("Please enter a valid cost");
            }
            catch (Exception e) {
                System.Console.WriteLine("Error: " + e.Message);
                System.Console.WriteLine("Failed to add listing");
            }
        }


        public void EditListing() {
            try {
                System.Console.WriteLine("Enter the listing ID of the listing you want to edit");
                string search = Console.ReadLine();
                int foundIndex = Find(search);
                if(foundIndex != -1) {
                    listings[foundIndex].SetListingId(GenerateListingId());
                    System.Console.WriteLine("Please enter trainer name");
                    listings[foundIndex].SetTrainerName(Console.ReadLine());
                    System.Console.WriteLine("Please enter date of training session");
                    listings[foundIndex].SetSessionDate(Console.ReadLine());
                    System.Console.WriteLine("Please enter the time of the training session");
                    listings[foundIndex].SetSessionTime(Console.ReadLine());
                    System.Console.WriteLine("Please enter the cost of the session");
                    listings[foundIndex].SetSessionCost(decimal.Parse(Console.ReadLine()));
                    System.Console.WriteLine("Is the session booked? Type yes or no");
                    listings[foundIndex].SetSessionStatus(Console.ReadLine());

                    Save();
                }
                else {
                    System.Console.WriteLine("Listing not found");
                }
            }
            catch (Exception e) {
                System.Console.WriteLine("An error occurred while editing the listing: " + e.Message);
            }
        }

        public void DeleteListing() {
            System.Console.WriteLine("Enter the name of the listing you would like to delete");
            string search = Console.ReadLine();
            int foundIndex = Find(search);
            if(foundIndex != -1) {
                for(int i = foundIndex; i < Listings.GetCount(); i++) {
                    listings[i] = listings[i + 1];
                }
                Listings.DecCount();
                Save();
                System.Console.WriteLine("Listing deleted!");
            }
            else {
                System.Console.WriteLine("Trainer not found");
            }
        }

        public void GetAllListingsFromFile() {
            try {
                //open
                StreamReader inFile = new StreamReader("listings.txt");

                //process
                Listings.SetCount(0);
                string line = inFile.ReadLine();
                while(line != null) {
                    string[] temp = line.Split('#');
                    listings[Listings.GetCount()] = new Listings(int.Parse(temp[0]), temp[1], temp[2], temp[3], decimal.Parse(temp[4]), temp[5]);
                    Listings.IncCount();
                    line = inFile.ReadLine();
                }

                //close
                inFile.Close();
            }
            catch (Exception e) {
                System.Console.WriteLine("An error occurred while reading listings from file: " + e.Message);
            }
        }

        public void PrintAllListings() {
            for(int i = 0; i < Listings.GetCount(); i++) {
                System.Console.WriteLine(listings[i].ListingToString());
            }
        }

        public void Save() {
            StreamWriter outFile = new StreamWriter("listings.txt", true);
            for(int i = 0; i < Listings.GetCount(); i++) {
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.WriteLine();
            outFile.Close();
        }

        private int Find(string search) {
            for(int i = 0; i < Listings.GetCount(); i++) {
                if(listings[i].GetTrainerName().ToUpper() == search.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }


        public int GenerateListingId() {
            int maxId = 0;
            for (int i = 0; i < Listings.GetCount(); i++) {
                if (listings[i].GetListingId() > maxId) {
                    maxId = listings[i].GetListingId();
                }
            }
            for (int i = 1; i <= maxId; i++) {
                bool idTaken = false;
                for (int j = 0; j < Trainers.GetCount(); j++) {
                    if (listings[j].GetListingId() == i) {
                        idTaken = true;
                        break;
                    }
                }
                if (!idTaken) {
                    return i;
                }
            }
            return maxId + 1;
        }

        
    }
}
