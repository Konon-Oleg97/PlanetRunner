
using UnityEngine;

public class PlanetConstraint : MonoBehaviour
{
    [SerializeField]
     Transform TargetPlanet;

    private void Start()
    {
        if (TargetPlanet == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Planet");
            TargetPlanet = go.transform;
        }  
    }
    void FixedUpdate()
    {
        Quaternion rotation = Quaternion.FromToRotation(-transform.up, TargetPlanet.position - transform.position);
        transform.rotation = rotation * transform.rotation;
    }
}
