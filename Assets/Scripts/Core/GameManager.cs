using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class GameManager : MonoBehaviour
{
  
    private static GameManager instance;
    public static GameManager Instance => instance;

    public DateTime LastDate => _lastDate;

    private DateTime _lastDate;

    [SerializeField] private DataKeys _keys;


    [SerializeField] private string _menuScene, _levelScene;


    //Здесь хорошо бы было использовать Zenject, но что бы не нагружать этот небольшой проект я решил прописать зависимости в одном месте в главном геймменеджере.
    //Назначил данному гейменджеру самый первый script execution order, относительно других компонентов
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
            

        

        UserData ud = new UserData(new PPReader(), new PPWriter(), _keys);
        InternalStore ins = new InternalStore();
        LevelManager lvlm = new LevelManager(_menuScene,_levelScene);

        GetLastDate();

        Application.targetFrameRate = 120;
        StandardPurchasingModule.Instance().useFakeStoreAlways = true;

        DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        SetLastDate();
    }
    void GetLastDate()
    {
        string lastDate;
        if (UserData.Instance.Read<string>(UserData.Instance.Keys.LastDate, out lastDate))
        {
            _lastDate = DateTime.Parse(lastDate);
        }
    }
    void SetLastDate()
    { 
        var date = DateTime.Now;
        UserData.Instance.Write<string>(UserData.Instance.Keys.LastDate, date.ToString());
    }

    [ContextMenu("Reset level progress")]
    void ResetLevelProgress()
    {
        LevelManager.Instance.Reset();
    }
  
}
