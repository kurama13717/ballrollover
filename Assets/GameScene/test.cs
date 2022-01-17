using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    /// <summary>
    /// ��p�[�e�B�N��
    /// </summary>
    public ParticleSystem SnowParticle;

    /// <summary>
    /// ��p�}�e���A��
    /// </summary>
    Material SnowMaterial;

    /// <summary>
    /// �f�B�X�v���C�X�����g�}�b�v�p�e�N�X�`���[
    /// </summary>
    Texture2D DisplacementTexture;

    /// <summary>
    /// �f�B�X�v���C�X�����g�}�b�v�p�e�N�X�`���[�X�V�t���O
    /// </summary>
    bool IsUpdateDisplacementTexture;

    /// <summary>
    /// �ϐ�p���[
    /// </summary>
    public float AccumulatePower = 0.2f;

    /// <summary>
    /// �ϐ�̍ő�l(0�`1)
    /// </summary>
    public float AccumulateLimit = 0.5f;

    /// <summary>
    /// �p�[�e�B�N���C�x���g�擾�p
    /// </summary>
    ParticleCollisionEvent[] _collisionEvents;

    void Start()
    {
        // �g�p����}�e���A�����擾
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
        SnowMaterial = render.material;

        // �f�B�X�v���C�X�����g�}�b�v�p�e�N�X�`���[
        DisplacementTexture = new Texture2D(256, 256, TextureFormat.ARGB32, false);
        for (int y = 0; y < DisplacementTexture.height; y++)
        {
            for (int x = 0; x < DisplacementTexture.width; x++)
            {
                DisplacementTexture.SetPixel(x, y, new Color(0, 0, 0));
            }
        }

        SnowMaterial.SetTexture("_DispTex", DisplacementTexture);
    }

    /// <summary>
    /// �p�[�e�B�N���̓����蔻��C�x���g
    /// </summary>
    /// <param name="other"></param>
    void OnParticleCollision(GameObject other)
    {
        if (DisplacementTexture == null) return;

        int safeLength = SnowParticle.GetSafeCollisionEventSize();
        if (_collisionEvents == null || _collisionEvents.Length < safeLength)
        {
            _collisionEvents = new ParticleCollisionEvent[safeLength];
        }
        IsUpdateDisplacementTexture = false;
        int numCollisionEvents = SnowParticle.GetCollisionEvents(gameObject, _collisionEvents);
        int i = 0;
        while (i < numCollisionEvents)
        {
            AccumulateSnow(_collisionEvents[i].intersection);
            i++;
        }

        // �e�N�X�`���[�X�V
        if (IsUpdateDisplacementTexture)
        {
            Debug.Log("Update");
            DisplacementTexture.Apply();
            SnowMaterial.SetTexture("_DispTex", DisplacementTexture);
        }
    }

    /// <summary>
    /// �w��ʒu�ɐ��ς��点�܂�
    /// </summary>
    /// <param name="position"></param>
    void AccumulateSnow(Vector3 position)
    {
        // �ʒu����q�b�g�����ꏊ�̃e�N�X�`���[UV�l�̎擾���@���킩��Ȃ��̂�
        // Ray���΂���RaycastHit�̒��̃e�N�X�`���[UV�l���g�p���邱�Ƃɂ��܂��B
        Ray ray = new Ray(new Vector3(position.x, position.y + Vector3.up.y * 1, position.z), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2) != true)
        {
            return;   // �n�ʂ������炸?
        }
        // Debug.LogFormat("tex = {0}, {1}", hit.textureCoord.x, hit.textureCoord.y);

        var tx = (int)(hit.textureCoord.x * DisplacementTexture.width);
        var ty = (int)(hit.textureCoord.y * DisplacementTexture.height);
        AccumulateSnowAdd(tx, ty, AccumulatePower);
        AccumulateSnowAdd(tx + 1, ty, AccumulatePower);
        AccumulateSnowAdd(tx, ty + 1, AccumulatePower);
        AccumulateSnowAdd(tx - 1, ty, AccumulatePower);
        AccumulateSnowAdd(tx, ty - 1, AccumulatePower);
        AccumulateSnowAdd(tx + 1, ty + 1, AccumulatePower);
        AccumulateSnowAdd(tx - 1, ty - 1, AccumulatePower);
        AccumulateSnowAdd(tx - 1, ty + 1, AccumulatePower);
        AccumulateSnowAdd(tx + 1, ty - 1, AccumulatePower);
        IsUpdateDisplacementTexture = true;
    }

    /// <summary>
    /// �w��ʒu�ɐ��ς��点�܂�
    /// </summary>
    /// <param name="texX"></param>
    /// <param name="texY"></param>
    /// <param name="power"></param>
    void AccumulateSnowAdd(int texX, int texY, float power)
    {
        if (texX < 0 || texX >= DisplacementTexture.width) return;
        if (texY < 0 || texY >= DisplacementTexture.height) return;
        var val = DisplacementTexture.GetPixel(texX, texY);
        var dis = Mathf.Min(AccumulateLimit, val.r + power);
        DisplacementTexture.SetPixel(texX, texY, new Color(dis, dis, dis));
        //DisplacementTexture.SetPixel(texX, texY, new Color(1.0f, 1.0f, 1.0f));
    }
}
