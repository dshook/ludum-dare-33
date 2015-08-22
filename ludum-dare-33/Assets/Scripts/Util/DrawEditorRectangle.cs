using UnityEngine;

[ExecuteInEditMode()]
public class DrawEditorRectangle : MonoBehaviour
{
    public Color color = Color.green;

    private Vector2 topLeft;
    private Vector2 topRight;
    private Vector2 bottomLeft;
    private Vector2 bottomRight;

    void Update()
    {
        CalcPositons();
        DrawBox();
    }

    void CalcPositons()
    {
        var rect = GetComponent<RectTransform>();

        
        topLeft.Set(rect.position.x + rect.rect.xMin, rect.position.y + rect.rect.yMax);
        topRight.Set(rect.position.x + rect.rect.xMax, rect.position.y + rect.rect.yMax);
        
        bottomLeft.Set(rect.position.x + rect.rect.xMin, rect.position.y + rect.rect.yMin);
        bottomRight.Set(rect.position.x + rect.rect.xMax, rect.position.y + rect.rect.yMin);
    }

    void DrawBox()
    {
        //if (Input.GetKey (KeyCode.S)) {
        Debug.DrawLine(topLeft, topRight, color);
        Debug.DrawLine(topRight, bottomRight, color);
        Debug.DrawLine(bottomRight, bottomLeft, color);
        Debug.DrawLine(bottomLeft, topLeft, color);
        //}
    }
}