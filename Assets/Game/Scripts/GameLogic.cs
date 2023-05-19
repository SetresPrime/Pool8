using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject WBCenter;
    [SerializeField] 
    private GameObject HitPoint;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private float multiplier;

    private Rigidbody rb;
    private Vector3 HitVec;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
    
        CuePos();
        HideCue();
        if (Input.GetKeyDown(KeyCode.Space))
            Strike();
    }
    void CuePos()
    {
        HitVec = new Vector3(HitPoint.transform.position.x - transform.position.x, 0, HitPoint.transform.position.z - transform.position.z);

        var MousePos = _camera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, transform.position.y, 0);
        var Distance = MousePos - gameObject.transform.position;

        WBCenter.transform.rotation = Quaternion.LookRotation(Distance);
    }
    public void Strike()
    {
        rb.AddForce(-HitVec * multiplier, ForceMode.Impulse) ;
    }
    void HideCue()
    {
        if (!HitPoint.activeSelf && rb.velocity.magnitude <= 0.01)
            HitPoint.SetActive(true);
        else if (HitPoint.activeSelf && rb.velocity.magnitude > 0.01)
            HitPoint.SetActive(false);
    }
}
        