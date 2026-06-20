using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void StartAnim()
    {
        //anim.SetBool("End Anim Bool", true);
        
        anim.SetTrigger("End Anim Trigger");
    }
}
