using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target; // 角色的 Transform 组件
    public float distance = 5f; // 摄像机与角色的距离
    public float minDistance = 2f; // 摄像机与角色的最小距离
    public float maxDistance = 10f; // 摄像机与角色的最大距离
    public float collisionOffset = 0.2f; // 碰撞偏移量

    private Vector3 direction; // 摄像机与角色之间的方向
    private RaycastHit hit; // 碰撞信息

    void LateUpdate()
    {
        // 计算摄像机与角色之间的方向
        direction = transform.position - target.position;
        direction.Normalize();

        // 使用射线检测是否有碰撞物体
        if (Physics.Raycast(target.position, direction, out hit, distance))
        {
            // 如果有碰撞物体，则调整摄像机距离
            distance = Mathf.Clamp(hit.distance - collisionOffset, minDistance, maxDistance);
        }

        // 更新摄像机位置
        transform.position = target.position + direction * distance;
    }
}
