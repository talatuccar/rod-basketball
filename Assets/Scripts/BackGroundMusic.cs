
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private static GameObject Instance;
    private void Awake()
    {
            DontDestroyOnLoad(this);

        if(Instance == null)
        
            Instance=gameObject;
        else      
            Destroy(gameObject);
        
    }

}
