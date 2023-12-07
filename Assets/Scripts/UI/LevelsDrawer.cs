using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class LevelsDrawer : MonoBehaviour
{
    [SerializeField] private UILineRenderer _lRenderer;
    [SerializeField] private float _roadWidth, _length;
    [SerializeField] private int _iterations;

    [SerializeField] private LvlButton _lvlButtonPrefab;

    private List<LvlButton> _buttons = new List<LvlButton>();

  

    [ContextMenu("Draw")]
    public void DrawLine()
    {
        var rect = GetComponent<RectTransform>();
       rect.sizeDelta = new Vector2(rect.sizeDelta.x, _iterations * _length + 100);

        ClearLine();
        _lRenderer.Points = new Vector2[_iterations];
        _lRenderer.Points[0] = new Vector2(_roadWidth, 0);
        _lRenderer.Points[1] = new Vector2(_roadWidth, Mathf.Sqrt(_length * _length + _roadWidth * _roadWidth));
        
        for(int i = 2; i < _iterations; i++)
        {
            int side = ((i % 2) == 0) ? -1 : 1;
            Vector2 point = new Vector2(_roadWidth * side, i * _length);
            _lRenderer.Points[i] = point;

            var lvlbtn = Instantiate(_lvlButtonPrefab,_lRenderer.transform);
            lvlbtn.GetComponent<RectTransform>().localPosition = point;
            _buttons.Add(lvlbtn);
            lvlbtn.Init(i-1);
        }
    }


    public void ClearLine()
    {
        for(int i = 0; i < _buttons.Count; i++)
        {
            Destroy(_buttons[i].gameObject);
        }
        _buttons.Clear();
    }
}
