namespace _clone.Scripts.Data.User.Subscription
{
    public class SubscriptionData : IData
    {
        public bool IsSubscribed { get; private set; }
        public SubscriptionTrial Trial { get; private set; }

        public void Set(SerializableSubscriptionData data)
        {
            Trial = data.trial;
            IsSubscribed = data.isSubscribed;
        }
    }
}