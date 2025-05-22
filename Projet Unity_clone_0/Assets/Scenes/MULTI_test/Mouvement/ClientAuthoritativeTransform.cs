using Unity.Netcode.Components;
using UnityEngine;

[DisallowMultipleComponent]
public class ClientAuthoritativeTransform : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false; // Autorité au client
    }
}
