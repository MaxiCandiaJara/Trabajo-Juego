using UnityEngine;

public class MusicController : MonoBehaviour
{
    [Header("Configuración de Música")]
    public AudioClip[] canciones;
    public string Play;

    [Header("Configuración de Audio")]
    [Range(0f, 1f)]
    public float volumen = 1f;
    public bool loop = true;

    private AudioSource audioSource;
    private string cancionActual = "";

    // Start es llamado una vez antes de la primera ejecución de Update
    void Start()
    {
        // Obtener o agregar el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("AudioSource agregado automáticamente");
        }

        // Configurar el AudioSource explícitamente
        audioSource.playOnAwake = false;
        audioSource.loop = loop;
        audioSource.volume = volumen;
        audioSource.spatialBlend = 0f; // 0 = 2D (se escucha igual en todas partes)
        audioSource.priority = 128; // Prioridad normal

        Debug.Log($"MusicController iniciado. Canciones en array: {canciones.Length}");
        Debug.Log($"Volumen configurado: {volumen}");

        // Reproducir la canción inicial si Play no está vacío
        if (!string.IsNullOrEmpty(Play))
        {
            ReproducirCancion(Play);
        }
        else
        {
            Debug.LogWarning("El campo 'Play' está vacío. Escribe el nombre de una canción para reproducir.");
        }
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Si el título de Play cambió, reproducir la nueva canción
        if (Play != cancionActual && !string.IsNullOrEmpty(Play))
        {
            ReproducirCancion(Play);
        }

        // Actualizar el volumen en tiempo real
        if (audioSource != null)
        {
            audioSource.volume = volumen;
            audioSource.loop = loop;
        }
    }

    /// <summary>
    /// Reproduce una canción buscándola por su nombre en el array de canciones
    /// </summary>
    /// <param name="nombreCancion">El nombre de la canción a reproducir</param>
    public void ReproducirCancion(string nombreCancion)
    {
        Debug.Log($"Intentando reproducir: '{nombreCancion}'");
        
        // Buscar la canción en el array
        AudioClip cancionEncontrada = BuscarCancion(nombreCancion);

        if (cancionEncontrada != null)
        {
            // Detener la canción actual si está sonando
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                Debug.Log("Canción anterior detenida");
            }

            // Asignar y reproducir la nueva canción
            audioSource.clip = cancionEncontrada;
            audioSource.Play();
            cancionActual = nombreCancion;

            Debug.Log($"✓ Reproduciendo: {nombreCancion}");
            Debug.Log($"  - Duración: {cancionEncontrada.length} segundos");
            Debug.Log($"  - Volumen: {audioSource.volume}");
            Debug.Log($"  - isPlaying: {audioSource.isPlaying}");
            Debug.Log($"  - AudioSource habilitado: {audioSource.enabled}");
        }
        else
        {
            Debug.LogError($"✗ No se encontró la canción: '{nombreCancion}'");
            Debug.LogError($"Canciones disponibles en el array:");
            for (int i = 0; i < canciones.Length; i++)
            {
                if (canciones[i] != null)
                {
                    Debug.LogError($"  [{i}] {canciones[i].name}");
                }
                else
                {
                    Debug.LogError($"  [{i}] (null)");
                }
            }
        }
    }

    /// <summary>
    /// Busca una canción en el array por su nombre
    /// </summary>
    /// <param name="nombreCancion">El nombre de la canción a buscar</param>
    /// <returns>El AudioClip si se encuentra, null si no</returns>
    private AudioClip BuscarCancion(string nombreCancion)
    {
        foreach (AudioClip cancion in canciones)
        {
            if (cancion != null && cancion.name.Equals(nombreCancion, System.StringComparison.OrdinalIgnoreCase))
            {
                return cancion;
            }
        }
        return null;
    }

    /// <summary>
    /// Pausa la reproducción de música
    /// </summary>
    public void PausarMusica()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
            Debug.Log("Música pausada");
        }
    }

    /// <summary>
    /// Reanuda la reproducción de música
    /// </summary>
    public void ReanudarMusica()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.UnPause();
            Debug.Log("Música reanudada");
        }
    }

    /// <summary>
    /// Detiene completamente la reproducción de música
    /// </summary>
    public void DetenerMusica()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            cancionActual = "";
            Debug.Log("Música detenida");
        }
    }

    /// <summary>
    /// Cambia el volumen de la música
    /// </summary>
    /// <param name="nuevoVolumen">Valor entre 0 y 1</param>
    public void CambiarVolumen(float nuevoVolumen)
    {
        volumen = Mathf.Clamp01(nuevoVolumen);
        if (audioSource != null)
        {
            audioSource.volume = volumen;
        }
    }
}
