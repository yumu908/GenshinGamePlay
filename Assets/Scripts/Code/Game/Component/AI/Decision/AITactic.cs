﻿namespace TaoTie
{
    public enum AITactic
    {
        InvalidTactic = 0,
        OnAware = 1,
        Idle = 2,
        FreeSkill = 3,
        Wander = 4,
        FollowScriptedPath = 5,
        Investigate = 6,
        ReturnToBornPos = 7,
        ReactActionPoint = 8,
        PatrolFollow = 9,
        FollowServerRoute = 10,
        OnAlert = 100,
        CombatIdle = 101,
        CombatSkillPrepare = 102,
        CombatSkill = 103,
        MeleeCharge = 104,
        FacingMove = 105,
        Surround = 106,
        FindBack = 107,
        CombatFixedMove = 108,
        CrabMove = 109,
        BuddySkill = 110,
        CombatFollowMove = 111,
        SpacialChase = 200,
        SpacialProbe = 201,
        SpacialAdjust = 202,
        ScriptedMoveTo = 300,
        Landing = 301,
        Extraction = 302,
        Flee = 303,
        OnNerve = 305,
        BirdCircling = 306,
        AutoPlayerFollowTarget = 400,
        BrownianMotion = 500,
        Max = 1024
    }
}