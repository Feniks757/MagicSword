using System;
using UnityEngine;

public class TowardsBullet : Bullet
{
    //private Vector3 _direction;

    // ����� ��� ���������� ����������� ����
    //public void CalculateDirection()
    //{
    //    if (_target != null)
    //    {
    //        _direction = (_target.position - transform.position).normalized;
    //    }
    //}

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
