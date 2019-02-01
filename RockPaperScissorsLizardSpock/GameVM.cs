using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class GameVM : INotifyPropertyChanged
    {
        const string ROCK_PATH = "image/rock.png";
        const string PAPER_PATH = "image/paper.png";
        const string SCISSORS_PATH = "image/scissors.png";
        const string SPOCK_PATH = "image/spock.png";
        const string LIZARD_PATH = "image/lizard.png";
        Random r = new Random();
        //use enum to assign names
        public enum PickChoices
        {
            None,
            Rock,
            Paper,
            Scissors,
            Spock,
            Lizard
        }
        //assign game results
        public enum WinOrLess
        {
            Win,
            Lose,
            Tie
        }
        private int winTimes;
        public int WinTimes
        {
            get { return winTimes; }
            set { winTimes = value; NotifyChanged(); }
        }
        private int lossTimes;
        public int LossTimes
        {
            get { return lossTimes; }
            set { lossTimes = value; NotifyChanged(); }
        }
        private int totalTimes;
        public int TotalTimes
        {
            get { return totalTimes; }
            set { totalTimes = value; NotifyChanged(); }
        }
        private int tieTimes;
        public int TieTimes
        {
            get { return tieTimes; }
            set { tieTimes = value; NotifyChanged(); }
        }
        private bool start = true;
        public bool Start
        {
            get { return start; }
            set { start = value; NotifyChanged(); }
        }
        private bool enableButton = false;
        public bool EnableButton
        {
            get { return enableButton; }
            set { enableButton = value; NotifyChanged(); }
        }
        public void StartGame()
        {
            Start = false;
            EnableButton = !Start;
        }
        private string resultStats;
        public string ResultStats
        {
            get { return resultStats; }
            set { resultStats = value; NotifyChanged(); }
        }
        private PickChoices userSelection;
        public PickChoices UserSelection
        {
            get { return userSelection; }
            set { userSelection = value; AIGuess(); NotifyChanged(); }
        }
        private string showOrHide = "Hidden";
        public string ShowOrHide
        {
            get { return showOrHide; }
            set { showOrHide = value; NotifyChanged(); }
        }
        private string aIPickImage;
        public string AIPickImage
        {
            get { return aIPickImage; }
            set { aIPickImage = value; NotifyChanged(); }
        }
        private string userPickImage;
        public string UserPickImage
        {
            get { return userPickImage; }
            set { userPickImage = value; NotifyChanged(); }
        }
        private PickChoices aISelection;
        public PickChoices AISelection
        {
            get { return aISelection; }
            set { aISelection = value; NotifyChanged(); }
        }
        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; NotifyChanged(); }
        }
        private string reset;
        public string Reset
        {
            get { return reset; }
            set { reset = value; NotifyChanged(); }
        }
        private ObservableCollection<string> gameRecord = new ObservableCollection<string>();
        public ObservableCollection<string> GameRecord
        {
            get { return gameRecord; }
            set { gameRecord = value; NotifyChanged(); }
        }
        //determine what computer picks
        public void AIGuess()
        {
            AISelection = PickChoices.None;
            switch (r.Next(1, 6))
            {
                case 1:
                    AISelection = PickChoices.Rock;
                    AIPickImage = ROCK_PATH;
                    break;
                case 2:
                    AISelection = PickChoices.Paper;
                    AIPickImage = PAPER_PATH;
                    break;
                case 3:
                    AISelection = PickChoices.Scissors;
                    AIPickImage = SCISSORS_PATH;
                    break;
                case 4:
                    AISelection = PickChoices.Spock;
                    AIPickImage = SPOCK_PATH;
                    break;
                case 5:
                    AISelection = PickChoices.Lizard;
                    AIPickImage = LIZARD_PATH;
                    break;
                default:
                    AIGuess();
                    break;
            }
        }
        public void SelectRock()
        {
            UserSelection = PickChoices.Rock;
            UserPickImage = ROCK_PATH;
            ShowOrHide = "Visibile";
            TotalTimes++;
            NotifyChanged();
        }
        public void SelectPaper()
        {
            UserSelection = PickChoices.Paper;
            UserPickImage = PAPER_PATH;
            ShowOrHide = "Visibile";
            TotalTimes++;
            NotifyChanged();
        }
        public void SelectScissors()
        {
            UserSelection = PickChoices.Scissors;
            UserPickImage = SCISSORS_PATH;
            ShowOrHide = "Visibile";
            TotalTimes++;
            NotifyChanged();
        }
        public void SelectSpock()
        {
            UserSelection = PickChoices.Spock;
            UserPickImage = SPOCK_PATH;
            ShowOrHide = "Visibile";
            TotalTimes++;
            NotifyChanged();
        }
        public void SelectLizard()
        {
            UserSelection = PickChoices.Lizard;
            UserPickImage = LIZARD_PATH;
            ShowOrHide = "Visibile";
            TotalTimes++;
            NotifyChanged();
        }
        //determine who wins
        public void GetGameResult()
        {
            if (UserSelection != AISelection)
            {
                if (UserSelection == PickChoices.Rock)
                {
                    if (AISelection == PickChoices.Lizard || AISelection == PickChoices.Scissors)
                    { Result = $"You {WinOrLess.Win}!"; WinTimes++; }

                    else if (AISelection == PickChoices.Paper || AISelection == PickChoices.Spock)
                    { Result = $"You {WinOrLess.Lose}!"; LossTimes++; }
                }
                else if (UserSelection == PickChoices.Paper)
                {
                    if (AISelection == PickChoices.Rock || AISelection == PickChoices.Spock)
                    { Result = $"You {WinOrLess.Win}!"; WinTimes++; }
                    else if (AISelection == PickChoices.Scissors || AISelection == PickChoices.Lizard)
                    { Result = $"You {WinOrLess.Lose}!"; LossTimes++; }
                }
                else if (UserSelection == PickChoices.Scissors)
                {
                    if (AISelection == PickChoices.Paper || AISelection == PickChoices.Lizard)
                    { Result = $"You {WinOrLess.Win}!"; WinTimes++; }
                    else if (AISelection == PickChoices.Rock || AISelection == PickChoices.Spock)
                    { Result = $"You {WinOrLess.Lose}!"; LossTimes++; }
                }
                else if (UserSelection == PickChoices.Lizard)
                {
                    if (AISelection == PickChoices.Paper || AISelection == PickChoices.Spock)
                    { Result = $"You {WinOrLess.Win}!"; WinTimes++; }
                    else if (AISelection == PickChoices.Rock || AISelection == PickChoices.Scissors)
                    { Result = $"You {WinOrLess.Lose}!"; LossTimes++; }
                }
                else if (UserSelection == PickChoices.Spock)
                {
                    if (AISelection == PickChoices.Rock || AISelection == PickChoices.Scissors)
                    { Result = $"You {WinOrLess.Win}!"; WinTimes++; }
                    else if (AISelection == PickChoices.Paper || AISelection == PickChoices.Lizard)
                    { Result = $"You {WinOrLess.Lose}!"; LossTimes++; }
                }
            }
            else
            {
                Result = $"{WinOrLess.Tie}, play again!";
                TieTimes++;
            }
            GameRecord.Add($"You picked {UserSelection}, computer picked {AISelection}. ---- {Result}");
            ResultStats = $"Total Played:{TotalTimes}, Win:{WinTimes}, Loss:{LossTimes}, Tie:{TieTimes}";
        }
        //reset everything
        public void ResetEverything()
        {
            AIPickImage = "";
            UserPickImage = "";
            Result = "";
            Start = true;
            EnableButton = false;
            ResultStats = string.Empty;
            WinTimes = 0;
            LossTimes = 0;
            TieTimes = 0;
            TotalTimes = 0;
            GameRecord.Clear();
        }
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
