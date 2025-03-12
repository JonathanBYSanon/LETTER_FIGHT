using LETTER_FIGHT.Core;
using LETTER_FIGHT.Model;
using LETTER_FIGHT.Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace LETTER_FIGHT.ViewModel
{
    public class GameViewModel : NotifyChangeBase
    {
        private ObservableCollection<Letter> _letters;
        public ObservableCollection<Letter> Letters
        {
            get { return _letters; }
            set
            {
                _letters = value;
                OnPropertyChanged();
            }
        }
        private Letter _selectedLetter;
        public Letter SelectedLetter
        {
            get { return _selectedLetter; }
            set
            {
                _selectedLetter = value;
                _selectedLetter.Counter++;
                addLetterToInput();
                OnPropertyChanged();
                _selectedLetter = null;
            }
        }
        private Player[] _players;
        public Player[] Players
        {
            get { return _players; }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }
        public int TargetScore
        {
            get { return SettingService.ActiveSettings.TargetScore; }
        }

        // Input with the chosen letters
        private string _input = "";
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged();
            }
        }

        // Word to be verified
        private string _word = "";
        public string Word
        {
            get { return _word; }
            set
            {
                if(value != _word) IsVerificationDone = false;
                _word = value;
                OnPropertyChanged();
            }
        }

        // Verification message from the verification service
        private string verificationMessage = "\t...";
        public string VerificationMessage
        {
            get { return verificationMessage; }
            set
            {
                verificationMessage = value;
                OnPropertyChanged();
            }
        }

        // Boolean properties to control the game flow
        private bool _isBattleInProgress = true;
        public bool IsBattleInProgress
        {
            get { return _isBattleInProgress; }
            set
            {
                _isBattleInProgress = value;
                OnPropertyChanged();
            }
        }
        private bool _isVerificationInProgress = false;
        public bool IsVerificationInProgress
        {
            get { return _isVerificationInProgress; }
            set
            {
                _isVerificationInProgress = value;
                OnPropertyChanged();
            }
        }

        private bool _isVerificationDone = false;
        public bool IsVerificationDone
        {
            get { return _isVerificationDone; }
            set
            {
                _isVerificationDone = value;
                OnPropertyChanged();
            }
        }

        private bool _isGameOver = false;
        public bool IsGameOver
        {
            get { return _isGameOver; }
            set
            {
                _isGameOver = value;
                OnPropertyChanged();
            }
        }
        
        public CommandBase EraseLetterCommand { get; set; }
        public CommandBase ChallengeCommand { get; set; }
        public CommandBase VerifyWordCommand { get; set; }
        public CommandBase CorrectCommand { get; set; }
        public CommandBase IncorrectCommand { get; set; }
        public CommandBase ExitCommand { get; set; }

        public GameViewModel()
        {
            Letters = GameInitializationService.GenerateLetters();
            Players = GameInitializationService.GeneratePlayers();
            EraseLetterCommand = new CommandBase(eraseLetterAction, canEraseLetter);
            ChallengeCommand = new CommandBase(challengeAction, canChallenge);
            VerifyWordCommand = new CommandBase(verifyWordAction);
            CorrectCommand = new CommandBase((obj) => addScore(true));
            IncorrectCommand = new CommandBase((obj) => addScore(false));
            ExitCommand = new CommandBase(exitAction);
        }

        // METHODS

        private void SwitchTurn()
        {
            Players[TurnControlService.ActivePlayerIndex].IsTurn = false;
            Players[TurnControlService.nextPlayer(Players.Length - 1)].IsTurn = true;
        }
        private void addLetterToInput()
        {
            Input += SelectedLetter.Value;
            SwitchTurn();
        }
        private void addScore(bool isWordCorrect)
        {
            if (isWordCorrect)
            {
                Players[TurnControlService.ActivePlayerIndex].Score += Word.Length;
            }
            else
            {
                SwitchTurn();
                Players[TurnControlService.ActivePlayerIndex].Score += Input.Length;
            }

            if (Players[TurnControlService.ActivePlayerIndex].Score >= SettingService.ActiveSettings.TargetScore)
            {
                IsVerificationInProgress = false;
                IsGameOver = true;
            }
            else
            {
                resetBoard();
            }
        }
        private void resetBoard()
        {
            foreach (var letter in Letters)
            {
                letter.Counter = 0;
            }

            IsBattleInProgress = true;
            IsVerificationInProgress = false;
            Input = "";
            Word = "";
            VerificationMessage = "";
        }
        private void eraseLetterAction(object obj)
        {
            char lastLetter = Input.Last();
            Letters.FirstOrDefault(l => l.Value == lastLetter).Counter--;
            Input = Input.Remove(Input.Length - 1);

            SwitchTurn();
        }
        private bool canEraseLetter(object obj)
        {
            return Input.Length > 0 && IsBattleInProgress;
        }
        private void challengeAction(object obj)
        {
            IsVerificationInProgress = true;
            IsBattleInProgress = false;
            SwitchTurn();
        }
        private bool canChallenge(object obj)
        {
            return Input.Length > 1;
        }
        private async void verifyWordAction(object obj)
        {
            (IsVerificationDone, VerificationMessage) = await WordValidationService.ValidateWordAsync(Input, Word);
        }

        private void exitAction(object obj)
        {
            NavigationService.Navigator.NavigateTo("Menu");
        }
    }
}
