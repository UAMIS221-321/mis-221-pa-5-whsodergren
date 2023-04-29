namespace mis_221_pa_5_whsodergren
{
    public class Reports
    {
        private Transactions[] transactions;
        private Trainers[] trainers;
        private Listings[] listings;

        public Reports(Transactions[] transactions, Trainers[] trainers, Listings[] listings) {
            this.transactions = transactions;
            this.trainers = trainers;
            this.listings = listings;
        }
        // Method for viewing individual customer sessions report
        public void ViewIndividualSessions() {
            try {
                Console.WriteLine("Enter the email of the customer you would like to view:");
                string searchEmail = Console.ReadLine();

                bool foundTransaction = false;
                for (int i = 0; i < Transactions.GetCount(); i++) {
                    if(searchEmail == transactions[i].GetCustomerEmail()) {
                        System.Console.WriteLine(transactions[i].TransactionToString());
                        foundTransaction = true;
                        System.Console.WriteLine("Would you like to save this report to a file? Yes or No");
                        string userInput = Console.ReadLine();
                        if (userInput == "Yes") {
                            SaveToFile(transactions);
                        }

                    }
                }
                if (!foundTransaction) {
                    System.Console.WriteLine("No Transactions Found!");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewHistoricalSessions() {
            TransactionUtility transactionReport = new TransactionUtility(transactions);
            System.Console.WriteLine("First will be sessions sorted by customer");
            SortByCustomer(transactions);
            transactionReport.PrintAllTransactions();
            Console.ReadKey();
            System.Console.WriteLine("Next wll be sessions sorted by dates");
            SortByDate(transactions);
            transactionReport.PrintAllTransactions();
            System.Console.WriteLine("Would you like to save the report? Yes or No");
            string userInput = Console.ReadLine();
            if(userInput == "Yes") {
                SaveToFile(transactions);
            }
            
        }


        public void ViewHistoricalRevenue() {
            try {
                string months = "Janurary Feburary March April May June July August September October November Decemeber";
                string days = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31";
                string[] calenderMonths = months.Split(' ');
                string[] calenderDays = days.Split(',');
                decimal monthlyRevenue = 0;
                for (int i = 0; i < Transactions.GetCount(); i++) {
                    for (int j = 0; j < calenderMonths.Length; j++) {
                        for (int k = 0; k < calenderDays.Length; k++) { 
                            
                            if (calenderMonths[j].ToUpper() + " " + calenderDays[k] == transactions[i].GetSessionDate().ToUpper()) {
                                months = calenderMonths[j];
                                monthlyRevenue += listings[i].GetSessionCost();
                                
                            }
                        }
                    }
                    
                }
                System.Console.WriteLine($"The Total Revenue for {months} is... ${monthlyRevenue}");
                SaveToFile(transactions);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void SaveToFile(Transactions[] transactions) {
            System.Console.WriteLine("Saving to File!");
                string saveFile = "reports.txt";

                StreamWriter toReportingFile = new StreamWriter(saveFile);

                for (int i = 0; i < Transactions.GetCount(); i++) {
                    toReportingFile.WriteLine(transactions[i].TransactionToFile());
                }
                toReportingFile.Close();
        }


        public void SortByCustomer(Transactions[] transactions)
        {
            for (int i = 0; i < Transactions.GetCount(); i++)
            {
                int min = i;

                for (int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if (transactions[j].GetCustomerName().CompareTo(transactions[min].GetCustomerName() ) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    SwapCustomers(min, i, transactions);
                }
            }
        }

        public void SortByDate(Transactions[] transactions)
        {
            
            for (int i = 0; i < Transactions.GetCount(); i++)
            {
                int totalSessions = 0;
                int min = i;

                for (int j = i + 1; j < Transactions.GetCount(); j++)
                {
                  
                    if (transactions[j].GetSessionDate().CompareTo(transactions[min].GetSessionDate() ) < 0)
                    {
                        min = j;
                        
                    }      
                   
                }
                if (min != i)
                {
                 SwapCustomers(min, i, transactions);
                }
                
            }
        }


  
          
        public void SwapCustomers(int x, int y, Transactions[] transactions) {

            Transactions temp = transactions[x];
            transactions[x] = transactions[y];
            transactions[y] = temp;

        }

            
    }
}
