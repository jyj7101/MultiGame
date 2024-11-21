using UnityEngine;

public static class Utils
{
    public static Vector3 MakeYZero(Vector3 vec)
    {
        vec = new Vector3(vec.x, 0, vec.z);
        return vec;
    }

    public static Vector3 MulVec3(Vector3 vec1, Vector3 vec2)
    {
        return new Vector3(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z);
    }
}

