using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject WBCenter;
    [SerializeField] 
    private GameObject hitPoint;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private float multiplier;

    private Rigidbody rb;
    private Vector3 hitVec;

    const float stopSpeed = 0.01f;
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
        hitVec = new Vector3(hitPoint.transform.position.x - transform.position.x, 0, hitPoint.transform.position.z - transform.position.z);

        var MousePos = _camera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, transform.position.y, 0);
        var Distance = MousePos - gameObject.transform.position;

        WBCenter.transform.rotation = Quaternion.LookRotation(Distance);
    }
    public void Strike()
    {
        if (rb.velocity.magnitude <= stopSpeed)
            rb.AddForce(-hitVec * multiplier, ForceMode.Impulse) ;
    }
    void HideCue()
    {
        if (!hitPoint.activeSelf && rb.velocity.magnitude <= stopSpeed)
            hitPoint.SetActive(true);
        else if (hitPoint.activeSelf && rb.velocity.magnitude > stopSpeed)
            hitPoint.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("pool8");
    }
}
        