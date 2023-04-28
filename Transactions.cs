namespace mis_221_pa_5_whsodergren
{
    public class Transactions
    {
        private int sessionId;
        private string customerName;
        private string customerEmail;
        private string sessionDate;
        private int trainerId;
        private string trainerName;
        private string sessionStatus;
        private static int transactionCount;

        

        public Transactions() {

        }


        public Transactions(int sessionId, string customerName, string customerEmail, string sessionDate, int trainerId, string trainerName, string sessionStatus) {
            this.sessionId = sessionId;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.sessionDate = sessionDate;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.sessionStatus = sessionStatus;

        }

        public void SetSessionId(int sessionId) {
            this.sessionId = sessionId;
        }

        public int GetSessionId() {
            return sessionId;
        }

        public void SetCustomerName(string customerName) {
            this.customerName = customerName;
        }

        public string GetCustomerName() {
            return customerName;
        }

        public void SetCustomerEmail(string customerEmail) {
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail() {
            return customerEmail;
        }

        public void SetSessionDate(string sessionDate) {
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate() {
            return sessionDate;
        }

        public void SetTrainerId(int trainerId) {
            this.trainerId = trainerId;
        }

        public int GetTrainerId() {
            return trainerId;
        }

         public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public void SetSessionStatus(string sessionStatus) {
            this.sessionStatus = sessionStatus;
        }

        public string GetSessionStatus() {
            return sessionStatus;
        }

        static public void SetCount(int transactionCount) {
            Transactions.transactionCount = transactionCount;
        }

        static public void IncCount() {
            Transactions.transactionCount++;
        }
        static public void DecCount() {
            Transactions.transactionCount--;
        }

        static public int GetCount() {
            return Transactions.transactionCount;
        }

        public string TransactionToString() {
            return $"Session ID: {sessionId}, Customer Name: {customerName}, Customer Email: {customerEmail}, Training Date: {sessionDate}, Trainer ID: {trainerId}, Trainer Name: {trainerName}, Session Status: {sessionStatus}";
        }

        public string TransactionToFile() {
            return $"{sessionId}#{customerName}#{customerEmail}#{sessionDate}#{trainerId}#{trainerName}#{sessionStatus}";
        }







    }
}