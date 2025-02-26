namespace _clone.Scripts.Data.User.Settings
{
    public interface ISettings
    {
        public IGame Games { get; }
        public IPuzzle Puzzles { get; }
        public IGeneral Generals { get; }

        public interface IGame
        {
            public bool ColorBlind { get; }
            public bool FluentInEnglish { get; }

            public void ChangeColorBlindState(bool state);
            public void ChangeFluentInEnglishState(bool state);
        }

        public interface IGeneral
        {
            public bool DeviceVibrations { get; }

            public void ChangeVibrationState(bool state);
        }

        public interface IPuzzle
        {
            public bool Sound { get; }
            public bool Music { get; }

            public void ChangePuzzleMusicState(bool state);
            public void ChangePuzzleSoundState(bool state);
        }
    }
}