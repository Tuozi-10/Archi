using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Unit Data")]
public class ScriptableUnitData : ScriptableObject
{
    [field: SerializeField] public Material Material { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 7f;
    [field: SerializeField] public float WorkTime { get; private set; } = 1f;
    [field: SerializeField] public float WorkRange { get; private set; } = 1f;
    [field: SerializeField] public int[] TargetResources { get; private set; } = {0};
    [field: SerializeField] public int MaxResource { get; private set; } = 1;

}
