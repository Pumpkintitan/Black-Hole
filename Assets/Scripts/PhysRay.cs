using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysRay : MonoBehaviour

{
    private Vector3 pos;
    public Vector3 vel;
    [SerializeField] public float grav;
    private Vector3 acc;
    // Start is called before the first frame update
    void Start()
    {
        acc = new Vector3(0f, 0f, 0f);
        // vel = new Vector3(1f,2f,1f);
        // pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        // LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // lineRenderer.widthMultiplier = 0.05f;
        // (Vector3[] l1,int l2) = calcGrav(1000, vel);
        // lineRenderer.positionCount = l2;
        // lineRenderer.SetPositions(l1);

    }

    // Update is called once per frame
    void Update()
    {
        // acc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) * -1f;
        // acc.Normalize();
        // acc = (acc * 30f)/ (Vector3.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),new Vector3(0f,0f,0f)) * Vector2.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),new Vector3(0f,0f,0f)));
        // vel = vel + acc * Time.deltaTime;
        // vel.Normalize();
        // vel = vel * 6f;
        // // pos = pos + vel;
        // gameObject.transform.Translate(vel * Time.deltaTime);
        // if (Vector3.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),new Vector3(0f,0f,0f)) > 20f || Vector3.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),new Vector3(0f,0f,0f)) < 0.6f) {
        //     Destroy(gameObject);
        // }

    }

    public Color calcGrav(int timestep, Vector3 vell)
    {
        vel = vell;
        for (int i = 0; i < timestep; i++)
        {
            acc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) * -1f;
            acc.Normalize();
            acc = (acc * 15f) / (Vector3.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(0f, 0f, 0f)) * Vector2.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(0f, 0f, 0f)));
            vel = vel + acc * Time.deltaTime;
            vel.Normalize();
            vel = vel * 6f;
            // pos = pos + vel;
            gameObject.transform.Translate(vel * Time.deltaTime);
            Collider[] hitColliders = new Collider[1];
            int b = Physics.OverlapSphereNonAlloc(gameObject.transform.position, 0.025f, hitColliders);
            if (hitColliders[0])
            {
                if (hitColliders[0].gameObject.tag == "BlackHole")
                {
                    return Color.black;
                }
                if (hitColliders[0].gameObject.tag == "Blue")
                {
                    return Color.blue;
                }
                if (hitColliders[0].gameObject.tag == "Orange")
                {
                    return new Color(1f, (165f / 255f), 0f);
                }
                if (hitColliders[0].gameObject.tag == "Red")
                {
                    return Color.red;
                }
                if (hitColliders[0].gameObject.tag == "Green")
                {
                    return Color.green;
                }

            }
        }
        return Color.white;
    }

    public void setvel(Vector3 v)
    {
        vel = v;
    }
}
