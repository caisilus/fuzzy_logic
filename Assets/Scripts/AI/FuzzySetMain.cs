using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
public delegate float F(float x);

public class FuzzySet
{
    
    public static FuzzySet max(FuzzySet f1, FuzzySet f2){
        Dictionary<float, float> data = new Dictionary<float, float>();
        foreach(KeyValuePair<float, float>  entry in f1.data)
        {
            data[entry.Key] = Mathf.Max(f1[entry.Key], f2[entry.Key]);
        }
        FuzzySet res = new FuzzySet(data);
        return res;
    }

    public static FuzzySet min(FuzzySet f1, FuzzySet f2){
        Dictionary<float, float> data = new Dictionary<float, float>();
        foreach(KeyValuePair<float, float>  entry in f1.data)
        {
            data[entry.Key] = Mathf.Min(f1[entry.Key], f2[entry.Key]);
        }
        FuzzySet res = new FuzzySet(data);
        return res;
    }

    public Dictionary<float, float> data =
    new Dictionary<float, float>();
    public FuzzySet(Dictionary<float, float> d)
    {
        data = d;
    }

    public FuzzySet(int start, int end, float numPoints, F f)
    {
        float delta = (end - start) / numPoints;
        for (int i = 0; i <= numPoints; i++)
        {
            float a = start + delta * i;
            data[a] = f(a);
        }
    }

    public float this[float key]
    {
        get => GetValue(key);
        set => SetValue(key, value);
    }

    private float GetValue(float key){
        float minDelta = float.MaxValue;
        float trueKey = 0f;
        foreach(float k in this.data.Keys)
        {
            float delta = Mathf.Abs(k - key);
            if (delta < minDelta){
                minDelta = delta;
                trueKey = k;
            }
        }
        return this.data[trueKey];
    }

    private void SetValue(float key, float newvalue)
    {
        if ((newvalue <= 1) && (newvalue >= 0)){
            this.data[key] = newvalue;
        }
    }

    public FuzzySet minimize(float new_prob)
    {
        Dictionary<float, float> new_data = new Dictionary<float, float>();
        foreach(KeyValuePair<float, float>  entry in this.data)
        {
             new_data[entry.Key] = Mathf.Min(this.data[entry.Key], new_prob);
        }
        FuzzySet res = new FuzzySet(new_data);
        return res;
    }

    public float GetFirstMax(){
        float maxKey = 0.0f;
        float maxValue = 0.0f;
        foreach(float k in this.data.Keys.OrderBy((a)=>a).ToArray())
        {
            if (data[k] > maxValue){
                maxValue = data[k];
                maxKey = k;
            }
        }
        return maxKey;
    }

    public override string ToString()
    {
        var asString = string.Join("\n", this.data);
        return asString;
    }
}

public class FuzzySetMain : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        FuzzySet test = new FuzzySet(new Dictionary<float, float>{{0f, 0.9f}, {1f, 0.5f}});
        FuzzySet test2 = new FuzzySet(new Dictionary<float, float>{{0f, 0.1f}, {1f, 0.6f}});
        FuzzySet test3 = new FuzzySet(new Dictionary<float, float>{{0f, 0.1f}, {1f, 0.6f}, {2f, 0.1f}, {3f, 0.6f}});

        Debug.Log("Test1");
        Debug.Log(test.ToString());
        Debug.Log(test2.ToString());
        Debug.Log("Test2");
        Debug.Log(FuzzySet.max(test, test2));
        Debug.Log(FuzzySet.min(test, test2));
        Debug.Log("Test3");
        Debug.Log(test3.GetFirstMax());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
