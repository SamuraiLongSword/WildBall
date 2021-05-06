using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float GetHorizontal { get; private set; }
    public float GetVertical { get; private set; }
    public float GetJump { get; private set; }
    public float GetFire1 { get; private set; }
    public float GetFire2 { get; private set; }
    public float GetMouseX { get; private set; }

    public bool MouseLeft { get; private set; }
    public bool MouseRight { get; private set; }
    public bool EButton { get; private set; }
    public bool RButton { get; private set; }
    public bool TButton { get; private set; }

    // Update is called once per frame
    void Update()
    {
        GetHorizontal = Input.GetAxis("Horizontal");
        GetVertical = Input.GetAxis("Vertical");
        GetJump = Input.GetAxis("Jump");
        GetFire1 = Input.GetAxis("Fire1");
        GetFire2 = Input.GetAxis("Fire2");
        GetMouseX = Input.GetAxis("Mouse X");

        MouseLeft = Input.GetButton("Fire1");
        MouseRight = Input.GetButton("Fire2");
        EButton = Input.GetKey(KeyCode.E);
        RButton = Input.GetKey(KeyCode.E);
        TButton = Input.GetKey(KeyCode.E);
    }
}
