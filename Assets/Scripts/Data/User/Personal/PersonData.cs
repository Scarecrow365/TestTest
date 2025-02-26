using System;
using UnityEngine;

namespace _clone.Scripts.Data.User.Personal
{
    public class PersonData : IData
    {
        private const string DefaultEmail = "guest";
        private const string KeyUserId = "user-id";
        public bool IsGuest => Email.Equals(DefaultEmail);
        public bool IsAuthorized => !string.IsNullOrEmpty(UserId);

        public string UserId { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Email { get; private set; }
        public int Age => DateTime.Today.Year - Birthday.Year;

        public PersonData()
        {
            RestoreUserId();
            SetEmail(DefaultEmail);
        }

        public void Set(ProfileData data)
        {
            Name = data.name;
            Email = data.email;
            Birthday = DateTime.Parse(data.birth_date);
        }

        public void SetUserId(string userId)
        {
            UserId = userId;
            PlayerPrefs.SetString(KeyUserId, userId);
            //To Do if (userId != null) ServiceLocator.Container.Single<AnalyticsService>().SetUserId(userId);
            Debug.Log($"New USER-ID - {userId}");
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetAge(int age)
        {
            Birthday = DateTime.Today.AddYears(-age);
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(KeyUserId);
            UserId = string.Empty;
            Name = string.Empty;
            Email = DefaultEmail;
            Birthday = DateTime.Today;
        }

        private void RestoreUserId()
        {
            UserId = PlayerPrefs.GetString(KeyUserId, string.Empty);
        }
    }
}