using UnityEngine;

public class MaterialColorHandler : MonoBehaviour
{
    [SerializeField] Color MaterialColor;
    [SerializeField] string colorPropertyNmae = "_Color";
    MaterialPropertyBlock propertyBlock;
    new Renderer renderer;
    void OnValidate()
    {
        if (propertyBlock == null) propertyBlock = new MaterialPropertyBlock();
        if(renderer==null) renderer = GetComponentInChildren<Renderer>();
        propertyBlock.SetColor(colorPropertyNmae, MaterialColor);
        renderer.SetPropertyBlock(propertyBlock);
    }
}
