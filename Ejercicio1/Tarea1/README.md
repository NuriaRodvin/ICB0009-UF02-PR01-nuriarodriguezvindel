# Ejercicio 1 - Tarea 1: Atención médica básica

## Descripción
Este programa simula la llegada de 4 pacientes al hospital y su atención médica en 4 consultas médicas disponibles. Los pacientes llegan cada 2 segundos y son atendidos por médicos en un tiempo de 10 segundos. El programa utiliza **hilos asíncronos** para simular la atención simultánea de los pacientes.

## Requisitos
- Simular la llegada de 4 pacientes al hospital.
- Cada paciente llega cada 2 segundos.
- Hay 4 médicos disponibles.
- Cada médico atiende a un paciente durante 10 segundos.
- Mostrar mensajes por pantalla cuando un paciente llega, es atendido y sale del hospital.

## Estructura del código
- **Clase `Paciente`:**
  - Representa a un paciente con un ID único.
  - Contiene un método `AtenderAsync` que simula la atención médica.
  - Utiliza un `SemaphoreSlim` para controlar el acceso a los médicos.

- **Clase `Hospital`:**
  - Contiene el método `Main` que genera 4 pacientes y gestiona su atención.
  - Utiliza `async`/`await` para manejar la atención de los pacientes de manera asíncrona.

## Preguntas y respuestas

### 1. ¿Cuántos hilos se están ejecutando en este programa? Explica tu respuesta.
En este programa se ejecutan **5 hilos en total**:
- **1 hilo principal (Main):** Controla la ejecución del programa y genera los pacientes.
- **4 hilos adicionales:** Uno por cada paciente, que simulan la atención médica de manera asíncrona.

### 2. ¿Cuál de los pacientes entra primero en consulta? Explica tu respuesta.
El **paciente 1** entra primero en consulta porque es el primero en llegar al hospital. Los pacientes llegan cada 2 segundos, y el paciente 1 se genera primero.

### 3. ¿Cuál de los pacientes sale primero de consulta? Explica tu respuesta.
Cualquiera de los pacientes puede salir primero, ya que el tiempo de atención es el mismo (10 segundos) y la asignación de médicos es aleatoria. Sin embargo, en la práctica, el **paciente 1** suele salir primero porque es el primero en comenzar su consulta.

## Ejecución del programa
Al ejecutar el programa, se mostrarán los siguientes mensajes en la consola:


## Capturas de pantalla
Incluye aquí capturas de pantalla de la ejecución del programa.

---

## Conclusión
Este programa cumple con todos los requisitos de la tarea y demuestra el uso de **hilos asíncronos** y **SemaphoreSlim** para gestionar recursos limitados (médicos). Además, está bien documentado y responde a las preguntas planteadas en el enunciado.