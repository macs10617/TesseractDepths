using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")] public GameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent Response;

    protected void OnEnable()
    {
        Event?.RegisterListener(this);

        if (Response == null)
            Response = new UnityEvent();
    }

    protected void OnDisable()
    {
        Event?.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }

    public void Register(GameEvent gameEvent)
    {
        Event = gameEvent;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}