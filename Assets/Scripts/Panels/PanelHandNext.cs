using System;
using Managers;
using UnityEngine;

namespace Panels
{
    public class PanelHandNext : MonoBehaviour, IPanels
    {
        public void ActivatePanel()
        {
            UIManager.Instance.ActivateHandDraw();
            UIManager.Instance.ResetNextButton();
        }
    }
}
