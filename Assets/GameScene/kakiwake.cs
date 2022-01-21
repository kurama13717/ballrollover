using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakiwake : MonoBehaviour
{
    [SerializeField]
    private GameObject Ieg;

    //Material SnowMaterial;
    //public GameObject Ieg;
    // Start is called before the first frame update
    public float span = 1f;
    private float currentTime = 0f;
    public GameObject obj;
    public float timer;
    void Start()
    {
       
        
    }
   
    // Update is called once per frame
    void Update()
    {
        // Ieg = (GameObject)Resources.Load("leg");
        Vector3 hue1 = GameObject.Find("Sphere").transform.position;
        Vector3 hue2 = GameObject.Find("Sphere").transform.localScale;
        currentTime += Time.deltaTime;
        float y = hue1.y;
        y -= (float)0.6 * hue2.x;
        Ray ray = new Ray(new Vector3(hue1.x, hue1.y-0.5f, hue1.z), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            if (currentTime > span)
            {
                Destroy(obj, timer);
                //GameObject.Instantiate(Ieg,new Vector3(hue1.x,hue1.y-3,hue1.z),Quaternion.identity,transform.parent);

                if (Ieg != null)
                {
                    obj = Instantiate(Ieg, transform.parent);
                    obj.transform.localPosition = new Vector3(hit.point.x, hit.point.y+0.2f, hit.point.z);
                    obj.transform.localEulerAngles = new Vector3(hit.transform.localEulerAngles.x,0, hit.transform.localEulerAngles.z);
                    obj.transform.localScale = new Vector3(0.1f*hue2.x, 0.1f, 0.1f*hue2.z);
                }
                currentTime = 0f;
            }
        }
        
    }
}
