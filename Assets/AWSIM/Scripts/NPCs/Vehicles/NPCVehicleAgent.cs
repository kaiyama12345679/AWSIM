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
        vehicle.Reset();
    }

    public override void CollectObservations(VectorSensor sensor) {
    }

    public override void OnActionReceived(ActionBuffers actionBuffers) {
        float x = actionBuffers.ContinuousActions[0];
        float z = actionBuffers.ContinuousActions[1];
        //target = new Vector3(x, 0, z);
    }
    
    public override void Heuristic(in ActionBuffers actionsOut) {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
        continuousActions[1] = Input.GetAxis("Vertical");
    }
}