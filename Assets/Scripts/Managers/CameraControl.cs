using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    float m_MoveSpeed = 30f;
    [SerializeField]
    //float m_Border = 10f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))// || (Input.mousePosition.y > Screen.height - m_Border))
            transform.Translate(Vector3.forward * m_MoveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.S))// || (Input.mousePosition.y < m_Border))
            transform.Translate(Vector3.back * m_MoveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D))// || (Input.mousePosition.x > Screen.width - m_Border))
            transform.Translate(Vector3.right * m_MoveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A))// || (Input.mousePosition.x < m_Border))
            transform.Translate(Vector3.left * m_MoveSpeed * Time.deltaTime, Space.World);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * m_MoveSpeed*100 * scroll * Time.deltaTime);
    }
}
