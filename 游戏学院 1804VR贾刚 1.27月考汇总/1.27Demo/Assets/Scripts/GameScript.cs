using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    GameObject player;
    Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("Role");
        player = GameObject.Instantiate(Resources.Load<GameObject>(playerName));
        camera = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = player.transform.position + new Vector3(0, 1, 0.2f);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * v * 5);
            player.transform.Rotate(Vector3.up * Time.deltaTime * h * 120);
        }
    }
}
