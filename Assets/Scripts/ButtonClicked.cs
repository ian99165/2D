using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonClicked : MonoBehaviour
{
    [SerializeField] private Button _button_Start;
    [SerializeField] private Button _button_Exit;
    [SerializeField] private Button _button_Rule;
    [SerializeField] private Button _button_rule_X;
    [SerializeField] private Button _button_back;
    [SerializeField] private Button _button_Exit_Game;
    [SerializeField] private Button _button_Home;
    [SerializeField] private Button _button_Win_Exit;
    
    public GameObject start_canvas;
    public GameObject esc_canvas;
    public GameObject rule_canvas;

    void Start()
    {
        _button_Start.onClick.AddListener(Start_Button);
        _button_Exit.onClick.AddListener(Exit_Button);
        _button_Rule.onClick.AddListener(Rule_Button);
        _button_rule_X.onClick.AddListener(Rule_Button_X);
        
        _button_back.onClick.AddListener(Back_Button);
        _button_Exit_Game.onClick.AddListener(Exit_Button);
        
        _button_Home.onClick.AddListener(Home_Button);
        _button_Win_Exit.onClick.AddListener(Exit_Button);
    }

    public void Start_Button()
    {
        Reply_P_H_();
        Close_Start_Canvas();
    }
    
    public void Back_Button()
    {
        Reply_P_H_();
        Close_Playing_Canvas();
    }
    public void Rule_Button()
    {
        rule_canvas.SetActive(true);
    }
    
    public void Rule_Button_X()
    {
        rule_canvas.SetActive(false);
    }
    
    public void Home_Button()
    {
        SceneManager.LoadScene("S1");
        Debug.Log("123");
    }

    public void Exit_Button()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    public void Reply_P_H_()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerHandler playerHandler = player.GetComponent<PlayerHandler>();
            if (playerHandler != null)
            {
                playerHandler.SetGameStart(); // 調用 SetGameStart 方法
                Debug.Log("ButtonClicked");
            }
            else
            {
                Debug.LogError("找不到 PlayerHandler 腳本！");
            }
        }
        else
        {
            Debug.LogError("找不到 Player 物件！");
        }
    }
    
    public void Open_Playing_Canvas()
    {
        esc_canvas.SetActive(true);
    }
    
    public void Close_Start_Canvas()
    {
        start_canvas.SetActive(false);
    }

    public void Close_Playing_Canvas()
    {
        esc_canvas.SetActive(false);
    }
}