using UnityEngine;

namespace NavMeshPlus.Extensions
{
    public class AgentRotate2d: MonoBehaviour
    {
        public float angularSpeed;

        private AgentOverride2d override2D;
        private void Start()
        {
            override2D = GetComponent<AgentOverride2d>();
            override2D.agentOverride = new RotateAgentInstantly(override2D.Agent, override2D, angularSpeed);
        }

    }
}
