using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private GameObject _itemPreview;
    [SerializeField] private GameObject _item;
    private GameEventListener _gameEventListener;

    private void Awake()
    {
        _gameEventListener = gameObject.AddComponent<GameEventListener>();
        _gameEventListener.Register(_event);
        _gameEventListener.Response.AddListener(ActivateCube);
        
        _item.SetActive(false);
        _itemPreview.SetActive(true);
    }

    private void ActivateCube()
    {
        _itemPreview.SetActive(false);
        _item.SetActive(true);
    }
}