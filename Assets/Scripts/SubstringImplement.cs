using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SubstringImplement : MonoBehaviour
{
    [SerializeField] Text speechText;
    [SerializeField] float wordUpdateInterval = 0.1f;

    public void Initialize(string word)
    {
        Observable.FromCoroutine<string>(observer => SubstringCoroutine(observer, word))
                  .Subscribe(text => { speechText.text = text; })
                  .AddTo(this);
    }

    IEnumerator SubstringCoroutine(IObserver<string> observer, string word)
    {
        for (int i = 1; i < word.Length+1; i++)
        {
            observer.OnNext(word.Substring(0, i));
            yield return new WaitForSeconds(wordUpdateInterval);
        }

        observer.OnCompleted();
    }
}