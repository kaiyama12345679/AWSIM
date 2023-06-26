using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

namespace AWSIM
{
    /// <summary>
    /// Agent for a vehicle simulation.
    /// </summary>

    public class VehicleAgent : Agent {

        private AWSIM.Vehicle vehicle;

        public override void Initialize() {
            vehicle = GetComponent<Vehicle>();
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            //nothing to do
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            var continuousActionsOut = actionsOut.ContinuousActions;
            continuousActionsOut[0] = vehicle.DifferencePosition.x;
            continuousActionsOut[1] = vehicle.DifferencePosition.z;
            continuousActionsOut[2] = vehicle.DifferenceRotationY;

        }
    }
}