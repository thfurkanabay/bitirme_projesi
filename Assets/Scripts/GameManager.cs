using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private int currentQuestionIndex = 0;

        private void Awake()
        {
            Debug.Log("GameManager is awake");
            if (!Instance)
                Instance = this;

        }

        private void Start()
        {
            UIManager.Instance.NextPanel(currentQuestionIndex, currentQuestionIndex);
        }

        public void NextQuestion()
        {
            var nextQuestionIndex = currentQuestionIndex + 1;
            if (!UIManager.Instance.AnyPanelLeft(nextQuestionIndex)) return;
            UIManager.Instance.NextPanel(currentQuestionIndex, nextQuestionIndex);
            UIManager.Instance.ResetNextButton();
            IncrementQuestion();
        }

        private void IncrementQuestion()
        {
            currentQuestionIndex += 1;
        }
    }
}
