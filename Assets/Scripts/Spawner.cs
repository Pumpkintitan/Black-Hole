using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;
namespace StarterAssets

{
    public class Spawner : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject _ray;
        public GameObject _controller;
        private int numx = 160 * 4;
        private int numy = 90 * 4;
        private float totangx = 65.82932f;
        private int totangy = 40;
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (_controller.GetComponent<FirstPersonController>()._input.fire)
            {
                Debug.Log("enter");
                Color[] colors = new Color[numx*numy];

                for(int i = 0; i < numx; i++) {
                    for(int j = 0; j < numy; j++) {
                        float angx = -(totangx/2f) + (i*((float)totangx/(float)numx));
                        float angy = -(totangy/2f) + (j*((float)totangy/(float)numy));
                        GameObject a = Instantiate(_ray, gameObject.transform.position, Quaternion.identity);
                        Vector3 localfw = transform.InverseTransformDirection(gameObject.transform.forward);
                        localfw = Quaternion.AngleAxis(angx, Vector3.up) * localfw;
                        localfw = Quaternion.AngleAxis(angy, Vector3.right) * localfw;
                        localfw = transform.TransformDirection(localfw);
                        Color finish = a.GetComponent<PhysRay>().calcGrav(1000, localfw*6f);
                        colors[((numx)*(numy-j-1))+i] = finish;
                        Destroy(a);
                    }
                }
                Texture2D tex = new Texture2D(numx, numy, TextureFormat.RGBA32, false);
                tex.SetPixels(colors, 0);
                tex.Apply();
                byte[] bytes = tex.EncodeToPNG();
                Object.Destroy(tex);
                File.WriteAllBytes(Application.dataPath + "/../SavedScreen1.png", bytes);
                _controller.GetComponent<FirstPersonController>()._input.fire = false;
            }
        }

        // public Color calcGrav(int timestep, Vector3 vel, Vector3 pos)
        // {
            
        //     for (int i = 0; i < timestep; i++)
        //     {
        //         Vector3 acc = pos * -1f;
        //         acc.Normalize();
        //         acc = (acc * 30f) / (Vector3.Distance(pos, new Vector3(0f, 0f, 0f)) * Vector2.Distance(pos, new Vector3(0f, 0f, 0f)));
        //         vel = vel + acc * Time.deltaTime;
        //         vel.Normalize();
        //         vel = vel * 6f;
        //         pos = pos + vel * Time.deltaTime;
        //         // gameObject.transform.Translate(vel * Time.deltaTime);
        //         Collider[] hitColliders = new Collider[1];
        //         int b = Physics.OverlapSphereNonAlloc(pos, 0.025f, hitColliders);
        //         if (hitColliders[0])
        //         {
        //             if (hitColliders[0].gameObject.tag == "BlackHole")
        //             {
        //                 return Color.black;
        //             }
        //             if (hitColliders[0].gameObject.tag == "Blue")
        //             {
        //                 return Color.blue;
        //             }
        //             if (hitColliders[0].gameObject.tag == "Orange")
        //             {
        //                 return new Color(1, (float)(165 / 255), 0);
        //             }
        //             if (hitColliders[0].gameObject.tag == "Red")
        //             {
        //                 return Color.red;
        //             }
        //             if (hitColliders[0].gameObject.tag == "Green")
        //             {
        //                 return Color.green;
        //             }

        //         }
        //     }
        //     return Color.white;
        // }
    }
}