using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public void PlayerJoined(PlayerRef player)
    {
        if (Runner.LocalPlayer == player)
        {
            Runner.Spawn(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity );
        }
    }
}
