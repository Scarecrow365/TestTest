using System;

namespace _clone.Scripts.Data.User.Subscription
{
    [Serializable]
    public class SerializableSubscriptionData
    {
        public SubscriptionTrial trial;
        public bool isSubscribed;
    }

    public enum SubscriptionTrial
    {
        None,
        Active,
        Expired
    }
}