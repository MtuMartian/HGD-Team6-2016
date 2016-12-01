using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class vortex : MonoBehaviour
{
    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
    public float m_Drift = 0.01f;
    float angle = -90;

    private void LateUpdate()
    {
        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            angle += Time.deltaTime;

            float scale = 10;
            float y = -1 * Mathf.Sin(angle * Mathf.PI / 180) * scale;
            float x = Mathf.Cos(angle * Mathf.PI / 180) * scale;
            Vector3 delta = new Vector3(x, y, 0);

            m_Particles[i].velocity = delta;
        }

        // Apply the particle changes to the particle system
        m_System.SetParticles(m_Particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.maxParticles];
    }
}