namespace mis_221_pa_5_whsodergren
{
    public class TransactionUtility
    {
        
        private Transactions[] transactions;
        public TransactionUtility(Transactions[] transactions) {
            this.transactions = transactions;
        }
        
          
        public void ViewAvailableSessions() {
            try {
                StreamReader inFile = new StreamReader("listings.txt");
                string line = inFile.ReadLine();
                while (line != null) {
                    string[] temp = line.Split('#');
                    if(temp.Length >= 6 && temp[5].Trim().Equals("Available")) {
                        // Display available sessions
                        System.Console.WriteLine($"Listing ID: {temp[0]}");
                        System.Console.WriteLine($"Trainer Name: {temp[1]}");
                        System.Console.WriteLine($"Date of Session: {temp[2]}");
                        System.Console.WriteLine($"Time of Session: {temp[3]}");
                        System.Console.WriteLine($"Cost of Session: {temp[4]}");
                        System.Console.WriteLine($"Status: {temp[5]}");
                        System.Console.WriteLine();
                    }
                    line = inFile.ReadLine();
                }
                inFile.Close();
            }
            catch (FileNotFoundException e) {
                System.Console.WriteLine($"Error: {e.Message}");
            }
            catch (IOException e) {
                System.Console.WriteLine($"Error: {e.Message}");
            }
        }





        public void BookSession() {
            Transactions newTransaction = new Transactions();
            ViewAvailableSessions();

            try {
                System.Console.WriteLine("Please Enter your Name");
                newTransaction.SetCustomerName(Console.ReadLine());

                System.Console.WriteLine("Please Enter your Email Address");
                newTransaction.SetCustomerEmail(Console.ReadLine());

                System.Console.WriteLine("Enter the Listing ID of the Listing you would like to book");
                string listingId = Console.ReadLine();

                // Open listings.txt file and search for the listing with the specified id
                using (StreamReader inFile = new StreamReader("listings.txt")) {
                    string line = inFile.ReadLine();
                    while (line != null) {
                        string[] temp = line.Split('#');
                        if (temp[0].Equals(listingId) && temp[5].Trim().Equals("Available")) {
                            // Get the trainer name from listings.txt
                            string trainerName = temp[1];

                            // Get the trainer id from trainers.txt that corresponds with the name
                            using (StreamReader trainersFile = new StreamReader("trainers.txt")) {
                                string trainersLine = trainersFile.ReadLine();
                                while (trainersLine != null) {
                                    string[] trainersTemp = trainersLine.Split('#');
                                    if (trainersTemp[1].Equals(trainerName)) {
                                        newTransaction.SetTrainerId(int.Parse(trainersTemp[0]));
                                        break;
                                    }
                                    trainersLine = trainersFile.ReadLine();
                                }
                                trainersFile.Close();
                            }

                            // Set the properties of the transaction
                            newTransaction.SetSessionId(int.Parse(listingId));
                            newTransaction.SetTrainerName(trainerName);

                            System.Console.WriteLine("Enter the Training Date (format: YYYY-MM-DD)");
                            string dateStr = Console.ReadLine();
                            DateTime date;
                            if (!DateTime.TryParse(dateStr, out date)) {
                                throw new FormatException("Invalid date format, please enter a date in the format: YYYY-MM-DD");
                            }
                            newTransaction.SetSessionDate(dateStr);
                            newTransaction.SetSessionStatus("Completed");

                            // Append the transaction to the transactions.txt file
                            using (StreamWriter outFile = new StreamWriter("transactions.txt", true)) {
                                outFile.WriteLine($"{newTransaction.GetSessionId()}#{newTransaction.GetCustomerName()}#{newTransaction.GetCustomerEmail()}#{newTransaction.GetSessionDate()}#{newTransaction.GetTrainerId()}#{newTransaction.GetTrainerName()}#{newTransaction.GetSessionStatus()}");
                            }

                            // Update the status of the listing in listings.txt
                            string[] fileContent = File.ReadAllLines("listings.txt");
                            for (int i = 0; i < fileContent.Length; i++) {
                                string[] content = fileContent[i].Split('#');
                                if (content[0].Equals(listingId)) {
                                    content[5] = "Booked";
                                    fileContent[i] = String.Join("#", content);
                                    break;
                                }
                            }
                            File.WriteAllLines("listings.txt", fileContent);

                            System.Console.WriteLine("Your session has been successfully booked!");
                            return;
                        }
                        line = inFile.ReadLine();
                    }
                    System.Console.WriteLine("Invalid Listing ID or the listing is not available");
                }
            } catch (FileNotFoundException ex) {
                System.Console.WriteLine($"File not found: {ex.Message}");
            } catch (IOException ex) {
                System.Console.WriteLine($"An I/O error occurred: {ex.Message}");
            } catch (FormatException ex) {
                System.Console.WriteLine($"Invalid input format: {ex.Message}");
            } catch (Exception ex) {
                System.Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public void GetAllTransactionsFromFile() {
            //open
            StreamReader inFile = new StreamReader("transactions.txt");

            //process
            Transactions.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) {
                string[] temp = line.Split('#');
                try {
                    transactions[Transactions.GetCount()] = new Transactions(int.Parse(temp[0]), temp[1], (temp[2]), temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                    Transactions.IncCount();
                }
                catch (FormatException e) {
                    Console.WriteLine($"Error parsing integer value: {e.Message}");
                }
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
        }


        public void PrintAllTransactions() {
            for(int i = 0; i < Transactions.GetCount(); i++) {
                System.Console.WriteLine(transactions[i].TransactionToString());
            }
        }



    }
}