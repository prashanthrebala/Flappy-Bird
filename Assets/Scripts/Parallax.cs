using UnityEngine;

public class Parallax : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public float animationSpeed;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
