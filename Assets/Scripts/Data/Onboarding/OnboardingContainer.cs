using System.Collections.Generic;
using System.Linq;
using _clone.Scripts.Constants.Onboarding;
using _clone.Scripts.Core.Onboarding;
using _clone.Scripts.StateMachine.States.Onboarding;
using _clone.Scripts.StateMachine.States.Onboarding.CompleteStep;
using _clone.Scripts.StateMachine.States.Onboarding.FitnessTest;
using _clone.Scripts.StateMachine.States.Onboarding.QuestionnaireStep;
using _clone.Scripts.StateMachine.States.Onboarding.WelcomeStep;
using UnityEditor;
using UnityEngine;

namespace _clone.Scripts.Data.Onboarding
{
    [CreateAssetMenu(fileName = nameof(OnboardingContainer), menuName = "MindGame/View/" + nameof(OnboardingContainer))]
    public class OnboardingContainer : ScriptableObject, IData
    {
        [SerializeField] private List<string> stepsSequence;
        [SerializeField] private List<OnboardingStepView> stepViews = new();

        public int StepsCount => stepsSequence.Count;

        public bool TryGetStepViewPrefab(string id, out OnboardingStepView result)
        {
            result = stepViews.FirstOrDefault(view => view.Id.Contains(id));
            return result != null;
        }

        public BaseOnboardingStep GetOnboardingStep(int index)
        {
            return stepsSequence[index] switch
            {
                OnboardingStepsName.WelcomeViewStep => new OnboardingWelcomeStep(),
                OnboardingStepsName.QuestionnaireStep => new OnboardingQuestionnaireStep(),
                OnboardingStepsName.FitnessTestStep => new OnboardingFitnessTestStep(),
                OnboardingStepsName.CompleteStep => new OnboardingCompleteStep(),
                _ => null
            };
        }

#if UNITY_EDITOR
        [ContextMenu("Fill Steps Sequence")]
        public void FillStepsSequence()
        {
            stepsSequence.Clear();
            stepsSequence.Add(OnboardingStepsName.WelcomeViewStep);
            stepsSequence.Add(OnboardingStepsName.QuestionnaireStep);
            stepsSequence.Add(OnboardingStepsName.FitnessTestStep);
            stepsSequence.Add(OnboardingStepsName.CompleteStep);
            EditorUtility.SetDirty(this);
        }
#endif
    }
}