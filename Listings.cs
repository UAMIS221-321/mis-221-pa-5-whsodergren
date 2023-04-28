namespace mis_221_pa_5_whsodergren
{
    public class Listings
    {
        public int listingId;
        private string trainerName;
        private DateTime sessionDate;
        private string sessionTime;
        private decimal sessionCost;
        private string sessionStatus;
        static private int listingCount;

        public Listings() {

        }

        public Listings(int listingId, string trainerName, DateTime sessionDate, string sessionTime, decimal sessionCost, string sessionStatus) {
           this.listingId = listingId;
           this.trainerName = trainerName;
           this.sessionDate = sessionDate;
           this.sessionTime = sessionTime;
           this.sessionCost = sessionCost;
           this.sessionStatus = sessionStatus;


        }


        public void SetListingId(int listingId) {
            this.listingId = listingId;
        }

        public int GetListingId() {
            return listingId;
        }

         public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        
        public void SetSessionDate(DateTime sessionDate) {
            this.sessionDate = sessionDate;
        }

        public DateTime GetSessionDate() {
            return sessionDate;
        }

        public void SetSessionTime(string sessionTime) {
            this.sessionTime = sessionTime;
        }

        public string GetSessionTime() {
            return sessionTime;
        }

        public void SetSessionCost(decimal sessionCost) {
            this.sessionCost = sessionCost;
        }

        public decimal GetSessionCost() {
            return sessionCost;
        }

        public void SetSessionStatus(string sessionStatus) {
            this.sessionStatus = sessionStatus;
        }

        public string GetSessionStatus() {
            return sessionStatus;
        }

        static public void SetCount(int listingCount) {
            Listings.listingCount = listingCount;
        }

        static public void IncCount() {
            Listings.listingCount++;
        }
        static public void DecCount() {
            Listings.listingCount--;
        }

        static public int GetCount() {
            return Listings.listingCount;
        }

        public string ListingToString() {
            return $"Listing ID: {listingId}, Trainer: {trainerName}, Session Date: {sessionDate}, Session Time: {sessionTime}, Session Cost: {sessionCost}, Session status: {sessionStatus}";
        }

        public string ToFile() {
            return $"{listingId}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{sessionStatus}";
        }






    
    }
}