namespace mis_221_pa_5_whsodergren
{
    public class TrainerUtility
    {
        private Trainers[] trainers;

        public TrainerUtility(Trainers[] trainers) {
            this.trainers = trainers;

        }


        public void GetAllTrainersFromFile() {
            try {
                //open
                StreamReader inFile = new StreamReader("trainers.txt");

                //process
                Trainers.SetCount(0);
                string line = inFile.ReadLine();
                while (line != null) {
                    string[] temp = line.Split('#');
                    int id;
                    if (int.TryParse(temp[0], out id)) {
                        trainers[Trainers.GetCount()] = new Trainers(id, temp[1], temp[2], temp[3]);
                        Trainers.IncCount();
                    }
                    else {
                        throw new InvalidDataException($"Invalid Format on Line {line}");
                    }
                    line = inFile.ReadLine();
                }

                //close
                inFile.Close();
            }
            catch (FileNotFoundException) {
                Console.WriteLine("File not found: trainers.txt");
            }
            catch (IOException e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
            catch (Exception e) {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public void PrintAllTrainers() {
            for(int i = 0; i < Trainers.GetCount(); i++) {
                System.Console.WriteLine(trainers[i].TrainerToString());
            }
        }

        public void AddTrainer() {
            try {
                Trainers myTrainer = new Trainers();
                myTrainer.SetTrainerId(GenerateTrainerId());
                Console.WriteLine("Please enter the trainer name");
                myTrainer.SetTrainerName(Console.ReadLine());
                Console.WriteLine("Please enter the trainer mailing address");
                myTrainer.SetMailingAddress(Console.ReadLine());
                Console.WriteLine("Please enter the trainer email");
                myTrainer.SetTrainerEmail(Console.ReadLine());

                trainers[Trainers.GetCount()] = myTrainer;
                Trainers.IncCount();

                Save();
                Console.WriteLine("Trainer added!");
            }
            catch (Exception e) {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public void EditTrainer() {
            try {
                Console.Clear();
                Console.WriteLine("Enter the name of the trainer you would like to update");
                string search = Console.ReadLine();
                int foundIndex = Find(search);
                if (foundIndex != -1) {
                    trainers[foundIndex].SetTrainerId(GenerateTrainerId());
                    Console.WriteLine("Please enter the trainer name");
                    trainers[foundIndex].SetTrainerName(Console.ReadLine());
                    Console.WriteLine("Please enter the trainer mailing address");
                    trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                    Console.WriteLine("Please enter the trainer email");
                    trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                    Save();
                    Console.WriteLine("Trainer updated!");
                }
                else {
                    Console.WriteLine("Trainer not found");
                }
            }
            catch (Exception e) {
                Console.WriteLine($"An error occurred: {e.Message}");
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