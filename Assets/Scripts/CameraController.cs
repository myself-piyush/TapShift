using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Camera m_Camera;
    private Vector3 m_targetposition;
    private Vector3 m_InitialPosition;

    public Transform player;
    public float smooth;

   

    #region Unity Functions
    private void Start()
    {
     
    }
    private void Update()
    {
        
    }
    #endregion

    #region Public Functions
    public void OnInit()
    {
        m_Camera = GetComponent<Camera>();
        m_targetposition = transform.position;
        m_InitialPosition = m_targetposition;
    }
    public void OnUpdate()
    {
        FollowPlayer();
    }
    #endregion
    #region Private Functions
    private void FollowPlayer()
    {
        if(!player)
        {
            Debug.LogWarning("Camera could not find player reference ");
            return;
        }

        if(player.transform.position.y>transform.position.y)
        {
            m_targetposition.y = player.position.y;
        }
        transform.position = Vector3.Lerp(transform.position, m_targetposition, smooth * Time.deltaTime);
    }
    #endregion
}
