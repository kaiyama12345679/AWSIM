using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using AWSIM;
using UnityEngine.SceneManagement;

public class NPCVehicleAgent : Agent {
    NPCVehicle vehicle;
    public override void Initialize() {
        vehicle = GetComponent<NPCVehicle>();
    }

    public override void OnEpisodeBegin() {

        // ToDo: Reset the environment
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public override void CollectObservations(VectorSensor sensor) {
        //ToDo: Add Observations except for the vision of the agent
    }

    public override void OnActionReceived(ActionBuffers actionBuffers) {
        float x = actionBuffers.ContinuousActions[0];
        float z = actionBuffers.ContinuousActions[1];
        vehicle.AdjustPosition = new Vector3(x, 0, z);
        float yaw = actionBuffers.ContinuousActions[2];
        vehicle.AdjustRotation = Quaternion.Euler(0, yaw, 0);

        if (vehicle.isAdjust) {
            vehicle.SetPosition(vehicle.transform.position + vehicle.AdjustPosition);
            vehicle.SetRotation(vehicle.transform.rotation * vehicle.AdjustRotation);
        }
    }
    
    public override void Heuristic(in ActionBuffers actionsOut) {
        
    }
}