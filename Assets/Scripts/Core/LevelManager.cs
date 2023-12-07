
using System.Diagnostics;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LevelManager : Singletone<LevelManager>
{
    public int LastLvl => _lastLvl;
    private int _lastLvl;

    public int CurrentLvl => _currentLvl;
    private int _currentLvl = 0;

    private SceneAsset _menuScene, _levelScene;
    public LevelManager(SceneAsset menu, SceneAsset level)
    {
        _menuScene = menu;
        _levelScene = level;
        _lastLvl = 0;
        if(!UserData.Instance.Read<int>(UserData.Instance.Keys.LastLvl, out _lastLvl))
        {
            UserData.Instance.Write<int>(UserData.Instance.Keys.LastLvl, 0);
        }
    }

    public void LoadLevel(int lvlNum)
    {
        _currentLvl = lvlNum;
        SceneManager.LoadScene(_levelScene.name);
    }

    public void FinishLevel()
    {

         SetLastLevel(_currentLvl + 1);
        _currentLvl = 0;
        Debug.WriteLine($"You success complete {_currentLvl} level!");
        SceneManager.LoadScene(_menuScene.name);
    }

    public void SetLastLevel(int lvl)
    {
        if(lvl > _lastLvl)
        {
            _lastLvl = lvl;

            UserData.Instance.Write<int>(UserData.Instance.Keys.LastLvl, lvl);
        }
        
    }

    public void Reset()
    {
        SetLastLevel(0);
    }
    protected override LevelManager GetSelf()
    {
        return this;
    }
}


