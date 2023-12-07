using System;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    private static GameManager instance;
    public static GameManager Instance => instance;

    public DateTime LastDate => _lastDate;

    private DateTime _lastDate;

    [SerializeField] private DataKeys _keys;
    [SerializeField] private SceneAsset _menuScene, _levelScene;
    
    //Здесь хорошо бы было использовать Zenject, но что бы не нагружать этот небольшой проект я решил прописать зависимости в одном месте в главном геймменеджере.
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);

        UserData ud = new UserData(new PPReader(), new PPWriter(), _keys);
        InternalStore ins = new InternalStore();
        LevelManager lvlm = new LevelManager(_menuScene,_levelScene);

        SetLastDate();
    }

    void SetLastDate()
    {
        string lastDate;
        if(UserData.Instance.Read<string>(UserData.Instance.Keys.LastDate, out lastDate))
        {
            _lastDate = DateTime.Parse(lastDate);
        }
        
        var date = DateTime.Now;
        UserData.Instance.Write<string>(UserData.Instance.Keys.LastDate, date.ToString());
    }

    [ContextMenu("Reset level progress")]
    void ResetLevelProgress()
    {
        LevelManager.Instance.Reset();
    }
  
}
