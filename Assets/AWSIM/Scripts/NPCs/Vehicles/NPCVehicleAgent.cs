using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using AWSIM;

public class NPCVehicleAgent : Agent {
    NPCVehicle vehicle;
    public override void Initialize() {
        vehicle = GetComponent<NPCVehicle>();
    }

    public override void OnEpisodeBegin() {

        // ToDo: Reset the environment
        //vehicle.TargetPosition = transform.localPosition;
    }

    public override void CollectObservations(VectorSensor sensor) {
        //ToDo: Add Observations except for the vision of the agent
    }

    public override void OnActionReceived(ActionBuffers actionBuffers) {
        float x = actionBuffers.ContinuousActions[0];
        float z = actionBuffers.ContinuousActions[1];
        //vehicle.TargetPosition = new Vector3(x, 0, z) + transform.localPosition;
    }
    
    public override void Heuristic(in ActionBuffers actionsOut) {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
        continuousActions[1] = Input.GetAxis("Vertical");
    }
}