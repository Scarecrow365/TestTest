namespace _clone.Scripts.Data.User.Settings
{
    public class SettingsData : IData
    {
        public ISettings.IGame Games { get; }
        public ISettings.IPuzzle Puzzles { get; }
        public ISettings.IGeneral Generals { get; }

        public SettingsData()
        {
            Games = new Game();
            Puzzles = new Puzzle();
            Generals = new General();
        }

        public class Puzzle : ISettings.IPuzzle
        {
            public bool Sound { get; private set; }
            public bool Music { get; private set; }

            public void ChangePuzzleMusicState(bool state)
            {
                Music = state;
            }

            public void ChangePuzzleSoundState(bool state)
            {
                Sound = state;
            }
        }

        public class General : ISettings.IGeneral
        {
            public bool DeviceVibrations { get; private set; }

            public void ChangeVibrationState(bool state)
            {
                DeviceVibrations = state;
            }
        }

        public class Game : ISettings.IGame
        {
            public bool ColorBlind { get; private set; }
            public bool FluentInEnglish { get; private set; }

            public void ChangeColorBlindState(bool state)
            {
                ColorBlind = state;
            }

            public void ChangeFluentInEnglishState(bool state)
            {
                FluentInEnglish = state;
            }
        }
    }
}