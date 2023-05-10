using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRTS : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Button[] buttons;

    public int TextsCount => texts.Length;
    public int ButtonsCount => buttons.Length;
    public TextMeshProUGUI GetText(int index) => index >= texts.Length || index < 0 ? texts[0] : texts[index];
    public Button GetButton(int index) => index >= buttons.Length || index < 0 ? buttons[0] : buttons[index];
}
