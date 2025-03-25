# Ejercicio 2 - Tarea 4: Prioridades de los pacientes

## Descripción
Este programa amplía la simulación del hospital para incluir un sistema de prioridades en la atención de los pacientes. Los pacientes se clasifican en tres niveles de prioridad:
1. **Emergencias (nivel 1):** Atendidos primero.
2. **Urgencias (nivel 2):** Atendidos después de las emergencias.
3. **Consultas generales (nivel 3):** Atendidos al final.

Los pacientes en espera se atienden en función de su prioridad. Si varios pacientes tienen la misma prioridad, se atienden en el orden de llegada.

## Requisitos
1. **Ampliación de la clase `Paciente`:**
   - Añadir un atributo `Prioridad` (int) para indicar el nivel de prioridad del paciente.
   - Generar aleatoriamente la prioridad al crear un paciente (1 para emergencias, 2 para urgencias, 3 para consultas generales).

2. **Gestión de prioridades:**
   - Los pacientes deben ser atendidos en función de su prioridad.
   - Si hay varios pacientes con la misma prioridad, se atenderán en el orden de llegada.

3. **Visualización:**
   - Mostrar por consola la prioridad de cada paciente junto con su estado y tiempo de espera.

## Implementación

### Ampliación de la clase `Paciente`
Se ha ampliado la clase `Paciente` con los siguientes atributos y métodos:
- **Atributos:**
  - `Id`: Identificador único del paciente.
  - `LlegadaHospital`: Tiempo de llegada al hospital.
  - `TiempoConsulta`: Tiempo de consulta con el médico.
  - `RequiereDiagnostico`: Indica si el paciente necesita diagnóstico adicional.
  - `Prioridad`: Nivel de prioridad del paciente (1: Emergencia, 2: Urgencia, 3: Consulta general).
  - `Estado`: Estado actual del paciente (EsperaConsulta, Consulta, EsperaDiagnostico, Diagnostico, Finalizado).
  - `TiempoEspera`: Tiempo que el paciente ha esperado antes de ser atendido.

- **Métodos:**
  - `AtenderAsync`: Simula la atención del paciente, incluyendo la consulta y el diagnóstico (si es necesario).

### Gestión de prioridades
Se ha utilizado una lista de pacientes que se ordena por prioridad y tiempo de llegada antes de ser atendidos. Esto garantiza que los pacientes con mayor prioridad sean atendidos primero.

### Visualización del avance
Se muestra por consola el estado de cada paciente, junto con su prioridad, tiempo de espera y duración de la consulta o diagnóstico. El formato de visualización es:

Paciente "<Id>". Llegado el "<N>". Prioridad: "<P>". Estado: <estado>. Duración: "<S>" segundos.


## Ejecución del programa
Al ejecutar el programa, se mostrarán mensajes como:

Paciente 42. Llegado el 1. Prioridad: 1. Estado: Consulta. Duración Espera: 2 segundos.
Paciente 42. Llegado el 1. Prioridad: 1. Estado: EsperaDiagnostico.
Paciente 42. Llegado el 1. Prioridad: 1. Estado: Diagnostico.
Paciente 42. Llegado el 1. Prioridad: 1. Estado: Finalizado.
Todos los pacientes han sido atendidos.


## Preguntas y respuestas

### 1. ¿Cómo se gestiona la prioridad de los pacientes en el código?
La prioridad se gestiona mediante un atributo `Prioridad` en la clase `Paciente`, que se genera aleatoriamente entre 1 (emergencia), 2 (urgencia) y 3 (consulta general). Los pacientes se ordenan primero por prioridad y luego por tiempo de llegada antes de ser atendidos.

### 2. ¿Qué pasa si hay varios pacientes con la misma prioridad?
Si varios pacientes tienen la misma prioridad, se atienden en el orden en que llegaron al hospital. Esto se logra ordenando la lista de pacientes por prioridad y tiempo de llegada.

### 3. ¿Qué otra posibilidad de solución podrías plantear?
Otra posibilidad sería usar una **cola de prioridad** (`PriorityQueue`) para gestionar el acceso a las consultas médicas. Esto permitiría que los pacientes con mayor prioridad sean atendidos primero sin necesidad de ordenar la lista manualmente. Sin embargo, esta solución sería más compleja de implementar.

### 4. ¿Qué información adicional podría ser útil visualizar?
Otra información útil podría ser:
- **Tiempo total en el hospital:** Desde que el paciente llega hasta que finaliza la consulta y el diagnóstico (si es necesario).
- **Médico asignado:** Para saber qué médico atendió a cada paciente.
- **Uso de las máquinas de diagnóstico:** Para ver cuánto tiempo están en uso las máquinas y cuántos pacientes las han utilizado.

## Capturas de pantalla
A continuación se muestra una captura de pantalla de la ejecución del programa:
![image](https://github.com/user-attachments/assets/5eb1dcce-bf3c-4775-99d1-6a68dac0efcb)

![Captura de pantalla](https://github.com/user-attachments/assets/3070b4ab-a749-4e15-87fd-9e1d1ef2b71f)

## Conclusión
Este programa simula la atención de pacientes en un hospital con un sistema de prioridades, donde los pacientes son atendidos en función de su nivel de urgencia. Se ha utilizado sincronización para garantizar que los recursos no se sobresaturen y que los pacientes sean atendidos en el orden correcto.




## Capturas de Pantalla

A continuación se muestra una captura de pantalla de la ejecución del programa:
![image](https://github.com/user-attachments/assets/5eb1dcce-bf3c-4775-99d1-6a68dac0efcb)

![Captura de pantalla](https://github.com/user-attachments/assets/3070b4ab-a749-4e15-87fd-9e1d1ef2b71f)



