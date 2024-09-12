using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    public static event Action<bool> OnScored;

    bool colliderFlag = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NextLevel"))
        {
            colliderFlag = false;

            OnScored?.Invoke(true);

        }
        else if (other.CompareTag("Respawn") && colliderFlag)
        {
            OnScored?.Invoke(false);

        }

    }
}
