using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalResult2 : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        Transform myTransform = this.transform; // transform‚ğæ“¾
        Vector3 pos = myTransform.localPosition;     // À•W‚ğæ“¾
        if (collider.gameObject.name == "Sphere") // ‚Ô‚Â‚©‚Á‚½‘Šè‚Ì–¼‘O‚ğæ“¾(ŒŠ‚É—‚¿‚½)
        {
            SceneManager.LoadScene("ResultScene2");
        }
    }

}
