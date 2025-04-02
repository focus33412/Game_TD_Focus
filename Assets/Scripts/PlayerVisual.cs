using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
  public Animator animator; 

  private const string HORIZONTAL = "Horizontal";
  private const string VERTICAL = "Vertical";
  private const string SPEED = "Speed";

  private void Awake()
  {
    animator = GetComponent<Animator>();
  } 

  private void Update()
  {
    animator.SetFloat(HORIZONTAL, Player.Instance.GetHorizontalInput());
    animator.SetFloat(VERTICAL, Player.Instance.GetVerticalInput());
    animator.SetFloat(SPEED, Player.Instance.GetSpeed());
  } 
}
