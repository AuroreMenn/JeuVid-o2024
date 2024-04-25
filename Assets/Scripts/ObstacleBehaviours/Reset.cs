using Unity.Burst;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private float xpositionBase = 0;
    private float ypositionBase = 0;

    void Start(){
        xpositionBase = transform.position.x;
        ypositionBase = transform.position.y;
    }

    public void resetPosition(){
        transform.position = new Vector2(xpositionBase, ypositionBase);
    }
}

