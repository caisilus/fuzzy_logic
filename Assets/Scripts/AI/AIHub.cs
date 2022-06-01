using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Input [v, a, r, l, b, dist, angle]
// Output [v, a]
public class AiHub
{
    //Сенсор видит препятствие близко
    public static float sensorCloseFunc(float x)
    {
        if (x < 0.5f){
            return 1f;
        }
        else if (x < 0.7f){
            return 0.7f - 0.6f  * x;
        }else{
            return 0f;
        }
    }
    //быстро повернуть руль вправо
    public static float turnRightFastFunc(float x)
    {
        if (x < -0.5f){
            return 1f;
        }
        else if (x < 0f){
            return  -2 * x;
        }else{
            return 0f;
        }
    }

    //быстро повернуть руль влево
    public static float turnLeftFastFunc(float x)
    {
        if (x < 0f){
            return 0f;
        }
        else if (x < 0.5f){
            return  2 * x;
        }else{
            return 1f;
        }
    }

    //Отклонение направо
    public static float deviationRightFunc(float x){
        if (x < 0f){
            return 0f;
        }
        else{
            return x;
        }
    }

    //Отклонение налево
    public static float deviationLeftFunc(float x){
        if (x < 0f){
            return -x;
        }
        else{
            return 0f;
        }
    }

    //Близко до цели
    public static float closeToDestFunc(float x){
        if (x > 5f){
            return 0f;
        }else if (x >3f){
            return -0.5f * x + 2.5f;
        }
        else{
            return 1f;
        }
    }

    //Далеко до цели
    public static float farFromDestFunc(float x){
        if (x < 6f){
            return 0f;
        }
        else{
            return 0.2f * x - 1.5f;
        }
    }

    //Машна развёрнута задом к цели
    public static float turnBackFunc(float x){
        if (x > 0.8f){
            return 5*x - 4;
        }else if (x > -0.8f){
            return 0;
        }else{
            return -5*x - 4;
        }
    }

    //Машина развёрнута передом к цели
    public static float turnForwardFunc(float x)
    {
        if (x > 0.8f){
            return -5*x + 4;
        }else if (x > -0.8f){
            return 1f;
        }else{
            return 5*x + 4;
        }
    }

    //Быстро ехать назад
    public static float rideBackFastFunc(float x){
        if (x < -0.8f){
            return 1f;
        }else if (x < 0.0f){
            return -1.25f * x;
        }else{
            return 0f;
        }
    }

    //Ускорится быстро
    public static float f11(float x){
        return 1;
    }
    //Ускорится средне
    public static float f12(float x){
        return 1;
    }
    //Замедлиться
    public static float f13(float x){
        return 1;
    }

    //Едем быстро
    //Едем медленно

    private FuzzyAI currentAI;
    public AiHub()
    {

        F fun1 = sensorCloseFunc;
        F fun2 = turnRightFastFunc;
        F fun3 = turnLeftFastFunc;
        F fun4 = deviationRightFunc;
        F fun5 = deviationLeftFunc;
        F fun6 = closeToDestFunc;
        F fun7 = farFromDestFunc;
        F fun8 = turnBackFunc;
        F fun9 = turnForwardFunc;
        F fun10 = rideBackFastFunc;

        FuzzySet closeLeft = new FuzzySet(0, 1, 100.0f, fun1);
        FuzzySet closeRight = new FuzzySet(0, 1, 100.0f, fun1);
        FuzzySet turnRightFast = new FuzzySet(-1, 1, 200.0f, fun2);
        FuzzySet turnLeftFast = new FuzzySet(-1, 1, 200.0f, fun3);
        FuzzySet deviationRight = new FuzzySet(-1, 1, 200f, fun4);
        FuzzySet deviationLeft = new FuzzySet(-1, 1, 200f, fun5);

        FuzzySet closetoDest = new FuzzySet(0, 10, 200f, fun6);
        FuzzySet fartoDest = new FuzzySet(0, 10, 200f, fun7);

        FuzzySet turnBack = new FuzzySet(-1, 1, 200f, fun8);
        FuzzySet turnForward = new FuzzySet(-1, 1, 200f, fun9);
        FuzzySet rideBack = new FuzzySet(-1, 1, 200f, fun10);

        // Input [v, a, r, l, b, dist, angle]
        //Входные данные Скорость, угол, растояние справа, растояние слева, растояние сзади, растояние до цели, угол отклонения от цели(положительный направа отрицательный налево)
        //Выходные данные измениение скорости, угол поворота

        
        //Если препятствие слево то повернуть направо
        FuzzyRule rule1 = new FuzzyRule(new FuzzySet[]{closeLeft}, turnRightFast, 1, new int[]{3});
        //Если препятствие справо то повернуть налево
        FuzzyRule rule2 = new FuzzyRule(new FuzzySet[]{closeRight}, turnLeftFast, 1, new int[]{2});
        //Если мы далеко от цели и откланились от цели напрво то довернуть влево
        FuzzyRule rule3 = new FuzzyRule(new FuzzySet[]{deviationRight, fartoDest}, turnLeftFast, 1, new int[]{6, 5});
        //Если мы далеко от цели и откланились от цели налево то довернуть направо
        FuzzyRule rule4 = new FuzzyRule(new FuzzySet[]{deviationLeft, fartoDest}, turnRightFast, 1, new int[]{6, 5});
        //Если близко к цели и смотрим на цель то повернуть направо
        FuzzyRule rule5 = new FuzzyRule(new FuzzySet[]{closetoDest, turnForward}, turnRightFast, 1, new int[]{5, 6});
        //Если близко к цели и смотрим на цель то замедлить движение (пока не используется)
        FuzzyRule rule6 = new FuzzyRule(new FuzzySet[]{closetoDest, turnForward}, rideBack, 0, new int[]{5, 6});
        //Если близко к цели и развёрнуты к ней задом то ехать назад
        FuzzyRule rule7 = new FuzzyRule(new FuzzySet[]{closetoDest, turnBack}, rideBack, 0, new int[]{5, 6});

        //Если едем медленно или стоим то ускориться
        //Если справо препятстве или слева то замедлиться
        //Если близко к цели и смотрим на цель и едем вперёд то замедлить движение


        FuzzyAI ai0 = new FuzzyAI(new FuzzyRule[]{rule1, rule2, rule3, rule4, rule5, rule7}, 2);
        currentAI = ai0;
    }

    public FuzzyAI getAI()
    {
        return this.currentAI;
    }
}
