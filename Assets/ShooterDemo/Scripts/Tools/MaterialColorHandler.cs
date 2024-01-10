using UnityEngine;

public class MaterialColorHandler : MonoBehaviour
{
    [SerializeField] Color MaterialColor;
    [SerializeField] string colorPropertyNmae = "_Color";
    MaterialPropertyBlock propertyBlock;
    new Renderer renderer;
    private void Start()
    {
        
    }
    void OnValidate()
    {
        if (renderer==null) renderer = GetComponentInChildren<Renderer>();
        if (propertyBlock == null) propertyBlock = new MaterialPropertyBlock();
        //if (propertyBlock.HasColor(colorPropertyNmae)) 
            propertyBlock.SetColor(colorPropertyNmae, MaterialColor);
        renderer?.SetPropertyBlock(propertyBlock);
    }
}
