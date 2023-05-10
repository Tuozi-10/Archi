using UnityEngine;

public class UI_Warcraft : MonoBehaviour
{
    [SerializeField] private TMP_Text lumberText;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text toolText;

    public void UpdateLumber(int lumber)
    {
        lumberText.text = lumber.ToString();
    }
}
