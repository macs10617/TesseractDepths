using UnityEngine;

public class Level : MonoBehaviour
{
    public GameEvent Event => _enterEvent;
    [SerializeField] protected GameEvent _enterEvent;
    [SerializeField] protected Transform _levelSpawnPos;
    [SerializeField] protected Transform _levelTeleportPos;

    public void SetLevelSpawnPosRot()
    {
        if (!_levelSpawnPos) return;
        transform.position = _levelSpawnPos.position;
        transform.rotation = _levelSpawnPos.rotation;
    }

    public void SetLevelTeleportPosRot()
    {
        if (!_levelTeleportPos) return;

        transform.position = _levelTeleportPos.position;
        transform.rotation = _levelTeleportPos.rotation;
    }
}