using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    private Texture2D texture;

    void Start() {
       Renderer renderer = GetComponent<Renderer>();
       renderer.material.mainTexture = GenerateTexture();
}

Texture2D GenerateTexture () {
    Texture2D texture = new Texture2D(width, height);

    for(int x = 0; x < width; x++) {
        for(int y = 0; y < height; y++) {
            
            // float xCoord = (float)x / width * scale;
            // float yCoord = (float)y / height * scale;

            // float sample = Mathf.PerlinNoise(xCoord, yCoord);
            Color color = CalculateColor(x,y);
            texture.SetPixel(x, y, color);
        }
    }

    texture.Apply();
    return texture;
}

Color CalculateColor(int x, int y) {
    
    float sample = Mathf.PerlinNoise((float)x / width, (float)y / height);
    return new Color(sample, sample, sample);
   
}

}