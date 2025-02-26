using System;

namespace _clone.Scripts.Data.User.Personal
{
    [Serializable]
    public class ProfileData
    {
        public string name = string.Empty; //personal +
        public string email = string.Empty; // personal +
        public string subscribed_until = string.Empty; //Subscription +
        public bool cheatmenu; // debug +
        public bool has_override_lifetime; // subscription, possible to remove -
        public bool is_trial_now; // subscription +
        public bool is_subscribed; // subscription, possible to remove -
        public string birth_date = string.Empty; // personal +
        public int age; // personal +
        public int timezone; // personal, possible to remove +
        public bool is_fitness_test_finished; // daily
        public bool is_debug_mode; // debug +

        public Traning training_preferences; // 

        //public ReminderData reminder; // reminder +
        public PuzzleSettings puzzle_settings; // +

        //public SubscriptionData subsctiption;

        public class Traning
        {
            public bool color_blind; // settings.game +
            public bool fluent_in_english; // settings.game +
            public bool device_vibrations; // settings +
        }

        public class PuzzleSettings
        {
            public bool sound; // settings.puzzle +
            public bool music; // settings.puzzle +
        }
    }
}