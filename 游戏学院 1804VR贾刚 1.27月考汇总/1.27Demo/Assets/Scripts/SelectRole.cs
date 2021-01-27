using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectRole : MonoBehaviour
{
    public Button P1;
    public Button P2;
    public Button P3;
    public Button Back;
    public Button Game;
    public Text DesText;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        P1.onClick.AddListener(P1Click);
        P2.onClick.AddListener(P2Click);
        P3.onClick.AddListener(P3Click);
        Game.onClick.AddListener(GameClick);
        DesText.text = "PlayerType2\n\n血量300\n移动速度系数5\n占点进度系数3";
        PlayerPrefs.SetString("Role","Player2");
    }

    private void P1Click()
    {
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.Rotate(Vector3.up, -90);
        DesText.text = "PlayerType1\n\n血量500\n移动速度系数3\n占点进度系数1";
        PlayerPrefs.SetString("Role", "Player1");
    }

    private void P2Click()
    {
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.Rotate(Vector3.up, 0f);
        DesText.text = "PlayerType2\n\n血量300\n移动速度系数5\n占点进度系数3";
        PlayerPrefs.SetString("Role", "Player2");
    }

    private void P3Click()
    {
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.Rotate(Vector3.up, 90);
        DesText.text = "PlayerType3\n\n血量100\n移动速度系数10\n占点进度系数2";
        PlayerPrefs.SetString("Role", "Player3");
    }

    private void GameClick()
    {
        SceneManager.LoadScene("GameScene");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
