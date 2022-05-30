using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Если то
public class FuzzyRule
{
    // [v, a, r, l, f]
    // [v, a]
    public FuzzySet[] cause;
    public FuzzySet consequence;
    public int[] indexes;
    public string chain = "AND";
    public int outputindex;

    public FuzzyRule(FuzzySet[] c, FuzzySet cons, int o, int[] i, string ch = "AND")
    {   
        cause = c;
        consequence = cons;
        indexes = i;
        chain = ch;
        outputindex = o;
    }

    public float fuzzification(float[] input)
    {
        float res;
        float data, prob;
        if (this.chain == "AND")
        {
            res = 1f;
        }else{
            res = 0f;
        }

        for (int i = 0; i < indexes.Length; i++)
        {
            data = input[this.indexes[i]];
            prob = this.cause[i][data];

            if (this.chain == "AND"){
                res = Mathf.Min(res, prob);
            }else{
                res = Mathf.Max(res, prob);
            }

        }
        return res; 
    }

    public FuzzySet implement(float[] input){
        float new_prob = fuzzification(input);
        return this.consequence.minimize(new_prob);
    }
}
