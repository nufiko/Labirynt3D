using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera myCamera;
    public GameObject player;
    public Transform myRenderPlane;
    public Transform myColliderPlane;
    public Portal otherPortal;

    PortalCamera portalCamera;
    PortalTeleport portalTeleport;

    public Material material;
    float myAngle;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.gameObject.GetComponent<PortalTeleport>();
        player = GameObject.FindGameObjectWithTag("Player");

        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        portalTeleport.player = player.transform;
        portalTeleport.reciever = otherPortal.transform;

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);
        
        if(myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.SetMyAngle(myAngle);

    }

    // Start is called before the first frame update
    void Start()
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckAngle()
    {
        if (Mathf.Abs(otherPortal.ReturnMyAngle() - ReturnMyAngle()) != 180)
        {
            Debug.LogWarning("Portale nie są odpowiednio ustawione: " + gameObject.name);
            Debug.Log("Angle: " + (otherPortal.ReturnMyAngle() - ReturnMyAngle()));
        }
    }

    public float ReturnMyAngle()
    {
        return myAngle;
    }
}
