using UnityEngine;

[CreateAssetMenu(fileName = "Entity Data", menuName = "Entity/Data")]
public class EntityData : ScriptableObject
{
    [field : SerializeField]
    public float Health { get; private set; }

    [field : SerializeField]
    public float MoveSpeed { get; private set; }
}
