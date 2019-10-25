using UnityEngine;

namespace Complete
{
    public class TankMovement : MonoBehaviour
    {
        public AudioSource audioMovimento;         // Referencia ao audio source para tocar os sons do tanque
        public AudioClip tankParado;            // audio para quando o tanque estiver parado
        public AudioClip tankAndando;           // audio para quando o tanque estiver andando

        private Rigidbody rigidTank;              // referencia usada para mover o tanque

        private ParticleSystem[] allParticles; // referencias pra todas as particulas usadas pelo tanque

        private float movValue;         // valor do input de movimento.
        private float rotValue;             // valor do input de rotação.
        private float originalPitch;              // pitch do audio source no começo da Scene.
        public float pitchRange = 0.2f;           // quantidade que o pitch pode variar.
        public float movSpd = 10f;                 // velocidade de movimento do tanque.
        public float rotSpd = 80f;             // velocidade da rotação do tanque.        
        public float turboSpd = 5f;            // velocidade do turbo

        private void Awake ()
        {
            rigidTank = GetComponent<Rigidbody> ();
        }

        private void OnEnable ()
        {
            // setar a kinematic do tanque para falso para poder receber movimento
            rigidTank.isKinematic = false;

            // resetar o valor dos inputs.
            movValue = 0f;
            rotValue = 0f;

            // percorrer por todas as particulas para poderem "tocar"
            allParticles = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < allParticles.Length; ++i)
            {
                allParticles[i].Play();
            }
        }

        private void OnDisable ()
        {
            // setar a kinematic do tanque para verdadeiro para ele nao se mexer mais.
            rigidTank.isKinematic = true;

            // Parar todas as particulas
            for(int i = 0; i < allParticles.Length; ++i)
            {
                allParticles[i].Stop();
            }
        }

        private void Start ()
        {
            originalPitch = audioMovimento.pitch;
        }

        private void Update ()
        {
            // guardar os valores de movimento e rotação
            movValue = Input.GetAxis ("Vertical");
            rotValue = Input.GetAxis ("Horizontal");

            EngineAudio ();
        }

        private void EngineAudio ()
        {
            // se o tanque está parado....
            if (Mathf.Abs (movValue) < 0.1f && Mathf.Abs (rotValue) < 0.1f)
            {
                // ... e o audio source ta tocando o audio de movimento...
                if (audioMovimento.clip == tankAndando)
                {
                    // ... mudar o clip pro audio de tanque parado e tocar.
                    audioMovimento.clip = tankParado;
                    audioMovimento.pitch = Random.Range (originalPitch - pitchRange, originalPitch + pitchRange);
                    audioMovimento.Play ();
                }
            }
            else
            {
                // caso contrario, se o tanque estiver movendo e o audio source estiver tocando o audio de tanque parado...
                if (audioMovimento.clip == tankParado)
                {
                    // ... mudar o clip pro audio de tanque andando e tocar.
                    audioMovimento.clip = tankAndando;
                    audioMovimento.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                    audioMovimento.Play();
                }
            }
        }

        private void FixedUpdate ()
        {
            Move ();
            Turn ();
        }

        private void Move ()
        {

            if (Input.GetKeyDown(KeyCode.LeftShift)){ //adiciona turbo na velocidade de movimento caso o shift esteja pressionado
                movSpd += turboSpd;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))  //se soltar o shift, reseta a velocidade de movimento
            {
                movSpd = 10f;
            }
            Vector3 movement = transform.forward * movValue * movSpd * Time.deltaTime;
            rigidTank.MovePosition(rigidTank.position + movement);
        }

        private void Turn ()
        {
            // determina o numero de angulos baseado no input, na velocidade e no deltaTime
            float turn = rotValue * rotSpd * Time.deltaTime;

            // transforma em uma rotação no eixo Y
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

            // aplica a rotação ao rigidbody
            rigidTank.MoveRotation (rigidTank.rotation * turnRotation);
        }
    }
}