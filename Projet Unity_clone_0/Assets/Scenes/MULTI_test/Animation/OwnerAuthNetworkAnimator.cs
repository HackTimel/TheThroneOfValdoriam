using Unity.Netcode.Components;

public class OwnerAuthNetworkAnimator : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative() => false;
}

