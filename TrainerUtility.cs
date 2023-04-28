namespace mis_221_pa_5_whsodergren
{
    public class TrainerUtility
    {
        private Trainers[] trainers;

        public TrainerUtility(Trainers[] trainers) {
            this.trainers = trainers;

        }


        public void GetAllTrainersFromFile() {
            //open
            StreamReader inFile = new StreamReader("trainers.txt");

            //process
            Trainers.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) {
                string[] temp = line.Split('#');
                int id;
                if (int.TryParse(temp[0], out id)) {
                    trainers[Trainers.GetCount()] = new Trainers(id, temp[1], temp[2], temp[3]);
                    Trainers.IncCount();
                } else {
                    System.Console.WriteLine($"Invalid Format on Line {line}");
                }
                line = inFile.ReadLine();
            }

            //close
            inFile.Close();
        }

        public void PrintAllTrainers() {
            for(int i = 0; i < Trainers.GetCount(); i++) {
                System.Console.WriteLine(trainers[i].TrainerToString());
            }
        }

        public void AddTrainer() {
            Trainers myTrainer = new Trainers();
            myTrainer.SetTrainerId(GenerateTrainerId());
            System.Console.WriteLine("Please enter the trainer name");
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer mailing address");
            myTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer email");
            myTrainer.SetTrainerEmail(Console.ReadLine());

            trainers[Trainers.GetCount()] = myTrainer;
            Trainers.IncCount();

            Save();
            System.Console.WriteLine("Trainer added!");
            
        }

        public void EditTrainer() {
            Console.Clear();
            System.Console.WriteLine("Enter the name of the trainer you would like to update");
            string search = Console.ReadLine();
            int foundIndex = Find(search);
            if (foundIndex != -1) {
                System.Console.WriteLine("Please enter the trainer ID");
                trainers[foundIndex].SetTrainerId(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the trainer name");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer mailing address");
                trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer email");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save();
                System.Console.WriteLine("Trainer updated!");
            }
            else {
                System.Console.WriteLine("Trainer not found");
            }
        }


        public void DeleteTrainer() {
            Console.Clear();
            PrintAllTrainers();
            System.Console.WriteLine("Enter the name of the trainer you would like to delete");
            string search = Console.ReadLine();
            int foundIndex = Find(search);
            if(foundIndex != -1) {
                for(int i = foundIndex; i < Trainers.GetCount(); i++) {
                    trainers[i] = trainers[i + 1];
                }
                Trainers.DecCount();
                Save();
                System.Console.WriteLine("Trainer Deleted!");
            }
            else {
                System.Console.WriteLine("Trainer not found");
            }
        }


        public void Save() {
            StreamWriter outFile = new StreamWriter("trainers.txt", true);
            for(int i = 0; i < Trainers.GetCount(); i++) {
                outFile.WriteLine(trainers[i].TrainerToFile());
            }
            outFile.WriteLine();
            outFile.Close();
        }

        private int Find(string search) {
            for(int i = 0; i < Trainers.GetCount(); i++) {
                if(trainers[i].GetTrainerName().ToUpper() == search.ToUpper()) {
                    return i;
                }
            }

            return -1;
        }


        public int GenerateTrainerId() {
            int maxId = 0;
            for (int i = 0; i < Trainers.GetCount(); i++) {
                if (trainers[i].GetTrainerId() > maxId) {
                    maxId = trainers[i].GetTrainerId();
                }
            }
            for (int i = 1; i <= maxId; i++) {
                bool idTaken = false;
                for (int j = 0; j < Trainers.GetCount(); j++) {
                    if (trainers[j].GetTrainerId() == i) {
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