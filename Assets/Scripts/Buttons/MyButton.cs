using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class MyButton : MonoBehaviour
    {
        private bool isActivated = false;
        protected Button button;
        protected Animator animator;
        protected AudioSource audioSource;

        private void Awake()
        {
            button = GetComponent<Button>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        protected virtual void OnClick()
        {
            if (!audioSource) return;
            if (!audioSource.isPlaying) audioSource.Play();
            if (isActivated) return;
            UIManager.Instance.ResetHandDraw();
            UIManager.Instance.ActivateNextButton();
            if (!animator) return;
            animator.SetTrigger("animate");
            isActivated = true;
        }
    }
}
