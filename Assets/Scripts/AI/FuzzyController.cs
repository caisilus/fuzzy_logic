using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FuzzyAI
{
    public FuzzyRule[] rules;
    public int result_size;
    public FuzzyAI(FuzzyRule[] r, int s)
    {
        rules = r;
        result_size = s;
    }

    public float[] step(float[] input)
    {
        float[] output = new float[result_size];
        Dictionary<int, FuzzySet> resultSets =
        new Dictionary<int, FuzzySet>();
        for (int i = 0; i < rules.Length; i++)
        {
            FuzzySet res_set = rules[i].implement(input);
            int rule_index = rules[i].outputindex;
            if (resultSets.ContainsKey(rule_index)){
                resultSets[rule_index] = FuzzySet.max(resultSets[rule_index], res_set);
            }else{
                resultSets[rule_index] = res_set;
            }

        }

        for (int i = 0; i < output.Length; i++)
        {
            if (resultSets.ContainsKey(i)){
                output[i] = resultSets[i].GetFirstMax();
            }
        }

        return output;
    }

}

public class FuzzyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
