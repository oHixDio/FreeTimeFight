using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// UIMaster‚Ì‹@”\‰„’·”Å

// Leader‚ðŽæ“¾‰Â”\
public class MainManager : MonoBehaviour
{
    [SerializeField] ADUI adUI;
    public ADUI AdUI { get { return adUI; } }

    [SerializeField] ComplateUI complateUI;
    public ComplateUI ComplateUI { get { return complateUI; } }

    [SerializeField] HPFrameUI hpFrameUI;
    public HPFrameUI HPFrameUI { get { return hpFrameUI; } }

    // Leader
    [SerializeField] MainFrameLeader mainFrameLeader;
    public MainFrameLeader MainFrameLeader { get {  return mainFrameLeader; } }
    
}
