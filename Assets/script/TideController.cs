using UnityEngine;
using System.Collections;

public class TideController : MonoBehaviour
{
    public float minZ = -5.0f; // M?c n??c th?p nh?t
    public float maxZ = 5.0f;  // M?c n??c cao nh?t
    public float riseDuration = 7.0f; // Th?i gian ?? ??t ??n maxZ t? minZ
    public float initialDelay = 5.0f; // Th?i gian ? minZ tr??c khi b?t ??u l�n

    private void Start()
    {
        // B?t ??u coroutine ?? ?i?u khi?n th?y tri?u
        StartCoroutine(TideMovement());
    }

    private IEnumerator TideMovement()
    {
        // ??t v? tr� ban ??u t?i minZ
        Vector3 startPosition = transform.position;
        startPosition.z = minZ;
        transform.position = startPosition;

        // ??i trong 5 gi�y t?i v? tr� minZ
        yield return new WaitForSeconds(initialDelay);

        // T�nh to�n t?c ?? t?ng c?a th?y tri?u
        float elapsedTime = 0.0f;
        Vector3 endPosition = transform.position;
        endPosition.z = maxZ;

        // T?ng d?n v? tr� t? minZ l�n maxZ trong 7 gi�y
        while (elapsedTime < riseDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / riseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ??m b?o v? tr� cu?i c�ng l� maxZ
        transform.position = endPosition;

        // Sau khi ??t maxZ, quay tr? l?i minZ ngay l?p t?c
        transform.position = startPosition;
    }
}
