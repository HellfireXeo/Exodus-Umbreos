using System;
using System.Collections;
using UnityEngine;


public class StatHandle : PlayerHandle
{
    
    private int combatLevel;
    public int targetLevel;

    private float life;
    


    private int stat_atk = 1; // starting attack
    private int stat_str = 1; // starting strength
    private int stat_def = 1; // starting defence
    private int stat_rng = 1; // starting range
    private int stat_mgk = 1; // starting magick

    private int stat_fth = 1; // starting faith

    private float experince = 0.2f;
    private float experince_gained = 0f;
    private float _xp = 0f;

    private bool didHit = false;


    // Start is called before the first frame update
    void Start()
    {
        life = 0.01f;
        targetLevel = 1;
    }


    void BattleExperince(int target_level)
    {
        targetLevel = target_level;
        combatLevel = (stat_atk + stat_str + stat_def + stat_rng + stat_mgk) / 5;
        float configure_amount = (combatLevel + stat_fth) * targetLevel / 2.2f;
        _xp = UnityEngine.Random.Range(configure_amount / 2.6f, configure_amount);
        experince_gained += _xp;


        Debug.Log(":: TOTAL ::" + experince_gained + "  :: XP ::" + _xp);
    }

    
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            BattleExperince(targetLevel);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            life += 0.5f;
            Debug.Log(":: Life :: " + life);
        }
        measureLife(life);

    }
}
