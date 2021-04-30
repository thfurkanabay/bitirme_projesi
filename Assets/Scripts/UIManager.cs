using Panels;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        [SerializeField] private GameObject[] questionPanels;
       // [SerializeField] private GameObject handDraw;
        [SerializeField] private GameObject nextButtonGameObject;

        //private RectTransform handDrawRectTransform;
        //private Animator handDrawAnim;

        private RectTransform nextButtonRectTransform;
        private Animator nextButtonAnim;
        private Button nextButton;

        [SerializeField] private Vector3 handDrawStartPos;
        [SerializeField] private Vector3 nextButtonStartPos;
        private void Awake()
        {
            Debug.Log("UI manager is awake");
            if (!Instance)
                Instance = this;

            if (questionPanels.Length == 0)
            {
                Debug.Log("No question panels found!");
                return;
            }

            foreach (var panel in questionPanels)
            {
                panel.SetActive(false);
            }

            //handDrawAnim = handDraw.GetComponent<Animator>();
            //handDrawRectTransform = handDraw.GetComponent<RectTransform>();
            handDrawStartPos = new Vector3(1260, 215, 0);

            nextButton = nextButtonGameObject.GetComponent<Button>();
            nextButtonAnim = nextButtonGameObject.GetComponent<Animator>();
            nextButtonRectTransform = nextButtonGameObject.GetComponent<RectTransform>();
            nextButtonStartPos = new Vector3(1232, -385, 0);
        }

        public void ResetHandDraw()
        {
            Debug.Log("HandDraw is Reset");
           // handDrawAnim.enabled = false;
            //handDrawRectTransform.anchoredPosition = handDrawStartPos;
        }

        public void ActivateHandDraw()
        {
            Debug.Log("HandDraw is Activated");
         //   handDrawAnim.enabled = true;
        }
        public void ResetNextButton()
        {
            Debug.Log("NextQuestionButton is Reset");
            nextButton.enabled = false;
            nextButtonAnim.enabled = false;
            nextButtonRectTransform.anchoredPosition = nextButtonStartPos;
        }

        public void ActivateNextButton()
        {
            Debug.Log("NextButton is Activated");
            nextButtonAnim.enabled = true;
            nextButton.enabled = true;
        }

        public void NextPanel(int currentQuestionIndex, int nextQuestionIndex)
        {
            questionPanels[currentQuestionIndex].SetActive(false);
            questionPanels[nextQuestionIndex].SetActive(true);
            questionPanels[nextQuestionIndex].GetComponent<IPanels>().ActivatePanel();
        }

        public bool AnyPanelLeft(int nextPanelIndex)
        {
            return nextPanelIndex < questionPanels.Length;
        }
    }
}
