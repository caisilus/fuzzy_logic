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
        if (x < 0.3f){
            return 1f;
        }
        else if (x < 0.5f){
            //return 0.7f - 0.6f  * x;
            return -5f * x + 2.5f; 
        }else{
            return 0f;
        }
    }
    //Сенсор видит препятствие средне
    public static float sensorMiddleFunc(float x)
    {
        if (x < 0.3f)
        {
            return 0f;
        }
        else if (x < 0.4f)
        {
            //return 0.7f - 0.6f  * x;
            return 10f * x - 3f;
        } else if (x < 0.6f)
        {
            return 1.0f;
        } else if(x < 0.7f)
        {
            return -10f * x + 7;
        }
        else
        {
            return 0f;
        }
    }
    //Сенсор видит препятствие далеко
    public static float sensorFarFunc(float x)
    {
        if (x < 0.7f)
        {
            return 0f;
        }
        else if (x < 0.9f)
        {
            //return 0.7f - 0.6f  * x;
            return 5f * x + 3.5f;
        }
        else
        {
            return 1f;
        }
    }
    //быстро повернуть руль вправо
    public static float turnRightFastFunc(float x)
    {
        if (x < -0.7f){
            return 1f;
        }
        else if (x < -0.5f){
            return  -5f * x - 2.5f;
        } else{
            return 0f;
        }
    }

    //быстро повернуть руль влево
    public static float turnLeftFastFunc(float x)
    {
        if (x < 0.5f){
            return 0f;
        }
        else if (x < 0.7f){
            return  5f * x - 2.5f;
        }else{
            return 1f;
        }
    }
    
    //средне повернуть руль вправо
    public static float turnRightMiddleFunc(float x)
    {
        if (x < -0.7f)
        {
            return 0f;
        } else if (x < -0.6f) 
        {
            return 10f * x + 7f;
        }
        else if (x < -0.4f)
        {
            return 1;
        }
        else if(x < -0.3f)
        {
            return -10f * x  - 3f;
        }
        else
        {
            return 0f;
        }
    }

    //средне повернуть руль влево
    public static float turnLeftMiddleFunc(float x)
    {
        if (x < 0.3f)
        {
            return 0f;
        }
        else if (x < 0.4f)
        {
            return 10f * x - 3f;
        }
        else if  (x < 0.6f)
        {
            return 1.0f;
        }
        else if  (x < 0.7f)
        {
            return -10f * x + 7;
        }
        else
        {
            return 0f;
        }
    }

    public static float turnRightSmallFunc(float x)
    {
        if (x > 0.0f)
        {
            return 0.0f;
        }
        else if (x > -0.2f)
        {
            return 1f;
        }
        else if (x > -0.4f)
        {
            return 5.0f * x + 2.0f;
        }
        else
        {
            return 0f;
        }
    }

    //средне повернуть руль влево
    public static float turnLeftSmallFunc(float x)
    {
        if (x < 0.0f)
        {
            return 0.0f;
        }
        else if (x < 0.2f)
        {
            return 1f;
        }
        else if (x < 0.4f)
        {
            return -5.0f * x + 2.0f;
        }
        else
        {
            return 0f;
        }
    }

    // Почти 0 угол
    public static float turnAroundZeroFunc(float x)
    {
        if (x < -0.3f)
        {
            return 0f;
        } else if (x < -0.1f)
        {
            return 5.0f * x + 1.5f;
        } else if (x < 0.1f)
        {
            return 1f;
        } else if (x < 0.3f)
        {
            return -5.0f * x + 1.5f;
        } else
        {
            return 0f;
        }
    }

    //Отклонение направо
    public static float deviationRightFunc(float x){
        if (x < 0.5f){
            return 0f;
        }
        else{
            return 2.0f * x - 1.0f;
        }
    }

    //Отклонение налево
    public static float deviationLeftFunc(float x){
        if (x < -0.5f){
            return -2.0f * x - 1.0f;
        }
        else{
            return 0f;
        }
    }

    //Отклонение направо
    public static float deviationRightSmallFunc(float x)
    {
        if (x < 0f)
        {
            return 0f;
        } else if(x < 0.05f)
        {
            return 20.0f * x;
        } 
        else if(x < 0.3f)
        {
            return 1.0f;
        } 
        else if(x < 0.5f)
        {
            return -5f * x + 2.5f;
        }
        else
        {
            return 0f;
        }
    }

    //Отклонение налево
    public static float deviationLeftSmallFunc(float x)
    {
        if (x < -0.5f)
        {
            return 0;
        }
        else if  (x < -0.3f)
        {
            return 5f * x + 2.5f;
        }
        else if  (x < -0.05f)
        {
            return 1f;
        } 
        else if (x < 0.0f)
        {
            return -20.0f * x;
        }
        else
        {
            return 0f;
        }
    }

    public static float deviationUltraSmallLeft(float x)
    {
        if (x < 0.0f)
        {
            return 0.0f;
        }
        else if (x <= 0.05f)
        {
            return 1.0f;
        } else if (x < 0.1f)
        {
            return -20.0f * x + 2.0f;
        } else
        {
            return 0.0f;
        }
    }

    public static float deviationUltraSmallRight(float x)
    {
        if (x > 0.0f)
        {
            return 0.0f;
        }
        else if (x >= -0.05f)
        {
            return 1.0f;
        }
        else if (x > -0.1f)
        {
            return 20.0f * x + 2.0f;
        }
        else
        {
            return 0.0f;
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
            return 0.25f * x - 1.5f;
        }
    }

    //Машна развёрнута задом к цели
    public static float turnBackFunc(float x){
        if (x > 0.9f){
            return 10.0f * x - 9.0f;
        }else if (x > -0.9f){
            return 0;
        }else{
            return -10.0f * x - 9.0f;
        }
    }

    //Машина развёрнута передом к цели
    public static float turnForwardFunc(float x)
    {
        if (x > 0.9f)
        {
            return 0;
        }
        else if (x > 0.7f)
        {
            return -5f * x + 5f;
        }
        else if (x > -0.7f)
        {
            return 1;
        }
        else if (x > -0.9f)
        {
            return 5f * x + 5f;
        }
        else
        {
            return 0;
        }
    }

    //Быстро ехать назад
    public static float rideBackFastFunc(float x){
        if (x < -0.8f){
            return 1f;
        }else if (x < -0.6f){
            return -5f * x - 3f;
        }else{
            return 0f;
        }
    }

    //Быстро ехать вперед
    public static float rideForwardFastFunc(float x)
    {
        if (x > 0.8f)
        {
            return 1f;
        }
        else if (x > 0.6f)
        {
            return 5f * x - 3f;
        }
        else
        {
            return 0f;
        }
    }

    //Срдене ехать назад
    public static float rideBackFunc(float x)
    {
        if (x < -0.6f)
        {
            return 0f;
        }
        else if (x < -0.4f)
        {
            return 5f * x + 3f;
        } else if(x < -0.2f)
        {
            return 1f;
        } else if(x < 0f)
        {
            return -5f * x;
        }
        else
        {
            return 0f;
        }
    }

    //Срдене ехать вперед
    public static float rideForwardFunc(float x)
    {
        if (x > 0.6f)
        {
            return 0f;
        }
        else if (x > 0.4f)
        {
            return -5f * x + 3f;
        }
        else if (x > 0.2f)
        {
            return 1f;
        }
        else if (x > 0f)
        {
            return 5f * x;
        }
        else
        {
            return 0f;
        }
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
        F fun11 = rideForwardFastFunc;
        F fun12 = rideBackFunc;
        F fun13 = rideForwardFunc;
        F fun14 = sensorFarFunc;
        F fun15 = sensorMiddleFunc;
        F fun16 = deviationRightSmallFunc;
        F fun17 = deviationLeftSmallFunc;
        F fun18 = turnRightMiddleFunc;
        F fun19 = turnLeftMiddleFunc;
        F fun20 = turnAroundZeroFunc;
        F ultraSmallL = deviationUltraSmallLeft;
        F ultraSmallR = deviationUltraSmallRight;
        F smallTurnL = turnLeftSmallFunc;
        F smallTurnR = turnRightSmallFunc;

        // сенсоры
        FuzzySet closeLeft = new FuzzySet(0, 1, 100.0f, fun1);
        FuzzySet closeRight = new FuzzySet(0, 1, 100.0f, fun1);
        FuzzySet closeBack = new FuzzySet(0, 1, 100.0f, fun1);

        FuzzySet farLeft = new FuzzySet(0, 1, 100f, fun14);
        FuzzySet farRight = new FuzzySet(0, 1, 100f, fun14);
        FuzzySet farBack = new FuzzySet(0, 1, 100f, fun14);

        FuzzySet middleLeft = new FuzzySet(0, 1, 100f, fun15);
        FuzzySet middleRight = new FuzzySet(0, 1, 100f, fun15);
        FuzzySet middleBack = new FuzzySet(0, 1, 100f, fun15);

        // поворот
        FuzzySet turnRightFast = new FuzzySet(-1, 1, 200.0f, fun2);
        FuzzySet turnLeftFast = new FuzzySet(-1, 1, 200.0f, fun3);

        FuzzySet turnRightMiddle = new FuzzySet(-1, 1, 200.0f, fun18);
        FuzzySet turnLeftMiddle = new FuzzySet(-1, 1, 200.0f, fun19);

        FuzzySet turnAroundZero = new FuzzySet(-1, 1, 200.0f, fun20);

        FuzzySet turnRightSmall = new FuzzySet(-1, 1, 200.0f, smallTurnR);
        FuzzySet turnLeftSmall = new FuzzySet(-1, 1, 200.0f, smallTurnL);

        // инфа о цели
        FuzzySet deviationRight = new FuzzySet(-1, 1, 200f, fun4);
        FuzzySet deviationLeft = new FuzzySet(-1, 1, 200f, fun5);

        FuzzySet deviationRightSmall = new FuzzySet(-1, 1, 200f, fun16);
        FuzzySet deviationLeftSmall = new FuzzySet(-1, 1, 200f, fun17);

        FuzzySet deviationRightUltraSmall = new FuzzySet(-1, 1, 200f, ultraSmallR);
        FuzzySet deviationLeftUltraSmall = new FuzzySet(-1, 1, 200f, ultraSmallL);

        FuzzySet closetoDest = new FuzzySet(0, 10, 200f, fun6);
        FuzzySet fartoDest = new FuzzySet(0, 10, 200f, fun7);

        FuzzySet turnBack = new FuzzySet(-1, 1, 200f, fun8);
        FuzzySet turnForward = new FuzzySet(-1, 1, 200f, fun9);
        
        // изменение скорости
        FuzzySet rideBackFast = new FuzzySet(-1, 1, 200f, fun10);
        FuzzySet rideBackMiddle = new FuzzySet(-1, 1, 200f, fun12);

        FuzzySet rideForwardFast = new FuzzySet(-1, 1, 200f, fun11);
        FuzzySet rideForwardMiddle = new FuzzySet(-1, 1, 200f, fun13);

        // Input [v, a, r, l, b, dist, angle]
        //Входные данные Скорость, угол, растояние справа, растояние слева, растояние сзади, растояние до цели, угол отклонения от цели(положительный направа отрицательный налево)
        //Выходные данные измениение скорости, угол поворота

        //Выход [dv, a]

        // --------------------------------------- ПРЕПЯТСТВИЯ ---------------------------------------
        //Если препятствие слево то повернуть направо
        FuzzyRule rule1 = new FuzzyRule(new FuzzySet[]{closeLeft}, turnRightFast, 1, new int[]{3});
        //Если препятствие справо то повернуть налево
        FuzzyRule rule2 = new FuzzyRule(new FuzzySet[]{closeRight}, turnLeftFast, 1, new int[]{2});
        //Если препятствие слева или справо близко и быстро вперёд, то сильно замедлиться
        FuzzyRule rule9 = new FuzzyRule(new FuzzySet[] { closeRight, rideForwardFast }, rideBackFast, 0, new int[] { 2, 0 });
        FuzzyRule rule10 = new FuzzyRule(new FuzzySet[] { closeLeft, rideForwardFast }, rideBackFast, 0, new int[] { 3, 0 });
        //Если препятствие слева или справо близко и средне вперёд, то средне замедлиться
        FuzzyRule rule11 = new FuzzyRule(new FuzzySet[] { closeRight, rideForwardMiddle }, rideBackMiddle, 0, new int[] { 2, 0 });
        FuzzyRule rule12 = new FuzzyRule(new FuzzySet[] { closeLeft, rideForwardMiddle }, rideBackMiddle, 0, new int[] { 3, 0 });
        //Если препятствие слева или справо средне и едем средне вперёд, то средне замедлиться
        FuzzyRule rule13 = new FuzzyRule(new FuzzySet[] { middleRight, rideForwardMiddle }, rideBackMiddle, 0, new int[] { 2, 0 });
        FuzzyRule rule14 = new FuzzyRule(new FuzzySet[] { middleLeft, rideForwardMiddle }, rideBackMiddle, 0, new int[] { 3, 0 });
        //Если препятствие слева или справо средне и едем быстро вперёд, то средне замедлиться
        FuzzyRule rule15 = new FuzzyRule(new FuzzySet[] { middleRight, rideForwardFast }, rideBackFast, 0, new int[] { 2, 0 });
        FuzzyRule rule16 = new FuzzyRule(new FuzzySet[] { middleLeft, rideForwardFast }, rideBackFast, 0, new int[] { 3, 0 });

        // --------------------------------------- ВЫРАВНИВАЕМ К ЦЕЛИ ---------------------------------------
        //Если мы далеко от цели и сильно отклонились направо и последний поворот не направо, то довернуть сильно влево
        FuzzyRule rule3 = new FuzzyRule(new FuzzySet[]{deviationRight, fartoDest, farLeft, turnLeftFast}, 
            turnLeftFast, 1, new int[]{6, 5, 3, 1});
        FuzzyRule rule19 = new FuzzyRule(new FuzzySet[] { deviationRight, fartoDest, farLeft, turnLeftMiddle },
            turnLeftFast, 1, new int[] { 6, 5, 3, 1 });
        FuzzyRule rule23 = new FuzzyRule(new FuzzySet[] { deviationRight, fartoDest, farLeft, turnAroundZero },
            turnLeftFast, 1, new int[] { 6, 5, 3, 1 });

        // Experiment
        FuzzyRule rule27 = new FuzzyRule(new FuzzySet[] { deviationRight, fartoDest, closeLeft },
            rideBackFast, 0, new int[] { 6, 5, 3 });
        FuzzyRule rule28 = new FuzzyRule(new FuzzySet[] { deviationRight, fartoDest, turnRightFast },
            rideBackFast, 0, new int[] { 6, 5, 1 });
        FuzzyRule rule29 = new FuzzyRule(new FuzzySet[] { deviationRight, fartoDest, turnRightMiddle },
            rideBackFast, 0, new int[] { 6, 5, 1 });

        //Если мы далеко от цели и сильно отклонились налево и последний поворот не налево, то довернуть сильно направо
        FuzzyRule rule4 = new FuzzyRule(new FuzzySet[]{deviationLeft, fartoDest, farRight, turnRightFast}, 
            turnRightFast, 1, new int[] {6, 5, 2, 1});
        FuzzyRule rule20 = new FuzzyRule(new FuzzySet[] { deviationLeft, fartoDest, farRight, turnRightMiddle },
            turnRightFast, 1, new int[] { 6, 5, 2, 1 });
        FuzzyRule rule24 = new FuzzyRule(new FuzzySet[] { deviationLeft, fartoDest, farRight, turnAroundZero },
            turnRightFast, 1, new int[] { 6, 5, 2, 1 });

        // Experiment
        FuzzyRule rule30 = new FuzzyRule(new FuzzySet[] { deviationLeft, fartoDest, closeRight },
            rideBackFast, 0, new int[] { 6, 5, 3 });
        FuzzyRule rule31 = new FuzzyRule(new FuzzySet[] { deviationLeft, fartoDest, turnLeftFast },
            rideBackFast, 0, new int[] { 6, 5, 1 });
        FuzzyRule rule32 = new FuzzyRule(new FuzzySet[] { deviationLeft, fartoDest, turnLeftMiddle },
            rideBackFast, 0, new int[] { 6, 5, 1 });

        //Если мы далеко от цели и слабо отклонились направо и последний поворот не направо, то довернуть средне влево
        FuzzyRule rule17 = new FuzzyRule(new FuzzySet[] { deviationRightSmall, fartoDest, farLeft, turnLeftFast }, turnLeftMiddle, 1, 
                                        new int[] { 6, 5, 3, 1 });
        FuzzyRule rule21 = new FuzzyRule(new FuzzySet[] { deviationRightSmall, fartoDest, farLeft, turnLeftMiddle }, 
                                            turnLeftMiddle, 1, new int[] { 6, 5, 3, 1 });
        FuzzyRule rule25 = new FuzzyRule(new FuzzySet[] { deviationRightSmall, fartoDest, farLeft, turnAroundZero },
                                            turnLeftMiddle, 1, new int[] { 6, 5, 3, 1 });

        // Experiment
        FuzzyRule rule33 = new FuzzyRule(new FuzzySet[] { deviationRightSmall, fartoDest, closeLeft },
            rideBackFast, 0, new int[] { 6, 5, 3 });
        FuzzyRule rule34 = new FuzzyRule(new FuzzySet[] { deviationRightSmall, fartoDest, turnRightFast },
            rideBackFast, 0, new int[] { 6, 5, 1 });
        FuzzyRule rule35 = new FuzzyRule(new FuzzySet[] { deviationRightSmall, fartoDest, turnRightMiddle },
            rideBackFast, 0, new int[] { 6, 5, 1 });

        //Если мы далеко от цели и слабо отклонились налево то довернуть средне направо
        FuzzyRule rule18 = new FuzzyRule(new FuzzySet[] { deviationLeftSmall, fartoDest, farRight, turnRightFast }, 
                                            turnRightMiddle, 1, new int[] { 6, 5, 2, 1 });
        FuzzyRule rule22 = new FuzzyRule(new FuzzySet[] { deviationLeftSmall, fartoDest, farRight, turnRightMiddle }, 
                                            turnRightMiddle, 1, new int[] { 6, 5, 2, 1 });
        FuzzyRule rule26 = new FuzzyRule(new FuzzySet[] { deviationLeftSmall, fartoDest, farRight, turnAroundZero },
                                            turnRightMiddle, 1, new int[] { 6, 5, 2, 1 });

        // Experiment
        FuzzyRule rule36 = new FuzzyRule(new FuzzySet[] { deviationLeftSmall, fartoDest, closeRight },
            rideBackFast, 0, new int[] { 6, 5, 3 });
        FuzzyRule rule37 = new FuzzyRule(new FuzzySet[] { deviationLeftSmall, fartoDest, turnLeftFast },
            rideBackFast, 0, new int[] { 6, 5, 1 });
        FuzzyRule rule38 = new FuzzyRule(new FuzzySet[] { deviationLeftSmall, fartoDest, turnLeftMiddle },
            rideBackFast, 0, new int[] { 6, 5, 1 });


        // SMALL TURNS RIGHT
        FuzzyRule rule43 = new FuzzyRule(new FuzzySet[] { deviationLeftUltraSmall, fartoDest, farRight, turnRightFast },
                                            turnRightSmall, 1, new int[] { 6, 5, 2, 1 });
        FuzzyRule rule44 = new FuzzyRule(new FuzzySet[] { deviationLeftUltraSmall, fartoDest, farRight, turnRightMiddle },
                                            turnRightSmall, 1, new int[] { 6, 5, 2, 1 });
        FuzzyRule rule45 = new FuzzyRule(new FuzzySet[] { deviationLeftUltraSmall, fartoDest, farRight, turnAroundZero },
                                            turnRightSmall, 1, new int[] { 6, 5, 2, 1 });

        // Experiment
        FuzzyRule rule46 = new FuzzyRule(new FuzzySet[] { deviationLeftUltraSmall, fartoDest, closeRight },
            rideBackFast, 0, new int[] { 6, 5, 3 });
        FuzzyRule rule47 = new FuzzyRule(new FuzzySet[] { deviationLeftUltraSmall, fartoDest, turnLeftFast },
            rideBackFast, 0, new int[] { 6, 5, 1 });
        FuzzyRule rule48 = new FuzzyRule(new FuzzySet[] { deviationLeftUltraSmall, fartoDest, turnLeftMiddle },
            rideBackFast, 0, new int[] { 6, 5, 1 });

        //SMALL TURNS LEFT
        FuzzyRule rule49 = new FuzzyRule(new FuzzySet[] { deviationRightUltraSmall, fartoDest, farLeft, turnLeftFast }, 
                                        turnLeftSmall, 1, new int[] { 6, 5, 3, 1 });
        FuzzyRule rule50 = new FuzzyRule(new FuzzySet[] { deviationRightUltraSmall, fartoDest, farLeft, turnLeftMiddle },
                                            turnLeftSmall, 1, new int[] { 6, 5, 3, 1 });
        FuzzyRule rule51 = new FuzzyRule(new FuzzySet[] { deviationRightUltraSmall, fartoDest, farLeft, turnAroundZero },
                                            turnLeftSmall, 1, new int[] { 6, 5, 3, 1 });

        // Experiment
        FuzzyRule rule52 = new FuzzyRule(new FuzzySet[] { deviationRightUltraSmall, fartoDest, closeLeft },
            rideBackFast, 0, new int[] { 6, 5, 3 });
        FuzzyRule rule53 = new FuzzyRule(new FuzzySet[] { deviationRightUltraSmall, fartoDest, turnRightFast },
            rideBackFast, 0, new int[] { 6, 5, 1 });
        FuzzyRule rule54 = new FuzzyRule(new FuzzySet[] { deviationRightUltraSmall, fartoDest, turnRightMiddle },
            rideBackFast, 0, new int[] { 6, 5, 1 });


        // -------------------------------------- ПОВОРОТ ДЛЯ ЗАДНЕГО ХОДА ---------------------------------
        //Если близко к цели и смотрим и последний поворот не налево на цель то повернуть направо
        FuzzyRule rule5 = new FuzzyRule(new FuzzySet[]{closetoDest, turnForward, farRight}, 
                                        turnRightFast, 1, new int[]{5, 6, 2});

        FuzzyRule rule41 = new FuzzyRule(new FuzzySet[] { closetoDest, turnForward, farRight, turnRightMiddle },
                                        turnRightFast, 1, new int[] { 5, 6, 2, 1 });

        FuzzyRule rule42 = new FuzzyRule(new FuzzySet[] { closetoDest, turnForward, farRight, turnRightFast },
                                        turnRightFast, 1, new int[] { 5, 6, 2, 1 });

        //Если близко к цели и смотрим на цель и едем быстро то замедлить средне
        FuzzyRule rule6 = new FuzzyRule(new FuzzySet[]{closetoDest, turnForward, rideForwardFast}, 
                                            rideBackFast, 0, new int[]{5, 6, 0});

        FuzzyRule rule40 = new FuzzyRule(new FuzzySet[]{closetoDest, turnForward, closeRight}, rideBackFast, 0, new int[] {5, 6, 2});

        //Если близко к цели и развёрнуты к ней задом то ехать назад
        FuzzyRule rule7 = new FuzzyRule(new FuzzySet[]{closetoDest, turnBack}, rideBackFast, 0, new int[]{5, 6});

        // TEST
        FuzzyRule rule39 = new FuzzyRule(new FuzzySet[] { closetoDest, turnForward, closeRight }, 
                                                        rideBackFast, 0, new int[] { 5, 6, 2 });


        // -------------------------------------- УСКОРЕНИЕ ------------------------------------------------

        //Если препятствия слева и справа далеко, то ускориться сильно
        FuzzyRule rule8 = new FuzzyRule(new FuzzySet[] { farLeft, farRight, fartoDest }, 
                                        rideForwardFast, 0, new int[] { 2, 3, 5 });

        // ------------------------------------- ЕДЕМ ЗАДНИМ ХОДОМ -----------------------------------------
        FuzzyRule back1 = new FuzzyRule(new FuzzySet[] { closeBack, rideBackFast }, rideForwardFast, 0, new int[] { 4, 0 });

        FuzzyAI ai0 = new FuzzyAI(new FuzzyRule[]{rule1, rule2, rule3, rule4, rule5, rule6, rule7, rule8,
                                                  rule9, rule10, rule11, rule12, rule13, rule14, rule15, rule16,
                                                  rule17, rule18, rule19, rule20, rule21, rule22, rule23, rule24, 
                                                  rule25, rule26, rule27, rule28, rule29, rule30, rule31, rule32,
                                                  rule33, rule34, rule35, rule36, rule37, rule38, rule39, rule40, 
                                                  back1 }, 2);
        currentAI = ai0;
    }

    public FuzzyAI getAI()
    {
        return this.currentAI;
    }
}
