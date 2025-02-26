using System;

namespace _clone.Scripts.Core.Onboarding.Questionnaire
{
    public struct QuestionnaryScreenCallbacks
    {
        public Action NoButtonCallback;
        public Action YesButtonCallback;
        public Action SkipButtonCallback;
        public Action BackButtonCallback;
    }
}