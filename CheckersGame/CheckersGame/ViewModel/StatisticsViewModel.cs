using CheckersGame.DataAccess;
using System.IO;

namespace CheckersGame.ViewModel
{
    public class StatisticsViewModel : BaseNotification
    {
        private int redWinsNr;

        public int RedWinsNumber
        {
            get { return redWinsNr; }
            set
            {
                redWinsNr = value;
                NotifyPropertyChanged();
            }
        }


        private int blackWinsNr;

        public int BlackWinsNumber
        {
            get { return blackWinsNr; }
            set
            {
                blackWinsNr = value;
                NotifyPropertyChanged();
            }
        }


        private int redMaxPiecesNr;

        public int RedMaxPiecesNr
        {
            get
            {
                return redMaxPiecesNr;
            }
            set
            {
                redMaxPiecesNr = value;
                NotifyPropertyChanged();
            }
        }


        private int blackMaxPiecesNr;

        public int BlackMaxPiecesNr
        {
            get
            {
                return blackMaxPiecesNr;
            }
            set
            {
                blackMaxPiecesNr = value;
                NotifyPropertyChanged();
            }
        }

        public StatisticsViewModel()
        {
            LoadStatistics();
        }

        public void SaveStatistics()
        {
            string statisticsFilePath = ".\\..\\..\\Resources\\Statistics\\Statistics.txt";
            using (StreamWriter writer = new StreamWriter(statisticsFilePath))
            {
                writer.WriteLine(RedWinsNumber);
                writer.WriteLine(BlackWinsNumber);
                writer.WriteLine(RedMaxPiecesNr);
                writer.WriteLine(RedMaxPiecesNr);
            }
        }

        public void LoadStatistics()
        {
            string statisticsFilePath = ".\\..\\..\\Resources\\Statistics\\Statistics.txt";

            if (!File.Exists(statisticsFilePath))
            {
                throw new FileNotFoundException("Statistics file not found.", statisticsFilePath);
            }

            using (StreamReader reader = new StreamReader(statisticsFilePath))
            {
                for (int i = 0; i < 4; i++)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        switch (i)
                        {
                            case 0:
                                RedWinsNumber = int.Parse(line);
                                break;
                            case 1:
                                BlackWinsNumber = int.Parse(line);
                                break;
                            case 2:
                                RedMaxPiecesNr = int.Parse(line);
                                break;
                            case 3:
                                BlackMaxPiecesNr = int.Parse(line);
                                break;
                        }
                    }
                }
            }
        }
    }
}
