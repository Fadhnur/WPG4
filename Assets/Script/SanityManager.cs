using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class SanityManager : MonoBehaviour
{
    //Slider sanitySlider;
    public int fullSanity;
    public int difficulty;
    float percent;
    float currentSanity;
    public PostProcessProfile profile;
    Vignette vignette;
    public string deathScene;

    // Start is called before the first frame update
    void Start()
    {

        currentSanity = fullSanity;

        profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0;
        StartCoroutine(LoseSanity());
    }


    //animasi mengurangi slider pada ui sanity
    IEnumerator LoseSanity()
    {
        while(currentSanity > 0)
        {
            currentSanity -= 2f * difficulty;
            
            percent = currentSanity / fullSanity;
            vignette.intensity.value = percent;

            yield return null;
        }
        SceneManager.LoadScene(deathScene);
    }
}