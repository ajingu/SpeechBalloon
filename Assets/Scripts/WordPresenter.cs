using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WordPresenter : MonoBehaviour 
{
    [SerializeField] Text inputText;
    [SerializeField] Button submitButton;
    [SerializeField] SubstringImplement substringImplement;

	void Start()
    {
        submitButton.OnClickAsObservable()
                    .Subscribe(_ => substringImplement.Initialize(inputText.text))
                    .AddTo(this);
    }
}
