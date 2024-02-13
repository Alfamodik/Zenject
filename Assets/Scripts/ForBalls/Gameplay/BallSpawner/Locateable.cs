using UnityEngine;

public abstract class Locateable : MonoBehaviour
{
    public void Locate(Transform transf)
    {
        transform.position = transf.position;
        transform.rotation = transf.rotation;
        transform.localScale = transf.localScale;
    }
}
