namespace mis_221_pa_5_whsodergren
{
    public class Reports
    {
        Transactions[] transactions;

        public Reports(Transactions[] transactions) {
            this.transactions = transactions;
        }
        // Method for viewing individual customer sessions report
        public void ViewIndividualSessions() {
            System.Console.WriteLine("Enter the email of the customer you would like to view");
            string searchEmail = Console.ReadLine();

            StreamReader transactionFile = new StreamReader("transactions.txt");
            Transactions.SetCount(0);
            string line = transactionFile.ReadLine();
            while(line != null) {
                string[] temp = line.Split("#");
                if(temp[2] == searchEmail) {
                    string customerName = temp[1];
                    string trainingDate = temp[3];
                    System.Console.WriteLine($"Customer Name: {customerName}. Date of Previous Training Sessions: {trainingDate}");
                    Transactions.IncCount();
                }
                line = transactionFile.ReadLine();
            }
            transactionFile.Close();    

        }

        public void ViewHistoricalSessions() {
            string curr = transactions[0].GetCustomerName();
            string sessionDate = transactions[0].GetSessionDate();
            int sessionCount = 1;
            for(int i = 1; i < Transactions.GetCount(); i++) {
                if(transactions[i].GetCustomerName() == curr) {
                    sessionCount++;
                }
                else {
                    sessionDate = transactions[i].GetSessionDate();
                    ProcessBreak(ref curr, ref sessionDate, ref sessionCount, transactions[i]);
                }
            }
            System.Console.WriteLine($"Customer Name: {curr}. Date of Training Session: {sessionDate}. Total number of sessions attended: {sessionCount}");
        }

        public void ProcessBreak(ref string curr, ref string sessionDate, ref int sessionCount, Transactions newTransaction) {
            System.Console.WriteLine($"Customer Name: {curr}. Date of Training Session: {sessionDate}. Total number of sessions attended: {sessionCount}");
            curr = newTransaction.GetCustomerName();
            sessionCount = 1;
        }


        public void ViewHistoricalRevenue() {
            StreamReader listingFile = new StreamReader("listings.txt");
            decimal totalRevenue = 0;
            string line = listingFile.ReadLine();
            while (line != null) {
                string[] temp = line.Split("#");
                DateTime sessionDate = DateTime.Parse(temp[2]);
                decimal sessionCost = decimal.Parse(temp[4]);
                string sessionStatus = temp[5];
                if (sessionDate.Year == DateTime.Now.Year && sessionStatus == "Booked") {
                    totalRevenue += sessionCost;
                }
                line = listingFile.ReadLine();
            }
            listingFile.Close();
            System.Console.WriteLine($"Total revenue for {DateTime.Now.Year}: {totalRevenue}");
        }



            

        
    }
}
