using TMPro;
using UnityEngine;

namespace Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointText;

        public void SetText(string msg) =>
            pointText.text = msg;
    }
}