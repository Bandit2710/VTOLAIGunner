﻿using CheeseMods.AIHelicopterGunner.AIHelpers;
using CheeseMods.AIHelicopterGunner.AIStates;
using CheeseMods.AIHelicopterGunner.Components;
using System.Linq;

namespace CheeseMods.AIHelicopterGunner.AttackBehaviours;

public class AttackBehaviour_OpticalMissileFaf : AttackBehaviour_ATGM
{
    public AttackBehaviour_OpticalMissileFaf(AIGunner gunner, WeaponManager weaponManager, State_Sequence sequence, float damage) : base(gunner, weaponManager, sequence, damage)
    {
    }

    public override string Name => "Optical Missile FAF";

    public override bool CanAttackImmediately(Actor actor)
    {
        return Gunner.InHFov(actor.position, AIGunnerConsts.omImmediateFov)
            && Gunner.InRange(actor.position, AIGunnerConsts.omMinRange, AIGunnerConsts.omMaxRange);
    }

    public override bool HaveAmmo()
    {
        return WeaponManager.equips.Any(e => e is HPEquipOpticalML ml
        && MissileHelper.IsNotOpticalFaf(ml)
        && ml.armed
        && ml.GetCount() > 0);
    }
}
