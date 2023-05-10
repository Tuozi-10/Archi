using UnityEngine;

public class EntityLocation : MonoBehaviour
{
    [SerializeField] private Structure[] structures;

    public int StructureCount=> structures.Length;
    public Structure GetStructure(int index) => index >= structures.Length || index < 0 ? structures[0] : structures[index];
}
