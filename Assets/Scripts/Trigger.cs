using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{

    public Rigidbody2D triggerBody;
    public UnityEvent onTriggerEnter;
    private static Collider2D identifier;
    public static string winnerName;

    void OnTriggerEnter2D(Collider2D other)
    {
        identifier = other;
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;

        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;
        if (hitRb == triggerBody)
        {
            onTriggerEnter.Invoke();
        }
    }

    public static string IdentifyName()
    {
        return identifier.name;
    }

}
