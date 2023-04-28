namespace mis_221_pa_5_whsodergren
{
    public class Trainers
    {
        private int trainerId;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;
        static private int trainerCount;


        //no arg constructer
        public Trainers() {

        }
        
        //arg constructer 1
        public Trainers(int trainerId, string trainerName, string mailingAddress, string trainerEmail) {
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmail = trainerEmail;

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


        public void SetMailingAddress(string mailingAddress) {
            this.mailingAddress = mailingAddress;
        }

        public string GetMailingAddress() {
            return mailingAddress;
        }


        public void SetTrainerEmail(string trainerEmail) {
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail() {
            return trainerEmail;
        }


        static public void SetCount(int trainerCount) {
            Trainers.trainerCount = trainerCount;
        }

        static public void IncCount() {
            Trainers.trainerCount++;
        }
        static public void DecCount() {
            Trainers.trainerCount--;
        }

        static public int GetCount() {
            return Trainers.trainerCount;
        }


        public string TrainerToString()
        {
            return $"Trainer ID: {trainerId}, Trainer Name: {trainerName}, Mailing Address: {mailingAddress}, Email: {trainerEmail}";
        }


        public string TrainerToFile()
        {
            return $"{trainerId}#{trainerName}#{mailingAddress}#{trainerEmail}";
        }
    }
}




    