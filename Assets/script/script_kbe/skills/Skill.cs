namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	
    public class Skill 
    {
    	public string name;
    	public string descr;
    	public Int32 id;
    	public float canUseDistMin = 0f;
    	public float canUseDistMax = 3f;
        public float coolTime = 1f;

        private float restCoolTimer;
		public Skill()
		{
		}
		
		public bool validCast(KBEngine.Entity caster, SCObject target)
		{
			float dist = Vector3.Distance(target.getPosition(), caster.position);
            if (dist > canUseDistMax || restCoolTimer < coolTime)
				return false;
			
			return true;
		}

        public void updateTimer(float second)
        {
            restCoolTimer += second;
        }
		
		public void use(KBEngine.Entity caster, SCObject target)
		{
			caster.cellCall("useTargetSkill", id, ((SCEntityObject)target).targetID);
            restCoolTimer = 0f;
		}
    }
} 
